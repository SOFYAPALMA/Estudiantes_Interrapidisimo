namespace Commun
{
    public interface ITokenClaimsService
    {
        Task<string> GetTokenAsync(string userName, string app, List<string> roles);
    }
}
