namespace HomeWork_13_5
{
    interface IAccount <in T>
        where T: Acc
    {
        void GetInfo(T args);
    }
}


