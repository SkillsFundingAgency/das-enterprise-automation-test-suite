using System.Collections.Generic;

namespace SFA.DAS.EmployerIncentives.UITests.Models
{
    public class TrainingDto
    {
        public string Reference { get; set; }

        public ICollection<PriceEpisodeDto> PriceEpisodes { get; set; }
    }
}
