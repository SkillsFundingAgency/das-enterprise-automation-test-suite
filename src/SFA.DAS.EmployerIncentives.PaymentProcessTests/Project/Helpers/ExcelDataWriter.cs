using Ganss.Excel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers
{
    public class ExcelDataWriter
    {
        private readonly ExcelMapper _excel = new ExcelMapper();
        private readonly string _fileName;

        public ExcelDataWriter(string fileName)
        {
            _fileName = fileName;
        }

        public async Task TakeDataSnapshot<T>(params IEnumerable<T>[] data) where T : class
        {
            foreach (var d in data)
            {
                await _excel.SaveAsync(_fileName, d, typeof(T).Name);
            }
        }
    }
}