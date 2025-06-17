Feature: RE_CEACHT_02

@regression
@registration
@addnonlevyfunds
Scenario: RE_CEACHT_02_Create an Employer Account with CompanyType Organisation and Add another Org of Charity Type
	When an Employer Account with Company Type Org is created and agreement is Signed
	And the Employer initiates adding another Org of Charity Type
	Then the Employer is able check the details of the Charity Org added are displayed in the 'Check your details' page and Continue