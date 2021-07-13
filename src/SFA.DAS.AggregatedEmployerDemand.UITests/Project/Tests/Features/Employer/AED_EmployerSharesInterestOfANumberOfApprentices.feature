Feature: AED_EmployerSharesInterestOfANumberOfApprentices

@aed
@regression
Scenario: AED_ESIOANOA_01_ShareInterestOfANumberOfApprentices
	Given the User searches a course then navigates to the provider list
	And the user selects get help with finding a training provider
	When the user enters the number of Apprentices as '2'
	And the user enters the location as 'Coventry, West Midlands' 
	And the user enters the Organisation name 'Quinton Testing Ltd'
	And the user enters the Organisation Email Address 'quintontestingltd@mailinator.com'
	Then the user is able to submit the form to register interest
	And confirm the user is able to verify the email 'quintontestingltd@mailinator.com'

Scenario: AED_ESIOANOA_02_ShareInterestWithNoNumberOfApprentices
	Given the User searches a course then navigates to the provider list
	And the user selects get help with finding a training provider
	When the user selects no Apprentices
	And the user enters the location as 'Coventry, West Midlands' 
	And the user enters the Organisation name 'Quinton Testing Ltd'
	And the user enters the Organisation Email Address 'quintontestingltd@mailinator.com'
	Then the user is able to submit the form to register interest
	And confirm the user is able to verify the email 'quintontestingltd@mailinator.com'
