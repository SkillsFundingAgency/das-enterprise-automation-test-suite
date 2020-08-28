Feature: CA_AP_09

@campaigns
@apprentice
@regression
Scenario: CA_AP_09 Check Become An Apprentice Page Details
	Given the user navigates to Become An Apprentice page
	And  Verify the content on Become An Apprentice Page
	Then the links are not broken

#@campaigns
#@employer
#@regression
#Scenario: CA_EMPP_10_Check The links on How do they work Page
#	Given the user navigates to the How do they work page
#	Then verify the links are not broken on How do they work page