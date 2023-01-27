using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator.Project;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.RAA.DataGenerator
{
    public class VacancyReferenceHelper
    {
        #region Helpers and Context
        private readonly ObjectContext _objectContext;
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        public VacancyReferenceHelper(PageInteractionHelper pageInteractionHelper, ObjectContext objectContext)
        {
            _objectContext = objectContext;
            _pageInteractionHelper = pageInteractionHelper;
        }

        public void SetVacancyReference(By vacancyReferenceNumber)
        {
            var referenceNumber = _pageInteractionHelper.GetText(vacancyReferenceNumber);

            _objectContext.SetVacancyReference(RegexHelper.GetVacancyReference(referenceNumber));
        }
    }
}
