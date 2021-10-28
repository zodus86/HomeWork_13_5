using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_13_5
{
    public class Person
    {
        public Guid ID { get; set; }
        public string FullName { get; set; }
        public ulong TelephonNumber { get; set; }
        public TypePersons TypePerson { get; set; }

        public Person (string fullName, ulong telephonNumber, TypePersons typePersons)
        {
            if (telephonNumber.ToString().Length > 3)
                TelephonNumber = telephonNumber;
            else 
                throw new BankException("Очень короткий телефон", "Конструктор Person");

            FullName = fullName;
            TypePerson = typePersons;
        }
    }
}
