namespace App.Exceptions;

[Serializable]
public class NotExistException : Exception
{
    public NotExistException() { }
    public NotExistException(string message) : base(message) { }
    public NotExistException(string message, Exception inner) : base(message, inner) { }
    protected NotExistException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}
