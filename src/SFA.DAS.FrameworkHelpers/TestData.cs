using CsvHelper.Configuration.Attributes;

namespace SFA.DAS.FrameworkHelpers
{
    public class TestData
    {
        [Name("Key")]
        public object Key { get; set; }

        [Name("Value")]
        public string Value { get; set; }
    }
}