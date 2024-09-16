using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace sprint3.NET.Database.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Usuario_Id { get; set; }

        public string NomeUsuario { get; set; }

        public string Senha { get; set; }

        public string NomeCompleto { get; set; }

        public string Email { get; set; }

        public DateTime DataCriacao { get; set; }

        [JsonIgnore]
        public virtual Agricultor Agricultor { get; set; }
    }
}
