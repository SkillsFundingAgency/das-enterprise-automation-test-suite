using System;

namespace SFA.DAS.LearnerVerification.Service.Project.Helpers.Models
{
    public class LearnerVerificationParameters
    {
        public LearnerVerificationParameters(string uln, string firstName, string lastName, string gender, DateTime? dateOfBirth)
        {
            Uln = uln;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            DateOfBirth = dateOfBirth;
        }

        public string Uln { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}