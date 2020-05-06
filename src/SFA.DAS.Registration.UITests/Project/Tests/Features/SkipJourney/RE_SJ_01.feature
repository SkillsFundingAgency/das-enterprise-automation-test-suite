Feature: RE_SJ_01

@regression
@registration
@addpayedetails
Scenario: RE_SJ_01_Verify GG route skip journey
	When an Employer creates an Account by skipping the add PAYE part
	Then ApprenticeshipEmployerType in Account table is marked as 2
	When the Employer chooses to add PAYE from Account Home Page
	Then the Employer is able to add PAYE and Organisation to the Account
	And ApprenticeshipEmployerType in Account table is marked as 0