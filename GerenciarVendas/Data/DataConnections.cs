using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace GerenciarVendas.Data
{
    public static class DataConnections
    {
        private static readonly string _connectionString = "Data Source=C:\\Users\\allys\\OneDrive\\Área de Trabalho\\C_sharp_\\Projetos\\GerenciamentoVendasCsh\\GerenciarVendas\\meuBanco.db;Version=3;";

        /* Para conectar com o banco de dados
         *  coloco o caminho ou o metodo de conexão
         *  depois eu faço o metodo que retorna a conexão aberta
         */
        public static SQLiteConnection GetConnection()
        {
            var connection = new SQLiteConnection(_connectionString);
            return connection;
        }
    }

    
}
