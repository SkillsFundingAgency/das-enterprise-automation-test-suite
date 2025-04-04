using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFA.DAS.RAA.APITests.Project
{
    public class CreateVacancyApiClient(ObjectContext objectContext, Outer_ApiAuthTokenConfig config, string apiBaseUrl) : Recruit_BaseApiRestClient(objectContext, config)
    {
        private readonly string _apiBaseUrl = apiBaseUrl;
        protected override string ApiName => "";

        protected override string ApiBaseUrl => _apiBaseUrl;

        public new void CreateRestRequest(Method method, string resource, string payload)
        {
            base.CreateRestRequest(method, resource, payload);

            restRequest.RequestFormat = DataFormat.Json;

            Addheader("Content-Type", "application/json");

            Addheader("Accept", "application/json");

        }
    }

}
