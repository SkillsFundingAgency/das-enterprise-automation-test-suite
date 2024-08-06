Feature: RE_Tasks_02

@regression
@registration
Scenario: RE_Tasks_02_Verify tasks menu on employer home page
	Given the Employer logins using existing Levy Account
	When current date is in range <16> - <19>
	Then display task: 'Levy declaration due by 19 <MMMM>'
	When there are X apprentice change(s) to review
	Then display task: '<X> apprentice change(s) to review'
	And 'View changes' link should navigate user to 'Manage your apprentices' page
	When there are X cohort(s) ready for approval
	Then display task: '<X> cohort(s) ready for approval'
	And 'View cohorts' link should navigate user to 'Apprentice Requests' page
	When there is pending Transfer requestready for approval
	Then display task: Transfer request received'
	And 'View details' link should navigate user to 'Transfers (../transfers/connections)' page
	When there are X transfer connection request(s) to review
	Then display task: '<X> connection request(s) to review'
	And 'View details' link should navigate user to 'Transfers (../transfers/connections)' page
	When there are X transfer pledge applications awaiting your approval
	Then display task: '<X> transfer pledge applications awaiting your approval'
	And 'View applications(s)' link should navigate user to ‘My Transfer Pledges’ page