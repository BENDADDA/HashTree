using System;
using System.Collections.Generic;
using System.Linq;
using System.Matlab;
using System.Runtime.CompilerServices;
using System.Text;
using System.Collections;
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
            hashTree.Add(0, "NULL");
            hashTree.Add(10, "Claire");
            hashTree.Add(92, "Scailare");
            hashTree.Add(389, "Jimes");
            hashTree.Add(-402, "Goodwin");
           
            foreach (var pair in hashTree)
            {
                Console.WriteLine(pair);
            }
            string str;
            hashTree.TryGetValue(2000, out str);
            Console.WriteLine("value:"+str);
           
            Dictionary<int, string> d = new Dictionary<int, string>();
            Console.WriteLine(d);
          
            Console.Write("\nPress any key to continue . . . ");
            Console.ReadKey();
        }
    }
}
