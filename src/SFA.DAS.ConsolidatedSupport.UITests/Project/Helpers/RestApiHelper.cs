using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestEase;
using SFA.DAS.UI.Framework;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project.Helpers
{
    public class User
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }

    public class Comment
    {
        public string Body { get; set; }
    }

    public class Ticket
    {
        public Uri Url { get; set; }

        public long Id { get; set; }

        public Comment Comment { get; set; }

        public string Subject { get; set; }
    }

    public class TicketRequest
    {
        public Ticket Ticket { get; set; }
    }

    public class CreateUser
    {
        public User User { get; set; }
    }

    public class TicketResponse
    {
        public Ticket Ticket { get; set; }

        public Comment[] Comments { get; set; }
    }

    public interface IApi
    {
        [Post("/tickets.json")]
        Task<TicketResponse> PostTicket([Body] TicketRequest ticket);

        [Post("/users.json")]
        Task<CreateUser> CreateUserTicket([Body] CreateUser user);
    }

    public static class ApiFactory
    {
        public static IApi CreateApi(string user, string password)
        {
            var httpClient = new HttpClient
            {
                BaseAddress = UrlConfig.ConsolidatedSupport_ApiBaseUrl
            };

            httpClient.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue
            {
                NoCache = true
            };

            var authentication = Encoding.ASCII.GetBytes($"{user}:{password}");

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authentication));

            return new RestClient(httpClient).CreateApi();
        }
    }

    public static class ApiFactoryExtensions
    {
        public static readonly JsonSerializerSettings serialiser = new()
        {
            ContractResolver = new SnakeCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore,
        };

        internal static IApi CreateApi(this RestClient client)
        {
            client.JsonSerializerSettings = serialiser;
            return client.For<IApi>();
        }
    }

    public partial class SnakeCasePropertyNamesContractResolver : DefaultContractResolver
    {
        private readonly Regex converter = MyRegex();

        protected override string ResolvePropertyName(string propertyName)
        {
            return converter.Replace(propertyName, "_${b}").ToLower();
        }

        [GeneratedRegex(@"((?<=[a-z])(?<b>[A-Z])|(?<=[^_])(?<b>[A-Z][a-z]))")]
        private static partial Regex MyRegex();
    }

    public class RestApiHelper(ConsolidatedSupportConfig config, ConsolidateSupportDataHelper dataHelper)
    {
        private readonly IApi zendeskApi = ApiFactory.CreateApi(config.Username, config.Password);

        internal async Task<Ticket> CreateTicket()
        {
            var ticket = new Ticket
            {
                Subject = dataHelper.Subject,
                Comment = new Comment { Body = dataHelper.CommentBody },
            };

            var response = await zendeskApi.PostTicket(new TicketRequest { Ticket = ticket });
            return response.Ticket;
        }

        internal async Task<User> CreateUser()
        {
            var user = new User
            {
                Name = ConsolidateSupportDataHelper.NewUserFullName
            };

            var response = await zendeskApi.CreateUserTicket(new CreateUser { User = user });

            return response.User;
        }
    }
}
