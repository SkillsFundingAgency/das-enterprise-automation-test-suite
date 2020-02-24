Feature: RP_AD_SP_02

@rpadsp02
@roatp
@roatpadmin
@regression
Scenario: RP_AD_SP_02_Verify Search For Training Provider
When the admin searches for a provider by provider name
Then the admin should be taken to one provider name result found page
When the admin searches for a provider by ukprn
Then the admin should be taken to one provider ukprn result found page
When the admin searches for a provider by partial provider name
Then the admin should be taken to multiple results found page