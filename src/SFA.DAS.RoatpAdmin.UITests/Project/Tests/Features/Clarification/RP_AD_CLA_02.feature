Feature: RP_AD_CLA_02

@roatp
@rpadcla02
@roatpclarification
@newroatpadmin
@regression
Scenario: RP_AD_CLA_02 Complete Clarification Journey as Employer Provider Route and mark as FAIL
	Given the admin lands on the Dashboard as Assessor1
	When selects the Employer Provider Route application from Clarification Tab
	Then the Clarification assessor FAILS few sections
	Then the Clarification assessor assesses the outcome as FAIL
	Then the Outcome tab is updated as FAIL
	Then verify subsections outcome failed by Clarification assessor are updated as FAIL