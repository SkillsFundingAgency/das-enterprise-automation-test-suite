using System.Collections.Generic;

namespace SFA.DAS.LearnerVerification.Service.Project.Helpers.Models
{
    public class LearnerVerificationResponse
    {
        public LearnerVerificationResponseType ResponseType { get; set; }
        public IEnumerable<LearnerDetailMatchingError> MatchingErrors { get; set; }

        public LearnerVerificationResponse(bool generatePositiveResponse = false)
        {
            if (generatePositiveResponse)
            {
                ResponseType = LearnerVerificationResponseType.SuccessfulMatch;
                MatchingErrors = new List<LearnerDetailMatchingError>();
            }
        }
    }

    public enum LearnerVerificationResponseType
    {
        SuccessfulMatch,

        SuccessfulLinkedMatch,

        SimilarMatch,

        SimilarLinkedMatch,

        LearnerDoesNotMatch,

        UlnNotFound
    }

    public enum LearnerDetailMatchingError
    {
        GivenDoesntMatchGiven,

        GivenDoesntMatchFamily,

        GivenDoesntMatchPreviousFamily,

        FamilyDoesntMatchGiven,

        FamilyDoesntMatchFamily,

        FamilyDoesntMatchPreviousFamily,

        DateOfBirthDoesntMatchDateOfBirth,

        GenderDoesntMatchGender
    }
}