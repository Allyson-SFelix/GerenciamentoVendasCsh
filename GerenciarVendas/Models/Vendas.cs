namespace GerenciarVendas.Models
{
    /* No models vou criar a/as classes para atribuir os valores
     * ou retirados do banco de dados ou recebidos pela interface 
     * para jogar depois no banco de dados
     */
    public class Vendas
    {
        public int Id { get; private set; } //autoincrementeds
        public string ItemNome { get; set; }
        public int Quantidade { get; set; }
        public float ValorUnitario { get; set; }

        public Vendas(string nome, int quantidade, float valorUnit)
        {
            ItemNome = nome;
            Quantidade = quantidade;
            ValorUnitario = valorUnit;
        }
        public Vendas(){
            ItemNome = string.Empty;
            Quantidade = 0;
            ValorUnitario = 0;
        }
        public void SetId(int id)
        {
            Id = id;
        }

    }
}
