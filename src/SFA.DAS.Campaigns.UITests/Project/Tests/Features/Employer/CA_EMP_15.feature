Feature: CA_EMP_15

@campaigns
@apprentice
@regression
Scenario: CA_EMP_15 Check Setting Up Page Details
	Given the user navigates to Setting Up Page
	And  Verify the content on Setting Up Page
	Then the links are not broken