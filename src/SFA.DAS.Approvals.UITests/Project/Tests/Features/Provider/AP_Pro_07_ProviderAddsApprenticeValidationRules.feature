Feature: AP_Pro_07_ProviderAddsApprenticeValidationRules

@approvals
@regression
@provideraddapprentice
Scenario:AP_Pro_07_Provider Adds Apprentice Validation Rules
	Given Provider selects a NonLevy Employer and Standard
	Then Provider can an apprentice details from table below
 | Category					| ULN		| LastName 	 | FirstName  | DateOfBirth | EmailAddress	| StartDate   | EndDate		| TotalPrice | ErrorMessage |
 | ULN < 10				    | 171649120 | valid      | valid      | valid       | valid			| valid		  | valid		| valid      | You must enter a 10-digit unique learner number |
 | ULN-9999999999			| 9999999999| valid      | valid      | valid       | valid			| valid		  | valid		| valid      | You must enter a valid unique learner number |
 | EmailAddress 			| valid		| valid      | valid      | valid       | X@Y			| valid		  | valid		| valid      | Please enter a valid email address | 
 | DateOfBirth < 15 		| valid		| valid      | valid      | 2021-05-09  | valid			| valid		  | valid		| valid      | The apprentice must be at least 15 years old at the start of their training |  
 | DateOfBirth > 115		| valid		| valid      | valid      | 1904-05-01  | valid			| valid		  | valid		| valid      | The apprentice must be younger than 115 years old at the start of their training |
 | StartDate 			    | valid		| valid      | valid      | valid       | valid			| 2017-03-03  | valid		| valid      | The start date must not be earlier than May 2017 |  
 | EndDate 			        | valid		| valid      | valid      | valid       | valid			| 2021-03-03  | 2021-02-01  | valid      | The end date must not be on or before the start date | 
 | TotalPriceWithPence		| valid		| valid      | valid      | valid       | valid			| valid		  | valid		| 19.23      | The value '19.23' is not valid for Total agreed apprenticeship price (excluding VAT). |
 | TotalPrice > 100k 		| valid		| valid      | valid      | valid       | valid			| valid		  | valid		| 200000     | The total cost must be £100,000 or less          |
 | FirstNameEmpty			| valid		| valid		 |			  | valid		| valid			| valid		  | valid		| valid		 | First name must be entered	|
 | LastNameEmpty			| valid		| 			 | valid	  | valid		| valid			| valid	  	  | valid		| valid		 | Last name must be entered	| 
 | FirstName > 100			| valid		| valid		 | FirstNameFirstNameFirstNameFirstName FirstNameFirstNameFirstNameFirstNameFirstNames FirstNamesFirstNamesFirstNames	| valid		  | valid			| valid		  | valid		| valid		 | You must enter a first name that's no longer than 100 characters	|
 | LastName > 100			| valid		| LastNameLastNameLastNameFamily NameLastNameLastNameLastNameLastName LastNameLastNameLastNameLastNameLastName	| valid		| valid		  | valid			| valid		  | valid		| valid		 	| You must enter a last name that's no longer than 100 characters	|
 