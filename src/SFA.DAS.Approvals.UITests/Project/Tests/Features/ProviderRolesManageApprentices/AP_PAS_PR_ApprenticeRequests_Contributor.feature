@ignore
Feature: AP_PAS_PR_ApprenticeRequests_Contributor	

@Approvalproviderrole
Scenario: Provider Roles Contributor Apprentice Requests
Given the provider logs in as a Contributor
When the user clicks on apprentice request link from homepage or apprentice request link
Then the user can view apprentice requests page
And the user can view apprentice details ready for review page when user clicks on with employer box
And the user can view apprentice details ready for review page when user clicks on drafts box
And the user can view apprentice details ready for review page when user clicks on with transfer sending employers box
And the user can view view your cohort page by clicking view link on view your cohort page selecting the employers box
And the user can view view your cohort page by clicking view link on view your cohort page selecting with transfer sending employers box
And the user can view review your cohort page when user clicks on details link from apprentice details ready for review page selecting with employers box
And the user can view review your cohort page when user clicks on details link from apprentice details ready for review page selecting drafts box
And the user can create a cohort
And the user can add apprentice to a cohort
And the user can bulk upload apprentices
And the user can edit an existing apprenticeship record by selecting edit apprentice link selecting with employers or drafts boxes
And the user can delete a cohort
And the user can delete an apprentice in a cohort
