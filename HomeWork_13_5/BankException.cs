using System;

namespace HomeWork_13_5
{
    /// <summary>
    /// оьщее для системы банка
    /// </summary>
    public class BankException : Exception
    {
        public BankException(string msg) : base (msg) { }
    }
}