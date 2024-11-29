Feature: EducationalOrganisationData

The API endpoint should retrieve valid educatonal organisations for their respective regions


@api
@earlyconapi
@earlyconnecteducationalorgansationsdata
@regression
Scenario Outline: Verify Api GET Educational Organisation Data finds schools by search term for the region
	When the user sends <Method> request to <Endpoint> with payload <Payload>
	Then api <ResponseStatus> response is received
	And verify response body displays correct '<School>' information
	And verify response body displays correct '<TotalCount>' information

	Examples: 
  | Method | Endpoint																			    | ResponseStatus | Payload | School								  | TotalCount |
  | GET    | /early-connect/educational-organisations-data?LepCode=E37000019&SearchTerm=Rawtenstall | OK             |         | Bacup and Rawtenstall Grammar School | 1          |
  | GET    | /early-connect/educational-organisations-data?LepCode=E37000025&SearchTerm=Longbenton  | OK             |         | Longbenton High School               | 1          |
  | GET    | /early-connect/educational-organisations-data?LepCode=E37000051&SearchTerm=Drapers     | OK             |         | Drapers Academy                      | 1          |

@api
@earlyconapi
@earlyconnecteducationalorgansationsdata
@regression
Scenario Outline: Verify invalid leps code returns 400 Bad request 
	When the user sends <Method> request to <Endpoint> with payload <Payload>
	Then api <ResponseStatus> response is received

   Examples: 
 | Method | Endpoint															 | Payload | ResponseStatus |
 | GET    | /early-connect/educational-organisations-data?LepCode=E22000012      |         | Bad Request    |
