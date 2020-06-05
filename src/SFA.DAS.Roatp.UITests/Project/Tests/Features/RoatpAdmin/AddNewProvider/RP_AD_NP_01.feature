Feature: RP_AD_NP_01

@rpadnp01
@roatp
@roatpadmin
@deletetrainingprovider
@regression
Scenario: RP_AD_NP_01_Add A New Training Provider as Main Provider
	Given the admin initates an application as Main provider
	Then Organisation is successfully Added to the Register
	And the provider status should be set to On-Boarding
