using System.Text;

public interface ISmartphoneRepository
{
    List<Smartphone> GetSmartphones();
    Smartphone GetSmartphoneById(byte id);
    void AddSmartphone(Smartphone smartphone);
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
        Smartphone s1 = GetSmartphones().Where(s => s.Id == id).SingleOrDefault();

        return s1;
    }

    public void AddSmartphone(Smartphone smartphone)
    {
        string[] phonedetails = new string[] {
            smartphone.Id.ToString(),
            smartphone.Brand,
            smartphone.Type,
            smartphone.ReleaseYear.ToString(),
            smartphone.StartPrice.ToString(),
            smartphone.OperatingSystem
        };



        using (StreamWriter sw = new StreamWriter("./Files/smartphones.csv", true))
        {
            sw.WriteLine(string.Join(",", phonedetails));
        }
    }
}