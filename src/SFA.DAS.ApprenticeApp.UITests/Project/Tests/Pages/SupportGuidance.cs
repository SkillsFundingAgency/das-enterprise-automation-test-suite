using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFA.DAS.ApprenticeApp.UITests.Project.Tests.Pages
{
    public class SupportGuidance
    {
        private static By YourRightsAsAnApprenticeLink => By.CssSelector("a.app-stack__link[href='/Support/Category/your-rights-as-an-apprentice']");
        private static By WhereToGetSupportLink => By.CssSelector("a.app-stack__link[href='/Support/Category/where-to-get-support']");
        private static By SupportForLearningDifficultyLink => By.CssSelector("a.app-stack__link[href='/Support/Category/where-to-get-support']");
        private static By SupportForCareExperiencedApprenticesLink => By.CssSelector("a.app-stack__link[href='/Support/Category/support-for-care-experienced-apprentices']");
        private static By EndPointAssessmentsLink => By.CssSelector("a.app-stack__link[href='/Support/Category/end-point-assessments-epas']");
        private static By OffTheJobTrainingLink => By.CssSelector("a.app-stack__link[href='/Support/Category/off-the-job-otj-training']");
        private static By ConnectAndNetworkWithOtherApprenticesLink => By.CssSelector("a.app-stack__link[href='/Support/Category/connect-and-network-with-other-apprentices']");
        private static By RolesAndResponsibilitiesLink => By.CssSelector("a.app-stack__link[href='/Support/Category/roles-and-responsibilities']");
        private static By GetStudentDiscountsLink => By.CssSelector("a.app-stack__link[href='/Support/Category/get-student-discounts']");
        private static By AfterYourApprenticeshipLink => By.CssSelector("a.app-stack__link[href='/Support/Category/after-your-apprenticeship']");
    }
}
