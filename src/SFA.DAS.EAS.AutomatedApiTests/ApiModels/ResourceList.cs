using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.DAS.EAS.AutomatedApiTests.ApiModels
{
    public class ResourceList : List<Resource>
    {
        public ResourceList(IEnumerable<Resource> resources)
        {
            AddRange(resources);
        }
    }
}
