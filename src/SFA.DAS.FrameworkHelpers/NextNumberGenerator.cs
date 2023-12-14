namespace SFA.DAS.FrameworkHelpers
{
    public static class NextNumberGenerator
    {
        static readonly object _object = new();

        private static int count;

        static NextNumberGenerator()
        {
            count = 300;
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
