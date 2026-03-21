using System;
using blog.models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace blog
{
    class Program
    {
        private const string ConnectionString = @"Server=localhost,1433;Database=blog;User Id=sa;Password=Adm@30201;TrustServerCertificate=True";
        static void Main(string[] args)
        {
            //ReadUsers();
            //ReadUser();
            //CreateUser();
            //UpdateUser();
            DeleteUser();
        }

        public static void ReadUsers()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var users = connection.GetAll<User>();

                foreach (var user in users)
                {
                    Console.WriteLine($"{user.Name} --- {user.Bio}");
                }
            }
        }

        public static void ReadUser()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                Console.Write("Informe o ID de um usuário: ");
                var userId = Console.ReadLine();
                
                var user = connection.Get<User>(userId);
                Console.WriteLine($"{user.Name} --- {user.Bio}");
            }
        }

        public static void CreateUser()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var user = new User()
                {
                    Name = "Luis Manuel Silva Marcano",
                    Email = "luissilvam537@gmail.com",
                    PasswordHash = "HASH",
                    Bio = "Desenvolvedor Backend .NET",
                    Image = "https://image.com.br",
                    Slug = "luis-marcano"
                };
                
                connection.Insert(user);
                Console.WriteLine($"Usuário: {user.Name} criado com sucesso!");
            }
        }

        public static void UpdateUser()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var userUpdate = connection.Get<User>(1002);
                
                userUpdate.Name = "Luis Marcano";
                
                connection.Update(userUpdate);
                Console.WriteLine($"Usuário: {userUpdate.Name} atualizado com sucesso!");
            }
        }

        public static void DeleteUser()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var userDelete = connection.Get<User>(1002);
                
                connection.Delete(userDelete);
                Console.Write("Usuário deletado com sucesso!");
            }
        }
    }
}

