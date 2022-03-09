
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow.Generator.Plugins;
using TechTalk.SpecFlow.Generator.UnitTestConverter;
using TechTalk.SpecFlow.Infrastructure;
using TechTalk.SpecFlow.UnitTestProvider;

[assembly: GeneratorPlugin(typeof(TestMethodTagGeneratorPlugin))]

namespace SFA.DAS.FrameworkHelpers
{
    public class TestMethodTagGeneratorPlugin : IGeneratorPlugin
    {
        public void Initialize(GeneratorPluginEvents generatorPluginEvents, 
            GeneratorPluginParameters generatorPluginParameters,
            UnitTestProviderConfiguration unitTestProviderConfiguration) 
            => generatorPluginEvents.RegisterDependencies += RegisterDependencies;

        private void RegisterDependencies(object sender, RegisterDependenciesEventArgs eventArgs) 
            => eventArgs.ObjectContainer.RegisterTypeAs<TestMethodTagDecorator, ITestMethodTagDecorator>(TestMethodTagDecorator.TAG_NAME);
    }
}
