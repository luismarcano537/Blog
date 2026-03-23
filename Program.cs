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
            var userRepository = new Repository<User>(connection);
            
            ReadAllUsers(userRepository);
            //ReadUser(userRepository);
            //CreateUser(userRepository);
            //UpdateUser(userRepository);
            //DeleteUser(userRepository);
        }

        public static void CreateUser(Repository<User> repository)
        {
            var newUser = new User()
            {
                Name = "Juan Marcano",
                Email = "juan@gmail.com",
                PasswordHash = Guid.NewGuid().ToString(),
                Bio = "Desenvolvedor Mobile",
                Image = "https://image.com/juan-marcano-logo.jpg",
                Slug = "juan-marcano"
            };
            
            repository.Create(newUser);
        }

        public static void UpdateUser(Repository<User> repository)
        {
            var user = repository.Get(10);
            user.Name = "Beatriz Rosario";
            
            repository.Put(user);
        }

        public static void DeleteUser(Repository<User> repository)
        {
            Console.Write("Deleting user, please informed Id user: ");
            var id = int.Parse(Console.ReadLine());
            var user = repository.Get(id);
            
            repository.Delete(user);
        }

        public static void ReadUser(Repository<User> repository)
        {
            Console.Write("Reading user, please informed Id user: ");
            var id = int.Parse(Console.ReadLine());
            var user = repository.Get(id);
            
            Console.WriteLine(user);
        }

        public static void ReadAllUsers(Repository<User> repository)
        {
            var users = repository.Get();

            foreach (var user in users)
            {
                Console.WriteLine(user);
            }
        }
    }
}