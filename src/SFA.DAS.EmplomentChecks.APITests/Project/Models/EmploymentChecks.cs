using Dapper.Contrib.Extensions;
using System;

namespace SFA.DAS.EmploymentChecks.APITests.Project.Models;

[Table("Business.EmploymentCheck")]
public class EmploymentChecksDb
{
    public int Id { get; set; }

    public Guid CorrelationId {get; set;}

    public string CheckType { get; set; }

    public long Uln { get; set; }

    public long ApprenticeshipId { get; set; }

    public long AccountId { get; set; }

    public DateTime MinDate { get; set; }

    public DateTime MaxDate { get; set; }

    public bool? Employed { get; set; }

    public DateTime? MessageSentDate { get; set; }

    public string ErrorType { get; set; }

    public ProcessingCompletionStatus? RequestCompletionStatus { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }
}

public enum ProcessingCompletionStatus
{
    Started = 1,
    Completed = 2,
    Skipped = 3
}