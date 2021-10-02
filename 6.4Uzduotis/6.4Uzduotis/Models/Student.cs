using System;
using _6._4Uzduotis.Models;
using System.Linq;
using System.Threading.Tasks;

namespace _6._4Uzduotis.Models
{
    public class Student
    {
       

        public Student(string name, string surname, DateTime birthDay, string documentId)
        {
            Name = name;
            Surname = surname;
            BirthDay = birthDay;
            DocumentId = documentId;
            Age = DateTime.Now.Year - birthDay.Year;

        }

        
        

        public string Name { get; }
        public string Surname { get; }

        public DateTime BirthDay { get; }

        public string DocumentId { get; }

        public int Age { get; }

        public string GetInformation()
        {
            return $"{Name} {Surname} {BirthDay.ToString("yyyy-MM-dd")} {DocumentId} {Age}  ";




        }
    }
}
        
    
        



   



