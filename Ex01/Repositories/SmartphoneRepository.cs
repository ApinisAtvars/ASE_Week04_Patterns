public interface ISmartphoneRepository
{
    List<Smartphone> GetSmartphones();
    Smartphone GetSmartphoneById(byte id);
    void AddSmartphone(string id, string brand, string type, string releaseyear, string startprice, string operatingsystem);
}

public class SmarthoneRepository : ISmartphoneRepository
{
    public List<Smartphone> GetSmartphones()
    {
        List<Smartphone> smartphones = new List<Smartphone>();
        string[] lines = File.ReadAllLines("./Files/smartphones.csv");
        lines = lines.Skip(1).ToArray();
        foreach (var line in lines)
        {
            var columns = line.Split(",");
            Smartphone smartphone = new Smartphone();
            smartphone.Id = byte.Parse(columns[0]);
            smartphone.Brand = columns[1].Trim();
            smartphone.Type = columns[2].Trim();
            smartphone.ReleaseYear = int.Parse(columns[3]);
            smartphone.StartPrice = int.Parse(columns[4]);
            smartphone.OperatingSystem = columns[5].Trim();
            smartphones.Add(smartphone);
        }
        return smartphones;
    }

    public Smartphone GetSmartphoneById(byte id)
    {
        Smartphone s1 = new Smartphone();
        foreach (Smartphone smartphone in GetSmartphones())
        {
            if (smartphone.Id == id)
            {
                s1 = smartphone;
            }
        }
        return s1;
    }

    public void AddSmartphone(string id, string brand, string type, string releaseyear, string startprice, string operatingsystem)
    {
        string[] phonedetails = new string[] {
            id,
            brand,
            type,
            releaseyear,
            startprice,
            operatingsystem
        };



        using (StreamWriter sw = new StreamWriter("./Files/smartphones.csv"))
        {
            foreach (string detail in phonedetails)
            {
                sw.WriteLine(string.Join(",", detail));
            }
        }
    }
}