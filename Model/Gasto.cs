using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebService.Financeiro.Model
{
    [Table("gastos")]
    public class Gasto
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("nome")]
        public string Nome { get; set; }
        [Column("pagamento")]
        public string Pagamento { get; set; }
        [Column("tipo")]
        public string Tipo { get; set; }
        [Column("local")]
        public string Local { get; set; }
        [Column("gasto_dia")]
        public DateTime GastoDia { get; set; }
        [Column("valor")]
        public double Valor { get; set; }

        public Gasto()
        {
        }

        public Gasto(int id, string nome, string pagamento, string tipo, string local,DateTime gastoDia, double valor)
        {
            Id = id;
            Nome = nome;
            Pagamento = pagamento;
            Tipo = tipo;
            Local = local;
            GastoDia = gastoDia;
            Valor = valor;
        }
    }
}
