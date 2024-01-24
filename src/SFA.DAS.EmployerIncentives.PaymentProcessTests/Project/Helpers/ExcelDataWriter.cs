using Ganss.Excel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers
{
    public class ExcelDataWriter(string fileName)
    {
        private readonly ExcelMapper _excel = new();

        public async Task TakeDataSnapshot<T>(params IEnumerable<T>[] data) where T : class
        {
            foreach (var d in data)
            {
                await _excel.SaveAsync(fileName, d, typeof(T).Name);
            }
        }
    }
}