using NUnit.Framework;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions;

[Binding]
public class CreateAccountPocSteps
{
    private readonly AccountCreationStepsHelper _accountCreationStepsHelper;
    private readonly ScenarioContext _context;
   
    public CreateAccountPocSteps(ScenarioContext context)
    {
        _context = context;
        _accountCreationStepsHelper = new AccountCreationStepsHelper(context);
    }

    [When(@"the User initiates Account creation using (.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
    public void WhenTheUserInitiatesAccountCreationUsingExcel(string testcase, string fname, string lname, string email, string password, string confirmpassword, string output, string checkdb)
    {
        RegisterUserAccount(new UserDetails(testcase, fname, lname, email, password, confirmpassword, output, checkdb));
    }

    [When(@"the User initiates Account creation using (valid|invalid) details and datahelper")]
    public void WhenTheUserInitiatesAccountCreationUsingDataHelper(string userdetails) => RegisterUserAccount((GetUserDetailsHelper.GetUserDetails(userdetails)));
    
    private void RegisterUserAccount(UserDetails data)
    {
        static string GetMessage(bool x) => x ? "User details not found in the db" : "Found user detailsin the db";

        _accountCreationStepsHelper.RegisterUserAccount(data);

        _context.Get<ObjectContext>().Set($"UserDetails{data.Email}", data);

        _ = new CheckRegistrationPage(_context, data.Output);

        var actual = new UsersSqlDataHelper(_context.Get<DbConfig>()).GetUserDetails(data.Email);

        var expected = bool.Parse(data.CheckDb);

        Assert.AreEqual(expected, !string.IsNullOrEmpty(actual), GetMessage(expected));
    }
}
