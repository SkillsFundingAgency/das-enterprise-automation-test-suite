using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.TestDataExport;
using System;

namespace SFA.DAS.UI.Framework.TestSupport
{
    public class TryCatchExceptionHelper
    {
        private readonly ObjectContext _objectContext;

        public TryCatchExceptionHelper(ObjectContext objectContext) => _objectContext = objectContext;

        public void AfterScenarioException(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception ex)
            {
                _objectContext.SetAfterScenarioException(ex);
            }
        }
    }
}
