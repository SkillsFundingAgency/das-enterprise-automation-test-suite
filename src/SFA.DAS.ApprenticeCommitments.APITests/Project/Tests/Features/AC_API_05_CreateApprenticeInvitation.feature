Feature: CreateApprenticeInvitation

@api
@apprenticecommitmentsapi
@outerapi
@regression
@deleteinvitation
Scenario: AC_API_05A_New apprenticeship email sent
	When an apprenticeship is posted
	Then the apprentice details are updated in the login db

@api
@innerapi
Scenario: AC_API_05B_Inner das-commitments-api heathcheck
	Then das-commitments-api endpoint can be accessed