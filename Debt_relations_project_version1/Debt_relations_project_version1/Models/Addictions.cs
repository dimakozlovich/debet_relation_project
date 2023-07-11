using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;

namespace Debt_relations_project_version1.Models
{
    public class Addictions
    {
        public List<Addiction> ListOfAddiction = new List<Addiction>();

        public Addictions(User currentUser) 
        {
            string sqlCommand = $@"select User_ID, Name, Debet_of_the_first, currency from 
                                   Users inner join Addiction
                                   on Addiction.FIRST_USER_ID = Users.User_ID
                                   where SECOND_USER_ID = {currentUser.Id}";



            using (var sqlConnection = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=Debet_RelationsDB;Trusted_Connection=True;"))
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand(sqlCommand, sqlConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        int user_id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        decimal debet = reader.GetInt32(2);
                        string currency = reader.GetString(3);

                        var user = new User(user_id, name);  
                        var addiction = new Addiction(user, debet, currency);

                        ListOfAddiction.Add(addiction);
                    }
                }
            }
        
        }
    }
}
