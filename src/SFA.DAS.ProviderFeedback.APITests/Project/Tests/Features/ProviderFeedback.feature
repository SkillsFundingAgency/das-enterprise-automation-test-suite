Feature: ProviderFeedbackOuterApi

@api
@prvfbapi
@regression
Scenario: Verify ProviderFeedbackOuterApi returns expected response
	Given the user sends GET request to <Endpoint> without payload
	Then api <ResponseStatus> response is received
	And verify response body contains correct information for Ukprn '<Ukprn>'

	Examples: 
| Endpoint                                 | ResponseStatus | Ukprn    |
| /providerFeedback/10000528               | OK             | 10000528 |
| /providerFeedback/10000528/annual        | OK             | 10000528 |
| /providerFeedback/10000528/annual/AY2324 | OK             | 10000528 |