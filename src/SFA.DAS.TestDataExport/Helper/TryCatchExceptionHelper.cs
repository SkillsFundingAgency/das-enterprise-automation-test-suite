using SFA.DAS.FrameworkHelpers;
using System;

namespace SFA.DAS.TestDataExport.Helper
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
