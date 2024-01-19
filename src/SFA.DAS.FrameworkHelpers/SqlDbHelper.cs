namespace SFA.DAS.FrameworkHelpers;

public abstract class SqlDbHelper : SqlDbBaseHelper
{
    protected SqlDbHelper(ObjectContext objectContext, string connectionString) : base(objectContext, connectionString) { }

    #region ExecuteSqlCommand

    protected int ReTryExecuteSqlCommand(string queryToExecute) => SqlDbRetryHelper.RetryOnException(() => ExecuteSqlCommand(queryToExecute));

    #endregion

    protected List<string> GetData(string query) => GetData(query, connectionString);

    protected List<string> GetData(string query, string connectionstring) => GetData(query, connectionstring, null);

    protected List<string> GetData(string query, Dictionary<string, string> parameters) => GetData(query, connectionString, parameters);

    protected List<string> GetData(string query, string connectionstring, Dictionary<string, string> parameters)
    {
        (List<object[]> data, int noOfColumns) data = GetListOfData(query, connectionstring, parameters);

        var returnItems = new List<string>();

        for (int i = 0; i < data.noOfColumns; i++)
        {
            if (data.data.Count == 0) returnItems.Add(string.Empty);
            else returnItems.Add(data.data[0][i].ToString());
        }

        return returnItems;
    }

    protected List<string[]> GetMultipleData(string query) => GetListOfMultipleData([query]).FirstOrDefault();

    protected List<List<string[]>> GetListOfMultipleData(List<string> query)
    {
        List<(List<object[]> data, int noOfColumns)> multidatas = SqlDbRetryHelper.RetryOnException(() => GetMultipleListOfData(query));

        var multireturnItems = new List<List<string[]>>();

        foreach (var (data, noOfColumns) in multidatas)
        {
            var returnItems = new List<string[]>();

            var datalist = data;

            var noOfRows = datalist.Count;

            if (noOfRows == 0) returnItems.Add(new string[noOfColumns]);

            for (int i = 0; i < noOfRows; i++)
            {
                var items = new string[datalist[i].Length];

                for (int j = 0; j < items.Length; j++)
                {
                    var item = datalist[i][j].ToString();

                    items[j] = item;
                }
                returnItems.Add(items);
            }
            multireturnItems.Add(returnItems);
        }
        return multireturnItems;
    }

    protected string GetNullableData(string queryToExecute)
    {
        var data = GetData(queryToExecute);

        if (data.Count == 0) return string.Empty;

        else return data[0];
    }

    protected string GetDataAsString(string queryToExecute) => Convert.ToString(GetDataAsObject(queryToExecute));

    protected object GetDataAsObject(string queryToExecute) => GetListOfData(queryToExecute)[0][0];

    protected object WaitAndGetDataAsObject(string queryToExecute)
    {
        waitForResults = true;

        return GetDataAsObject(queryToExecute);
    }
}
