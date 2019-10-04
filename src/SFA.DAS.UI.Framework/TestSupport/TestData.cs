using CsvHelper.Configuration.Attributes;

namespace SFA.DAS.UI.Framework.TestSupport
{
    public class TestData
    {
        [Name("Key")]
        public string Key { get; set; }

        [Name("Value")]
        public string Value { get; set; }
    }
}
