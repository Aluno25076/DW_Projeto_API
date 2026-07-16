namespace DW_Projeto_API.Models.ViewModels
{
    /// <summary>
    /// Lista de subscriões
    /// </summary>
    public class SubscriptionDTO
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
        public string SubscriptProgram { get; set; }

        /// <summary>
        /// A duração da subscrição da base de daods
        /// </summary>
        public enum Duration
        {
            Weekly,
            Monthly,
            Quarterly,
            Semesterly,
            Yearly
        }

        /// <summary>
        /// Os membors que se increveram na subscrição da base de dados 
        /// </summary>
        public ICollection<Member> Subscribers { get; set; } = [];
    }
}
