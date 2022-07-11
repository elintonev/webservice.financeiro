using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebService.Financeiro.Model;
using WebService.Financeiro.Services;

namespace WebService.Financeiro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastosController : Controller
    {
        private readonly FinanceiroService m_financeiroService;
        public GastosController(FinanceiroService financeiroService)
        {
            m_financeiroService = financeiroService;
        }

        [Route("/")]
        [HttpGet]
        public async Task<ActionResult<Gasto>> GetGastoModel()
        {
            return Json(await m_financeiroService.ListarGastosAsync());
        }

        [Route("/total/{tipo}")]
        [HttpGet]
        public ActionResult GetTotalDeGastos(string tipo)
        {
            return Json(m_financeiroService.TotalDeGastosAsync(tipo));
        }

        [Route("/Add")]
        [HttpPost]
        public async Task<ActionResult> PostAdicionarGastos([FromBody] Gasto despesa)
        {
            var message = "Houve um erro ao incluir a despesa no banco de dados!";
            if (m_financeiroService.AdicionarGasto(despesa).Result == null)
            {
                return BadRequest(new { message });
            }

            return Json(await m_financeiroService.AdicionarGasto(despesa));
        }

        [Route("/{id}")]
        [HttpPut]
        public async Task<ActionResult> PutAdicionarGastos(int id, [FromBody]Gasto despesa)
        {
            return Json(await m_financeiroService.AtualizarGastoAsync(id, despesa));
        }

        [Route("/{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteAdicionarGastos(int id)
        {
            var actionMessage = await m_financeiroService.DeletarGastosAsync(id);
            var message = "Houve um erro ao atualizar o banco de dados!";
            if (actionMessage == null) 
            {
                return BadRequest(new { message });
            }
            return Json(actionMessage);
        }
    }
}
