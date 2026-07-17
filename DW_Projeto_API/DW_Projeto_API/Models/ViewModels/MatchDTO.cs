namespace DW_Projeto_API.Models.ViewModels
{
    /// <summary>
    /// Jogo — os relacionamentos são devolvidos como texto,
    /// tal como no PhotosDTO do professor (Categoria → nome)
    /// </summary>
    public class MatchDTO
    {
        public int Id { get; set; }
        public DateTime MatchDate { get; set; }
        public int DurationMinutes { get; set; }
        public string Field { get; set; } = "";
        public string? Employee { get; set; }
        public ICollection<string> Participants { get; set; } = [];
    }
}
