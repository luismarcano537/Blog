using System.ComponentModel.DataAnnotations.Schema;

namespace blog.models;
[Table("[Tags]")]
public class Tag
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }

    public override string ToString()
    {
        return Name;
    }
}