namespace SFA.DAS.LearnerVerification.Service.Project.Helpers.Models;

public class LearnerRegistrationResponse
{
    public LearnerRegistrationResponseCode ResponseCode { get; set; }
    public string Uln { get; set; }
}

public enum LearnerRegistrationResponseCode
{
    /// <summary>
    /// Learner successfully registered - an error response message will be returned if the
    /// operation fails
    /// </summary>
    WSRC0005,

    /// <summary>
    /// Learner registration unsuccessful message will be returned if the operation fails
    /// </summary>
    WSRC0021
}