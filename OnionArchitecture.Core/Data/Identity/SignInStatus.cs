namespace OnionArchitecture.Core.Data.Identity
{
    public enum SignInStatus
    {
        Success,
        LockedOut,
        RequiresTwoFactorAuthentication,
        Failure
    }
}