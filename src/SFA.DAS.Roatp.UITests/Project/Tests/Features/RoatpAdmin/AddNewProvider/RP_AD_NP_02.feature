Feature: RP_AD_NP_02

@rpadnp02
@roatp
@roatpadmin
@regression
Scenario: RP_AD_NP_02_Add A New Training Provider as Employer Provider
Given the admin initates an application as Employer provider
Then Organisation is successfully Added to the Register
And the provider status should be set to On-Boarding
