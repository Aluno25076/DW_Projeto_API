using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DW_Projeto_API.Models
{
    /// <summary>
    /// Representa um campo/court do clube de ténis
    /// </summary>
    public class Field
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
        /// Tipo de piso do campo
        /// </summary>
        public enum SurfaceType
        {
            Clay,
            Grass,
            HardCourt,
            Synthetic
        }

        [Required(ErrorMessage = "O {0} é obrigatório")]
        [Display(Name = "Tipo de Piso")]
        public SurfaceType Surface { get; set; }

        /// <summary>
        /// Indica se o campo é coberto (indoor) ou ao ar livre
        /// </summary>
        [Display(Name = "Coberto")]
        public bool IsIndoor { get; set; }

        /// <summary>
        /// Lista de jogos (Matches) marcados neste campo
        /// </summary>
        public ICollection<Match> Matches { get; set; } = [];
    }
}