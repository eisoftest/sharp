using System;
using System.Threading;
namespace mydelegates
{
    public delegate void MyTool(int rep, string id);

    public class Gunner
    {
        event MyTool Shot;

        public Gunner()
        {
            Shot += new MyTool(OnShot);
        }

        public void Shooting(int n, string x)
        {
            Shot(n, x);
        }

        void OnShot(int rep, string id)
        {
            for (int i = 0; i < rep; i++)
            {
                Console.WriteLine("{0} is shooting: {1}", id, DateTime.Now.ToString());
                Thread.Sleep(500);
            }
        }

    }



    public class MyClass
    {
        static void Main()
        {
            Console.WriteLine("\nStart...\n");

            Gunner g = new Gunner();
            Gunner h = new Gunner();
            g.Shooting(3, "Jim");
            h.Shooting(2, "Dan");

            Console.Write("\nEnd...");
            Console.ReadLine();
        }
    }

}
