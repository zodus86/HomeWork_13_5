using System;

namespace HomeWork_13_5
{
    /// <summary>
    /// исключения банка
    /// </summary>
    public class BankException : Exception
    {
        public string Method;
        /// <summary>
        /// исключения внутри банковской системы
        /// </summary>
        /// <param name="msg">Сообщения</param>
        /// <param name="method">Метод вызвавшыи исключения</param>
        public BankException(string msg, string method) : base (msg) 
        {
            Method = method;
        }
    }
}