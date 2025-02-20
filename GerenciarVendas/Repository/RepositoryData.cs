using System.Globalization;
using System.Data.SqlClient;
using System.Data.SQLite;
using GerenciarVendas.Models;
using GerenciarVendas.Utils;

using GerenciarVendas.UI;

namespace GerenciarVendas.Repository
{
    public static class RepositoryData
    {

        public static void CriarTabelaBD()
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

        public static async Task InserirVendaBD(Vendas venda)
        {
            // receber as informações -> OBJ venda


            //armazenar no banco de dados
            using (var connection = Data.DataConnections.GetConnection())
            {

                await connection.OpenAsync();
                using (var transition = await connection.BeginTransactionAsync())
                {
                    try
                    {
                        string query = "INSERT INTO Vendas(NomeProdutos,Quantidade,Preco) VALUES (@nome,@quantidade,@preco)";
                        using (var command = new SQLiteCommand(query, connection))
                        {

                            command.Parameters.AddWithValue("@nome", venda.ItemNome);
                            command.Parameters.AddWithValue("@quantidade", venda.Quantidade);
                            command.Parameters.AddWithValue("@preco", venda.ValorUnitario);
                            command.ExecuteNonQuery();
                        }
                        transition.Commit();
                    }
                    catch (Exception e)
                    {
                        transition.Rollback();
                        Console.Write("Rollback, erro:" + e.Message);
                    }
                }
            }
        }

        public static async Task AtualizarVendaBD(string TipoBusca)
        {

            //armazenar no banco de dados
            using (var connection = Data.DataConnections.GetConnection())
            {

                await connection.OpenAsync();
                using (var transition = await connection.BeginTransactionAsync())
                {
                    if (TipoBusca == "1") // pelo nome
                    {
                        
                    }

                    if (TipoBusca == "2") //pelo ID
                    {
                        Console.WriteLine("Digite o ID da Venda: ");
                        int id = int.Parse(Console.ReadLine() ?? "0");
                        
                        Vendas venda=new Vendas();

                        if (id==0)
                        {
                            transition.Rollback();
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Insira os Novos Dados da Venda");
                            venda = Helpers.DadosVendas();
                        }

                        try
                        {
                            string query = "UPDATE Vendas SET NomeProdutos=@nome,Preco=@preco,Quantidade=@quantidade WHERE Id=@id";
                            using (var command = new SQLiteCommand(query, connection))
                            {
                                Console.Write($"{id},{venda.ItemNome},{venda.Quantidade},{venda.ValorUnitario}");
                                command.Parameters.AddWithValue("@id", id);
                                command.Parameters.AddWithValue("@nome", venda.ItemNome);
                                command.Parameters.AddWithValue("@quantidade", venda.Quantidade);
                                command.Parameters.AddWithValue("@preco", venda.ValorUnitario);
                                int verificacaoExiste = command.ExecuteNonQuery();
                                if (verificacaoExiste != 0)
                                {
                                    Console.WriteLine("Atualizacao realizada com sucesso! ");
                                }
                                else
                                {
                                    Console.WriteLine("Não existe esse item/produto! ");
                                }
                            }
                            transition.Commit();
                        }
                        catch (Exception e)
                        {
                            transition.Rollback();
                            Console.Write("Rollback, erro:" + e.Message);
                        }
                    }
                }
            }
        }
    }
}