Feature: RV2_E_DHFD_01
As a Non Levy Employer, I want to add a vacancy after reserves funding from dynamic homepage
	

@raa-v2
@raa-v2e
@regression
@addpayedetails
@ignore
Scenario: RV2_E_DHFD_01 Employer creates a draft vacancy from dynamic homepage journey
	Given the user reserves funding from the dynamic home page
	And the employer continue to add vacancy in the Recruitment 
	When the Employer creates first Draft vacancy 'National Mininum Wage'
	Then the vacancy details is displayed on the Dynamic home page with Status 'DRAFT'
	And Employer can continue creating an advert