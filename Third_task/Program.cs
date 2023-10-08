using System.Runtime.InteropServices;

namespace Third_task
{
    class Parent
    {
        string pole1;
        uint pole2;
        public Parent()
        {
            
        }
        public Parent(string pole1,uint pole2)
        {
            this.pole1 = pole1;
            this.pole2 = pole2;
        }
        public virtual void Print()
        {
            Console.WriteLine($"{pole1} народився(-лася) в {pole2} році");
        }
        public int Method1()
        {
            return DateTime.Now.Year - (int)pole2;
        }
    }
    class Child:Parent
    {
        double pole3;
        public Child(string pole1,uint pole2,double pole3):base(pole1,pole2)
        {
            this.pole3 = pole3;
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Cередній бал за сесію: {pole3:F2}");
        }
        public int Method2()
        {
            if(pole3 >= 4.5 )
            {
                return 1600;
            }
            else if(pole3 >= 3)
            {
                return 1300;
            }
            else
            {
                return 0;
            }
        }
    }
    internal class Program
    {
        internal static void MethodForInput(out string name, out uint yearBirth)
        {
            Console.Write("Ім'я для екземпляру: ");
            name = Console.ReadLine();
            Console.Write("Дата народження для екземпляру: ");
            yearBirth = Convert.ToUInt32(Console.ReadLine());
            if(DateTime.Now.Year < yearBirth)
            {
                throw new Exception("Некоректно введений рік народження!");
            }
        }
        internal static void MethodForOutput(Parent parent)
        {
            parent.Print();
            Console.WriteLine($"Вік: {parent.Method1()}");
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;
            string name;
            uint yearBirth;
            double avarScore;
            try
            {
                MethodForInput(out name, out yearBirth);
                Parent parent = new Parent(name, yearBirth);
                MethodForOutput(parent);
                Console.WriteLine();
                MethodForInput(out name, out yearBirth);
                Console.Write("Середній бал для екземпляру Child: ");
                avarScore = Convert.ToDouble(Console.ReadLine());
                if (avarScore < 0)
                {
                    throw new Exception("Бал не може бути від'ємним!");
                }
                Child child = new Child(name, yearBirth, avarScore);
                MethodForOutput(child);
                Console.WriteLine($"Стипендія: {child.Method2()}");
            }
            catch(Exception e) when (e is OverflowException || e is FormatException) 
            {
                Console.WriteLine("Помилка: некоректно введене значення!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Помилка: {e.Message}");
            }
        }
    }
}