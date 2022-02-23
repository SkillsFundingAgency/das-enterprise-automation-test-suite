Feature: EmploymentCheckE2EManuallyInsertNino

@api
@regression
@employmentcheckapi
Scenario: EC_API_010_PerformEmploymentCheck_ManuallyInsertNino
	Given employment check has been requested for an apprentice with ULN '<ULN>'
	And a NINO '<NINO>' has been manually inserted
	When check is picked up for enrichment process
	Then call to DC api is not made
	And an employment check request to HMRC is created using the Nino provided

Examples:
	| ULN       | NINO       |
	| 123456789 | EC_API_010 |