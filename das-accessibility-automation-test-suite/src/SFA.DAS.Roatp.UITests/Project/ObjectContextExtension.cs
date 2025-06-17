using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Roatp.UITests.Project.Helpers;

namespace SFA.DAS.Roatp.UITests.Project;

public static class ObjectContextExtension
{
    #region Constants
    private const string EmailKey = "emailkey";
    private const string SignInId = "passwordkey";
    private const string NewUkprnKey = "newukprnkey";
    private const string ApplicationReference = "applicationreference";
    private const string ApplicationRoute = "applicationroute";
    #endregion

    public static void SetEmail(this ObjectContext objectContext, string email) => objectContext.Replace(EmailKey, email);
    public static void SetSigninId(this ObjectContext objectContext, string signInId) => objectContext.Replace(SignInId, signInId);
    public static void SetNewUkprn(this ObjectContext objectContext, string NewUkprn) => objectContext.Replace(NewUkprnKey, NewUkprn);
    internal static void SetApplicationReference(this ObjectContext objectContext, string applicationReference) => objectContext.Replace(ApplicationReference, applicationReference);
    public static void SetApplicationRoute(this ObjectContext objectContext, ApplicationRoute applicationRoute) => objectContext.Replace(ApplicationRoute, applicationRoute);

    internal static string GetEmail(this ObjectContext objectContext) => objectContext.Get(EmailKey);
    internal static string GetSignInId(this ObjectContext objectContext) => objectContext.Get(SignInId);
    public static string GetNewUkprn(this ObjectContext objectContext) => objectContext.Get(NewUkprnKey);
    internal static string GetApplicationReference(this ObjectContext objectContext) => objectContext.Get(ApplicationReference);
    public static ApplicationRoute GetApplicationRoute(this ObjectContext objectContext) => objectContext.Get<ApplicationRoute>(ApplicationRoute);
}
