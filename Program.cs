class Principal
{
    public static void Main()
    {
        string escolha;

        List<Produto> Estoque = new();
        do
        {
            Console.WriteLine("");
            Console.WriteLine("CONTROLE DE ESTOQUE-SUPERMERCADO");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Digite o número correspondente a ação que deseja realizar:");
            Console.WriteLine("[1] Adicionar novo produto");
            Console.WriteLine("[2] Listar produtos");
            Console.WriteLine("[3] Remover produto ");
            Console.WriteLine("[4] Entrada de estoque");
            Console.WriteLine("[5] Saída de estoque");
            Console.WriteLine("[6] Atualizar preço:");
            Console.WriteLine("[0] Sair");
            escolha = Console.ReadLine();
            switch (escolha)
            {

                case "1":
                    Console.WriteLine("Digite o nome do produto:");
                    string nome = Console.ReadLine();
                    Console.WriteLine("Digite o valor do produto:");
                    double preco = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Digite o tipo do produto (alimento, limpeza, higiene pessoal):");
                    string tipo = Console.ReadLine();
                    Console.WriteLine("Digite a quantidade em estoque do produto:");
                    int quantidade = Convert.ToInt32(Console.ReadLine());
                    Produto novoProduto = new(nome, preco, tipo, quantidade);
                    Estoque.Add(novoProduto);
                    Console.WriteLine("Produto {0} adicionado ao estoque!", nome);
                    break;

                case "2":
                    Console.WriteLine("LISTA DE PRODUTOS");
                    for (int i = 0; i < Estoque.Count; i++)
                    {
                        int posProduto = i + 1;
                        Produto x = Estoque[i];
                        Console.WriteLine("{0}-Nome produto: {1} | Valor: {2} R$ | Tipo: {3} | Estoque: {4}", posProduto, x.NomeProduto,
                        x.PrecoProduto, x.TipoProduto, x.Quantidade);
                    }
                    break;

                case "3":
                    Console.WriteLine("Digite o número do produto que deseja remover:");
                    int remover = Convert.ToInt32(Console.ReadLine());
                    Estoque.RemoveAt(remover - 1);
                    Console.WriteLine("Item removido!");
                    break;

                case "4":
                    Console.WriteLine("Digite o número correspondente ao produto que deseja dar entrada");
                    int entrada = Convert.ToInt32(Console.ReadLine()) - 1;
                    Console.WriteLine("Digite a quantidade de entradas do produto:");
                    int numEntradas = Convert.ToInt32(Console.ReadLine());
                    Estoque[entrada].Quantidade += numEntradas;
                    Console.WriteLine("A nova quantidade em estoque é {0}", Estoque[entrada].Quantidade);
                    break;

                case "5":
                    Console.WriteLine("Digite o número correspondente ao produto que deseja dar saida");
                    int saida = Convert.ToInt32(Console.ReadLine()) - 1;
                    Console.WriteLine("Digite o número de saídas do produto: ");
                    int numSaidas = Convert.ToInt32(Console.ReadLine());
                    Estoque[saida].Quantidade -= numSaidas;
                    Console.WriteLine("A nova quantidade em estoque é {0}", Estoque[saida].Quantidade);
                    break;

                case "6":
                    Console.WriteLine("Digite o número correspondente ao produto que deseja atualizar o valor:");
                    int num = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Digite o novo valor:");
                    double novoValor = Convert.ToDouble(Console.ReadLine());
                    Estoque[num - 1].PrecoProduto = novoValor;
                    Console.WriteLine("O valor do produto foi atualizado para: {0} R$", novoValor);
                    break;


            }
        } while (escolha != "0");



    }
}

class Produto
{
    public string NomeProduto { get; set; }
    public double PrecoProduto { get; set; }
    public string TipoProduto { get; set; }
    public double Quantidade { get; set; }


    public Produto(string nomeProduto, double precoProduto, string tipoProduto, double quantidade)
    {
        this.NomeProduto = nomeProduto;
        this.PrecoProduto = precoProduto;
        this.TipoProduto = tipoProduto;
        this.Quantidade = quantidade;

    }
}

