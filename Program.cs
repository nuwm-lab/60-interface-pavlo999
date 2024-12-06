using System;

abstract class Function
{
    // Абстрактні методи, які мають бути реалізовані в похідних класах
    public abstract void SetCoefficients(params double[] coefficients);
    public abstract void PrintCoefficients();
    public abstract double CalculateValue(double x);

    // Конструктор абстрактного класу
    public Function()
    {
        Console.WriteLine("Створено екземпляр функції.");
    }

    // Деструктор
    ~Function()
    {
        Console.WriteLine("Екземпляр функції знищено.");
    }
}

class LinearFunction : Function
{
    protected double a1, a0;

    // Конструктор для лінійної функції
    public LinearFunction(double a1, double a0)
    {
        this.a1 = a1;
        this.a0 = a0;
    }

    // Реалізація абстрактного методу для задання коефіцієнтів
    public override void SetCoefficients(params double[] coefficients)
    {
        if (coefficients.Length != 2)
            throw new ArgumentException("Для лінійної функції потрібно два коефіцієнти.");
        a1 = coefficients[0];
        a0 = coefficients[1];
    }

    // Реалізація абстрактного методу для виведення коефіцієнтів
    public override void PrintCoefficients()
    {
        Console.WriteLine($"Лінійна функція: f(x) = {a1}x + {a0}");
    }

    // Реалізація абстрактного методу для обчислення значення
    public override double CalculateValue(double x)
    {
        return a1 * x + a0;
    }
}

class Polynomial : Function
{
    private double a4, a3, a2, a1, a0;

    // Конструктор для багаточлена
    public Polynomial(double a4, double a3, double a2, double a1, double a0)
    {
        this.a4 = a4;
        this.a3 = a3;
        this.a2 = a2;
        this.a1 = a1;
        this.a0 = a0;
    }

    // Реалізація абстрактного методу для задання коефіцієнтів
    public override void SetCoefficients(params double[] coefficients)
    {
        if (coefficients.Length != 5)
            throw new ArgumentException("Для багаточлена потрібно п'ять коефіцієнтів.");
        a4 = coefficients[0];
        a3 = coefficients[1];
        a2 = coefficients[2];
        a1 = coefficients[3];
        a0 = coefficients[4];
    }

    // Реалізація абстрактного методу для виведення коефіцієнтів
    public override void PrintCoefficients()
    {
        Console.WriteLine($"Багаточлен: f(x) = {a4}x^4 + {a3}x^3 + {a2}x^2 + {a1}x + {a0}");
    }

    // Реалізація абстрактного методу для обчислення значення
    public override double CalculateValue(double x)
    {
        return a4 * Math.Pow(x, 4) + a3 * Math.Pow(x, 3) + a2 * Math.Pow(x, 2) + a1 * x + a0;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Динамічне створення об'єкта на основі вибору користувача
        Function function;

        // Вибір типу функції користувачем
        Console.WriteLine("Оберіть тип функції: 1 - лінійна, 2 - багаточлен");
        int choice = int.Parse(Console.ReadLine());

        if (choice == 1)
        {
            // Створюємо лінійну функцію
            Console.WriteLine("Задайте коефіцієнти для лінійної функції (a1 та a0):");
            double a1 = double.Parse(Console.ReadLine());
            double a0 = double.Parse(Console.ReadLine());
            function = new LinearFunction(a1, a0);
        }
        else
        {
            // Створюємо багаточлен
            Console.WriteLine("Задайте коефіцієнти для багаточлена (a4, a3, a2, a1, a0):");
            double a4 = double.Parse(Console.ReadLine());
            double a3 = double.Parse(Console.ReadLine());
            double a2 = double.Parse(Console.ReadLine());
            double a1 = double.Parse(Console.ReadLine());
            double a0 = double.Parse(Console.ReadLine());
            function = new Polynomial(a4, a3, a2, a1, a0);
        }

        // Виведення коефіцієнтів функції
        function.PrintCoefficients();

        // Обчислення значення функції в заданій точці
        Console.Write("Введіть точку x для обчислення значення функції: ");
        double x = double.Parse(Console.ReadLine());
        Console.WriteLine($"Значення функції в точці {x} = {function.CalculateValue(x)}");

        Console.ReadLine(); // Для затримки програми
    }
}
