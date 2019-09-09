using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.DAS.EAS.AutomatedApiTests.Models
{
    public class TeamMember
    {
        public string UserRef { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public bool CanReceiveNotifications { get; set; }
                
        public InvitationStatus Status { get; set; }

        public enum InvitationStatus : byte
        {
            Pending = 1,
            Accepted = 2,
            Expired = 3,
            Deleted = 4
        }
    }
}
