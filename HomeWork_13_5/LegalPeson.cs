namespace HomeWork_13_5
{
    public class LegalPeson : IPerson<Person>
    {
        public ulong TelephonNumber { get; set; }
        public TypePersons TypePerson { get; set; }
        public string Name { get; set; }
        public LegalPeson(string name, ulong telephonNumber)
        {
            Name = name;
            TypePerson = TypePersons.Legal;
            TelephonNumber = telephonNumber;
        }

        /// <summary>
        /// ковариантность без наследования.
        /// </summary>
        public Person GetPerson 
        { get {  return new Person(Name, TelephonNumber, TypePerson); }  }
    }
}
