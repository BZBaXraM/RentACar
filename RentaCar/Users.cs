using System.ComponentModel.DataAnnotations;

namespace RentaCar;

public class Users
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    [Required] public Account? Account { get; set; }
    [Required] public Car? Car { get; set; }
}