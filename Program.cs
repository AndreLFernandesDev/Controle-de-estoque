using Dominios;
using dotenv.net;
class Principal
{
    async public static Task Main()
    {
        DotEnv.Load();
        string escolha;
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
                    int id = 0;
                    id = Convert.ToInt32(null);
                    Console.WriteLine("Digite o nome do produto:");
                    string nome = Console.ReadLine();
                    Console.WriteLine("Digite o valor do produto:");
                    double preco = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Qtd estoque:");
                    int quantidade = Convert.ToInt32(Console.ReadLine());
                    Produto novoProduto = new(id, nome, preco, quantidade);
                    await Db.AddProduto(novoProduto);
                    Console.WriteLine("Produto '{0}' foi adicionado ao estoque!", nome);
                    break;

                case "2":
                    Console.WriteLine("LISTA DE PRODUTOS");
                    var estoque = await Db.ListarProdutos();
                    for (int i = 0; i < estoque.Count; i++)
                    {
                        Produto x = estoque[i];
                        Console.WriteLine("Id:{0} -Nome produto: {1} | Preço: {2} R$ | Qtd estoque: {3}", x.Id, x.NomeProduto,
                        x.PrecoProduto, x.Quantidade);
                    }
                    break;

                case "3":
                    Console.WriteLine("Digite o ID do produto que deseja remover:");
                    int idDelet = Convert.ToInt32(Console.ReadLine());
                    await Db.DeletarProduto(idDelet);
                    Console.WriteLine("Produto removido!");
                    break;

                case "4":
                    Console.WriteLine("Digite o ID do produto que deseja dar entrada");
                    int idEntrada = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Digite a quantidade de produtos que entrou:");
                    double quantidadeEntrada = Convert.ToDouble(Console.ReadLine());
                    await Db.EntradaProduto(idEntrada, quantidadeEntrada);
                    break;

                case "5":
                    Console.WriteLine("Digite ID do produto que deseja dar saida:");
                    int idSaida = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Digite a quantidade de produtos que saiu:");
                    int numSaidas = Convert.ToInt32(Console.ReadLine());
                    await Db.SaidaProduto(idSaida, numSaidas);
                    break;

                case "6":
                    Console.WriteLine("Digite o ID do produto que deseja atualizar o valor:");
                    int num = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Digite o novo valor do produto:");
                    double novoValor = Convert.ToDouble(Console.ReadLine());
                    await Db.AtualizarValor(num, novoValor);
                    Console.WriteLine("O valor do produto foi atualizado para: {0} R$", novoValor);
                    break;


            }
        } while (escolha != "0");



    }
}

class Produto
{
    public int Id { get; set; }
    public string NomeProduto { get; set; }
    public double PrecoProduto { get; set; }
    public double Quantidade { get; set; }


    public Produto(int id, string nomeProduto, double precoProduto, double quantidade)
    {
        this.Id = id;
        this.NomeProduto = nomeProduto;
        this.PrecoProduto = precoProduto;
        this.Quantidade = quantidade;

    }
}

