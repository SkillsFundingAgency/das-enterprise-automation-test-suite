Feature: GetApprenticeshipRecords

@api
@apprenticecommitmentsapi
@outerapi
@regression
@deleteuser
Scenario: AC_API_03_Get apprenticeship records
	Given an apprentice has created an account
	Then the apprenticeship records can be fetched