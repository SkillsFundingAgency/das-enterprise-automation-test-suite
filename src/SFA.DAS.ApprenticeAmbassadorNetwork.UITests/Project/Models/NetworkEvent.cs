namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Models
{
    public class NetworkEvent
    {
        public string EventTitle { get; set; }
        
    }

    public class NetworkEventWithLocation : NetworkEvent
    {
        public string Location { get; set; }
    }

    public class NetworkEventWithOrdinal : NetworkEvent
    {
        public int Order { get; set; }
    }
}
