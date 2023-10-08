using System.Reflection.Emit;

namespace Second_task
{
    class Parent
    {
        protected int pole1, pole2, pole3;
        public Parent()
        {
            
        }
        public Parent(int pole1, int  pole2, int pole3)
        {
            this.pole1 = pole1;
            this.pole2 = pole2;
            this.pole3 = pole3;
        }
        public void Print()
        {
            Console.WriteLine($"a={pole1} b={pole2} c={pole3}");
        }
        public int Method1()
        {
            return pole1 * pole2 * pole3;
        }
        public int Method2()
        {
            return 2*(pole1*pole2+pole1*pole3+pole2*pole3);
        }
    }
    class Child:Parent
    {
        public Child(int pole)
        {
            base.pole1 = pole;
            base.pole2 = pole;
            base.pole3 = pole;
        }
        public double Method3()
        {
            return (4 / 3) * (Math.PI * Math.Pow(pole1 / 2, 3));
        }
        public double Method4() 
        {
            return 4 * Math.PI * Math.Pow(pole1 / 2, 2);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Random rand = new Random();
            int maxValForRand = 50;
            bool cubeWas = false;
            for (int i = 0; i < 5;)
            {
                int pole1 = rand.Next(1, maxValForRand), pole2 = rand.Next(1, maxValForRand), pole3 = rand.Next(1, maxValForRand);
                if (pole1 == pole2 && pole2 == pole3)
                {
                    Child child = new Child(pole1);
                    child.Print();
                    Console.WriteLine($"Куб: об'єм={child.Method1()}; площа повної поверхні={child.Method2()}");
                    Console.WriteLine($"Вписана куля: об'єм={child.Method3():F2}; площа повної поверхні={child.Method4():F2}");
                    Console.WriteLine();
                    cubeWas = true;
                    i++;
                }
                else if(cubeWas)
                {
                    Parent parent = new Parent(pole1,pole2,pole3);
                    parent.Print();
                    Console.WriteLine($"Паралелепіпед: об'єм={parent.Method1()}; площа повної поверхні={parent.Method2()}");
                    Console.WriteLine();
                    i++;
                }
            }
        }
    }
}