using System;
using System.Threading.Tasks.Dataflow;
class Program
{
    static double Average(int [] values)
    {
        double sum = 0;
        foreach(int n in values)
        {
            sum += n;
        }
        return sum/values.Length;
    }
    static double Leibniz(int count = 200)
    {
        double sum = 0;
        for(double i = 0; i < count; i++)
        {
            sum += 1/(i*2+1)*(i%2 == 0 ? 1 : -1);
        }
        return sum*4;
    }
    public static int CountIncrements(double rate)
    {
        double iniziale = 1000000;
        int i=0;
        while(iniziale <= 2000000)
        {
            i++;
            iniziale += iniziale*rate;
        }
        return i;
    }
}