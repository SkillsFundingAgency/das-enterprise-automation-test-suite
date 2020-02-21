Feature: RP_AD_NP_03

@rpadnp03
@roatp
@roatpadmin
@regression
Scenario: RP_AD_NP_03_Add A New Training Provider as Supporting Provider
	Given the admin initates an application as Supporting provider
	Then Organisation is successfully Added to the Register
	And the provider status should be set to Active
