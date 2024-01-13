using dotenv.net;
using MySqlConnector;
namespace Dominios
{
    class Db
    {
        private static readonly MySqlConnectionStringBuilder builder;
        static Db()
        {
            var envVars = DotEnv.Read();
            builder = new()
            {
                Server = envVars["DB_SERVER"],
                Database = envVars["DB_NAME"],
                UserID = envVars["DB_USER"],
                Password = envVars["DB_PASSWORD"],
            };
        }
        public static async Task<int> AddProduto(Produto novoProduto)
        {

            using var connection = new MySqlConnection(builder.ConnectionString);
            await connection.OpenAsync();
            using var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Produtos (nome,preco,quantidade) VALUES (@nome,@preco,@quantidade)";
            command.Parameters.AddWithValue("@nome", novoProduto.NomeProduto);
            command.Parameters.AddWithValue("@preco", novoProduto.PrecoProduto);
            command.Parameters.AddWithValue("@quantidade", novoProduto.Quantidade);
            int rowCount = await command.ExecuteNonQueryAsync();
            return rowCount;

        }
        public static async Task<List<Produto>> ListarProdutos()
        {
            List<Produto> ListaProduto = new();
            using var connection = new MySqlConnection(builder.ConnectionString);
            await connection.OpenAsync();
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Produtos;";
            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                Produto novoProduto = new(reader.GetInt32(0), reader.GetString(1), reader.GetDouble(2), reader.GetDouble(3));
                ListaProduto.Add(novoProduto);
            }
            return ListaProduto;

        }
        public static async Task<int> DeletarProduto(int id)
        {
            using var connection = new MySqlConnection(builder.ConnectionString);
            {
                await connection.OpenAsync();
                using var command = connection.CreateCommand();
                {
                    command.CommandText = "DELETE FROM Produtos WHERE Id=@id;";
                    command.Parameters.AddWithValue("@id", id);
                    int rowCount = await command.ExecuteNonQueryAsync();
                    return rowCount;
                }
            };
        }
        public static async Task<int> EntradaProduto(int id, double valorEntrada)
        {
            using var connection = new MySqlConnection(builder.ConnectionString);
            {
                await connection.OpenAsync();
                using var command = connection.CreateCommand();
                {
                    command.CommandText = "UPDATE Produtos SET Quantidade=Quantidade+@valorEntrada WHERE Id=@id;";
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@valorEntrada", valorEntrada);
                    int rowCount = await command.ExecuteNonQueryAsync();
                    return rowCount;
                }
            }
        }
        public static async Task<int> SaidaProduto(int id, double valorSaida)
        {
            using var connection = new MySqlConnection(builder.ConnectionString);
            {
                await connection.OpenAsync();
                using var command = connection.CreateCommand();
                {
                    command.CommandText = "UPDATE Produtos SET Quantidade=Quantidade-@valorSaida WHERE Id=@id; ";
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@valorSaida", valorSaida);
                    int rowCount = await command.ExecuteNonQueryAsync();
                    return rowCount;
                }
            }
        }
        public static async Task<int> AtualizarValor(int id, double valor)
        {
            using var connection = new MySqlConnection(builder.ConnectionString);
            {
                await connection.OpenAsync();
                using var command = connection.CreateCommand();
                {
                    command.CommandText = "UPDATE Produtos SET Preco=@preco Where Id=@id;";
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@preco", valor);
                    int rowCount = await command.ExecuteNonQueryAsync();
                    return rowCount;
                }
            }
        }
    }

}