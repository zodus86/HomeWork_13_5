﻿namespace HomeWork_13_5
{
    public class PhysicalPerson :  IPerson<Person>
    {
        public TypePersons TypePerson { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public ulong TelephonNumber { get; set; }

        /// <summary>
        /// Ковариантность к общему без наследования
        /// </summary>
        public Person GetPerson
        {
           get { return new Person($"{LastName} {FirstName}", TelephonNumber, TypePerson); } 
        }

        public PhysicalPerson(string lastName, string firstName, ulong telephonNumber)
        {
            if (telephonNumber.ToString().Length > 3)
                TelephonNumber = telephonNumber;
            else throw new BankPersonException("Очень короткий телефон");

            LastName = lastName;
            FirstName = firstName;
            TypePerson = TypePersons.Physical;
        }

    }
}
