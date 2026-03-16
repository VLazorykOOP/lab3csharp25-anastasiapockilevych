using System;using System.Collections.Generic;using System.Linq;namespace LabWork
{
    class Romb
    {
        protected int a;  // сторона
        protected int d1; // діагональ
        protected int c;  // колір

        public Romb(int side, int diagonal, int color)
        {
            a = side;
            d1 = diagonal;
            c = color;
        }

        public int Side { get => a; set => a = value; }
        public int Diagonal { get => d1; set => d1 = value; }
        public int Color { get => c; }

        public int GetPerimeter() => 4 * a;

        public double GetArea()
        {
            // S = d1 * sqrt(a^2 - (d1/2)^2)
            double halfD1 = d1 / 2.0;
            if (halfD1 >= a) return 0; 
            double halfD2 = Math.Sqrt(Math.Pow(a, 2) - Math.Pow(halfD1, 2));
            return (d1 * (2 * halfD2)) / 2.0;
        }

        public bool IsSquare()
        {
            // a * sqrt(2)
            return Math.Abs(d1 - a * Math.Sqrt(2)) < 0.1;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Колір: {c,-3} | Ст: {a,-2} | Діаг: {d1,-2} | P: {GetPerimeter(),-3} | S: {GetArea(),-6:F2} | Квадрат: {(IsSquare() ? "Так" : "Ні")}");
        }
    }

    abstract class Animal
    {
        public string Name { get; set; }
        public Animal(string name) => Name = name;
        public virtual void Show() => Console.Write($"[{this.GetType().Name}] Ім'я: {Name}");
    }

    class Mammal : Animal // ссавець
    {
        public Mammal(string name) : base(name) { }
        public override void Show() { base.Show(); Console.WriteLine(" - Годує молоком."); }
    }

    class Bird : Animal // птах
    {
        public Bird(string name) : base(name) { }
        public override void Show() { base.Show(); Console.WriteLine(" - Має крила."); }
    }

    class Artiodactyl : Mammal // парнокопитне
    {
        public Artiodactyl(string name) : base(name) { }
        public override void Show() { base.Show(); Console.WriteLine(" - Має копита (Парнокопитне)."); }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // дані для ромбів
            List<Romb> rombs = new List<Romb> {
                new Romb(10, 14, 3), // квадрат
                new Romb(5, 4, 1),
                new Romb(8, 10, 2),
                new Romb(7, 7, 3),
                new Romb(10, 10, 1)
            };

            // дані для тварин
            Animal[] animals = {
                new Bird("Орел"),
                new Artiodactyl("Олень"),
                new Mammal("Тигр"),
                new Artiodactyl("Жираф"),
                new Bird("Сова")
            };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== ГОЛОВНЕ МЕНЮ ===");
                Console.WriteLine("1. Завдання 1: Ромби (Сортування та Квадрати)");
                Console.WriteLine("2. Завдання 2: Тварини (Ієрархія та Типи)");
                Console.WriteLine("0. Вихід");
                Console.Write("\nВиберіть пункт: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        MenuRomb(rombs);
                        break;
                    case "2":
                        MenuAnimals(animals);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Помилка! Спробуйте ще раз.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void MenuRomb(List<Romb> rombs)
        {
            Console.Clear();
            Console.WriteLine("--- РОБОТА З РОМБАМИ ---");
            Console.WriteLine("1. Впорядкувати за кольором");
            Console.WriteLine("2. Впорядкувати за площею");
            Console.WriteLine("3. Впорядкувати за периметром");
            Console.WriteLine("4. Показати кількість квадратів");
            Console.WriteLine("5. Назад");

            string choice = Console.ReadLine();
            Console.WriteLine("\nРезультат:");

            switch (choice)
            {
                case "1":
                    foreach (var r in rombs.OrderBy(x => x.Color)) r.ShowInfo();
                    break;
                case "2":
                    foreach (var r in rombs.OrderBy(x => x.GetArea())) r.ShowInfo();
                    break;
                case "3":
                    foreach (var r in rombs.OrderBy(x => x.GetPerimeter())) r.ShowInfo();
                    break;
                case "4":
                    int count = rombs.Count(r => r.IsSquare());
                    Console.WriteLine($"Знайдено квадратів: {count}");
                    break;
                default: return;
            }
            Console.WriteLine("\nНатисніть будь-яку клавішу...");
            Console.ReadKey();
        }

        static void MenuAnimals(Animal[] animals)
        {
            Console.Clear();
            Console.WriteLine("--- ІЄРАРХІЯ ТВАРИН ---");
            Console.WriteLine("Виведення масиву, впорядкованого за типами об'єктів:\n");

            var sorted = animals.OrderBy(a => a.GetType().Name);
            foreach (var a in sorted)
            {
                a.Show();
            }

            Console.WriteLine("\nНатисніть будь-яку клавішу...");
            Console.ReadKey();
        }
    }
}

зроби декілька прикладів для кожного випадку 
