Feature: RV2_E_DHFD_01
As a Non Levy Employer, I want to add a vacancy after reserves funding from dynamic homepage
	

@raa-v2
@raa-v2e
@regression
@dynamichomepage
@addpayedetails
Scenario: AP_DH_01 Employer reserves funding to add an apprentices from dynamic homepage journey
	Given the User creates Employer account and sign an agreement
	When the Employer reserves funding for an apprenticeship course from reserved panel
	Then the funding is successfully reserved
	And the new reserved funding panel is shown to employer on the homepage
	And the employer continue to add vacancy in the Recruitment 
	Given the Employer completes the first part of the journey
	When the Employer saves the vacancy as a draft
	And the vacancy details is displayed on the Dynamic home page with Status 'Saved as draft'
	Then Employer is able to open the draft and create the vacancy by filling the data for the second part
	And the vacancy details is displayed on the Dynamic home page with Status 'Submitted'	
	Given the Reviewer Refer the vacancy
	And the vacancy details is displayed on the Dynamic home page with Status 'Saved as draft'
	
	

	
	