using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using TestContext = NUnit.Framework.TestContext;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    internal sealed class MyInterestsPage : BasePage
    {
        protected override string PageTitle => "MY INTERESTS";
        protected override By PageHeader => _pageTitle;

        #region Constants
        private const string ExpectedIndustry1Name = "AGRICULTURE, ENVIRONMENT AND ANIMAL CARE";
        private const string ExpectedIndustry1Description = "Want to work outside, work with animals or do you just feel passionate about working for the environment? Here you go.";
        private const string ExpectedIndustry2Name = "BUSINESS AND ADMINISTRATION";
        private const string ExpectedIndustry2Description = "Where could a business-centric apprenticeship take you? Manager? CEO? Check out the current opportunities and see if you could go global.";
        private const string ExpectedIndustry3Name = "CARE SERVICES";
        private const string ExpectedIndustry3Description = "Care service apprentices are making a real difference in their local communities. Every day, they’re helping vulnerable children, young people, adults and the elderly, across a range of different community care and support services.";
        private const string ExpectedIndustry4Name = "CATERING AND HOSPITALITY";
        private const string ExpectedIndustry4Description = "Are you fascinated by cooking? Perhaps you love working with food and drink? Or maybe ‘front of house’ or customer service are more your thing. Let’s find out.";
        private const string ExpectedIndustry5Name = "CONSTRUCTION";
        private const string ExpectedIndustry5Description = "The multi-billion pound building industry covers a range of different apprenticeships, from traditional and specialist skills, civil engineering to joinery and more.";
        private const string ExpectedIndustry6Name = "CREATIVE AND DESIGN";
        private const string ExpectedIndustry6Description = "Excited by the idea of designing your own video game or crafting your own fashion label? Keen photographer or passionate composer-in-the making? If you have a flair for the artistic, the creative or the outrageous, look no further.";
        private const string ExpectedIndustry7Name = "DIGITAL";
        private const string ExpectedIndustry7Description = "Apprenticeships in digital span a huge range of careers, as new technology transforms businesses large and small, traditional and start-ups, across the country. Ready to get connected?";
        private const string ExpectedIndustry8Name = "EDUCATION AND CHILDCARE";
        private const string ExpectedIndustry8Description = "If you can see yourself helping children and young people develop the skills they need to succeed, this is the apprenticeship sector for you.";
        private const string ExpectedIndustry9Name = "ENGINEERING AND MANUFACTURING";
        private const string ExpectedIndustry9Description = "From nuclear reactors and software systems to product design and automotive, engineering and manufacturing apprenticeships take many forms. Ready to switch on?";
        private const string ExpectedIndustry10Name = "HAIR AND BEAUTY";
        private const string ExpectedIndustry10Description = "From high street salons and spas to theatre dressing rooms and film and TV sets. Who knows where a hair and beauty apprenticeship could take you…";
        private const string ExpectedIndustry11Name = "HEALTH AND SCIENCE";
        private const string ExpectedIndustry11Description = "These apprenticeships give you the training to embark on a range of different science and research-based careers, including NHS and community health roles, chemical and pharmaceutical businesses, biotechnology and nuclear manufacturing.";
        private const string ExpectedIndustry12Name = "LEGAL, FINANCE AND ACCOUNTING";
        private const string ExpectedIndustry12Description = "Companies large and small need teams of people to look after their finances, legal affairs and accounts. Which means you could start an apprenticeship in any one of hundreds of different businesses.";
        private const string ExpectedIndustry13Name = "PROTECTIVE SERVICES";
        private const string ExpectedIndustry13Description = "Discover apprenticeships that are all about keeping people safe, including fire services, waste management, and HM Armed Forces.";
        private const string ExpectedIndustry14Name = "SALES, MARKETING AND PROCUREMENT";
        private const string ExpectedIndustry14Description = "Explore a host of apprenticeships across a wide range of different sales, promotion and procurement industries. From retail and customer services to digital marketing. National and local employers are always on the lookout for new apprentices.";
        private const string ExpectedIndustry15Name = "TRANSPORT AND LOGISTICS";
        private const string ExpectedIndustry15Description = "How about helping to keep the nation’s transport systems running smoothly? Across everything from aviation to coach travel. Or try a career in logistics, making sure products show up at the right place, at the right time.";

        #endregion

        #region Helpers
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionCampaignsHelper _pageInteractionCampaignsHelper;

        #endregion

        #region Page Object Elements
        private readonly By _pageTitle = By.XPath("//h1[@class='heading-xl hero-heading__heading']");
        private readonly By _industry1Name = By.XPath("(//div[@class='grid-column-full-width-one-quarter']/a//h2)[1]");
        private readonly By _industry1Description = By.XPath("(//div[@class='grid-column-full-width-one-quarter']/a//p)[1]");
        private readonly By _industry2Name = By.XPath("(//div[@class='grid-column-full-width-one-quarter']/a//h2)[2]");
        private readonly By _industry2Description = By.XPath("(//div[@class='grid-column-full-width-one-quarter']/a//p)[3]");
        private readonly By _industry3Name = By.XPath("(//div[@class='grid-column-full-width-one-quarter']/a//h2)[3]");
        private readonly By _industry3Description = By.XPath("(//div[@class='grid-column-full-width-one-quarter']/a//p)[5]");
        private readonly By _industry4Name = By.XPath("(//div[@class='grid-column-full-width-one-quarter']/a//h2)[4]");
        private readonly By _industry4Description = By.XPath("(//div[@class='grid-column-full-width-one-quarter']/a//p)[7]");
        private readonly By _industry5Name = By.XPath("(//div[@class='grid-column-full-width-one-quarter']/a//h2)[5]");
        private readonly By _industry5Description = By.XPath("(//div[@class='grid-column-full-width-one-quarter']/a//p)[9]");
        private readonly By _industry6Name = By.XPath("(//div[@class='grid-column-full-width-one-quarter']/a//h2)[6]");
        private readonly By _industry6Description = By.XPath("(//div[@class='grid-column-full-width-one-quarter']/a//p)[11]");
        private readonly By _industry7Name = By.XPath("(//div[@class='grid-column-full-width-one-quarter']/a//h2)[7]");
        private readonly By _industry7Description = By.XPath("(//div[@class='grid-column-full-width-one-quarter']/a//p)[13]");
        private readonly By _industry8Name = By.XPath("(//div[@class='grid-column-full-width-one-quarter']/a//h2)[8]");
        private readonly By _industry8Description = By.XPath("(//div[@class='grid-column-full-width-one-quarter']/a//p)[15]");
        private readonly By _industry9Name = By.XPath("(//div[@class='grid-column-full-width-one-quarter']/a//h2)[9]");
        private readonly By _industry9Description = By.XPath("(//div[@class='grid-column-full-width-one-quarter']/a//p)[17]");
        private readonly By _industry10Name = By.XPath("(//div[@class='grid-column-full-width-one-quarter']/a//h2)[10]");
        private readonly By _industry10Description = By.XPath("(//div[@class='grid-column-full-width-one-quarter']/a//p)[19]");
        private readonly By _industry11Name = By.XPath("(//div[@class='grid-column-full-width-one-quarter']/a//h2)[11]");
        private readonly By _industry11Description = By.XPath("(//div[@class='grid-column-full-width-one-quarter']/a//p)[21]");
        private readonly By _industry12Name = By.XPath("(//div[@class='grid-column-full-width-one-quarter']/a//h2)[12]");
        private readonly By _industry12Description = By.XPath("(//div[@class='grid-column-full-width-one-quarter']/a//p)[23]");
        private readonly By _industry13Name = By.XPath("(//div[@class='grid-column-full-width-one-quarter']/a//h2)[13]");
        private readonly By _industry13Description = By.XPath("(//div[@class='grid-column-full-width-one-quarter']/a//p)[25]");
        private readonly By _industry14Name = By.XPath("(//div[@class='grid-column-full-width-one-quarter']/a//h2)[14]");
        private readonly By _industry14Description = By.XPath("(//div[@class='grid-column-full-width-one-quarter']/a//p)[27]");
        private readonly By _industry15Name = By.XPath("(//div[@class='grid-column-full-width-one-quarter']/a//h2)[15]");
        private readonly By _industry15Description = By.XPath("(//div[@class='grid-column-full-width-one-quarter']/a//p)[29]");

        #endregion

        public MyInterestsPage(ScenarioContext context) : base(context)
        {
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionCampaignsHelper = context.Get<PageInteractionCampaignsHelper>();
            base.VerifyPage();
        }

        internal void verifyContentUnderWhatIsAnApprenticeshipSection()
        {
            string actualIndustry1Name = _pageInteractionHelper.GetText(_industry1Name);
            string actualIndustry1Description = _pageInteractionHelper.GetText(_industry1Description);

            string actualIndustry2Name = _pageInteractionHelper.GetText(_industry2Name);
            string actualIndustry2Description = _pageInteractionHelper.GetText(_industry2Description);

            string actualIndustry3Name = _pageInteractionHelper.GetText(_industry3Name);
            string actualIndustry3Description = _pageInteractionHelper.GetText(_industry3Description);

            string actualIndustry4Name = _pageInteractionHelper.GetText(_industry4Name);
            string actualIndustry4Description = _pageInteractionHelper.GetText(_industry4Description);

            string actualIndustry5Name = _pageInteractionHelper.GetText(_industry5Name);
            string actualIndustry5Description = _pageInteractionHelper.GetText(_industry5Description);

            string actualIndustry6Name = _pageInteractionHelper.GetText(_industry6Name);
            string actualIndustry6Description = _pageInteractionHelper.GetText(_industry6Description);

            string actualIndustry7Name = _pageInteractionHelper.GetText(_industry7Name);
            string actualIndustry7Description = _pageInteractionHelper.GetText(_industry7Description);

            string actualIndustry8Name = _pageInteractionHelper.GetText(_industry8Name);
            string actualIndustry8Description = _pageInteractionHelper.GetText(_industry8Description);

            string actualIndustry9Name = _pageInteractionHelper.GetText(_industry9Name);
            string actualIndustry9Description = _pageInteractionHelper.GetText(_industry9Description);

            string actualIndustry10Name = _pageInteractionHelper.GetText(_industry10Name);
            string actualIndustry10Description = _pageInteractionHelper.GetText(_industry10Description);

            string actualIndustry11Name = _pageInteractionHelper.GetText(_industry11Name);
            string actualIndustry11Description = _pageInteractionHelper.GetText(_industry11Description);

            string actualIndustry12Name = _pageInteractionHelper.GetText(_industry12Name);
            string actualIndustry12Description = _pageInteractionHelper.GetText(_industry12Description);

            string actualIndustry13Name = _pageInteractionHelper.GetText(_industry13Name);
            string actualIndustry13Description = _pageInteractionHelper.GetText(_industry13Description);

            string actualIndustry14Name = _pageInteractionHelper.GetText(_industry14Name);
            string actualIndustry14Description = _pageInteractionHelper.GetText(_industry14Description);

            string actualIndustry15Name = _pageInteractionHelper.GetText(_industry15Name);
            string actualIndustry15Description = _pageInteractionHelper.GetText(_industry15Description);


            _pageInteractionHelper.VerifyText(actualIndustry1Name, ExpectedIndustry1Name);
            _pageInteractionHelper.VerifyText(actualIndustry2Name, ExpectedIndustry2Name);
            _pageInteractionHelper.VerifyText(actualIndustry3Name, ExpectedIndustry3Name);
            _pageInteractionHelper.VerifyText(actualIndustry4Name, ExpectedIndustry4Name);
            _pageInteractionHelper.VerifyText(actualIndustry5Name, ExpectedIndustry5Name);
            _pageInteractionHelper.VerifyText(actualIndustry6Name, ExpectedIndustry6Name);
            _pageInteractionHelper.VerifyText(actualIndustry7Name, ExpectedIndustry7Name);
            _pageInteractionHelper.VerifyText(actualIndustry8Name, ExpectedIndustry8Name);
            _pageInteractionHelper.VerifyText(actualIndustry9Name, ExpectedIndustry9Name);
            _pageInteractionHelper.VerifyText(actualIndustry10Name, ExpectedIndustry10Name);
            _pageInteractionHelper.VerifyText(actualIndustry11Name, ExpectedIndustry11Name);
            _pageInteractionHelper.VerifyText(actualIndustry12Name, ExpectedIndustry12Name);
            _pageInteractionHelper.VerifyText(actualIndustry13Name, ExpectedIndustry13Name);
            _pageInteractionHelper.VerifyText(actualIndustry14Name, ExpectedIndustry14Name);
            _pageInteractionHelper.VerifyText(actualIndustry15Name, ExpectedIndustry15Name);

            _pageInteractionHelper.VerifyText(actualIndustry1Description, ExpectedIndustry1Description);
            _pageInteractionHelper.VerifyText(actualIndustry2Description, ExpectedIndustry2Description);
            _pageInteractionHelper.VerifyText(actualIndustry3Description, ExpectedIndustry3Description);
            _pageInteractionHelper.VerifyText(actualIndustry4Description, ExpectedIndustry4Description);
            _pageInteractionHelper.VerifyText(actualIndustry5Description, ExpectedIndustry5Description);
            _pageInteractionHelper.VerifyText(actualIndustry6Description, ExpectedIndustry6Description);
            _pageInteractionHelper.VerifyText(actualIndustry7Description, ExpectedIndustry7Description);
            _pageInteractionHelper.VerifyText(actualIndustry8Description, ExpectedIndustry8Description);
            _pageInteractionHelper.VerifyText(actualIndustry9Description, ExpectedIndustry9Description);
            _pageInteractionHelper.VerifyText(actualIndustry10Description, ExpectedIndustry10Description);
            _pageInteractionHelper.VerifyText(actualIndustry11Description, ExpectedIndustry11Description);
            _pageInteractionHelper.VerifyText(actualIndustry12Description, ExpectedIndustry12Description);
            _pageInteractionHelper.VerifyText(actualIndustry13Description, ExpectedIndustry13Description);
            _pageInteractionHelper.VerifyText(actualIndustry14Description, ExpectedIndustry14Description);
            _pageInteractionHelper.VerifyText(actualIndustry15Description, ExpectedIndustry15Description);
        }


        internal void selectAnyRequiredIndustry(string requiredIndustryName)
        {
            for(int i = 1; i <= 15; i++)
            {
                string industryNameXpath = "(//div[@class='grid-column-full-width-one-quarter']/a//h2)[" + i + "]";
                if (requiredIndustryName.Contains(_pageInteractionCampaignsHelper.GetText(industryNameXpath)))
                {
                    _pageInteractionCampaignsHelper.ScrollToReachTheRequiredElement(industryNameXpath);
                    _formCompletionHelper.ClickElement(By.XPath(industryNameXpath));
                    break;
                }
            }
        }

    }
}
