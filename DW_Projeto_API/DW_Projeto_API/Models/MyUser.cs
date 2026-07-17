using System.ComponentModel.DataAnnotations;

namespace DW_Projeto_API.Models
{
    /// <summary>
    /// Classe para representar os utilizadores da aplicação
    /// estes dados identificam os utilizadores, independentemente 
    /// do tipo de utilizador (Membro, Funcionario)
    /// </summary>
    public class MyUser
    {
        /// <summary>
        /// Chave Primaria (PK)
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nome Completo do utilizador
        /// </summary>
        [StringLength(50)]
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatorio!")]
        [Display(Name = "Nome Completo")]
        public string Name { get; set; } = "";

        /// <summary>
        /// Data de nascimento
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatorio!")]
        [Display(Name = "Data de nascimento")]
        public DateOnly BirthDate { get; set; }

        /// <summary>
        /// Número de telephone
        /// </summary>
        [Display(Name = "Telemóvel")]
        [StringLength(19)]
        [RegularExpression(@"\+?[0-9]{9,18}", ErrorMessage = "O número de telemóvel deve conter apenas dígitos (entre 9 e 18) e pode começar com um sinal de mais.")]
        public string? CellPhone { get; set; }

        /// <summary>
        /// 'nome de utilizador' do Membro, 
        /// que será utilizado para autenticação e login na aplicação
        /// Fará a 'ponte' entre os dados da autenticação e os dados do negócio
        /// </summary>
        [StringLength(50)]
        public string UserName { get; set; } = "";
    }
}
