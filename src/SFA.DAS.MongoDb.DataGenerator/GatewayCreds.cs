namespace SFA.DAS.MongoDb.DataGenerator
{
    public class GatewayCreds
    {
        internal GatewayCreds(string gatewayid, string gatewaypassword, string paye, int index)
        {
            GatewayId = gatewayid;
            GatewayPassword = gatewaypassword;
            Paye = paye;
            Index = index;
        }

        public string GatewayId { get; private set; }
        public string GatewayPassword { get; private set; }
        public string Paye { get; private set; }
        public int Index { get; private set; }
        public string AornNumber { get; set; }

        public override string ToString() => $"Gatewayid:'{GatewayId}', GatewayPassword:'{GatewayPassword}', Paye/EmpRef:'{Paye}'{GetAornNumber()}";

        private string GetAornNumber() => string.IsNullOrEmpty(AornNumber) ? string.Empty : $", AornNumber: '{AornNumber}'";
    }
}
