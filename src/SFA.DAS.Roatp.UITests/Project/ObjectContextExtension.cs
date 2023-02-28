using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Roatp.UITests.Project.Helpers;

namespace SFA.DAS.Roatp.UITests.Project;

public static class ObjectContextExtension
{
    #region Constants
    private const string CreateAccountCredsKey = "createAccountcredskey";
    private const string EmailKey = "emailkey";
    private const string PasswordKey = "passwordkey";
    private const string NewUkprnKey = "newukprnkey";
    private const string ApplicationReference = "applicationreference";
    private const string ApplicationRoute = "applicationroute";
    #endregion

    internal static void SetCreateAccountCreds(this ObjectContext objectContext, string email, string password) => objectContext.Set(CreateAccountCredsKey, $"Email : {email}, Password : {password}");
    public static void SetEmail(this ObjectContext objectContext, string email) => objectContext.Replace(EmailKey, email);
    public static void SetPassword(this ObjectContext objectContext, string password) => objectContext.Replace(PasswordKey, password);
    public static void SetNewUkprn(this ObjectContext objectContext, string NewUkprn) => objectContext.Replace(NewUkprnKey, NewUkprn);
    internal static void SetApplicationReference(this ObjectContext objectContext, string applicationReference) => objectContext.Replace(ApplicationReference, applicationReference);
    public static void SetApplicationRoute(this ObjectContext objectContext, ApplicationRoute applicationRoute) => objectContext.Replace(ApplicationRoute, applicationRoute);

    internal static string GetEmail(this ObjectContext objectContext) => objectContext.Get(EmailKey);
    internal static string GetPassword(this ObjectContext objectContext) => objectContext.Get(PasswordKey);
    public static string GetNewUkprn(this ObjectContext objectContext) => objectContext.Get(NewUkprnKey);
    internal static string GetApplicationReference(this ObjectContext objectContext) => objectContext.Get(ApplicationReference);
    public static ApplicationRoute GetApplicationRoute(this ObjectContext objectContext) => objectContext.Get<ApplicationRoute>(ApplicationRoute);
}
