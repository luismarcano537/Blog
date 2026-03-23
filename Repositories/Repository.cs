using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace blog.Repositories;

public class Repository<T> where T : class
{
    private readonly SqlConnection _connection;

    public Repository(SqlConnection connection)
        => _connection = connection;
    
    public IEnumerable<T> Get()
        => _connection.GetAll<T>().ToList();

    public T Get(int id)
        => _connection.Get<T>(id);
    
    public void Create(T model)
        => _connection.Insert(model);

    public bool Put(T model)
        => _connection.Update(model);

    public bool Delete(T  model)
        => _connection.Delete(model);
}