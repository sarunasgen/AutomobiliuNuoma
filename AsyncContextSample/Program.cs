using System;

namespace AsyncContextSample;

public class Program
{
    public static void Main(string[] args)
    {
        Program p = new Program();
        p.DoActions();
        Console.ReadKey();
    }
    public async Task DoActions()
    {
        AsyncActions asyncActions = new AsyncActions();
        var numbersTask = asyncActions.PrintRandomNumbers();
        var negativeNumbersTask = asyncActions.PrintRandomNegativeNumbers();
        Task.WhenAll(numbersTask, negativeNumbersTask).ContinueWith(x => asyncActions.PrintRandomChar());
        bool hasWaited = asyncActions.WaitSeconds(10).Result;
    }
}
public class AsyncActions
{
    public async Task PrintRandomNumbers()
    {
        Random r = new Random();
        for(int i = 0; i < 50; i++)
        {
            await Task.Delay(100);
            i = i;
            Print("Random number: " + r.Next());
        }
        Console.WriteLine("Done");
    }
    public async Task PrintRandomNegativeNumbers()
    {
        Random r = new Random();
        for (int i = 0; i < 50; i++)
        {
            await Task.Delay(100);
            i = i;
           Print("Random negative number: " + r.Next(-1000000, 0));
        }
        Console.WriteLine("Done");
    }
    public async Task PrintRandomChar()
    {
        Random r = new Random();
        for (int i = 0; i < 100; i++)
        {
            await Task.Delay(500);
            i = i;
            Print((char)r.Next(1,128));
        }
        Console.WriteLine("Done");
    }
    public async void Print(string s)
    {
        Console.WriteLine(s);
    }
    public async void Print(char s)
    {
        Console.WriteLine(s);
    }
    public async Task<bool> WaitSeconds(int seconds)
    {
        await Task.Delay(seconds * 1000);
        return true;
    }
}