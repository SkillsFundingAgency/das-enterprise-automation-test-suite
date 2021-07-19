Feature: RP_Gateway_Search


@roatp
@roatpadmin
@newroatpadmin
@rpsearch
@rpadfha01
@rpsearch01
@regression
Scenario: RP_AD_GW_Seacrh
	Given the admin lands on the Dashboard
	When the admin searches for a provider in Gateway by provider name
	Then the search results should be displayed  
	When the admin searches for a provider in Gateway by UKPRN
	Then the search results should be displayed 