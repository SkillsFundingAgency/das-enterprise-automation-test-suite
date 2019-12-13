using OpenQA.Selenium;
using SFA.DAS.FAA.UITests.Project;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.FAA.UITests.Helpers
{
    public class VacancyReferenceHelper
    {
        #region Helpers and Context
        private readonly RegexHelper _regexHelper;
        private readonly ObjectContext _objectContext;
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        public VacancyReferenceHelper(PageInteractionHelper pageInteractionHelper, ObjectContext objectContext, RegexHelper regexHelper)
        {
            _regexHelper = regexHelper;
            _objectContext = objectContext;
            _pageInteractionHelper = pageInteractionHelper;
        }

        public void SetVacancyReference(By vacancyReferenceNumber)
        {
            var referenceNumber = _pageInteractionHelper.GetText(vacancyReferenceNumber);

            _objectContext.SetVacancyReference(_regexHelper.GetVacancyReference(referenceNumber));
        }
    }
}
