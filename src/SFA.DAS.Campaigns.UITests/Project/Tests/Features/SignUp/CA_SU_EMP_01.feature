Feature: CA_SU_EMP_01

Sign up to Emails as an Employer
@campaigns
@signup
@regression
Scenario: CA_SU_EMP_01_Sign Up to emails as an Employer with less than Ten employees
	Given the employer navigates to Sign Up Page
	When the employer fill Your details section
	And  Your Company by selecting radiobutton Less than Ten employees
	Then an employer registers interest

@campaigns
@signup
@regression
Scenario: CA_SU_EMP_02_Sign Up to emails as an Employer with between 10 and 49 employees
	Given the employer navigates to Sign Up Page
	When the employer fill Your details section
	And Your Company by selecting radiobutton Between Ten and FourtyNine employees
	Then an employer registers interest

@campaigns
@signup
@regression
Scenario: CA_SU_EMP_03_Sign Up to emails as an Employer with between 50 and 249 employees
	Given the employer navigates to Sign Up Page
	When the employer fill Your details section
	And Your Company by selecting radiobutton Between Fifty and TwoFourtyNine employees
	Then an employer registers interest

@campaigns
@signup
@regression
Scenario: CA_SU_EMP_04_Sign Up to emails as an Employer with over 250 employees
	Given the employer navigates to Sign Up Page
	When the employer fill Your details section
	And Your Company by selecting radiobutton Over TwoHundredandFifty employees
	Then an employer registers interest