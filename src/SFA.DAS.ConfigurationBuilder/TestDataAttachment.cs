using TechTalk.SpecFlow;

namespace SFA.DAS.ConfigurationBuilder
{
    public class TestDataAttachment
    {
        private readonly ObjectContext _objectContext;

        public TestDataAttachment(ScenarioContext context) => _objectContext = context.Get<ObjectContext>();

        public void AddTestDataAttachment() => new FrameworkHelpers.TestAttachmentHelper().AddTestDataAttachment(_objectContext.GetDirectory(), _objectContext.GetAll());
    }
}