using System;
using testBTBD.Db;

namespace testBTBD
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var relation = new Relations();
            
            relation.StartRelationTransaction();
            relation.LogAllPersonName();
            
            Console.ReadKey();
        }
    }
}