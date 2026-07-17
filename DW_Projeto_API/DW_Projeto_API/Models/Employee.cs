using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DW_Projeto_API.Models
{
    /// <summary>
    /// Dados do employee do clube de tenis
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Chave primária (PK)
        /// </summary>
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório")]
        [Display(Name = "Nome")]
        [StringLength(50)]
        public string Name { get; set; } = "";

        /// <summary>
        /// Cargo/função do funcionário no clube (ex: Treinador, Rececionista)
        /// </summary>
        [Required(ErrorMessage = "O {0} é obrigatório")]
        [Display(Name = "Cargo")]
        [StringLength(50)]
        public string Position { get; set; } = "";

        /// <summary>
        /// Salário do funcionário
        /// </summary>
        [Precision(9, 2)]
        public decimal Salary { get; set; }

        /// <summary>
        /// Atributo auxiliar para o salário, para garantir
        /// que o valor possa ser guardado como uma moeda padrão
        /// </summary>
        [NotMapped]
        [Required(ErrorMessage = "O {0} é obrigatório")]
        [Display(Name = "Salário")]
        [StringLength(10)]
        [RegularExpression("[0-9]{1,7}([,.][0-9]{1,2})?",
           ErrorMessage = "O {0} deve ser um número com até 2 casas decimais")]
        public string SalaryAux { get; set; } = "";

        /// <summary>
        /// Data de contratação do funcionário
        /// </summary>
        [Display(Name = "Data de Contratação")]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }

        /// <summary>
        /// Lista de jogos (Matches) arbitrados/geridos por este funcionário
        /// </summary>
        public ICollection<Match> Matches { get; set; } = [];
    }
}