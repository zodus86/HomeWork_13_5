namespace HomeWork_13_5
{
    /// <summary>
    /// исключения с Контрагентами
    /// </summary>
    public class BankPersonException : BankException
    {
        public BankPersonException(string msg) : base(msg) { }
    }
}