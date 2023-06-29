using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.BulkUpload;

public class BulkCsvUploadValidateErrorMsghelper
{
    private readonly ScenarioContext _context;

    public BulkCsvUploadValidateErrorMsghelper(ScenarioContext context) => _context = context;

    internal ProviderFileUploadValidationErrorsPage VerifyErrorMessage(string expectedMessage, string title = null)
    {
        expectedMessage = expectedMessage.RemoveSpace();

        string actualMessage = new ProviderFileUploadValidationErrorsPage(_context).GetErrorMessage();

        int index = expectedMessage.Length < 80 ? expectedMessage.Length : 80;

        StringAssert.Contains(expectedMessage.Substring(0, index), actualMessage, string.IsNullOrEmpty(title) ? string.Empty : $"Scenario : {title}");

        return new ProviderFileUploadValidationErrorsPage(_context);
    }
}