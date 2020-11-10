Feature: RP_AD_CLA_01

@roatp
@rpadcla01
@roatpadmin
@roatpclarification
@newroatpadmin
@regression
Scenario: RP_AD_CLA_01 Complete Clarification Journey as Main Provider Route
	Given the admin lands on the Dashboard as Assessor1
	When selects the Main Provider Route application from Clarification Tab
	Then the Clarification assessor assesses all the sections of the application as PASS
	Then the Clarification assessor assesses the outcome as PASS
	Then the Outcome tab is updated as PASS
	Then the subsections outcome are updated as PASS