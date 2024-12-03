Feature: EducationalOrganisationData

The API endpoint should retrieve valid educatonal organisations for their respective regions


@api
@earlyconapi
@earlyconnecteducationalorgansationsdata
@regression
Scenario Outline: EC_GAA_EDUC_01_SchoolSearchTerm - GET schools by search term for the regions
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
  Scenario Outline: EC_GAA_EDUC_02_RegionTotalSchools - API GET Total schools and colleges for the regions
    When the user sends <Method> request to <Endpoint> with payload <Payload>
	Then api <ResponseStatus> response is received
	And verify response body displays correct '<County>' information
	And verify response body displays correct '<TotalCount>' information

	Examples: 
  | Method | Endpoint                                                        | ResponseStatus |  County	   | TotalCount |
  | GET    | /early-connect/educational-organisations-data?LepCode=E37000019 | OK             |  Lancashire| 34         |
  | GET    | /early-connect/educational-organisations-data?LepCode=E37000025 | OK             |  North East| 82         |
  | GET    | /early-connect/educational-organisations-data?LepCode=E37000051 | OK             |  London    | 810         |
