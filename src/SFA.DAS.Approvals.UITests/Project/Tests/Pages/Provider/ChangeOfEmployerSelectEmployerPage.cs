using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ChangeOfEmployerSelectEmployerPage : BasePage
    {
        private PageInteractionHelper _pageInteractionHelper;
        private FormCompletionHelper _formCompletionHelper;
        private readonly TableRowHelper _tableRowHelper;
        private readonly AgreementIdSqlHelper _agreementIdSqlHelper;
        private readonly ObjectContext _objectContext;
        private readonly ScenarioContext _context;
        private readonly string _newEmployerEmail;
        public ChangeOfEmployerSelectEmployerPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _tableRowHelper = context.Get<TableRowHelper>();
            _agreementIdSqlHelper = context.Get<AgreementIdSqlHelper>();
            _newEmployerEmail = context.GetUser<TransfersUser>().Username;
        }

        protected override string PageTitle { get; }

        public ChangeOfEmployerConfirmNewEmployerPage SelectNewEmployer()
        {
            string _newEmployerName = _context.GetTransfersConfig<TransfersConfig>().ReceiverOrganisationName;
            _newEmployerName = _newEmployerName.Substring(0, 10) + "%";
            string agreementId = _agreementIdSqlHelper.GetAgreementId(_newEmployerEmail, _newEmployerName);
            _tableRowHelper.SelectRowFromTable("Select", agreementId);
            
            return new ChangeOfEmployerConfirmNewEmployerPage(_context);
        }

    }
}
