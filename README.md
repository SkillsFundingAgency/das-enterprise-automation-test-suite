![Build Status](https://sfa-gov-uk.visualstudio.com/_apis/public/build/definitions/c39e0c0b-7aff-4606-b160-3566f3bbce23/715/badge)

# DFE-STANDARDISED-TEST-AUTOMATION-FRAMEWORK

This is a SpecFlow-Selenium functional testing framework created using Selenium WebDriver with NUnit and C# in SpecFlow BDD methodology and Page Object Pattern.

## Prerequisites to run the application:
1. Visual Studio
2. Browsers (Chrome, Firefox, IE)

## Set Up:
All other dependencies (ex: Selenium, drivers etc) are packaged within the solution using NuGet package manager. Once the solution is imported and built all the dependencies will be available within the solution.

Note: This framework is built with all standard libraries and ready to write new tests, an example test is also provided for reference. However solution, project & namespace must be renamed before writing tests.

## How to use User secrets
1. Navigate to "%APPDATA%/Microsoft" Create Directory "UserSecrets" if you dont find it.
2. Create a folder under "%APPDATA%/Microsoft/UserSecrets" folder in the format <ProjectName>_<EnvironmentName>_Secrets. You can get project name and environment name from appsettings.Environment.json project specific file
3. Create a file "secrets.json" and replace only those values you want to keep it as secrets (copy the structure from appsettings.Project.json file)

## Automated SpecFlow Tests:
Acceptance Tests must be written in Feature files (Project/Tests/Features/) using standard Gherkin language using Given, When, Then format with an associated step definition for each test step. Test steps in the scenarios explains the business conditions/behaviour and the associated step definition defines how the individual scenario steps should be automated.

A tag must be provided (ex: @Regression, @Smoke) for each test scenario which groups the tests, this provides the option to select which group of tests to execute.

## Running Tests:
Once the solution is imported and built, open Test Explorer window (Test->Windows->Test Explorer) which shows all the tests generated from the feature files using the scenario titles. From Test Explorer, we can choose to run
1. All Tests
2. Failed/Passed/NotRun Tests
3. Select a particular scenario to Run/Debug

## To Execute tests in Local :
1. To execute tests in your local, change the Browser value to "local" (will execute in chrome) or "chrome" or "googlechrome",  "firefox" or "mozillafirefox", "ie" or "internetexplorer".
2. To execute tests through Zap Proxy, change the Browser value to "zapProxyChrome"
```json
{
  "Browser": "chrome"
}
```

## To Execute tests in Browserstack / Cloud :
To execute tests in BrowserStack, change the Browser value to "browserstack" or "cloud" in ``appsettings.Project.json`` your project specific appsettings file (you can add the node if node does not exists)
```json
{
  "Browser": "browserstack"
}
```

## Running Tests from Command Prompt:

```
c:\> dotnet test C:\SFA\DFE-Standardised-Test-Automation-Framework\src\ESFA.UI.Specflow.TestProject\ESFA.UI.Specflow.TestProject.csproj --filter "TestCategory=regression|TestCategory=anotherregression"

c:\> dotnet vstest C:\SFA\DFE-Standardised-Test-Automation-Framework\src\SFA.DAS.PocProject.UITests\SFA.DAS.PocProject.UITests.dll /TestCaseFilter:"TestCategory=regression|FullyQualifiedName=Namespace.ClassName.MethodName"
```


## Framework:

### Supported Browsers: The framework can currently work on the following browsers
1. Chrome - use "chrome", "googlechrome" or "local" as values for the Browser in appsettings
2. Firefox - use "firefox" or "mozillafirefox" as values for the Browser in appsettings
3. Internet Explorer - use "ie" or "internetexplorer" as values for the Browser in appsettings
3. Chrome Headless - use "headlessbrowser" or "headless" as values for the Browser in appsettings

Note: Tests can be executed on different browsers using BrowserStack. Tests can also be run in headless mode using the Chrome headless browser.

### Standards/Rules:
1. The framework is designed using Page Object Model
2. Every class must implement single responsible principle. Where,
	a. Every Page class is responsible for only one web page and identifying the elements within the page and implementing methods a user can do on that page
	b. Every Test Class is responsible to access the methods from Page Classes and execute the test steps with required data
	c. Helper classes are just responsible for assisting the user with reusable methods to easily interact with the web page, Database and API.
3. Each test must be independent of other tests
4. Where possible create the users/data on runtime and clear the users/data at the end of the tests
5. Every Page class must extend BasePage (Project/Tests/TestSupport/BasePage) and implement the methods from it, which initiate the elements and waits for the page to load and verifies the current page

### Helpers: The framework has the following helper classes to assist the testing (Project/Framework/Helpers/)
1. FormCompletionHelper - Which helps most of the user actions on a page
2. PageInteraction - Helps verifying data and elements on the page
3. RandomDataHelper - Helps creating random data to use
4. HttpClientRequestHelper - Helps making some HTTP requests (POST, PUT, GET, DELETE, PATCH)
5. SqlDatabaseConnectionHelper - Helps connecting to the SQL Database to read and write the data from Database
6. CosmosActionPerformerHelper - Helps connecting to Cosmos DB to read and write the data
7. CosmosConnectionHelper - Provides assistance to CosmosActionPerformerHelper by creating DocumentClient and DocumentRepository

## Some selenium best practices:
1. Use PageObject pattern
2. Preferred selector order: id > name > css > xpath
3. Avoid Thread.sleep prefer WebDriverWaits
4. Create your data set
5. Tests must be independent from other tests
6. Don't use static user/data, create a user/data for every test and delete the user/data after the test is completed

## Parallel Test Execution Limitations:

This framework supports Feature Level parallelization (tests under different feature file will run in parallel) not Scenario Level parallelization (tests under same feature file will not execute in parallel).

Note : referenced from https://github.com/techtalk/SpecFlow/issues/1599, https://github.com/techtalk/SpecFlow/issues/1535

## Parallel Test Execution in Azure DevOps:

By default up to all available cores on the machine may be used, we can use /Parallel argument to restrict the no of tests to be executed in parellel 

## No of Threads in parallel test execution
If LevelOfParallelism is not specified, workers defaults to the number of processors on the machine, or 2, whichever is greater.
1. You can specify no of threads to use in the parameter : ``[assembly: LevelOfParallelism(2)]``
2. You can specify 0 to exeute tests in sequential order : ``[assembly: LevelOfParallelism(0)]``
