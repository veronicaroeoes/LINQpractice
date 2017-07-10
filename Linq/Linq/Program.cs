using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            var workers = new List<Workers>
            {
                new Workers{ Name = "Veronica", Age = 26, WorkPlaceID = 1},
                new Workers{ Name = "Pontus", Age = 25, WorkPlaceID = 2},
                new Workers{ Name = "Patrik", Age = 44, WorkPlaceID = 3},
                new Workers{ Name = "Sara", Age = 55, WorkPlaceID = 1},
                new Workers{ Name = "Rebecca", Age = 22, WorkPlaceID = 2},
                new Workers{ Name = "Greta", Age = 26, WorkPlaceID = 2}
            };
            var work = new List<Work>
            {
                new Work {CompanyName = "Academy", WorkPlaceID = 1},
                new Work {CompanyName = "PREL", WorkPlaceID = 2},
                new Work {CompanyName = "HPE", WorkPlaceID = 3}
            };

            var q1 = workers
                .Where(p => p.Age > 30)
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Age)
                .Select(p => p.Name);

            Console.WriteLine("Persons over 30");

            foreach (var item in q1)
                Console.WriteLine(item);

            Console.WriteLine();

            var q2 = workers
                .Count(p => p.Age < 30);

            Console.WriteLine($"Number of persons under 30 is {q2}");

            Console.WriteLine();

            var q3 = workers
                .Average(p => p.Age);

            Console.WriteLine($"Average age of workers is {q3}");

            Console.WriteLine();

            var q4 = workers
                .FirstOrDefault(p => p.Name == "Pontus");

            if (q4 != null)
                Console.WriteLine(q4);

            Console.WriteLine();

            var q5 = workers
                .Join(work, w => w.WorkPlaceID, wp => wp.WorkPlaceID, (w, wp) => $"{w.Name} {wp.CompanyName}");

            foreach (var item in q5)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            var q6 = work
                .GroupJoin(workers, wp => wp.WorkPlaceID, w => w.WorkPlaceID, (wp, works) => new
                {
                    WorkName = wp.CompanyName,
                    WorkersCount = works.Count()
                })
                .OrderByDescending(w => w.WorkersCount);

            foreach (var item in q6)
            {
                Console.WriteLine(item.WorkName + item.WorkersCount);
            }

            Console.WriteLine();

            var q7 = work

                .Join(workers, wp => wp.WorkPlaceID, w => w.WorkPlaceID, (wp, works) => new
                {
                    WorkName = wp.CompanyName,
                    WorkersName = works.WorkPlaceID()
                    workers.Select(w => w.WorkPlaceID == wp.WorkPlaceID)
                });

            foreach (var item in q7)
            {
                Console.WriteLine(item.ToString());
                
                //Console.Write(item.WorkersName.ToString());
            }



        }
    }
}
