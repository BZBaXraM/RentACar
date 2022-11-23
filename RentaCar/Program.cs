using RentaCar;
using AppContext = RentaCar.AppContext;

Menu();

void Menu()
{
    while (true)
    {
        Console.WriteLine("1. Регистрация" +
                          "\n2. Логин");
        Console.Write("Выберите пункт из меню: ");
        IAccount account = new Addition();
        var select = int.Parse(Console.ReadLine()!);
        switch (select)
        {
            case 1:
                account.Registration();
                break;
            case 2:
                account.Login();
                break;
            default:
                Console.WriteLine("Ошибка!");
                break;
        }
    }
}


using AppContext context = new AppContext();

Car car = new Car
{
    Brand = "Aston Martin", Number = "YM11S", Model = "Vantage", Color = "White", Date = DateOnly.Parse("01.01.2022"),
    Price = 146.986
};
Car carTwo = new Car
{
    Brand = "Aston Martin", Number = "YM11S", Model = "DBX", Color = "Red", Date = DateOnly.Parse("01.01.2022"),
    Price = 188.986
};
Car carThree = new Car
{
    Brand = "Aston Martin", Number = "YM98S", Model = "DB11", Color = "Black", Date = DateOnly.Parse("01.01.2022"),
    Price = 220.086
};
Car carFour = new Car
{
    Brand = "Aston Martin", Number = "YM88S", Model = "DBS", Color = "Black", Date = DateOnly.Parse("01.01.2022"),
    Price = 335.686
};
Car carFive = new Car
{
    Brand = "Aston Martin", Number = "YA01S", Model = "Vanquish S", Color = "Blur", Date = DateOnly.Parse("01.01.2018"),
    Price = 203.747
};

context.AddRange(car, carTwo, carThree, carFour, carFive);
// context.SaveChanges();