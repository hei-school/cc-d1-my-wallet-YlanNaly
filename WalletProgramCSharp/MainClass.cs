using System;
using System.Collections.Generic;
using System.IO;

public class WalletModel
{
    private Dictionary<string, double> wallet;
    private Dictionary<string, double> deps;
    private Dictionary<string, double> source;

    public WalletModel()
    {
        wallet = new Dictionary<string, double>();
        deps = new Dictionary<string, double>();
        source = new Dictionary<string, double>();
    }

    public void AddSource(string name, string nameSource, double value)
    {
        string key = $"{name}-{nameSource}";
        if (wallet.ContainsKey(name))
        {
            double actualValue = wallet[name];
            wallet[name] = actualValue + value;
        }
        else
        {
            wallet[name] = value;
        }
        source[key] = value;
        Console.WriteLine($"Ajouté {value} de {name} à votre portefeuille.");
    }

    public void AddExpense(string name, string nameExpense, double value)
    {
        string key = $"{name}-{nameExpense}";
        if (wallet.ContainsKey(name))
        {
            double actualValue = wallet[name];
            if (0.0 < value && value < actualValue)
            {
                wallet[name] = actualValue - value;
                deps[key] = value;
                Console.WriteLine($"Ajouté {value} de dépense {name} à votre portefeuille.");
            }
            else if (value < 0.0)
            {
                Console.WriteLine("Dépense 0 ariary ?");
            }
            else if (actualValue < value)
            {
                Console.WriteLine($"Trop peu pour acheter quoi que cela soit :\nLe solde : {actualValue}\nTon soit disant dépense : {value}");
            }
        }
    }

    public double GetAmountsForWallet(string name)
    {
        List<double> listAmounts = new List<double>();
        foreach (var pair in wallet)
        {
            if (pair.Key.StartsWith(name))
            {
                listAmounts.Add(pair.Value);
            }
        }
        wallet[name] = CalculateTotal(listAmounts);
        return wallet[name];
    }

    private double CalculateTotal(List<double> list)
    {
        double total = 0;
        foreach (double value in list)
        {
            total += value;
        }
        return total;
    }

    public void GetListExpense(string name)
    {
        List<double> listExpense = new List<double>();
        foreach (var pair in deps)
        {
            if (pair.Key.StartsWith(name))
            {
                listExpense.Add(pair.Value);
                Console.WriteLine("------------- ID -------------");
                Console.WriteLine(pair.Key);
                Console.WriteLine("---------- DEPENSES ----------");
                Console.WriteLine(pair.Value);
            }
        }
        Console.WriteLine("---------- TOTAL -------------");
        Console.WriteLine(listExpense.Count);
        Console.WriteLine("------------------------------");
    }

    public void GetListSource(string name)
    {
        List<double> listSource = new List<double>();
        foreach (var pair in source)
        {
            if (pair.Key.StartsWith(name))
            {
                listSource.Add(pair.Value);
                Console.WriteLine("------------- ID -------------");
                Console.WriteLine(pair.Key);
                Console.WriteLine("---------- REVENUES ----------");
                Console.WriteLine(pair.Value);
            }
        }
        Console.WriteLine("---------- TOTAL -------------");
        Console.WriteLine(listSource.Count);
        Console.WriteLine("------------------------------");
    }

    public void SetAmount(string value)
    {
        wallet[value] = 0.0;
    }
}

public class Action
{
    private Dictionary<string, WalletModel> wallet;
    private const string FILENAME = "wallet.json";

    public Action()
    {
        wallet = new Dictionary<string, WalletModel>();
        ChargeData();
    }

    private void ChargeData()
    {
        try
        {
            string jsonData = File.ReadAllText(FILENAME);
            wallet = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, WalletModel>>(jsonData);
        }
        catch (Exception e)
        {
            Console.WriteLine("Impossible de charger les données existantes.");
        }
    }

    private void SaveData()
    {
        try
        {
            string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(wallet);
            File.WriteAllText(FILENAME, jsonData);
        }
        catch (Exception e)
        {
            Console.WriteLine("Erreur lors de la sauvegarde des données.");
        }
    }

    public void CreateWallet(string name)
    {
        wallet[name] = new WalletModel();
        SaveData();
        Console.WriteLine($"Portefeuille créé pour {name}");
    }

