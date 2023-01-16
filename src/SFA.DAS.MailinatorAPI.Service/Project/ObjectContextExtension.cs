using SFA.DAS.ConfigurationBuilder;
using System.Collections.Generic;

namespace SFA.DAS.MailinatorAPI.Service.Project;

public static class ObjectContextExtension
{
    private const string ListOfMessages = "listofmessages";

    internal static void SetMessageList(this ObjectContext objectContext) => objectContext.Set(ListOfMessages, new List<(string domain, string inbox, string id)>() { });

    internal static void SetMessage(this ObjectContext objectContext, (string domain, string inbox, string id) message) => objectContext.GetMessageList().Add(message);

    internal static List<(string domain, string inbox, string id)> GetMessageList(this ObjectContext objectContext) => objectContext.Get<List<(string domain, string inbox, string id)>>(ListOfMessages);
}
