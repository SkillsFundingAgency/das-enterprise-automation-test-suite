//using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFA.DAS.SupportConsole.UITests.Project.Helpers
{
    public class EmployerStepsHelper : EmployerHomePageStepsHelper
    {
        private readonly ObjectContext _objectContext;
        private readonly ScenarioContext _context;
        private readonly EmployerHomePageStepsHelper _employerHomePageStepsHelper;
        private readonly EmployerHomePageStepsHelper _homePageStepsHelper;


        public EmployerStepsHelper(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            _employerHomePageStepsHelper = new EmployerHomePageStepsHelper(_context);
        }
    }
}
