Feature: RP_AD_CLA_02

@roatp
@rpadcla02
@roatpadmin
@roatpclarification
@newroatpadmin
@regression
Scenario: RP_AD_CLA_02 Complete Clarification Journey as Employer Provider Route
	Given the admin lands on the Dashboard as Assessor1
	When selects the Employer Provider Route application from Clarification Tab
	Then the Clarification assessor assesses all the sections of the application as FAIL
	Then the Clarification assessor assesses the outcome as FAIL
	Then the Outcome tab is updated as FAIL