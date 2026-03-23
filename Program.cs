using blog.models;
using blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace blog
{
    class Program
    {
        private const string ConnectionString =
            @"Server=localhost,1433;Database=blog;User Id=sa;Password=Adm@30201;TrustServerCertificate=True";

        static void Main(string[] args)
        {
            using var connection = new SqlConnection(ConnectionString);
            var userRepository = new UserRepository(connection);

            var users = userRepository.Get();
            foreach (var user in users)
            {
                Console.WriteLine(user.ToString());
            }

            Console.Write("Localizando um usuário por ID: ");
            var id = Console.ReadLine();

            var userbyId = userRepository.Get(id);

            Console.WriteLine(userbyId.ToString());
        }
    }
}