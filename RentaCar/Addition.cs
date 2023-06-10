namespace RentaCar;

public class Addition : INewCar, IAccount
{
    private readonly Car _car = new();
    private readonly Account _account = new();
    private readonly Rental _rental = new();

    private async Task Menu()
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
                    await AddNewCar();
                    break;
                case 2:
                    await SearchInfo();
                    break;
                case 3:
                    await DeleteInfo();
                    break;
                case 4:
                    await RentalCar();
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

    public async Task Registration()
    {
        await using AppContext context = new();

        Console.Write("Введите имя: ");
        var name = Console.ReadLine();
        Console.Write("Введите фамилию: ");
        var surname = Console.ReadLine();
        Console.Write("Введите новый логин: ");
        var login = Console.ReadLine();
        Console.Write("Введите новый пароль: ");
        var password = Console.ReadLine();
        Console.Clear();
        // Thread.Sleep(500);
        await Task.Delay(500);
        Console.WriteLine("Регистрация произошла успешно! ");

        _account.Name = name;
        _account.Surname = surname;
        _account.Login = login;
        _account.Password = password;
        await context.AddRangeAsync(_account);
        await context.SaveChangesAsync();
    }

    public async Task Login()
    {
        await using AppContext context = new();

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
            await Task.Delay(500);
            await Menu();
        }
        else
        {
            Console.WriteLine("Не правильный логин илм пароль!");
        }
    }

    public async Task AddNewCar()
    {
        await using AppContext context = new();

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
        await context.AddAsync(_car);
        await context.SaveChangesAsync();
    }

    public async Task SearchInfo()
    {
        await using AppContext context = new();

        Console.Clear();
        Console.Write("Введите название бренда: ");
        var search = Console.ReadLine();
        Console.Clear();
        var cnt = context.Cars?.Where(x => x.Brand == search);
        foreach (var item in cnt!)
        {
            await Task.Delay(1000);
            Console.WriteLine($"Id: {item.Id} {item.Brand} {item.Model}");
        }
        //Console.WriteLine(cnt is null ? "Ошибка!" : $"Id {cnt.Id} Названия бренда: {cnt.Brand}");
    }

    public async Task DeleteInfo()
    {
        Console.Clear();
        await using AppContext context = new AppContext();

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
        await context.SaveChangesAsync();
        Console.WriteLine();

        Console.WriteLine("Оставшееся машины в БД: ");
        cnt = context.Cars?.ToList();
        foreach (var item in cnt!)
        {
            Console.WriteLine($"{item.Id} {item.Brand} {item.Model}");
        }

        Console.WriteLine();
    }

    public async Task RentalCar()
    {
        Console.Clear();
        await using AppContext context = new AppContext();

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

        if (context != null)
        {
            await context.AddAsync(_rental);
            await context.SaveChangesAsync()!;
        }

        foreach (var item in cntTwo!)
        {
            Console.WriteLine(item.Id);
        }
    }
}