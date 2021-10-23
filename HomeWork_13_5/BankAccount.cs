namespace HomeWork_13_5
{
    /// <summary>
    /// Банковские счета
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BankAccount<T> : IAccount<Acc>
        where T: Person
    {
        public ulong Account { get; set; }
        public bool IOpen { get; set; }
        public TypeAccounts TypeAccount { get; set; }
        public Person Owner { get; set; }
        public decimal Value { get; set; }
        public BankAccount(Person person, ulong account, TypeAccounts typeAccounts, decimal value)
        {
            Account = account;
            IOpen = true;
            TypeAccount = typeAccounts;
            Owner = person;
            Value = value;
        }

        /// <summary>
        /// обобщение
        /// </summary>
        /// <param name="args"></param>
        public void GetInfo(Acc args)
        {
            args.Account = Account;
            args.Value = Value;
        }
    }
}


