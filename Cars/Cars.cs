using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public class Car
    {
        public int Year { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public double Displacement { get; set; }
        public int Cylinders { get; set; }
        public int City { get; set; }
        public int Highway { get; set; }
        public int Combined { get; set; }
       
    }

    public static class MyLinq
    {
        public static IEnumerable<T> ToX<T>(this IEnumerable<T> l)
        {
            return l.Where(y => y.Equals("SDFAD"));
        }    
    }
       
}