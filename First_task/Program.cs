namespace First_task
{
    class Parent
    {
        int pole1;
        public Parent(int pole1)
        {
            this.pole1 = pole1;
        }
        public virtual void Print()
        {
            Console.WriteLine($"Площа аудиторії в кв м: {pole1}");
        }
        public virtual int Method()
        {
            return Convert.ToInt32(pole1 / 1.2);
        }
    }
    class Child1 : Parent
    {
        int pole2;

        public Child1(int pole1, int pole2) : base(pole1)
        {
            this.pole2 = pole2;
        }
        public override void Print() 
        {
            base.Print();
            Console.WriteLine($"Кількість ярусів: {pole2}");
        }
        public override int Method()
        {
            return base.Method() * pole2;
        }
    }
    class Child2 : Parent
    {
        int pole3;
        public Child2(int pole1, int pole3) : base(pole1)
        {
            this.pole3 = pole3;
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Кількість комп'ютерів: {pole3}");
        }
        public override int Method()
        {
            return pole3 - 1;
        }
    }
    internal class Program
    {
        public static void UsingMethodClass(Parent parent)
        {
            parent.Print();
            Console.WriteLine($"Кількість місць в аудиторії: {parent.Method()}");
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Parent parent;
            Random rand = new Random();
            int maxValForNext = 50;
            parent = new Parent(rand.Next(maxValForNext));
            UsingMethodClass(parent);
            parent = new Child1(rand.Next(maxValForNext), rand.Next(maxValForNext));
            UsingMethodClass(parent);
            parent = new Child2(rand.Next(maxValForNext), rand.Next(maxValForNext));
            UsingMethodClass(parent);
        }
    }
}