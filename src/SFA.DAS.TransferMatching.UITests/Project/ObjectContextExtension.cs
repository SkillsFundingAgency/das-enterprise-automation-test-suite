using SFA.DAS.ConfigurationBuilder;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.TransferMatching.UITests.Project
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string EmployerTotalPledgeAmount = "employertotalpledgeamount";
        private const string PledgeId = "pledgeid";
        private const string PledgeAmount = "pledgeamount";
        private const string PledgeCreatedOn = "pledgecreatedon";
        private const string PledgeDetailList = "pledgedetaillist";
        #endregion

        internal static void SetPledgeDetailList(this ObjectContext objectContext) => objectContext.Set(PledgeDetailList, new List<Pledge>());

        internal static List<Pledge> GetPledgeDetailList(this ObjectContext objectContext) => objectContext.Get<List<Pledge>>(PledgeDetailList);

        internal static void SetEmployerTotalPledgeAmount(this ObjectContext objectContext, int value) => objectContext.Replace(EmployerTotalPledgeAmount, value);

        public static int GetEmployerTotalPledgeAmount(this ObjectContext objectContext) => objectContext.Get<int>(EmployerTotalPledgeAmount);

        internal static void SetPledgeAmount(this ObjectContext objectContext, int value) => objectContext.Replace(PledgeAmount, value);

        internal static void SetPledgeCreatedOn(this ObjectContext objectContext, DateTime value) => objectContext.Replace(PledgeCreatedOn, value);

        internal static void SetPledgeDetail(this ObjectContext objectContext, string pledgeId)
        {
            var pledgeDetailList = objectContext.GetPledgeDetailList();

            pledgeDetailList.Add(new Pledge { PledgeId = pledgeId, Amount = objectContext.GetPledgeAmount(), CreatedOn = objectContext.GetPledgeCreatedOn()});
        }

        internal static Pledge GetPledgeDetail(this ObjectContext objectContext) => objectContext.GetPledgeDetailList().LastOrDefault();

        internal static Pledge GetPledgeDetail(this ObjectContext objectContext, int index) => objectContext.GetPledgeDetailList().ElementAt(index);

        private static int GetPledgeAmount(this ObjectContext objectContext) => objectContext.Get<int>(PledgeAmount);

        private static DateTime GetPledgeCreatedOn(this ObjectContext objectContext) => objectContext.Get<DateTime>(PledgeCreatedOn);
    }

    public class Pledge
    {
        public string PledgeId;
        public int Amount;
        public DateTime CreatedOn;
        
        public override string ToString() => $"Pledge Id:'{PledgeId}', Amount:'{Amount}'";
    }
}
