using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.DAS.TransferMatching.UITests.Project.Helpers
{
    public class TMDataHelper
    {
        private readonly RandomDataGenerator _randomDataGenerator;

        public TMDataHelper(RandomDataGenerator randomDataGenerator) => _randomDataGenerator = randomDataGenerator;

        public int PledgeAmount(int availablePledgeAmount) => _randomDataGenerator.GenerateRandomNumberBetweenTwoValues(1, availablePledgeAmount);
    }
}
