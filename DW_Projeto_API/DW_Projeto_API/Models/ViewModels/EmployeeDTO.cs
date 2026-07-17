namespace DW_Projeto_API.Models.ViewModels
{
    /// <summary>
    /// Funcionário — dados sensíveis (salário) não são expostos pela API
    /// </summary>
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Position { get; set; } = "";
        public int NumberOfMatches { get; set; }
    }
}