using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace SFA.DAS.API.Framework.StepDefinitions
{
    [Binding]
    public class TransformationSteps
    {
        public TransformationSteps(ScenarioContext _) { }

        [StepArgumentTransformation(@"(GET|POST)")]
        public Method HttpMethodTransformation(string method) => Transform<Method>(method);

        [StepArgumentTransformation(@"(OK|BadRequest|Unauthorized|Forbidden|NotFound)")]
        public HttpStatusCode HttpStatusCodeTransformation(string statuscode) => Transform<HttpStatusCode>(statuscode);

        private TEnum Transform<TEnum>(string value) where TEnum : struct => Enum.Parse<TEnum>(value, true);

    }
}
