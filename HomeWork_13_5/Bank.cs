using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace HomeWork_13_5
{
    /// <summary>
    /// Репозиторий банка клиентов (счета и контрагенты)
    /// </summary>
    class Bank
    {
        public Dictionary<BankAccount<Person>, Person> clients;
        public List<Person> persons;
        public List<BankAccount<Person>> bankAccounts;

        /// <summary>
        /// Добавить клиента
        /// </summary>
        /// <param name="bankAccount"></param>
        /// <param name="person"></param>
        public void AddClient(BankAccount<Person> bankAccount, Person person)
        {
            clients.Add(bankAccount, person);
        }

        /// <summary>
        /// Наполнить данными
        /// </summary>
        public void CreateBank()
        {
            Random random = new Random();

            BankAccount<Person> bankAccount;
            Person person;

            for (int i = 0; i < random.Next(1, 100); i++)
            {
                person = new LegalPeson($"OOO_{i}", 88000101100 + (ulong)i).GetPerson;
                bankAccount = new BankAccount<Person>(person, 10000_20000_20000_20000 + (ulong)i, TypeAccounts.Kt, random.Next(-1_000_000, 0));

                clients.Add(bankAccount, person);
                persons.Add(person);
                bankAccounts.Add(bankAccount);

            }

            for (int i = 0; i < random.Next(1, 100); i++)
            {
                person = new PhysicalPerson($"Фамилия_{i}", $"Имя_{i}", 98180101100 + (ulong)i).GetPerson;
                bankAccount = new BankAccount<Person>(person, 10000_10000_10000_10000 + (ulong)i, TypeAccounts.Dt, random.Next(0, 5_000_000));
                clients.Add(bankAccount, person);
                persons.Add(person);
                bankAccounts.Add(bankAccount);
            }
        }

        public Bank()
        {
            clients = new Dictionary<BankAccount<Person>, Person>();
            persons = new List<Person>();
            bankAccounts = new List<BankAccount<Person>>();
        }
    }
}
