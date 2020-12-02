using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ViewChangesPage : ApprovalsBasePage
    {
        protected override string PageTitle => "View changes";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By Description => By.CssSelector("p.govuk-body");
        private By CurrentDetailsCoumn => By.XPath("//th[contains(text(),' Current details')]");
        private By RequestedChangesCoumn => By.XPath("//th[contains(text(),'Requested changes')]");

        /*
        private By CurrentTrainingProvider => By.CssSelector("p.govuk-body");
        private By RequestedTrainingProvider => By.CssSelector("p.govuk-body");
        private By CurrentTrainingStartDate => By.CssSelector("p.govuk-body");
        private By RequestedTrainingStartDate => By.CssSelector("p.govuk-body");
        private By CurrentTrainingEndDate => By.CssSelector("p.govuk-body");
        private By RequestedTrainingEndDate => By.CssSelector("p.govuk-body");
        private By CurrentPrice => By.CssSelector("p.govuk-body");
        private By RequestedPrice => By.CssSelector("p.govuk-body");
        */


        public ViewChangesPage(ScenarioContext context) : base(context) => _context = context;

        public void GetDescription()
        { 
        
        }

        public Dictionary<string, string> GetDetails()
        {
            var changeDetails = new Dictionary<string, string>();

            changeDetails.Add("CurrentTrainingProvider", tableRowHelper.GetColumn("Training provider", CurrentDetailsCoumn).Text);
            changeDetails.Add("CurrentTrainingStartDate", "");
            changeDetails.Add("CurrentTrainingEndDate", "");
            changeDetails.Add("CurrentPrice", "");

            changeDetails.Add("RequestedTrainingProvider", tableRowHelper.GetColumn("Training provider", RequestedChangesCoumn).Text);
            changeDetails.Add("RequestedTrainingStartDate", "");
            changeDetails.Add("RequestedTrainingEndDate", "");
            changeDetails.Add("RequestedPrice", "");


            return changeDetails;
        }

    }
}
