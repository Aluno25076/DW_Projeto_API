using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


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
        [ForeignKey(nameof(Field))]
        [Required(ErrorMessage = "O {0} é obrigatório")]
        [Display(Name = "Campo")]
        public int FieldFK { get; set; }

        /// <summary>
        /// Campo onde o jogo se realiza
        /// </summary>
        [ValidateNever]
        [Display(Name = "Campo")]
        public Field Field { get; set; } = null!;

        /// <summary>
        /// FK para o Funcionário responsável pelo jogo (opcional)
        /// </summary>
        [ForeignKey(nameof(Employee))]
        [Display(Name = "Funcionário")]
        public int? EmployeeFK { get; set; }

        /// <summary>
        /// Funcionário responsável pelo jogo
        /// </summary>
        [ValidateNever]
        [Display(Name = "Funcionário")]
        public Employee? Employee { get; set; }

        /// <summary>
        /// Lista de participantes (Members) no jogo
        /// </summary>
        public ICollection<Member> Participants { get; set; } = [];

        /// <summary>
        /// Resultado do jogo (nulo enquanto o jogo não tiver acabado)
        /// </summary>
        public Result? Result { get; set; }
    }
}