using Microsoft.Data.SqlClient;

namespace Debt_relations_project_version1.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }

        public int IndificatorNumber { get; set; }

        public IConfiguration Configuration { get; }


        public User(string name, string mail)
        {
            Name = name;
            Mail = mail;
            string connection = "Server=(localdb)\\mssqllocaldb;Database=Debet_RelationsDB;Trusted_Connection=True;";
            using (var sqlConnection = new SqlConnection(connection))
            {
                sqlConnection.Open();
                string userfind = $"select USER_ID, Parole from Users where Name = '{name}' AND Mail = '{mail}'";
                SqlCommand command = new SqlCommand(userfind, sqlConnection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(reader.GetOrdinal("USER_ID")))
                        {
                            Id = reader.GetInt32(0);
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("Parole")))
                        {
                            Password = reader.GetString(1);
                        }
                    }
                }
                command.Parameters.Clear();
                reader.Close();

            }
        }
        public User(string name, string mail, string password)
        {
            Name = name; Mail = mail; Password = password;
            using (var sqlConnection = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=Debet_RelationsDB;Trusted_Connection=True;"))
            {
                sqlConnection.Open();
                string sqlCommand = @$"INSERT INTO Users (Name, Mail, Parole) Values('{name}','{Mail}','{password}')";
                SqlCommand command = new SqlCommand(sqlCommand, sqlConnection);
                command.ExecuteNonQuery();
            }
        }

    }
}
