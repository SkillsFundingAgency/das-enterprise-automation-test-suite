Feature: EPAO_RG_CA_10

@epao
@recordagrade
@regression
@epaoca1standard2version1versionconfirmed
Scenario: EPAO_RG_CA_10 - Certify an Apprentice as Pass - 1 Standard - multiple Version - with Version Confirmed
	Given the Assessor User is logged into Assessment Service Application
	When the User certifies an Apprentice as 'pass' using 'apprentice' route
	Then the User can navigates to record another grade
	And the Assessment is recorded as 'pass'