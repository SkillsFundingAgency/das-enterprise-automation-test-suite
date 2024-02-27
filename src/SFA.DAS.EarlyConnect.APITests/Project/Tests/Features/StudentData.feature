Feature: StudentData
The API system should allow valid student data to be posted successfully 

@api
@earlyconapi
@regression
Scenario Outline: Verify valid student data post 
	When the user sends <Method> request to <Endpoint> with payload <Payload>
	Then api <ResponseStatus> response is received


	Examples: 
| TestCaseId | Method | Endpoint                        | Payload			| ResponseStatus   |
| EC201      | POST   | /early-connect/student-data/add |  StudentData.json | Created		   |	



 
	
