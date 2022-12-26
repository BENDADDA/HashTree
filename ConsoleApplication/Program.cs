using System;
using System.Collections.Generic;
using System.Linq;
using System.Matlab;
using System.Text;
namespace ConsoleApplication
{
    class Program
    {
       
        static void Main(string[] args)
        {
            HashTree<int, string> hashTree = new HashTree<int, string>();   
            hashTree.Add(3, "Ben");
            hashTree.Add(281, "Mohammed");
            hashTree.Add(21, "Malik");
            hashTree.Add(7, "Benaouda");
            hashTree.Add(23, "Jack");
            hashTree.Add(220, "Yassine");
            hashTree.Add(2000, "Bendadda");
            hashTree.Add(-39,"Chareli");
            hashTree.Add(500, "Yoasaffe");
            hashTree.Add(19, "Julliet");
            hashTree.Add(10, "Claire");
            hashTree.Add(92, "Scailare");
            hashTree.Add(389, "Jimes");
            hashTree.Add(-402, "Goodwin");     
            Console.WriteLine("Count:"+hashTree.Count);
            Console.WriteLine("Value:"+hashTree.GetValue(7));
            Console.Write("\nPress any key to continue . . . ");
            Console.ReadKey();
        }
    }
}
