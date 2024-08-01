using AutomobiliuNuoma.Core.Contracts;
using AutomobiliuNuoma.Core.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobiliuNuoma.Core.Repositories
{
    public class DarbuotojaiDbRepository : IDarbuotojaiRepository
    {
        private readonly string _dbConnectionString;
        public DarbuotojaiDbRepository(string connectionString)
        {
            _dbConnectionString = connectionString;
        }

        public Darbuotojas GautiDarbuotojaPagalId(int darbuotojoId)
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            var result = dbConnection.
                QueryFirst<Darbuotojas>(@"SELECT * FROM Darbuotojai WHERE Id = @Id", new {Id = darbuotojoId});
            dbConnection.Close();
            return result;
        }

        public List<Darbuotojas> GautiDarbuotojus()
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            var result = dbConnection.
                Query<Darbuotojas>(@"SELECT * FROM Darbuotojai").ToList();
            dbConnection.Close();
            return result;
        }

        public void PridetiDarbuotoja(Darbuotojas darbuotojas)
        {
            string sqlCommand = @"
            INSERT INTO [dbo].[Darbuotojai]
           ([Vardas]
           ,[Pavarde]
           ,[Pareigos])
             VALUES
           (@Vardas
           ,@Pavarde
           ,@Pareigos)";

            using (var connection = new SqlConnection(_dbConnectionString))
            {
                connection.Execute(sqlCommand, darbuotojas);
            }
        }
    }
}
