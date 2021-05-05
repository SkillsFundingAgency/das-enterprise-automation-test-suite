Feature: AP_PAS_PR_07_ManageYourApprentices_ContributorWithApproval

@approvals
@regression
@Approvalproviderrole
Scenario: AP_PAS_PR_07_Provider Roles Contributor with approval Manage your Apprentices
Given the provider logs in as a ContributorWithApproval
When the user clicks on manage apprentice link from homepage or manage apprentices link
Then the user can download csv file
And the user can view details of the apprenticeship on apprenticeship details page
And the user can view changes via view changes link in the banner
And the user can view details of ILR mismatch via view details link in the ILR data mismatch banner
And the user can view details of ILR mismatch request restart via view details link in the ILR data mismatch banner
And the user can view review changes via review details link in the banner
And the user can view view changes nonCoE page via view changes link in the banner
And the user cannot trigger change of employer journey using change link against the employer field
And the user cannot edit an existing apprenticeship record by selecting edit apprentice link under manage appreciates
And the user cannot take action on details of ILR mismatch page by selecting any radio buttons on the page
And the user cannot take action on details of ILR mismatch request restart via view details link in the ILR data mismatch banner
And the user cannot take action on review changes page
And the user cannot take action on View changes on nonCoE page
