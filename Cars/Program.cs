using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Cars
{
    class Program
    {
        
        static void Main(string[] args)
        {
            const string filename = "fuel.csv";
            const string manufacturerFilename = "manufacturers.csv";
            IEnumerable<string> fuelsCsv = File.ReadLines(filename);
            IEnumerable<string> manufacturerCsv = File.ReadLines(manufacturerFilename);
            var cars = deserialize_csv(fuelsCsv, DataType.Cars).Cast<Car>();
            var manufacturers = deserialize_csv(manufacturerCsv, DataType.Manufacturers).Cast<Manufacturer>();
            
            var query =
                from car in cars
                join m in manufacturers
                    on car.Manufacturer equals m.Name
                orderby car.Combined descending, car.Name ascending
                select new
                {
                    m.Headquarters,
                    car.Name,
                    car.Combined
                };
    
            foreach (var item in query.Take(10))
            {
                Console.WriteLine(item);
            }

        }
        
        
        static List<string> give_me_the_cars_names(IEnumerable<Car> cars)
        {
            return cars.Select(c => c.Name).Distinct().ToList();
        }
        static string[] parse_csv_line(string line)
        {
            return line.Split(",");
        }

        static IEnumerable<object> deserialize_csv(IEnumerable<string> csvFile, DataType dataType )
        {
            return csvFile
                .Skip(dataType == DataType.Cars ? 1 : 0)
                .Select<object, object>(line =>
                {
                    string[] fields = parse_csv_line((string)line);
                    if (dataType == DataType.Cars)
                    {
                        return new Car()
                        {
                            Year = Int32.Parse(fields[0]),
                            Manufacturer = fields[1],
                            Name = fields[2],
                            Combined = Int32.Parse(fields[7])
                        };
                    }
                    else
                    {
                        return new Manufacturer()
                        {
                            Name = fields[0],
                            Headquarters = fields[1],
                            Year = Int32.Parse(fields[2])
                        };
                    }
                });
        }
    }
}
