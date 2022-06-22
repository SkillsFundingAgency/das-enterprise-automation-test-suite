using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
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
    
    [When(@"the User initiates Account creation using (valid|invalid) details")]
    public void WhenTheUserInitiatesAccountCreation(string userdetails) 
    {
        var data = GetUserDetailsHelper.GetUserDetails(userdetails);

        _accountCreationStepsHelper.RegisterUserAccount(data);

        if (userdetails == "valid") new ConfirmYourIdentityPage(_context, data.Email, data.Password);
        else if (userdetails == "invalid") new SetUpAsAUserPage(_context);
    } 
}
