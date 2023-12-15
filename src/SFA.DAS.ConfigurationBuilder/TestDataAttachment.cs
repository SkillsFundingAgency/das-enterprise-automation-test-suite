using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConfigurationBuilder
{
    public class TestDataAttachment(ScenarioContext context)
    {
        private readonly ObjectContext _objectContext = context.Get<ObjectContext>();

        public void AddTestDataAttachment() => FrameworkHelpers.TestAttachmentHelper.AddTestDataAttachment(_objectContext.GetDirectory(), _objectContext.GetAll());
    }
}