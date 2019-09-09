using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.DAS.EAS.AutomatedApiTests.Models
{
    public class ResourceList : List<Resource>
    {
        public ResourceList(IEnumerable<Resource> resources)
        {
            AddRange(resources);
        }
    }
}
