using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sprint3.NET.Database.Models
{
    [Table("DadoClimatico")]
    public class DadoClimatico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DdClimatico_Id { get; set; }

        public int FazendaId { get; set; }

        [JsonIgnore]
        public virtual Fazenda Fazenda { get; set; }

        public DateTime Data { get; set; }

        public decimal TemperaturaMedia { get; set; }

        public decimal UmidadeRelativa { get; set; }

        public decimal Precipitacao { get; set; }
    }
}
