using System;
using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages;

public class EmployerDetailsPage : AanBasePage
{
    protected override string PageTitle => "Check your employer's name and address";

    private By AddressFound = By.Id("AddressLine1");
    private By EmployerName = By.Id("EmployerName");
    public EmployerDetailsPage(ScenarioContext context) : base(context) { }

    public CurrentJobTitlePage EnterEmployersDetailsAndContinue()
    {
        formCompletionHelper.EnterText(EmployerName, aanDataHelpers.VenueName);
        formCompletionHelper.EnterText(AddressFound, aanDataHelpers.VenueName);
        Continue();
        return new CurrentJobTitlePage(context);
    }
}

    

