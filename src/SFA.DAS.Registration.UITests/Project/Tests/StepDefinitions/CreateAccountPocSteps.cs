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

    [When(@"the User initiates Account creation using (.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
    public void WhenTheUserInitiatesAccountCreationUsingExcel(string testcase, string fname, string lname, string email, string password, string confirmpassword, string output)
    {
        RegisterUserAccount(new UserDetails(testcase, fname, lname, email, password, confirmpassword, output));
    }


    [When(@"the User initiates Account creation using (valid|invalid) details and datahelper")]
    public void WhenTheUserInitiatesAccountCreationUsingDataHelper(string userdetails) => RegisterUserAccount((GetUserDetailsHelper.GetUserDetails(userdetails)));
    
    private void RegisterUserAccount(UserDetails data)
    {
        _accountCreationStepsHelper.RegisterUserAccount(data);

        _context.Get<ObjectContext>().Set($"UserDetails{data.Email}", data);

        _ = new CheckRegistrationPage(_context, data.Output);
    }
}
