namespace DynamicsClient;

public static class Accounts
{
    public static Task<List<Account>?> GetCollectionAsync() =>
        HttpOperations.GetCollectionAsync<Account>("accounts", "$select=new_nit,name,new_vencesuscripcion,statecode");
}