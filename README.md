[![Build Status](https://dev.azure.com/sfa-gov-uk/Digital%20Apprenticeship%20Service/_apis/build/status/das-enterprise-automation-test-suite?branchName=master)](https://dev.azure.com/sfa-gov-uk/Digital%20Apprenticeship%20Service/_build/latest?definitionId=1678&branchName=master)

# DAS-ENTERPRISE-AUTOMATION-TEST-SUITE

This is a SpecFlow-Selenium functional testing framework created using Selenium WebDriver with NUnit and C# (.Net core) in SpecFlow BDD methodology and Page Object Pattern.

## Prerequisites to run the application:
1. Visual Studio (2017 with V15.9 or higher). Please check and upgrade your IDE if this is not the case.
2. Download appropriate 'Dot Net Core 3.1' version matching Visual Studio version. NOTE: If you have been using .NET Framework so far, you might not have this installed in your computer at the moment. 
3. Browsers (Chrome, Firefox, IE)

## Set Up:
All other dependencies (ex: Selenium, drivers etc) are packaged within the solution using NuGet package manager. Once the solution is imported and built all the dependencies will be available within the solution.

Note: This framework is built with all standard libraries and ready to write new tests, an example test is also provided for reference. However solution, project & namespace must be renamed before writing tests.

## Steps to add a new test project:

1. Right click the solution and add a ```Nunit Test Project (.Net core)``` project
	- please use naming format (SFA.DAS.YourProjectName.UITests)
	- you can remove the UnitTest1.cs file added by default
	- update ```<PropertyGroup>``` node in the .csproj file to include ```<RootNamespace>``` 
	```text
	<PropertyGroup>
		<TargetFramework>netcoreapp3.1</TargetFramework>
		<RootNamespace>SFA.DAS.YourProjectName.UITests</RootNamespace>
		<IsPackable>false</IsPackable>
	</PropertyGroup>
	```
2. Add nuget depedencies ( you can edit the csproj file or you can choose to add it via nuget package manager either way make sure you add the same version as other projects)
	- Microsoft.NET.Test.Sdk
	- NUnit3TestAdapter
	- Selenium.WebDriver.ChromeDriver
	- SpecFlow.Tools.MsBuild.Generation
	- SpecFlow.NUnit
	
3. Copy the below code to .csproj file to add link to nunitconfiguration.cs and specflow.json files
```text
	<ItemGroup>
		<Compile Include="..\NUnitConfigurator.cs" Link="NUnitConfigurator.cs">
			<CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
		</Compile>
	</ItemGroup>

	<ItemGroup>
		<Content Include="..\specflow.json" Link="specflow.json">
			<CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
		</Content>
	</ItemGroup>
```

4. Add ```SFA.DAS.YourProjectName.UITests.json```

``` json
{
  "runtimeOptions": {
    "tfm": "netcoreapp3.1",
    "framework": {
      "name": "Microsoft.NETCore.App",
      "version": "3.1.5"
    }
  }
}
```
5. Add ```appsettings.Environment.json```
```json
{
  "local_EnvironmentName": "PP",
  "ProjectName": "YourProjectName"
}
```
6. Add ```appsettings.Project.BrowserStack.json```
```json
{
  "BrowserStackSetting": {
    "build": "SFA.DAS.YourProjectName.UITests"
  }
}
```
7. Add ```appsettings.Project.json``` (the project specific config)
```json
{
  "YourProjectNameConfig": {
    "ABC": "__ABC__"
  }
}
```
8. Add the following mandatory references to the .csproj file 
```text
	<ItemGroup>
		<ProjectReference Include="..\SFA.DAS.TestDataExport\SFA.DAS.TestDataExport.csproj" />
		<ProjectReference Include="..\SFA.DAS.ConfigurationBuilder\SFA.DAS.ConfigurationBuilder.csproj" />
		<ProjectReference Include="..\SFA.DAS.UI.Framework\SFA.DAS.UI.Framework.csproj" />
	</ItemGroup>
```
Please follow existing folder structure, folder name and file name so that it would be consistent with other project structure and naming conventions

## How to use User secrets:
1. Navigate to ```"%APPDATA%/Microsoft"``` then Create Directory ```"UserSecrets"``` if you don't find it.
2. Create a ```<YourProjectName>_<EnvironmentName>_Secrets``` folder under ```"%APPDATA%/Microsoft/UserSecrets"```. You can get project name and environment name from the ```"appsettings.Environment.json"``` file under your respective project(s). ex: 
	For Registration project, the ```"appsettings.Environment.json"``` file will look like 
```json
{
  "local_EnvironmentName": "PP",
  "ProjectName": "Registration"
}
```
so you need to create a folder as ```"Registration_PP_Secrets"``` (without the quotes) under ```"%APPDATA%/Microsoft/UserSecrets"``` folder 
	
3. Create a file named ```"secrets.json"``` and replace only those values you want to keep it as secrets (you can copy the structure from ```"appsettings.Project.json"``` file under your respective project(s)).

## Automated SpecFlow Tests:
Acceptance Tests must be written in Feature files under ```/Project/Tests/Features/``` folder using standard Gherkin language using Given, When, Then format with an associated step definition for each test step. Test steps in the scenarios explains the business conditions/behaviour and the associated step definition defines how the individual scenario steps should be automated.

## Specflow scenario tagging 

1. Mandatory tags (these mandatory tags are used for test execution)
	- ```@regression``` (these scenarios will be picked up by enterprise test suite)
	- ```@<yourprojectname>``` (these scenarios will be picked up by project specific test suite)
2. Reserved tags (these reserved tags are either used to drive the framework or to create test data)
	- ```@levy, @nonlevy, @addpayedetails, @addtransferslevyfunds, @addlevyfunds, @donottakescreenshot``` (in registration)
	- ```@liveapprentice, @waitingtostartapprentice, @currentacademicyearstartdate, @onemonthbeforecurrentacademicyearstartdate, @selectstandardcourse``` (in approvals)
	- any tag starts with perf for ex : ```@perftestnonlevy, @perftestlevy``` (used to create test data for performance tests)
3. Optional tags / requirement specific tags
	- you can tag a scenario based on your interest / requirment for ex ```@<yourprojectnamee2e>``` - indicates e2e scenario 
	- naming convention - all tags should be specified in lower cases and should start with your project name for ex: ```@<yourprojectnamee2e>```
4. Non specflow tests
	- its not mandatory to tag non specflow tests for ex: Unit tests.

## To Execute tests from your desktop :

### To Execute tests in your desktop :
1. To execute tests in your local, change the Browser value to "local" (will execute in chrome) or "chrome" or "googlechrome",  "firefox" or "mozillafirefox", "ie" or "internetexplorer" in ``secrets.json`` in your project specific secrets file (you can add the below section into it if it does not exist already).
2. To execute tests through Zap Proxy, change the Browser value to "zapProxyChrome"
```json
"TestExecutionConfig": {
    "Browser": "local"
  }
```

### To Execute tests from your desktop but in Browserstack / Cloud :
To execute tests in BrowserStack, change the Browser value to "browserstack" or "cloud" in ``secrets.json`` in your project specific secrets file (you can add the below section into it if it does not exist already)
```json
"TestExecutionConfig": {
    "Browser": "cloud"
  }
```
To mention BrowserStack login details, create a folder by name "BrowserStackSecrets" (without the quotes) under "%APPDATA%/Microsoft/UserSecrets", create a file names "secrets.json" and add below section with your BrowserStack username and key (You can get the Access Key from BrowserStack application).
```json
{
  "BrowserStackSetting:User": "XXX",
  "BrowserStackSetting:Key": "XXX",
}
```

### To Execute tests from your desktop via Test Explorer:
Once the solution is imported and built, open Test Explorer window ```(Test->Windows->Test Explorer)``` which shows all the tests generated from the feature files using the scenario titles. From Test Explorer, we can choose to run
1. All Tests
2. Failed/Passed/NotRun Tests
3. Select a particular scenario to Run/Debug


### To Execute tests from your desktop via Command Prompt:

```
c:\> dotnet test C:\SFA\DFE-Standardised-Test-Automation-Framework\src\ESFA.UI.Specflow.TestProject\ESFA.UI.Specflow.TestProject.csproj --filter "TestCategory=regression|TestCategory=anotherregression"

c:\> dotnet vstest C:\SFA\DFE-Standardised-Test-Automation-Framework\src\SFA.DAS.PocProject.UITests\SFA.DAS.PocProject.UITests.dll /TestCaseFilter:"TestCategory=regression|FullyQualifiedName=Namespace.ClassName.MethodName"
```

## Build and Release process:

### Build 
Every commit made (merge to master or a push to remote branch) will trigger a build process under `das-enterprise-automation-test-suite` pipeline using `azure-pipelines.yml` in Azure Devops which can then be deployed to a Release pipeline (where you can select a pipeline and specify the Browser and Test category value).

### Release 
Every release pipeline would be picking up the build artifact from `das-enterprise-automation-test-suite` build

Every weekday (morning between 12 to 5) most of the release pipeline is scheduled to execute against latest master which will give us an idea of the state of the appication.

### Variables
We use variable groups (library) to define and declare the variables, and the values will be shared among the piepline to avoid duplication. They are
```
 1. TEST Automation Suite Variables - will hold variables for TEST environment
 2. TEST2 Automation Suite Variables - will hold variables for TEST2 environment
 3. PreProd Automation Suite Variables - will hold variables for PP environment
 4. Release Automation Suite Variables - will hold variables at Release Level
 5. Release Automation Suite Variables (Db) - will hold DB variables at Release environment
```
Any pipeline specfic variables like ```SQLServerAccountPassword, CosmosDBKey, ServiceBusAccessKey, Browser and TestCategory``` would be define and declare under pipeline private variables

### Variable scope
If the variables are defined in more than one place then vsts will prioritize in following order

	1. Environment specfic pipeline private variable  
	2. Release specific pipeline private variable
	3. Environment specfic variable group
	4. Release specific variable group

## Framework:

### Supported Browsers: 
The framework can currently work on the following browsers
1. Chrome - use "chrome", "googlechrome" or "local" as values for the Browser in appsettings
2. Firefox - use "firefox" or "mozillafirefox" as values for the Browser in appsettings
3. Internet Explorer - use "ie" or "internetexplorer" as values for the Browser in appsettings
3. Chrome Headless - use "headlessbrowser" or "headless" as values for the Browser in appsettings

Note: Tests can be executed on different browsers versions using BrowserStack.

### Standards/Rules:
1. The framework is designed using Page Object Model
2. Every class must implement single responsible principle. Where,
	a. Every Page class is responsible for only one web page and identifying the elements within the page and implementing methods a user can do on that page
	b. Every Test Class is responsible to access the methods from Page Classes and execute the test steps with required data
	c. Helper classes are just responsible for assisting the user with reusable methods to easily interact with the web page, Database and API.
3. Each test must be independent of other tests
4. Where possible create the users/data on runtime and clear the users/data at the end of the tests
5. Every Page class must extend BasePage (Project/Tests/TestSupport/BasePage) and implement the methods from it, which initiate the elements and waits for the page to load and verifies the current page

### Helpers: 
The framework has the following helper classes under ```SFA.DAS.UI.FrameworkHelpers``` project to assist the testing, key helpers are
1. FormCompletionHelper - Which helps most of the user actions on a page
2. PageInteractionHelper - Helps verifying data and elements on the page
3. RandomDataGenerator - Helps creating random data to use
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

we use the below run settings file to implement parellel execution in Azure Devops
```
<RunSettings>
	<RunConfiguration>
		<!-- 0 = As many processes as possible, limited by number of cores on machine, 1 = Sequential (1 process), 2-> Given number of processes up to limit by number of cores on machine-->
		<MaxCpuCount>1</MaxCpuCount>
		<!-- Disables in-assembly parallel execution, applies to both MSTest and NUnit -->
		<DisableParallelization>false</DisableParallelization>
	</RunConfiguration>

	<!-- Adapter Specific sections -->

	<!-- NUnit3 adapter, uncomment sections to set as appropriate, numeric, booleans, enums have their default values below, except RandomSeed -->
	<!-- For documentation, see https://github.com/nunit/docs/wiki/Tips-And-Tricks -->
	<NUnit>
		<NumberOfTestWorkers>__NumberOfTestWorkers__</NumberOfTestWorkers>
	</NUnit>
</RunSettings>
```
where ```__NumberOfTestWorkers__``` can be transformed using the piepline private variables.

By default up to all available cores on the machine may be used, we can use ```/Parallel``` argument or ```MaxCpuCount``` node to restrict the no of tests to be executed in parellel. 

By default we run 5 tests in parallel per docker instance, we can change it using ```__NumberOfTestWorkers__```

## Parallel Test Execution in your desktop:
If LevelOfParallelism is not specified, workers defaults to the number of processors on the machine, or 2, whichever is greater.
1. You can specify no of threads to use in the parameter : ``[assembly: LevelOfParallelism(2)]``
2. You can specify 0 to exeute tests in sequential order : ``[assembly: LevelOfParallelism(0)]``

By default we run 5 tests in parallel, you can change it under ```NUnitConfigurator.cs```
