Feature: TM_34_NavigateToLinksFromTransfersPledgePage

@regression
@transfermatching
Scenario: TM_34_ Navigate to different links from Create a Transfer Pledge page
     Given the levy employer logins using existing transfer matching account
     Then Employer navigates to Create a Transfer Pledge page
     Then Standard gov.uk footer should be displayed at the bottom of the page in Transfers
     And the Help widget is displayed on bottom right hand corner in Transfers
     And the employer can navigate to Accessibility statement page from Transfers