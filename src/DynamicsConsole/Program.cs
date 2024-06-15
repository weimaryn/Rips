// See https://aka.ms/new-console-template for more information
var accounts = await DynamicsClient.Accounts.GetCollectionAsync();

if (accounts != null )
    foreach (var item in accounts)
    {
        Console.WriteLine($"Account Number: {item.AccountNumber}");
        Console.WriteLine($"Name: {item.Name}");
        Console.WriteLine($"State Code: {item.StateCode}");
        Console.WriteLine($"Expiration: {item.Expiration}");
    }

