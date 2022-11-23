namespace RentaCar;

public class Addition : INewCar, IAccount
{
    private readonly Car _car = new();
    private readonly Account _account = new();
    private readonly Rental _rental = new();

    private void Menu()
    {
        while (true)
        {
            Console.WriteLine("1. Добавление новый машины" +
                              "\n2. Искать информацию о машине " +
                              "\n3. Удалить информацию о машине" +
                              "\n4. Взять в аренду машину" +
                              "\n5. Выход");
            Console.Write("Выберите пункт из меню: ");
            var select = int.Parse(Console.ReadLine()!);
            switch (select)
            {
                case 1:
                    AddNewCar();
                    break;
                case 2:
                    SearchInfo();
                    break;
                case 3:
                    DeleteInfo();
                    break;
                case 4:
                    RentalCar();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Ошибка!");
                    break;
            }
        }
    }

    public void Registration()
    {
        using AppContext context = new AppContext();

        Console.Write("Введите имя: ");
        var name = Console.ReadLine();
        Console.Write("Введите фамилию: ");
        var surname = Console.ReadLine();
        Console.Write("Введите новый логин: ");
        var login = Console.ReadLine();
        Console.Write("Введите новый пароль: ");
        var password = Console.ReadLine();
        Console.Clear();
        Thread.Sleep(500);
        Console.WriteLine("Регистрация произошла успешно! ");

        _account.Name = name;
        _account.Surname = surname;
        _account.Login = login;
        _account.Password = password;
        context.Add(_account);
        context.SaveChanges();
    }

    public void Login()
    {
        using AppContext context = new AppContext();

        Console.Clear();
        Console.Write("Введите логин: ");
        var login = Console.ReadLine();
        Console.Write("Введите пароль: ");
        var password = Console.ReadLine();

        Console.Clear();
        if (context.Accounts.FirstOrDefault(x => x.Login == login && x.Password == password) != null)
        {
            Console.WriteLine("Добро пожаловать на Rent a Car от Бахы!");
            Console.WriteLine();
            Thread.Sleep(500);
            Menu();
        }
        else
        {
            Console.WriteLine("Не правильный логин илм пароль!");
        }
    }

    public void AddNewCar()
    {
        using AppContext context = new AppContext();

        Console.Write("Add Brand: ");
        var addBrand = Console.ReadLine();
        Console.Write("Add Number: ");
        var addNumber = Console.ReadLine();
        Console.Write("Add Color: ");
        var addColor = Console.ReadLine();
        Console.Write("Add Release Date: ");
        var addDate = DateOnly.Parse(Console.ReadLine()!);
        Console.Write("Add Model: ");
        var addModel = Console.ReadLine();
        Console.Write("Add Price: ");
        var addPrice = Convert.ToDouble(Console.ReadLine());

        _car.Brand = addBrand;
        _car.Number = addNumber;
        _car.Color = addColor;
        _car.Date = addDate;
        _car.Model = addModel;
        _car.Price = addPrice;
        // _car.RentalDate = addRentalDate;
        context.Add(_car);
        context.SaveChanges();
    }

    public void SearchInfo()
    {
        using AppContext context = new AppContext();

        Console.Clear();
        Console.Write("Введите название бренда: ");
        var search = Console.ReadLine();
        Console.Clear();
        var cnt = context.Cars?.Where(x => x.Brand == search);
        foreach (var item in cnt!)
        {
            Thread.Sleep(1000);
            Console.WriteLine($"Id: {item.Id} {item.Brand} {item.Model}");
        }
        //Console.WriteLine(cnt is null ? "Ошибка!" : $"Id {cnt.Id} Названия бренда: {cnt.Brand}");
    }

    public void DeleteInfo()
    {
        Console.Clear();
        using AppContext context = new AppContext();

        var cnt = context.Cars?.ToList();
        foreach (var item in cnt!)
        {
            Console.WriteLine($"{item.Id} {item.Brand} {item.Model}");
        }

        Console.WriteLine();

        Console.Write("Введите Id для удаление: ");
        var deleteInfo = int.Parse(Console.ReadLine()!);
        _car.Id = deleteInfo;
        var cntTwo = context.Cars?.FirstOrDefault(x => x.Id == deleteInfo);
        Console.WriteLine(cntTwo is null
            ? "Ошибка!"
            : $"{context.Cars?.Remove(cntTwo)} Id: {cntTwo.Id} с называнием {cntTwo.Brand} и моделем {cntTwo.Model} удалено!");
        context.SaveChanges();
        Console.WriteLine();

        Console.WriteLine("Оставшееся машины в БД: ");
        cnt = context.Cars?.ToList();
        foreach (var item in cnt!)
        {
            Console.WriteLine($"{item.Id} {item.Brand} {item.Model}");
        }

        Console.WriteLine();
    }

    public void RentalCar()
    {
        Console.Clear();
        using AppContext context = new AppContext();

        var cnt = context.Cars?.ToList();
        foreach (var item in cnt!)
        {
            Console.WriteLine($"{item.Id} {item.Brand} {item.Model}");
        }

        Console.WriteLine();

        Console.Write("Введите Id машины для аренды: ");
        var id = int.Parse(Console.ReadLine()!);
        var cntTwo = context?.Cars?.Where(x => x.Id == id);
        Console.Write("На какую дату ходите аредовать машину? ");
        var rentalDate = DateOnly.Parse(Console.ReadLine()!);

        _rental.Id = id;
        // _car.Brand = _rental.Brand;
        _rental.RentalDate = rentalDate;

        context?.Add(_rental);
        context?.SaveChanges();

        foreach (var item in cntTwo!)
        {
            Console.WriteLine(item.Id);
        }
    }
}