using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.DAS.EAS.AutomatedApiTests.Models
{
    public class PagedApiResponseWrapper<T>
    {
        public T[] Data { get; set; }
        public int Page { get; set; }
        public int TotalPages { get; set; }
    }
}
