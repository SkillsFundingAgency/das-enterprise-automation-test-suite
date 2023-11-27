namespace SFA.DAS.FrameworkHelpers
{
    public static class NextNumberGenerator
    {
        static readonly object _object = new object();

        private static int count;

        static NextNumberGenerator()
        {
            count = 200;
        }

        public static int GetNextCount()
        {
            lock (_object)
            {
                count++;
                return count;
            }
        }
    }
}
