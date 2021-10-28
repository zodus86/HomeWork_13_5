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
            if (account.ToString().Length == 20)
                Account = account;
            else
            {
                throw new BankException($"длина счете - {account.ToString().Length} отличается от заданой - 20",
                                        "Конструктор - BankAccount");
            }

            IOpen = true;
            TypeAccount = typeAccounts;
            Owner = person;
            Value = value;
        }
       
        /// <summary>
        /// узнать сумму счетов
        /// </summary>
        /// <param name="ac1"></param>
        /// <param name="ac2"></param>
        /// <returns></returns>
        public static decimal operator +(BankAccount<T> ac1, BankAccount<T> ac2)
        {
            return (ac1.Value + ac2.Value);
        }

        /// <summary>
        /// установка акаунта c проверкой на длину
        /// </summary>
        /// <param name="account"></param>
        public void SetAccount(ulong account)
        {
            if (account.ToString().Length == 20)
                Account = account;
            else
            {
                throw new BankException($"длина счете - {account.ToString().Length} отличается от заданой - 20",
                "метод - SetAccount");
            }
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


