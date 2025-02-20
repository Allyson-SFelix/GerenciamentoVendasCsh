using System;
using System.Collections.Generic;
using System.Globalization;
using GerenciarVendas.Models;
using GerenciarVendas.Repository;
using GerenciarVendas.Utils;

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
                        AtualizarVenda();
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


        public static async void AtualizarVenda()
        {
            Console.WriteLine("- - MENU | Atualizar Vendas - -");
            // perguntar se é via codigo ou por nome de produto  
            Console.Write("1 - - Nome produto da venda\n2 - - Codigo da venda\n: ");
            string tipoBusca = Console.ReadLine() ?? "1";

            await RepositoryData.AtualizarVendaBD(tipoBusca);
        }


        public static async void AdicionarVenda()
        {
            Console.WriteLine("- - MENU | Adicionar Vendas - -");

            Vendas venda = Helpers.DadosVendas();

            await RepositoryData.InserirVendaBD(venda);
        }   
    }

    
}
