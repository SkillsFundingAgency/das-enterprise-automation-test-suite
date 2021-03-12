using System.Collections.Generic;

namespace SFA.DAS.EmployerIncentives.UITests.Models
{
    public class TrainingDto
    {
        public string Reference { get; set; }

        public IList<PriceEpisodeDto> PriceEpisodes { get; set; }
    }
}
