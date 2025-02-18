using System.Globalization;
using System.Data.SqlClient;
using System.Data.SQLite;
using GerenciarVendas.Models;

namespace GerenciarVendas.Repository
{
    public class RepositoryData
    {

        public void CriarTabela()
        {
            using (var connection = Data.DataConnections.GetConnection())
            {
                connection.Open();

                string query = "CREATE TABLE Vendas(Id INTEGER PRIMARY KEY AUTOINCREMENT, NomeProdutos VARCHAR (40) NOT NULL, Quantidade INTEGER NOT NULL, Preco DECIMAL )";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }


            }
        }

        public async Task InserirVenda(Vendas venda)
        {
            // receber as informações -> OBJ venda


            //armazenar no banco de dados
            using (var connection = Data.DataConnections.GetConnection())
            {

                await connection.OpenAsync();
                using (var transition = await connection.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        string query = "INSERT INTO Vendas(NomeProdutos,Quantidade,Preco) VALUES (@nome,@quantidade,@preco)";
                           using (var command = new SQLiteCommand(query, connection))
                        {

                            command.Parameters.AddWithValue("@nome", venda.ItemNome);
                            command.Parameters.AddWithValue("@quantidade", venda.Quantidade);
                            command.Parameters.AddWithValue("@preco",venda.ValorUnitario);
                            command.ExecuteNonQuery();

                            transition.Commit();
                        }

                    }
                    catch (Exception e)
                    {
                        transition.Rollback("");
                        Console.Write("Rollback, erro:" + e.Message);
                    }
                }
            }
        }
    }
}