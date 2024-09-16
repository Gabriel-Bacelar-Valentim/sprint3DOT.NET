using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sprint3.NET.Database.Models
{
    [Table("Fazenda")]
    public class Fazenda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Fazenda_Id { get; set; }

        public int AgricultorId { get; set; }
        public virtual Agricultor Agricultor { get; set; }

        public string? Nome { get; set; }

        public decimal TamanhoHectares { get; set; }

        public string? Localizacao { get; set; }

        [JsonIgnore]

        public virtual ICollection<Solo> Solos { get; set; }

        [JsonIgnore]

        public virtual ICollection<Safra> Safras { get; set; }
    }
}
