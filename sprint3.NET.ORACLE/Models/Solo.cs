using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace sprint3.NET.Database.Models
{
    [Table("Solo")]
    public class Solo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Solo_Id { get; set; }

        public int FazendaId { get; set; }

        [JsonIgnore]
        public virtual Fazenda Fazenda { get; set; }

        public string TipoSolo { get; set; }

        public decimal PH { get; set; }

        public decimal NivelNitrogenio { get; set; }

        public decimal NivelPotassio { get; set; }

    }
}
