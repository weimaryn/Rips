namespace DynamicsClient;

public static class Accounts
{
    public static Task<List<Account>?> GetCollectionAsync() 
    {
        HttpOperations http = new();
        return http.GetCollectionAsync<Account>("accounts", "$select=new_nit,name,new_vencesuscripcion,statecode");
    }
}
