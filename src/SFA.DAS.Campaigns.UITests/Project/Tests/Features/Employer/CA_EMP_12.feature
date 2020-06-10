Feature: CA_EMP_12

@campaigns
@employer
@regression
Scenario: CA_EMPP_12 Check that Levy Paying Employer Selected appropriate content displayed 
	Given the user navigates to the How do they work page
	Then Employer Selects Yes on How do they work page and clicks continue
	And Verifies that correct content is displayed on Funding An Apprentice page
