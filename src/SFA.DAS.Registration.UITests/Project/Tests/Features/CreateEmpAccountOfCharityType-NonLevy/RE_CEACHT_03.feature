Feature: RE_CEACHT_03

@regression
@registration
@addpayedetails
Scenario: RE_CEACHT_03_Create an Employer Account with Charity Type Org Whose Address is Not in the Charity Commission database
	When an Employer initiates adding an Org of Charity Type Whose Address is Not in the Charity Commission database
	And adds the Organisation address details manually
	Then the Employer is able check the details entered in the 'Check your details' page and complete registration