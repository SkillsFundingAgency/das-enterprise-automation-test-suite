using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System;
using System.Linq;

namespace SFA.DAS.SupportConsole.UITests.Project.SqlHelpers
{
    public class CommitmentsSqlDataHelper : SqlDbHelper
    {
        public CommitmentsSqlDataHelper(DbConfig dBConfig) : base(dBConfig.CommitmentsDbConnectionString) { }

        public void UpdateApprenticeshipStatus(string uln, int status)
        {
            string stopDate, pauseDate, completionDate;

            if (uln.Equals(null))
                throw new Exception("ULN is not set");

            if (status < 1 || status > 4)
                throw new Exception("Invalid Status!");


            pauseDate = (status == 2) ? DateTime.Now.ToString("yyyy-MM-dd") : null;
            stopDate = (status == 3) ? DateTime.Now.ToString("yyyy-MM-dd") : null;            
            completionDate = (status == 4) ? DateTime.Now.ToString("yyyy-MM-dd") : null;

            string sqlQueryToSetDataLockSuccessStatus = $@"UPDATE Apprenticeship
                                                            SET PaymentStatus = {status.ToString()}, StopDate = '{stopDate}', PauseDate = '{pauseDate}', CompletionDate = '{completionDate}'
                                                            WHERE ULN = '{uln}'";

            ExecuteSqlCommand(sqlQueryToSetDataLockSuccessStatus);
        }

		internal ApprenticeshipDetailsWithPrice GetApprenticeshipDetails(string uln, string cohortRef)
		{
			string sql = $@"Select CASE
					WHEN c.Approvals & 3 = 3 THEN 3  --Both agreed
					WHEN c.Approvals & 1 = 1 THEN 1  -- Employer only agreed
					WHEN c.Approvals & 2 = 2 THEN 2  -- Provider agreed,
					ELSE 0
				END as AgreementStatus,
				a.PaymentStatus,
				a.ULN,
				a.Email,
				P.Name,
				a.FirstName,
				a.LastName,
				a.DateOfBirth,
				c.Reference,
				a.EmployerRef,
				ale.Name as 'LegalEntityName',
				c.ProviderId,
				a.TrainingName,
				a.TrainingCode,
				CASE 
					WHEN A.IsApproved != 1 THEN NULL
					WHEN A.Email IS NULL THEN 'N/A'
					WHEN ACS.CommitmentsApprovedOn IS NULL THEN 'Unconfirmed'
					WHEN ACS.ApprenticeshipConfirmedOn IS NOT NULL THEN 'Confirmed'
					WHEN ACS.ConfirmationOverdueOn < GETUTCDATE()  THEN 'Overdue'
					ELSE 'Unconfirmed'
				END AS ConfirmationStatusDescription,
				a.StartDate,
				a.EndDate,
				CASE
					WHEN
						a.PaymentStatus = 0
					THEN
						a.Cost
					ELSE
						(
						SELECT TOP 1 Cost FROM PriceHistory WHERE ApprenticeshipId = a.Id
							AND ( 
								-- If started take if now with a PriceHistory or the last one (NULL end date)
								( a.StartDate <= GETUTCDATE()
								  AND ( 
									( FromDate <= GETUTCDATE() AND ToDate >= FORMAT(GETUTCDATE(),'yyyMMdd')) 
									  OR ToDate IS NULL
									)
								)
								-- If not started take the first one
								OR (a.StartDate > GETUTCDATE()) 
							)
							ORDER BY FromDate
						 )
				END AS 'Cost',
                a.MadeRedundant,
				a.CompletionDate,
				a.StopDate,
				a.PauseDate,
				a.TrainingCourseVersionConfirmed,
				a.TrainingCourseVersion,
				a.TrainingCourseOption
				 from Commitment c
			inner join Apprenticeship a on a.CommitmentId = c.Id
			inner join AccountLegalEntities ale on ale.Id = c.AccountLegalEntityId
			inner join Providers p on p.Ukprn = c.ProviderId
			left join ApprenticeshipConfirmationStatus ACS ON ACS.ApprenticeshipId = A.Id
			where ULN = '{uln}'
			and c.Reference = '{cohortRef}'";

			var result = GetMultipleData(sql).First();

			return new ApprenticeshipDetailsWithPrice
			{
				AgreementStatus = int.Parse(result[0]),
				PaymentStatus = int.Parse(result[1]),
				ULN = result[2],
				Email = result[3],
				ProviderName = result[4],
				FirstName = result[5],
				LastName = result[6],
				DateOfBirthAsString = result[7],
				CohortReference = result[8],
				EmployerReference = result[9],
				LegalEntityName = result[10],
				UKPRN = result[11],
				TrainingName = result[12],
				TrainingCode = result[13],
				ConfirmationStatusDescription = result[14],
				StartDateAsString = result[15],
				EndDateAsString = result[16],
				Cost = int.Parse(result[17]),
				MadeRedundant = GetBoolValue(result[18]),
				CompletionDateAsString = result[19],
				StopDateAsString = result[20],
				PauseDateAsString = result[21],
				TrainingCourseVersionConfirmed = GetBoolValue(result[22]),
				TrainingCourseVersion = result[23],
				TrainingCourseOption = result[24]
			};
		}

        private bool? GetBoolValue(string v)
        {
			if (string.IsNullOrWhiteSpace(v))
				return null;

			bool.TryParse(v, out bool result);
			return result;
        }
    }
}
