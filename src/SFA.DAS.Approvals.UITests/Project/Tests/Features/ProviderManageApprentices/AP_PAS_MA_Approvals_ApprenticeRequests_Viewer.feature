Feature: AP_PAS_MA_Approvals_ApprenticeRequests_Viewer

@Recruitproviderrole
Scenario Outline: Provider Roles Viewer Apprentice Requests
Given the provider logs in as a Viewer
When the user clicks on apprentice request link from homepage or apprentice request link
Then the user can view apprentice requests page
#And the user can download csv file
#And the user can view details of the apprenticeship on apprenticeship details page
#And the user can view changes via view changes link in the banner
#And the user can view details of ILR mismatch via view details link in the ILR data mismatch banner
#And the user can view details of ILR mismatch request restart via view details link in the ILR data mismatch banner
#And the user can view review changes via review details link in the banner
#And the user can view view changes nonCoE page via view changes link in the banner
#And the user can can access  apprentice request page via apprentice requests link on homepage or from apprentice requests menu bar
And the user can view apprentice details ready for review page when user clicks on with employer box
And the user can view apprentice details ready for review page when user clicks on drafts box
And the user can view apprentice details ready for review page when user clicks on with transfer sending employers box
And the user can view view your cohort page by clicking view link on view your cohort page selecting the employers box
And the user can view view your cohort page by clicking view link on view your cohort page selecting with transfer sending employers box
And the user can view review your cohort page when user clicks on details link from apprentice details ready for review page selecting with employers box
And the user can view review your cohort page when user clicks on details link from apprentice details ready for review page selecting drafts box
#And the user cannot trigger change of employer journey using change link against the employer field
#And the user cannot edit an existing apprenticeship record by selecting edit apprentice link under manage appreciates
#And the user cannot take action on details of ILR mismatch page by selecting any radio buttons on the page
#And the user cannot take action on details of ILR mismatch request restart via view details link in the ILR data mismatch banner
#And the user cannot take action on review changes page
#And the user cannot take action on View changes on nonCoE page
#And the user cannot create a cohort
#And the user cannot edit an apprentice in a cohort
And the user cannot bulk upload apprentices via csv file
And the user cannot send a cohort to employer
And the user cannot delete a cohort