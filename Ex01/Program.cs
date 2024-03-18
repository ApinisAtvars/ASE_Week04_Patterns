int choice = -1;
var repo = new SmarthoneRepository();
var SmartphoneService = new SmartphoneService(repo);


while (choice != 4)
{
    Console.WriteLine("MENU:\n1.List all smartphones.\n2.Search for smartphones by brand or type\n3.Add a new smartphone to the catalog\n4.Exit the application");
    choice = int.Parse(Console.ReadLine());
    switch (choice)
    {
        case 1:
            List<Smartphone> allsmartphones = SmartphoneService.ListAllSmartphones();
            foreach (Smartphone smartphone1 in allsmartphones)
            {
                Console.WriteLine($"Brand: {smartphone1.Brand}   Model: {smartphone1.Type}");
            }
            break;
        case 2:
            Console.WriteLine("Do you want to seach by Brand(b) or Type(t)?");
            string brandortype = Console.ReadLine();
            allsmartphones = SmartphoneService.ListAllSmartphones();
            switch (brandortype)
            {
                case "b":
                    Console.WriteLine("Enter the brand name:");
                    string brandname = Console.ReadLine();
                    List<Smartphone> smartphones = SmartphoneService.SearchByBrand(brandname, allsmartphones);
                    foreach (Smartphone smartphone2 in smartphones)
                    {
                        Console.WriteLine($"Brand: {smartphone2.Brand}   Model: {smartphone2.Type}");
                    }
                    break;

                case "t":
                    Console.WriteLine("Enter the type:");
                    string type = Console.ReadLine();
                    List<Smartphone> smartphones1 = SmartphoneService.SearchByType(type, allsmartphones);
                    foreach (Smartphone smartphone3 in smartphones1)
                    {
                        Console.WriteLine($"Brand: {smartphone3.Brand}   Model: {smartphone3.Type}");
                    }
                    break;
            }
            break;
        case 3:
            Console.WriteLine("Enter a brand");
            string brand = Console.ReadLine();
            Console.WriteLine("Enter the type");
            string type2 = Console.ReadLine();
            Console.WriteLine("Enter the release year");
            int releaseyear = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the start price");
            int startprice = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the OS");
            string os = Console.ReadLine();
            Smartphone smartphone = new Smartphone()
            {
                Brand = brand,
                Type = type2,
                ReleaseYear = releaseyear,
                StartPrice = startprice,
                OperatingSystem = os
            };

            SmartphoneService.AddSmartphone(smartphone);
            break;


    }
}

