namespace RentaCar;

public class Car
{
    public int Id { get; set; }
    public string? Brand { get; set; }
    public string? Number { get; set; }
    public string? Color { get; set; }
    public DateOnly Date { get; set; }
    public string? Model { get; set; }
    public double Price { get; set; }
    
    // public int AccountId { get; set; }
    // public Account? Account { get; set; }
}