using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace modulo1_Semana09.Models
{
    [Table("Semana")]
    public class SemanaModel
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [NotNull]
        [Column("DataSemana")]
        public DateTime DataSemana { get; set; }

        [MaxLength(100)]
        [NotNull]
        [Column("Conteudo")]
        public string Conteudo { get; set; }

        [NotNull]
        public bool AplicadoConteudo { get; set; }

        
    }
}
