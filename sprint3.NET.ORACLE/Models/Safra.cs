using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace sprint3.NET.Database.Models
{
    [Table("Safra")]
    public class Safra
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Safra_Id { get; set; }

        public int FazendaId { get; set; }

        [JsonIgnore]
        public virtual Fazenda Fazenda { get; set; }

        public string Cultura { get; set; }

        public int Ano { get; set; }

        public decimal QuantidadeProduzida { get; set; }
    }
}
