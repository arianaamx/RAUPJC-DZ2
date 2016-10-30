using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_4_5_zadatak
{
    class Program
    {
        static void Main(string[] args)
        {
            var integers = new[] { 1, 2, 2, 2, 3, 3, 4, 5 };
            var brojceki = integers.GroupBy(x => x).Distinct().ToArray();
            var length = brojceki.Length;
            var strings = new string[length];

            Console.WriteLine("TRECI ZAD:");
            foreach (var i in brojceki)
            {
                var counted = i.Count();
                strings[i.Key-1] = $"Broj {i.Key-1} ponavlja se {counted} puta";
                Console.WriteLine(strings[i.Key-1]);
            }

            Console.WriteLine(" ");
            Console.WriteLine("CETVRTI ZAD: ");
            Example1();
            Example2();

            Console.WriteLine("PETI ZAD:");

            var universities = GetAllCroatianUniversities();

            var allCroatianStudents = universities.SelectMany(x => x.Students).Distinct().ToArray();
            Console.WriteLine("Svi Hrvatski Studenti:");
            foreach (var student in allCroatianStudents)
                Console.WriteLine(student.Name + "-" + student.Jmbag);

            var croatianStudentsOnMultipleUniversities = universities.SelectMany(t => t.Students)
                                                                       .GroupBy(x => x)
                                                                      .Where(y => y.Count() > 1)
                                                                      .Select(y => y.Key).ToArray();
            Console.WriteLine("Ucenici na vise fakulteta: ");
            foreach (var student in croatianStudentsOnMultipleUniversities)
                Console.WriteLine(student.Name + "-" + student.Jmbag);

            var studentsOnMaleOnlyUniversities = universities.Where(y => y.Students.All(x => x.Gender != Gender.Female))
                            .SelectMany(t => t.Students).Distinct().ToArray();
            Console.WriteLine("Samo muski faksevi : ");
            foreach (var student in studentsOnMaleOnlyUniversities)
                Console.WriteLine(student.Name + "-" + student.Jmbag);

            Console.ReadLine();
        }

        static void Example1()
        {
            var list = new List<Student>() { new Student(name: " Ivan ", jmbag: " 001234567 ") };
            var ivan = new Student(" Ivan ", jmbag: " 001234567 ");

            var anyIvanExists = list.Any(s => (bool)(s == ivan));
            Console.WriteLine(anyIvanExists);
        }

        static void Example2()
        {
            var list = new List<Student>()
            { new Student (" Ivan ", jmbag :" 001234567 ") ,
              new Student (" Ivan ", jmbag :" 001234567 ") };

            // 2 :(
            var distinctStudents = list.Distinct().Count();
            Console.WriteLine(distinctStudents);
        }

        static University[] GetAllCroatianUniversities()
        {
            var studentiFera = new Student[2] {new Student("Ariana", "19", Gender.Female),
                                               new Student("Lucija", "20", Gender.Female)};
            var studentiMedicine = new Student[3] {new Student ("Ivan", "21", Gender.Male),
                                                    new Student ("Ariana","19",Gender.Female),
                                                    new Student ("Ivanka", "20", Gender.Female)};
            var studentiEkonomije = new Student[2] {new Student ("Marko", "20", Gender.Male),
                                                    new Student ("Ivek", "19", Gender.Male)};

            var faksevi= new  University[3] { new University ("FER", studentiFera),
                                              new University ("Medicina", studentiMedicine),
                                              new University ("Ekonomija", studentiEkonomije)};
            return faksevi;
        }
            
      }
}
