namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.StepDefinitions.Employer
{
    public abstract class AAN_E_BaseSteps : BaseSteps
    {
        protected readonly AANSqlHelper aANSqlHelper;

        public AAN_E_BaseSteps(ScenarioContext context) : base(context)
        {
            aANSqlHelper = context.Get<AANSqlHelper>();
        }
    }
}