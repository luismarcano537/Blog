using System.ComponentModel.DataAnnotations.Schema;

namespace blog.models;

[Table("[Role]")]
public class Role
{
    public int Id { get; set; }
    public string Name { get; set; }
    public String Slug { get; set; }

    public override string ToString()
    {
        return $"{Name} - {Slug}";
    }
}