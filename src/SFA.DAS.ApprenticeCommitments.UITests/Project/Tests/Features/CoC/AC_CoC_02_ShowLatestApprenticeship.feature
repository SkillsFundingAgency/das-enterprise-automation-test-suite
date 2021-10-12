Feature: AC_CoC_02_ShowLatestApprenticeship

@apprenticecommitments
@regression
@changeOfEmployer
@onemonthbeforecurrentacademicyearstartdate
Scenario: AC_CoC_02_ShowLatestApprenticeship
	Given the Employer has approved apprentice
	And the apprentice completed confirm my apprenticeship details
	Then the Employer can stop the live apprentice
	When the Employer has approved another apprenticeship
	Then only the latest apprenticeship should be visible
