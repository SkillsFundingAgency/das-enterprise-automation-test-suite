Feature: GetApprenticeshipRecords


@api
@apprenticecommitmentsapi
@outerapi
@regression
@deleteuser
Scenario: Get apprenticeship records
	Given an apprentice has created an account
	Then the apprenticeship records can be fetched
