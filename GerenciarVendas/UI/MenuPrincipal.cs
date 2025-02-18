using System;
using System.Collections.Generic;
using System.Globalization;
using GerenciarVendas.Models;
using GerenciarVendas.Repository;

namespace GerenciarVendas.UI
{
    public static class MenuPrincipal
    {
        public static void Menu()
        {
            string entrada = "1";

            while (entrada != "0")
            {
                Console.WriteLine("- - MENU - -");
                Console.WriteLine(" 1 <- Adicionar Venda");
                Console.WriteLine(" 2 <- Listar Venda");
                Console.WriteLine(" 3 <- Atualizar Venda");
                Console.WriteLine(" 4 <- Remover Venda");
                Console.WriteLine(" 0 <- Sair");

                entrada = Console.ReadLine() ?? "1";
                

                switch (entrada)
                {
                    case "1":
                        Console.WriteLine("Adicionar Venda");
                        AdicionarVenda();
                        break;
                    case "2":
                        Console.Write("Listar Venda");
                        break;
                    case "3":
                        Console.Write("Atualizar Venda");
                        break;
                    case "4":
                        Console.Write("Remover Venda");
                        break;
                    case "0":
                        Console.Write("Saindo!");
                        break;
                    default:
                        Console.Write("Opcao errada!");
                        break;
                }
            }
        }

        public static async void AdicionarVenda()
        {
            Console.WriteLine("- - MENU | VENDAS - -");
            Console.Write("Nome do produto: ");
            string nome = Console.ReadLine() ?? "Default";
            Console.Write("Quantidade: ");
            int quantidadeVenda = int.Parse(Console.ReadLine() ?? "0", CultureInfo.InvariantCulture) ;
            Console.Write("Preco unitario: ");
            float precoUnit = float.Parse(Console.ReadLine() ?? "0", CultureInfo.InvariantCulture);

            Vendas venda = new Vendas(nome, quantidadeVenda, precoUnit);

            float valorTotal = (precoUnit * quantidadeVenda);
            
            Console.WriteLine("Valor total: "+valorTotal.ToString("F2", CultureInfo.InvariantCulture));

            RepositoryData repository = new RepositoryData();
            await repository.InserirVenda(venda);
        }   
    }

    
}
