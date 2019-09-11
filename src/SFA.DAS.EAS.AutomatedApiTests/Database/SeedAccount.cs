using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.DAS.EAS.AutomatedApiTests.Database
{
    public class SeedAccount
    {
        public string AccountHashedId { get; set; }
        public string AccountPublicHashedId { get; set; }
        public string LegalEntityCode { get; set; }
        public string LegalEntityName { get; set; }
        public string LegalEntityAddress { get; set; }
        public DateTime DateOfIncorporation { get; set; }
        public string LegalEntityStatus { get; set; }
        public short LegalEntitySource { get; set; }
        public string PayeRef { get; set; }
        public string PayeName { get; set; }
        public string PublicHashId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmailAddress { get; set; }
    }
}