using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.Financeiro.Data;
using WebService.Financeiro.Model;

namespace WebService.Financeiro.Services
{
    public class FinanceiroService
    {
        private readonly WebServiceFinanceiroContext m_webServiceFinanceiroContext;

        public FinanceiroService(WebServiceFinanceiroContext webServiceFinanceiroContext)
        {
            m_webServiceFinanceiroContext = webServiceFinanceiroContext;
        }

        public async Task<List<Gasto>> ListarGastosAsync()
        {
            return await m_webServiceFinanceiroContext.Gastos.OrderBy(x => x.Nome).ToListAsync();
        }

        public async Task<Gasto> AdicionarGasto(Gasto despesa)
        {
            var banco = m_webServiceFinanceiroContext.Gastos.Where(x => x.Id == despesa.Id).FirstOrDefault();

            if (banco == null)
            {
                m_webServiceFinanceiroContext.Add(despesa);
                await m_webServiceFinanceiroContext.SaveChangesAsync();
                return despesa;
            }

            return despesa;
        }

        public async Task<Gasto> AtualizarGastoAsync(int id, Gasto novaDespesa)
        {
            var banco = m_webServiceFinanceiroContext.Gastos.Where(x => x.Id == id).FirstOrDefault();

            if (banco != null)
            {
                banco.Nome = novaDespesa.Nome;
                banco.Valor = banco.Valor + novaDespesa.Valor;
                banco.Pagamento = novaDespesa.Pagamento;
                banco.Tipo = novaDespesa.Tipo;
                banco.Local = novaDespesa.Local;
                banco.GastoDia = DateTime.Now;

                m_webServiceFinanceiroContext.Update(banco);
                await m_webServiceFinanceiroContext.SaveChangesAsync();

                return banco;
            }

            var novoGasto = new Gasto()
            {
                Nome = novaDespesa.Nome,
                Valor = novaDespesa.Valor,
                Pagamento = novaDespesa.Pagamento,
                Tipo = novaDespesa.Tipo,
                Local = novaDespesa.Local,
                GastoDia = DateTime.Now
            };

            m_webServiceFinanceiroContext.Add(novoGasto);
            await m_webServiceFinanceiroContext.SaveChangesAsync();

            return novoGasto;
        }

        public async Task<string> DeletarGastosAsync(int id)
        {
            var banco = m_webServiceFinanceiroContext.Gastos.Where(x => x.Id == id).FirstOrDefault();
            if (banco != null)
            {
                m_webServiceFinanceiroContext.Remove(banco);
                await m_webServiceFinanceiroContext.SaveChangesAsync();
                return "Despesa excluída com sucesso!";
            }

            return null;
        }

        public ResultadoTotalGastos TotalDeGastosAsync(string tipo)
        {   
            var banco = m_webServiceFinanceiroContext.Gastos.Where(x => x.Tipo.ToUpper() == tipo.ToUpper()).Sum(c => c.Valor);

            return new ResultadoTotalGastos() {
                Nome = tipo,
                Valor = banco,
            };
        }

        public class ResultadoTotalGastos
        {
            public string Nome { get; set; }
            public double Valor { get; set; }
        }
    }
}
