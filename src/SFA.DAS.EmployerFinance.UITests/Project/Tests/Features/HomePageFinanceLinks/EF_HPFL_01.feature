Feature: EF_HPFL_01

@regression
@employerfinance
@addpayedetails
Scenario: EF_HPFL_01 - Validate Home Page Finance section for a NonLevy User who has Signed Agreement
	When an Employer creates a Non Levy Account and Signs the Agreement
	Then Check funding availability and make a reservation link is displayed on the Employer Home Page
	And  Your funding reservations and Your finances links are displayed in the Finances section
	And Employer is able to navigate the Check the funding availability and make a reservation link on the Home Page
	And Employer is able to navigate the Your funding reservations link from 'Finances' section on the Home Page
	When Employer navigates the Your finances link from 'Finances' section on the Home Page
	Then 'Finance' page is displayed with View transactions, Download transactions and Transfers links