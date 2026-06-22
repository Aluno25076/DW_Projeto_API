namespace DW_Projeto_API.Models.ViewModels
{
    /// <summary>
    /// Lista de subscriões
    /// </summary>
    public class SubscriptionsDTO
    {
        /// <summary>
        /// O id da categoria da base de dados
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// A pagamanto/taxa da subscrição da base de dados
        /// </summary>
        public decimal Fee { get; set; }

        /// <summary>
        /// O programa da subscrição da base de dados
        /// </summary>
        public string SubcriptProgram { get; set; }

        /// <summary>
        /// A duração da subscrição da base de daods
        /// </summary>
        public enum Duration
        {
            Weekly,
            Monthly,
            Yearly
        }

        /// <summary>
        /// Os membors que se increveram na subscrição da base de dados 
        /// </summary>
        public ICollection<Member> MembersList { get; set; } = new List<Member>();
    }
}
