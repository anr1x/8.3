using System;

// Абстрактні класи для компонентів продукту
public abstract class Screen { public abstract void Display(); }
public abstract class Processor { public abstract void Process(); }
public abstract class Camera { public abstract void Capture(); }

// Конкретні класи компонентів для смартфону
public class SmartphoneScreen : Screen
{
    public override void Display() => Console.WriteLine("Дисплей для смартфону");
}

public class SmartphoneProcessor : Processor
{
    public override void Process() => Console.WriteLine("Процесор для смартфону");
}

public class SmartphoneCamera : Camera
{
    public override void Capture() => Console.WriteLine("Камера для смартфону");
}

// Конкретні класи компонентів для ноутбука
public class LaptopScreen : Screen
{
    public override void Display() => Console.WriteLine("Дисплей для ноутбука");
}

public class LaptopProcessor : Processor
{
    public override void Process() => Console.WriteLine("Процесор для ноутбука");
}

public class LaptopCamera : Camera
{
    public override void Capture() => Console.WriteLine("Камера для ноутбука");
}

// Фабрики для створення компонентів
public interface IProductFactory
{
    Screen CreateScreen();
    Processor CreateProcessor();
    Camera CreateCamera();
}

public class SmartphoneFactory : IProductFactory
{
    public Screen CreateScreen() => new SmartphoneScreen();
    public Processor CreateProcessor() => new SmartphoneProcessor();
    public Camera CreateCamera() => new SmartphoneCamera();
}

public class LaptopFactory : IProductFactory
{
    public Screen CreateScreen() => new LaptopScreen();
    public Processor CreateProcessor() => new LaptopProcessor();
    public Camera CreateCamera() => new LaptopCamera();
}

// Клас для створення продуктів
public class ProductCreator
{
    public void AssembleProduct(IProductFactory factory)
    {
        Screen screen = factory.CreateScreen();
        Processor processor = factory.CreateProcessor();
        Camera camera = factory.CreateCamera();

        Console.WriteLine("Створено новий продукт:");
        screen.Display();
        processor.Process();
        camera.Capture();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Оберіть тип продукту (smartphone, laptop):");
        string productType = Console.ReadLine().ToLower();

        IProductFactory factory = null;
        switch (productType)
        {
            case "smartphone":
                factory = new SmartphoneFactory();
                break;
            case "laptop":
                factory = new LaptopFactory();
                break;
            default:
                Console.WriteLine("Непідтримуваний тип продукту");
                break;
        }

        if (factory != null)
        {
            ProductCreator creator = new ProductCreator();
            creator.AssembleProduct(factory);
        }
    }
}
