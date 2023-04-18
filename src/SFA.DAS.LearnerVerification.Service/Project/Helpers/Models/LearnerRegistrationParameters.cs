using System;

namespace SFA.DAS.LearnerVerification.Service.Project.Helpers.Models
{
    public class LearnerRegistrationParameters
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PostCode { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
    }

    public enum Gender
    {
        Unknown = 0,
        Male = 1,
        Female = 2,
        NotSpecified = 9
    }
}