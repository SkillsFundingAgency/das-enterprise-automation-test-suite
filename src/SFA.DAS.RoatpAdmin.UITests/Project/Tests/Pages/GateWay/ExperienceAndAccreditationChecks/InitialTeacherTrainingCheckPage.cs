using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.ExperienceAndAccreditationChecks
{
    public class InitialTeacherTrainingCheckPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Initial teacher training (ITT) check";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public InitialTeacherTrainingCheckPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
    }
}
