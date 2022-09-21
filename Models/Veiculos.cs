using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace atvCarros0609
{
    [Table("Veiculo")]
    public class Veiculos
    {
        public int veiculosId { get; set; }

        [Column("proprietario")]
        [Display(Name = "Nome do Proprietário")]
        public string proprietario { get; set; }

        [Column("telefone")]
        [Display(Name = "Número de telefone")]
        public string telefone { get; set; }

        [Column("placa")]
        [Display(Name = "Placa do Veículo")]
        public string placa { get; set; }

        [Column("corVe")]
        [Display(Name = "Cor do Veículo")]
        public string corVe { get; set; }

        [Column("modeloVe")]
        [Display(Name = "Modelo do Veículo")]
        public string modeloVe { get; set; }
    }
}
