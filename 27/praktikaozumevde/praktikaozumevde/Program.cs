using System.Reflection;




Console.WriteLine("zamani daxil edin");
int zaman = int.Parse(Console.ReadLine());
Ayveilyap(zaman);



static void Ayveilyap(int num)
{

if (num > 12)
    {
        int year=num/12;
         int ay=num%12;
        Console.WriteLine(year+"il  "+ay+"ay");

    }
else
    {
        Console.WriteLine(num+"ay");


    }


}