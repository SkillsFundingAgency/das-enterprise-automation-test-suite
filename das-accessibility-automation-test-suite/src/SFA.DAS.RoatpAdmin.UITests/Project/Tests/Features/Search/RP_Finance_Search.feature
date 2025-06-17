Feature: RP_Finance_Search


@roatp
@roatpadmin
@newroatpadmin
@rpsearch
@rpadoutcome01
@rpsearch02
@regression
Scenario: RP_AD_FinanceAdmin_Search_Using_NameAndUKPRN
	Given the admin lands on the Dashboard
	When the admin searches for a provider in Finance by provider name
	Then the search results should be displayed for Finance  
	When the admin searches for a provider in Finance by UKPRN
	Then the search results should be displayed for Finance