using System;
using System.Collections.Generic;

namespace SortingHat
{
    class Program
    {
        static void Main(string[] args)
        {
            SortingHat sort = Input.ParseFile("C:\\Users\\UncleDad\\Desktop\\tp11-guy-noe.djoufaing-nzumgueng\\acdc_ranks.in");
            sort.ProcessAssignments();
            Output.SaveAssignments(sort, "C:\\Users\\UncleDad\\Desktop\\tp11-guy-noe.djoufaing-nzumgueng\\acdc_ranks2.in");
        }
    }
}