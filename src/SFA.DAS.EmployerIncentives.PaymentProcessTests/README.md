# Running tests in local (dev) environment
### SFA.DAS.EmployerIncentives.PaymentProcessTests
1. Ensure  `appsettings.Environment.json` file is targeting `DEV` environment:
```json
{
  "local_EnvironmentName": "DEV",
  "ProjectName": "EmployerIncentives"
}
```
2. add the following minimum configuration to `%APPDATA%/Microsoft/UserSecrets/EmployerIncentives_DEV_Secrets` folder (note: this is for the profile which VS runs under):
​
```json
{
  "EIPaymentProcessConfig": {
    "EI_PaymentsAppCode": "",
    "EI_PaymentsAppBaseUrl": "http://localhost:7071",
    "EI_ApiStubBaseUrl": "https://at-stub.apprenticeships.education.gov.uk",
    "EI_ServiceBusConnectionString": "UseLearningEndpoint=true",
    "LearningTransportStorageDirectory": "c:\\temp\\learningtransport"
  },
  "DbDevConfig": {
    "Server": "(localdb)\\MSSQLLocalDB",
    "ConnectionDetails": "Integrated Security=True;Trusted_Connection=False;Pooling=False;Connect Timeout=30;MultipleActiveResultSets=True",
    "EmployerIncentivesDbName":"SFA.DAS.EmployerIncentives.Database"
  }
}
```

### SFA.DAS.EmployerIncentives

1. Ensure the `local.appsettings.json` or `appsettings.development.json` file in the `FA.DAS.EmployerIncentives.Api`, `SFA.DAS.EmployerIncentives.Functions.DomainMessageHandlers` and `SFA.DAS.EmployerIncentives.Functions.PaymentsProcess` projects contains the following:

```json
  "ApplicationSettings": {
    "DbConnectionString": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SFA.DAS.EmployerIncentives.Database;Integrated Security=True;Pooling=False;Connect Timeout=30;MultipleActiveResultSets=True",
    "NServiceBusConnectionString": "UseLearningEndpoint=true",
    "UseLearningEndpointStorageDirectory": "c:\\temp\\learningtransport"
  },
  "BusinessCentralApi": {
    "ApiBaseUrl": "https://at-stub-api.apprenticeships.education.gov.uk/businesscentral/",
    "SubscriptionKey": "",
    "ApiVersion": "2020-10-01",
    "PaymentRequestsLimit": 1000
  },
  "MatchedLearnerApi": {
    "ApiBaseUrl": "https://at-stub-api.apprenticeships.education.gov.uk/learner-match/",
    "ClientId": "",
    "Version": "1"
  }
```

The value for `UseLearningEndpointStorageDirectory` must match the value used in `SFA.DAS.EmployerIncentives.PaymentProcessTests`

2. Set the `SFA.DAS.EmployerIncentives.Api`, `SFA.DAS.EmployerIncentives.Functions.DomainMessageHandlers` and `SFA.DAS.EmployerIncentives.Functions.PaymentsProcess` projects projects as start up projects
3. Ensure `SFA.DAS.EmployerIncentives.Database` has been published from the branch you're working on.

### Running the tests

1. Run the 3 projects from the `SFA.DAS.EmployerIncentives` solution
2. Run the tests