Feature: ProviderAddsApprenticesToACohort

@regression
Scenario: Provider adds apprentices and views cohort details when the cohort is with the employer
	Given the Employer login using existing levy account
	When the Employer create a cohort and send to provider to add apprentices
	And the provider adds 2 apprentices approves them and sends to employer to approve
	Then Provider is able to view the cohort with employer
	And Provider is able to view all apprentice details when the cohort with employer