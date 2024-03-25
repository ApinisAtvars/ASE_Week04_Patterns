public class BeerException : Exception
{
    public Exception WrongFieldname { get; set; }
    public Exception WrongValue { get; set; }

    public BeerException(Exception fieldNameException, Exception wrongValueException)
    {

    }
}