using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.DAS.EAS.AutomatedApiTests.Database
{
    public class PasswordProfile
    {
        public string Id { get; set; }
        public string Key { get; set; }
        public int WorkFactor { get; set; }
        public int SaltLength { get; set; }
        public int StorageLength { get; set; }
    }
}
