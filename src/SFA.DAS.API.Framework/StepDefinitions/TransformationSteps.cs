namespace SFA.DAS.API.Framework.StepDefinitions;

[Binding]
public class TransformationSteps(ScenarioContext _)
{
    [StepArgumentTransformation(@"(GET|POST)")]
    public static Method HttpMethodTransformation(string method) => Transform<Method>(method);

    [StepArgumentTransformation(@"(OK|BadRequest|Unauthorized|Forbidden|NotFound)")]
    public static HttpStatusCode HttpStatusCodeTransformation(string statuscode) => Transform<HttpStatusCode>(statuscode);

    private static TEnum Transform<TEnum>(string value) where TEnum : struct => Enum.Parse<TEnum>(value, true);

}
