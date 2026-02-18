using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Category
{
    [Key]
    public required int CategoryId { get; set; }
    public required string CategoryName { get; set; }
}
