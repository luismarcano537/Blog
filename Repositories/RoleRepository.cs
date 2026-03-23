using blog.models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace blog.Repositories;

public class RoleRepository
{
    private readonly SqlConnection _connection;

    public RoleRepository(SqlConnection connection)
        => _connection = connection;
    
    public IEnumerable<Role> GetRoles()
        => _connection.GetAll<Role>();

    public Role GetRole(int id)
        => _connection.Get<Role>(id);

    public void UpdateRole(Role role)
        => _connection.Update(role);
    
    public void CreateRole(Role role)
        => _connection.Insert(role);
    
    public void DeleteRole(Role role)
        => _connection.Delete(role);
}