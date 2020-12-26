using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DataModels;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSQL
{

    public class Rep
    {
        private readonly string connectionString;

        public Rep(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<Human> Get()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var persons = new List<Human>();

                try
                {
                    var command = new SqlCommand("GetPersonsInfo", connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

                    var reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var person = new Human();
                            person.Id = reader.GetInt32(0);
                            person.FI = reader.GetString(1);
                            person.PhoneNumber = reader.GetString(2);
                            person.Job = reader.GetString(3);
                            person.BirthDay = reader.GetDateTime(4);

                            persons.Add(person);
                        }
                    }
                    reader.Close();

                    return persons;
                }

                finally
                {
                    connection.Close();
                }
            }
        }
    }    
}      

