using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace sprint3.NET.Database.Models
{
    [Table("Agricultor")]
    public class Agricultor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Agricultor_Id { get; set; }

        public int UsuarioId { get; set; }

        [JsonIgnore]
        public virtual Usuario Usuario { get; set; }

        public string Nome { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        [JsonIgnore]
        public virtual ICollection<Fazenda> Fazendas { get; set; }
    }
}
