namespace DW_Projeto_API.Models.ViewModels
{
    /// <summary>
    /// Campo/court do clube de ténis
    /// </summary>
    public class FieldDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Surface { get; set; } = "";
        public bool IsIndoor { get; set; }
    }
}