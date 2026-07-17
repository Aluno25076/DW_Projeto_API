using System.ComponentModel.DataAnnotations;


namespace DW_Projeto_API.Models
{
    public class Match
    {
        /// <summary>
        /// Chave primária (PK)
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Data e hora do jogo
        /// </summary>
        [Required(ErrorMessage = "A {0} é obrigatória")]
        [Display(Name = "Data do Jogo")]
        public DateTime MatchDate { get; set; }

        /// <summary>
        /// Duração do jogo em minutos
        /// </summary>
        [Display(Name = "Duração (min)")]
        public int DurationMinutes { get; set; }

        /// <summary>
        /// Campo (Field) onde o jogo se realiza - FK
        /// </summary>
        [Required(ErrorMessage = "O {0} é obrigatório")]
        [Display(Name = "Campo")]
        public int FieldId { get; set; }
        public Field Field { get; set; } = null!;

        /// <summary>
        /// Funcionário responsável pelo jogo (ex: árbitro) - FK
        /// </summary>
        [Display(Name = "Funcionário")]
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        /// <summary>
        /// Lista de participantes (Members) no jogo
        /// </summary>
        public ICollection<Member> Participants { get; set; } = [];
    }
}
