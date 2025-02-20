using System.Globalization;
using GerenciarVendas.Models;

namespace GerenciarVendas.Utils
{
    public static class Helpers
    {
       public static Vendas DadosVendas()
        {
            Console.Write("Nome do produto: ");
            string nome = Console.ReadLine() ?? "Default";

            Console.Write("Quantidade: ");
            int quantidadeVenda = int.Parse(Console.ReadLine() ?? "0", CultureInfo.InvariantCulture);

            Console.Write("Preco unitario: ");
            float precoUnit = float.Parse(Console.ReadLine() ?? "0", CultureInfo.InvariantCulture);

            return new Vendas(nome, quantidadeVenda, precoUnit);
        }
    }
}
