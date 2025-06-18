Feature: RP_Assessor_Search


@roatp
@roatpadmin
@newroatpadmin
@rpsearch
@rpadoutcome01
@rpsearch03
@regression
Scenario: RP_AD_AssessorAdmin_Search_Using_NameAndUKPRN
	Given the admin lands on the Dashboard
	When the admin searches for a provider in Assessor by provider name
	Then the search results should be displayed for Assessor 
	When the admin searches for a provider in Assessor by UKPRN
	Then the search results should be displayed for Assessor 