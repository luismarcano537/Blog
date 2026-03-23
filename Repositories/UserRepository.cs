using blog.models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace blog.Repositories;

public class UserRepository
{
    private readonly SqlConnection _connection;

    public UserRepository(SqlConnection connection)
        => _connection = connection;

    public IEnumerable<User> Get()
        => _connection.GetAll<User>();

    public User Get(string id)
        => _connection.Get<User>(id);

    public void Create(User user)
        => _connection.Insert(user);

    public void Update(User user)
        => _connection.Update(user);

    public void Delete(string id)
    {
        var userDelete = _connection.Get<User>(id);
        _connection.Delete(userDelete);
    }
}