    public void AddSource(string name, string source, double value)
    {
        WalletModel walletModel;
        if (wallet.TryGetValue(name, out walletModel))
        {
            walletModel.AddSource(name, source, value);
            SaveData();
        }
        else
        {
            Console.WriteLine($"Portefeuille introuvable pour {name}");
        }
    }

    public void Expenses(string name, string nameExpense, double value)
    {
        WalletModel walletModel;
        if (wallet.TryGetValue(name, out walletModel))
        {
            walletModel.AddExpense(name, nameExpense, value);
            SaveData();
        }
        else
        {
            Console.WriteLine($"Portefeuille introuvable pour {name}");
        }
    }

    public void ShowWalletModel(string name)
    {
        WalletModel walletModel;
        if (wallet.TryGetValue(name, out walletModel))
        {
            Console.WriteLine($"Votre compte est de : {walletModel.GetAmountsForWallet(name)}");
        }
        else
        {
            Console.WriteLine($"Portefeuille introuvable pour {name}");
        }
    }

    public void ShowListExpenses(string name)
    {
        WalletModel walletModel;
        if (wallet.TryGetValue(name, out walletModel))
        {
            walletModel.GetListExpense(name);
        }
        else
        {
            Console.WriteLine($"Portefeuille introuvable pour {name}");
        }
    }

    public void ShowListSource(string name)
    {
        WalletModel walletModel;
        if (wallet.TryGetValue(name, out walletModel))
        {
            walletModel.GetListSource(name);
        }
        else
        {
            Console.WriteLine($"Portefeuille introuvable pour {name}");
        }
    }

    public void ResetWallet(string name)
    {
        WalletModel walletModel;
        if (wallet.TryGetValue(name, out walletModel))
        {
            walletModel.SetAmount(name);
            SaveData();
            Console.WriteLine($"Portefeuille réinitialisé pour {name}");
        }
        else
        {
            Console.WriteLine($"Portefeuille introuvable pour {name}");
        }
    }
}

public class MainClass
{
    public static void Main(string[] args)
    {
        Action gestionPortefeuilles = new Action();
        bool action = true;

        while (action)
        {
            Console.WriteLine("\nMenu :");
            Console.WriteLine("1. Créer un portefeuille pour une personne");
            Console.WriteLine("2. Ajouter un source à un portefeuille");
            Console.WriteLine("3. Ajouter une dépense à un portefeuille");
            Console.WriteLine("4. Afficher le portefeuille d'une personne");
            Console.WriteLine("5. Afficher la liste des dépenses d'une personne");
            Console.WriteLine("6. Afficher la liste des revenus d'une personne");
            Console.WriteLine("7. Vider votre portefeuille");
            Console.WriteLine("8. Ranger votre portefeuille");
            Console.WriteLine("9. Quitter");

            Console.Write("Choix : ");
            int choix = Convert.ToInt32(Console.ReadLine());

            switch (choix)
            {
                case 1:
                    string namePerson = Console.ReadLine();
                    gestionPortefeuilles.CreateWallet(namePerson);
                    break;
                case 2:
                    string nameActifPerson = Console.ReadLine();
                    string nameSource = Console.ReadLine();
                    double montant = Convert.ToDouble(Console.ReadLine());
                    gestionPortefeuilles.AddSource(nameActifPerson, nameSource, montant);
                    break;
                case 3:
                    string name = Console.ReadLine();
                    string nameDeps = Console.ReadLine();
                    double deps = Convert.ToDouble(Console.ReadLine());
                    gestionPortefeuilles.Expenses(name, nameDeps, deps);
                    break;
                case 4:
                    string nameAffichage = Console.ReadLine();
                    gestionPortefeuilles.ShowWalletModel(nameAffichage);
                    break;
                case 5:
                    string nameListExpenses = Console.ReadLine();
                    gestionPortefeuilles.ShowListExpenses(nameListExpenses);
                    break;
                case 6:
                    string nameListSource = Console.ReadLine();
                    gestionPortefeuilles.ShowListSource(nameListSource);
                    break;
                case 7:
                    string reset = Console.ReadLine();
                    gestionPortefeuilles.ResetWallet(reset);
                    break;
                case 8:
                    action = false;
                    break;
                default:
                    Console.WriteLine("Choix invalide.");
                    break;
            }
        }

        Console.WriteLine("Programme terminé");
    }
}
