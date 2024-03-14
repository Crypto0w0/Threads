using System.ComponentModel;
using System.Threading;

static class Program
{
    static int start;
    static int end;
    static void Init()
    {
        try
        {
            start = Convert.ToInt32(Console.ReadLine());
        }
        catch (TypeInitializationException)
        {
            start = 0;
        }
        try
        {
            end = Convert.ToInt32(Console.ReadLine());
        }
        catch (TypeInitializationException)
        {
            end = -1;
        }
    }
    
    static Thread t1 = new Thread(() => GenNum(start, end));
    
    static void Main()
    {
        Init();
        t1.Start();
        while (t1.IsAlive)
        {
            string c = Console.ReadLine();
            if (c == "s")
            {
                t1.Abort();
            }
        }
    }
    static void GenNum(int s, int e)
    {
        int n = 0;
        if (e == -1)
        {
            while(true)
            {
                Console.WriteLine(n);
                n++;
            }
        }
        if (s == 0)
        {
            for (int i = s; i <= e; i++)
            {
                Console.WriteLine(i);
            }
        }
        t1.Abort();
    }
}