namespace HomeWork_13_5
{
    /// <summary>
    /// исключения с Счетами в банке
    /// </summary>
    public class BankAccountException : BankException
    {
        public BankAccountException(string msg) : base(msg) { }
    }
}