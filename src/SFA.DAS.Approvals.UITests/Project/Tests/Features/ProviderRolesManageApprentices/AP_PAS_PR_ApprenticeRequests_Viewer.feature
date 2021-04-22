@ignore
Feature: AP_PAS_PR_ApprenticeRequests_Viewer

@Approvalproviderrole
Scenario Outline: Provider Roles Viewer Apprentice Requests
Given the provider logs in as a Viewer
When the user clicks on apprentice request link from homepage or apprentice request link
Then the user can view apprentice requests page
And the user can view apprentice details ready for review page when user clicks on with employer box
And the user can view apprentice details ready for review page when user clicks on drafts box
And the user can view apprentice details ready for review page when user clicks on with transfer sending employers box
And the user can view view your cohort page by clicking view link on view your cohort page selecting the employers box
And the user can view view your cohort page by clicking view link on view your cohort page selecting with transfer sending employers box
And the user can view review your cohort page when user clicks on details link from apprentice details ready for review page selecting with employers box
And the user can view review your cohort page when user clicks on details link from apprentice details ready for review page selecting drafts box
And the user cannot bulk upload apprentices via csv file
And the user cannot send a cohort to employer
And the user cannot delete a cohort
And the user cannot edit an apprentice in a cohort