using Codesanook.EFNote.Console.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Codesanook.EFNote.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //********** Traditional SQL insert with ADO.NET **********
            // User Windows Authentication log in as a recommended log in
            var connectionString = ConfigurationManager.ConnectionStrings["NoteConnectionString"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                //Prepare SQL command
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Notebooks VALUES (@name)"; //Magic string

                //Prepare SQL parameter prevent SQL Injection
                const string notebookName = "Programming Tips";
                var parameter = new SqlParameter()
                {
                    ParameterName = "name",
                    Value = notebookName,
                    DbType = DbType.String
                };
                command.Parameters.Add(parameter);

                //Start execute query to a database server
                connection.Open();
                var rowsEffected = command.ExecuteNonQuery();
                System.Console.WriteLine($"New notebook inserted with rows effected {rowsEffected}");
            }

            //********** Insert with EF **********
            using (var dbContext = new NoteDbContext())
            {
                var notebook = new Notebook()
                {
                    Name = "Programming Tips"
                };

                dbContext.Notebooks.Add(notebook);
                dbContext.SaveChanges();

                System.Console.WriteLine($"New notebook inserted with Id {notebook.Id}");
            }
        }
    }
}
