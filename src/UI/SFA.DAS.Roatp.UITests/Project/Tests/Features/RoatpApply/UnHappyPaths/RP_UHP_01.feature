Feature: RP_UHP_01

@rpuhp01
@roatp
@roatpapply
@roatpuhp
@regression
Scenario: RP_UHP_01_MainRoute-Company
	Given the provider initates an application as main route company
	When the provider selects the unhappy path
	Then the provider cannot continue the journey
