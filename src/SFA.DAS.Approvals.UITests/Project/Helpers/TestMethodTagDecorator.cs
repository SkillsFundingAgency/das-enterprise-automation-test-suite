using System.CodeDom;
using TechTalk.SpecFlow.Generator;
using TechTalk.SpecFlow.Generator.UnitTestConverter;

namespace SFA.DAS.Approvals.UITests.Project.Helpers
{
    public class TestMethodTagDecorator : ITestMethodTagDecorator
    {
        public static readonly string TAG_NAME = "donotexecuteinparallel";
        private readonly ITagFilterMatcher _tagFilterMatcher;

        public TestMethodTagDecorator(ITagFilterMatcher tagFilterMatcher) => _tagFilterMatcher = tagFilterMatcher;

        public bool CanDecorateFrom(string tagName, TestClassGenerationContext generationContext, CodeMemberMethod testMethod) => _tagFilterMatcher.Match(TAG_NAME, tagName);

        public void DecorateFrom(string tagName, TestClassGenerationContext generationContext, CodeMemberMethod testMethod) => testMethod.CustomAttributes.Add(new CodeAttributeDeclaration("NUnit.Framework.NonParallelizableAttribute"));

        public int Priority { get; }
        public bool RemoveProcessedTags { get; }
        public bool ApplyOtherDecoratorsForProcessedTags { get; }
    }
}
