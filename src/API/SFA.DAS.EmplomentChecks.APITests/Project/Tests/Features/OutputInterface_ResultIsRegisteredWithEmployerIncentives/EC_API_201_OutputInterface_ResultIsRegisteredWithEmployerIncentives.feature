Feature: EC_API_201_OutputInterface_ResultIsRegisteredWithEmployerIncentives

Employment Check results are sent to Eemployer Incentives to consume for the payrun validation 

@api
@regression
@employmentcheckapi
Scenario: Employment Check results are sent to Employer Incentives to consume for the payrun validation 
Scenario: EC_API_201_OutputInterface_ResultIsRegisteredWithEmployerIncentives
	Given an employment check for an apprentice with '<Status>', '<Employed>', '<ErrorType>'
	When apprentice employment check result is published
	Then employment check database record updated to indicate result has been published if '<ShouldBeSent>'
	And employment check result has been processed by the Employer Incentives system

	Examples:
		| Status          | Employed | ErrorType    | ShouldBeSent |
		| Started         |          |              | false        |
		| Skipped         |          |              | false        |
		| Completed       | false    |              | true         |
		| Completed       | true     |              | true         |
		| Completed       |          | NinoNotFound | true         |
		| Completed       |          | PAYENotFound | true         |
		| Completed       |          | HmrcFailure  | true         |