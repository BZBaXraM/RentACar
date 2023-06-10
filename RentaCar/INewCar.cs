namespace RentaCar;

public interface INewCar
{
    Task AddNewCar();
    Task SearchInfo();
    Task DeleteInfo();
    Task RentalCar();
}