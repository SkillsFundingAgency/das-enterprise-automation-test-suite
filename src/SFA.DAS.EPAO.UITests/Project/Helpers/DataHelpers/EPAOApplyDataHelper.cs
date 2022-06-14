namespace SFA.DAS.EPAO.UITests.Project.Helpers.DataHelpers;

public class EPAOApplyDataHelper : EPAODataHelper
{
    public EPAOApplyDataHelper() : base() { }

    public static string InvalidOrgNameWithAlphabets => "asfasfasdfasdf";
    public static string InvalidOrgNameWithNumbers => "54678900";
    public static string InvalidOrgNameWithAWord => "EPA01";
}
