Feature: RP_AD_UP_01

@rpadup01
@roatp
@oldroatpadmin
@regression
Scenario: RP_AD_UP_01_Verify Update Training Provider
When the admin searches for a provider by provider name
Then the admin can acess all the Update links
When the admin update the provider details
Then changes made are reflected on provider page