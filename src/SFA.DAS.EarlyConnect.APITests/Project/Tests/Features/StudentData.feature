Feature: StudentData

A short summary of the feature

@api
@earlyconapi
@regression
Scenario Outline: Verify Student Data post 
	When the user sends <Method> request to <Endpoint> with payload <Payload>
	Then api <ResponseStatus> response is received


	Examples: 
| TestCaseId | Method | Endpoint                        | Payload			| ResponseStatus   |
| EC201      | POST   | /early-connect/student-data/add |  StudentData.json | OK		   |	



@api
@earlyconapi
@regression
Scenario Outline: Verify GET Metrics Data 
	When the user sends <Method> request to <Endpoint> with payload <Payload>
	Then api <ResponseStatus> response is received

	Examples: 
| TestCaseId | Method | Endpoint							  | Payload | ResponseStatus |
| EC222      | GET    | /early-connect/metrics-data/E37000025 |         |    OK          | 


 
	
