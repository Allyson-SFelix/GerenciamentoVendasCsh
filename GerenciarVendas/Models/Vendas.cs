using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciarVendas.Models
{
    /* No models vou criar a/as classes para atribuir os valores
     * ou retirados do banco de dados ou recebidos pela interface 
     * para jogar depois no banco de dados
     */
    public class Vendas
    {
        // int Id autoincrement DataBase
        public string ItemNome { get; set; }
        public int Quantidade { get; set; }
        public float ValorUnitario { get; set; }
    
        public Vendas(string nome, int quantidade, float valorUnit)
        {
            ItemNome = nome;
            Quantidade = quantidade;
            ValorUnitario = valorUnit;
        }
    }
}
