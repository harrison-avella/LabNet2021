using Lab.EF.Entities;
using Lab.EF.Logic;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.UI
{
    class Program
    {
        static void Main(string[] args)
        {


            RegionLogic regionLogic = new RegionLogic();

            var maximo = regionLogic.idMax();

            Console.WriteLine(maximo);

            Console.WriteLine(maximo);


        }
    }
}
