namespace SFA.DAS.Roatp.UITests.Project.Helpers.UkprnDataHelpers
{
    public class OldRoatpAdminUkprnDataHelpers : RoatpUkprnBaseDataHelpers
    {
        public OldRoatpAdminUkprnDataHelpers() : base() => AddAdminDatahelpers();

        public (string providername, string ukprn) GetOldRoatpAdminData(string key) => GetData(key, providernamekey, ukprnkey);

        private void AddAdminDatahelpers()
        {
            _data.Add("rpadsp01",
               [
                       new(providernamekey, "BARNARDO'S"),
                   new(ukprnkey, "10000532"),
               ]);
            _data.Add("rpadup01",
               [
                       new(providernamekey, "PHILIPS HAIR SALONS LIMITED"),
                   new(ukprnkey, "10005089"),
               ]);
            _data.Add("rpadnp01",
               [
                       new(providernamekey, "BUSINESS CONTINUITY TRAINING LIMITED"),
                   new(ukprnkey, "10023959"),
               ]);
            _data.Add("rpadnp02",
               [
                        new(providernamekey, "LOCUS INTERNATIONAL LIMITED"),
                   new(ukprnkey, "10036913"),
               ]);
            _data.Add("rpadnp03",
               [
                        new(providernamekey, "OLMEC"),
                   new(ukprnkey, "10033872"),
               ]);
        }
    }
}
