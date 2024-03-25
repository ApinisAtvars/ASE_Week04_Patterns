
public interface IBeerRepository
{
    List<Beer> GetBeers();
}

public class BeerRepository : IBeerRepository
{
    public List<Beer> GetBeers()
    {
        List<Beer> allbeers = new List<Beer>();
        string[] lines = File.ReadAllLines("./Files/beers.csv");

        foreach (var line in lines)
        {
            var columns = line.Split(";");
            Beer beer = new Beer();
            beer.Number = int.Parse(columns[0].Trim());
            beer.Name = columns[1].Trim();
            beer.Brewery = columns[2].Trim();
            beer.Colour = columns[3].Trim();
            beer.Alcohol = decimal.Parse(columns[4].Trim());

            allbeers.Add(beer);
        }
        return allbeers;
    }
}