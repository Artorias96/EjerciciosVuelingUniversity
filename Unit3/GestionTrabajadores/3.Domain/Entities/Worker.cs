using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTrabajadores
{
    public class Worker
    {

        public static int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime LeavingDate { get; set; }

        public Worker(string name, string surname, DateTime birthday)
        {
            Id++;
            Name = name;
            Surname = surname;
            BirthDate = birthday;
        }

        public virtual void ShowValues()
        {
            Console.WriteLine($"Worker Name: {Name}");
            Console.WriteLine($"Surname: {Surname}");
            Console.WriteLine($"BirthDay {BirthDate}");
        }

    }
}
