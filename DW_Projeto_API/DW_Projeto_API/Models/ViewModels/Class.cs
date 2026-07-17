

using Microsoft.Build.Framework;

using System.ComponentModel.DataAnnotations;


namespace DW_Projeto_API.Models.ViewModels
{

    /// <summary>
    /// classe que será usada para receber os dados de login do utilizador, 
    /// como o 'nome de utilizador' e a 'password', e será utilizada para 
    /// validar as credenciais do utilizador durante o processo de autenticação.
    /// </summary>
    public class LoginDTO
    {

        [System.ComponentModel.DataAnnotations.Required]
        [StringLength(50)]
        public string Username { get; set; } = "";

        [System.ComponentModel.DataAnnotations.Required]
        [StringLength(50)]
        public string Password { get; set; } = "";

    }
}