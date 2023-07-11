using Microsoft.Identity.Client;

namespace Debt_relations_project_version1.Models
{
    public class Addiction
    {
        public User DependentUser { get; set; }
        public decimal Debet { get; set; }
        public string Currency { get; set; }

        public Addiction(User user, decimal debet, string currency)
        {
            DependentUser= user;
            Debet= debet;
            Currency= currency;
        }
    }
}
