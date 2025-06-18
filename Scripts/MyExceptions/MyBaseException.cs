namespace IT_Academy_CSharp.MyExceptions;

public class MyBaseException : Exception
{
    public MyBaseException() : base("The application is suddenly closed due to invalid data.")
    {
    }

    public MyBaseException(string message) : base(message)
    {
        
    }
}