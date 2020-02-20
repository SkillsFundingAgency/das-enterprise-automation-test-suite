Feature: EF_HPFL_01

@regression
@registration
@addpayedetails
Scenario: EF_HPFL_01 - Validate Home Page Finance section for a NonLevy User who has Signed Agreement
	When an Employer creates a Non Levy Account and Signs the Agreement
	Then Check funding availability and make a reservation link is displayed on the Employer Home Page
	And  Your funding reservations and Your finances links are displayed in the Finances section
	When the Employer clicks on Check funding availability and make a reservation link
	Then 'Reserve funding to train' page is displayed
	#When the Employer clicks on 'Your funding reservations' link
	#Then 'Your funding reservations' page is displayed with 'Your funding reservations' message
	#When the Employer clicks on 'Your finances' link
	#Then 'Finance' page is displayed with 'view transactions','Transfers' and 'Download transactions' links