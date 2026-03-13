using System;
using System.Collections.Generic;
using System.Linq;

namespace LabWork3
{
    class Romb
    {
        protected int a;
        protected int d1;
        protected int c;

        public Romb(int side, int diagonal, int color)
        {
            a = side;
            d1 = diagonal;
            c = color;
        }

        ~Romb()
        {
        }

        public int Side 
        { 
            get { return a; } 
            set { a = value; } 
        }

        public int Diagonal 
        { 
            get { return d1; } 
            set { d1 = value; } 
        }

        public int Color 
        { 
            get { return c; } 
        }

        public void ShowLengths()
        {
            Console.WriteLine($"Сторона: {a}, Діагональ: {d1}, Колір: {c}");
        }

        public int GetPerimeter() 
        { 
            return 4 * a; 
        }

        public double GetArea()
        {
            double halfD1 = d1 / 2.0;
            if (halfD1 >= a) return 0;
            double d2 = 2 * Math.Sqrt(Math.Pow(a, 2) - Math.Pow(halfD1, 2));
            return (d1 * d2) / 2.0;
        }

        public bool IsSquare()
        {
            return Math.Abs(d1 - a * Math.Sqrt(2)) < 0.1;
        }
    }

    abstract class Animal
    {
        public string Name;
        public Animal(string name) { Name = name; }
        public virtual void Show() { Console.Write($"[{this.GetType().Name}] {Name}"); }
    }

    class Mammal : Animal
    {
        public Mammal(string name) : base(name) { }
        public override void Show() { base.Show(); Console.WriteLine(" - Ссавець"); }
    }

    class Bird : Animal
    {
        public Bird(string name) : base(name) { }
        public override void Show() { base.Show(); Console.WriteLine(" - Птах"); }
    }

    class Artiodactyl : Mammal
    {
        public Artiodactyl(string name) : base(name) { }
        public override void Show() { base.Show(); Console.WriteLine(" -> Парнокопитне"); }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<Romb> rombs = new List<Romb> {
                new Romb(10, 14, 2),
                new Romb(5, 7, 1),
                new Romb(10, 10, 3)
            };

            Animal[] animals = {
                new Bird("Орел"),
                new Artiodactyl("Олень"),
                new Mammal("Тигр"),
                new Artiodactyl("Зубр")
            };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Ромби");
                Console.WriteLine("2. Тварини");
                Console.WriteLine("0. Вихід");
                
                string choice = Console.ReadLine() ?? "";
                if (choice == "1") MenuRomb(rombs);
                else if (choice == "2") MenuAnimals(animals);
                else if (choice == "0") break;
            }
        }

        static void MenuRomb(List<Romb> rombs)
        {
            Console.Clear();
            Console.WriteLine("Впорядковано за кольором:");
            foreach (var r in rombs.OrderBy(x => x.Color)) r.ShowLengths();

            Console.WriteLine("\nВпорядковано за площею:");
            foreach (var r in rombs.OrderBy(x => x.GetArea())) 
                Console.WriteLine($"S: {r.GetArea():F2} (Колір: {r.Color})");

            Console.WriteLine("\nВпорядковано за периметром:");
            foreach (var r in rombs.OrderBy(x => x.GetPerimeter())) 
                Console.WriteLine($"P: {r.GetPerimeter()} (Колір: {r.Color})");

            Console.WriteLine($"\nКількість квадратів: {rombs.Count(r => r.IsSquare())}");
            Console.ReadLine();
        }

        static void MenuAnimals(Animal[] animals)
        {
            Console.Clear();
            var sorted = animals.OrderBy(a => a.GetType().Name);
            foreach (var a in sorted) a.Show();
            Console.ReadLine();
        }
    }
}
