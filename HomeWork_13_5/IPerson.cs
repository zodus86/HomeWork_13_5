namespace HomeWork_13_5
{
    interface IPerson<out T>
        where T:Person
    {
        T GetPerson { get; }
    }
}
