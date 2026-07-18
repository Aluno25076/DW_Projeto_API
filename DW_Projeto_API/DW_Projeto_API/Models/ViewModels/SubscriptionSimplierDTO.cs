namespace DW_Projeto_API.Models.ViewModels
{
    /// <summary>
    /// Lista de subscriões representada de forma simples
    /// </summary>
    public class SubscriptionSimplierDTO
    {
        /// <summary>
        /// O id da categoria da base de dados
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// o Nome da subscrição da base de dados
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// A pagamanto/taxa da subscrição da base de dados
        /// </summary>
        public decimal Fee { get; set; }

        /// <summary>
        /// O programa da subscrição da base de dados
        /// </summary>
        public string SubcriptProgram { get; set; } = "";
    }
}
