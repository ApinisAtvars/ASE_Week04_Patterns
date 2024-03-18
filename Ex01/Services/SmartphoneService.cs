public interface ISmartphoneService
{
    List<Smartphone> ListAllSmartphones();
    List<Smartphone> SearchByType(string type, List<Smartphone> smartphones);
    List<Smartphone> SearchByBrand(string brand, List<Smartphone> smartphones);
    void AddSmartphone(Smartphone smartphone);
}

public class SmartphoneService : ISmartphoneService
{
    private ISmartphoneRepository _smartphoneRepo;

    public SmartphoneService(ISmartphoneRepository smartphoneRepository)
    {
        this._smartphoneRepo = smartphoneRepository;
    }

    public List<Smartphone> ListAllSmartphones()
    {
        return _smartphoneRepo.GetSmartphones();
    }

    public List<Smartphone> SearchByType(string type, List<Smartphone> smartphones)
    {
        List<Smartphone> result = new List<Smartphone>();

        foreach (Smartphone smartphone in smartphones)
        {
            if (smartphone.Type == type)
            {
                result.Add(smartphone);
            }
        }

        return result;
    }

    public List<Smartphone> SearchByBrand(string brand, List<Smartphone> smartphones)
    {
        List<Smartphone> result = new List<Smartphone>();

        foreach (Smartphone smartphone in smartphones)
        {
            if (smartphone.Brand == brand)
            {
                result.Add(smartphone);
            }
        }

        return result;
    }

    public void AddSmartphone(Smartphone smartphone)
    {
        _smartphoneRepo.AddSmartphone(smartphone);
    }
}