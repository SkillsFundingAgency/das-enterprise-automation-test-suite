Feature: ProviderEditsOrDeletesApprenticesOfACohort

@regression
Scenario: Provider Edits, Deletes Apprentices and Deletes Cohort that is not sent to a Employer
	Given the Employer login using existing levy account
	When the Employer create a cohort and send to provider to add apprentices
	And Provider adds 2 apprentices and saves without sending to the employer
	Then Provider is able to edit all apprentices before approval
	And Provider is able to delete all apprentices before approval
	And Provider is able to delete the cohort before approval