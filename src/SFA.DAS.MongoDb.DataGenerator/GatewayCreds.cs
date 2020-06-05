using System;

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
        internal int Index { get; private set; }

        public override string ToString() => $"Gatewayid:'{GatewayId}', GatewayPassword:'{GatewayPassword}', Paye/EmpRef:'{Paye}'";
    }
}
