using NUnit.Framework.Constraints;
using SFA.DAS.FrameworkHelpers;
using System;
using System.Text.RegularExpressions;

public class EmployerUserDetails
{
    public string Email { get; set; }
    public string HashedId { get; set; }
}

public class LoggedInEmployerDetails
{
    private readonly ObjectContext _objectContext;

    public LoggedInEmployerDetails(ObjectContext objectContext)
    {
        _objectContext = objectContext;
    }

    public EmployerUserDetails? GetLoggedInEmployerUserDetails()
    {
        var details = _objectContext.Get("usercreds_0");

        if (string.IsNullOrEmpty(details))
        {
            _objectContext.SetDebugInformation("(usercred_0) object in ObjectContext is null or empty");
            return null;
        }

        var email = ExtractMatch(details, @"Email address:'([^']*)'");
        var hashedId = ExtractMatch(details, @"HashedId\s*:\s*'([^']*)'");

        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(hashedId))
        {
            _objectContext.SetDebugInformation("Employer email or Employer hashedId values in (usercred_0) object in ObjectContext are null or empty");
            return null;
        }

        return new EmployerUserDetails { Email = email, HashedId = hashedId };
    }

    private static string? ExtractMatch(string input, string pattern)
    {
        var match = Regex.Match(input, pattern);
        return match.Success ? match.Groups[1].Value : null;
    }
}
