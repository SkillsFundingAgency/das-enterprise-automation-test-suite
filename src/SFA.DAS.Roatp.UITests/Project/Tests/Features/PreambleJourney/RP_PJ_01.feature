Feature: RP_PJ_01

@rppj01
@roatp
@regression
Scenario: RP_PJ_01_OnRoatpAsEmployer-CharityAndCompany - Route as Main 
	Given the provider initates an application as employer who is already on Roatp as employer
	Then the provider can change the route as main provider
