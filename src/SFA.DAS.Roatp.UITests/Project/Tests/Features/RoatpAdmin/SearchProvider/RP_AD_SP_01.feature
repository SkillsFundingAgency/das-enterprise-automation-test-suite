Feature: RP_AD_SP_01

@rpadsp01
@roatp
@roatpadmin
@regression
Scenario: RP_AD_SP_01_Verify Search and check Update links
When the admin searches for a provider
Then the admin should be taken to the provider name result page
And the admin can acess all the Update links