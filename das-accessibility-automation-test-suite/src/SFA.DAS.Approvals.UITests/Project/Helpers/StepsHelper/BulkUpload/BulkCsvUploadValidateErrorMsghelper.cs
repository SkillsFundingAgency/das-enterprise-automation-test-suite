using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.BulkUpload;

public class BulkCsvUploadValidateErrorMsghelper(ScenarioContext context)
{
    internal ProviderFileUploadValidationErrorsPage VerifyErrorMessage(string expectedMessage, string title = null)
    {
        expectedMessage = expectedMessage.RemoveSpace();

        string actualMessage = new ProviderFileUploadValidationErrorsPage(context).GetErrorMessage();

        int index = expectedMessage.Length < 80 ? expectedMessage.Length : 80;

        StringAssert.Contains(expectedMessage[..index], actualMessage, string.IsNullOrEmpty(title) ? string.Empty : $"Scenario : {title}");

        return new ProviderFileUploadValidationErrorsPage(context);
    }
}