using System.Data;

public class Beer
{
    public int Number
    {
        get
        {
            return Number;
        }
        set
        {
            if (value.GetType() == typeof(int))
            {
                Number = value;
            }
            else
            {
                throw new InvalidDataException();
            }
        }
    }
    public string Name
    {
        get
        {
            return Name;
        }
        set
        {
            if (value.GetType() == typeof(string))
            {
                Name = value;
            }
            else if (value == null)
            {
                throw new NoNullAllowedException();
            }
            else
            {
                throw new InvalidDataException();
            }
        }
    }
    public string Brewery
    {
        get
        {
            return Brewery;
        }
        set
        {
            if (value.GetType() == typeof(string))
            {
                Brewery = value;
            }
            else if (value == null)
            {
                throw new NoNullAllowedException();
            }
            else
            {
                throw new InvalidDataException();
            }
        }
    }
    public string Colour
    {
        get
        {
            return Colour;
        }
        set
        {
            if (value.GetType() == typeof(string))
            {
                Colour = value;
            }
            else if (value == null)
            {
                throw new NoNullAllowedException();
            }
            else
            {
                throw new InvalidDataException();
            }
        }
    }
    public decimal Alcohol
    {
        get
        {
            return Alcohol;
        }
        set
        {
            if (value.GetType() == typeof(decimal))
            {
                Alcohol = value;
            }
            else
            {
                throw new InvalidDataException();
            }
        }
    }


}