![Build Status](https://sfa-gov-uk.visualstudio.com/_apis/public/build/definitions/c39e0c0b-7aff-4606-b160-3566f3bbce23/715/badge)

# DFE-STANDARDISED-TEST-AUTOMATION-FRAMEWORK

This is a SpecFlow-Selenium functional testing framework created using Selenium WebDriver with NUnit and C# in SpecFlow BDD methodology and Page Object Pattern.

## Prerequisites to run the application:
1. Visual Studio
2. Browsers (Chrome, Firefox, IE)

## Set Up:
All other dependencies (ex: Selenium, drivers etc) are packaged within the solution using NuGet package manager. Once the solution is imported and built all the dependencies will be available within the solution.

Note: This framework is built with all standard libraries and ready to write new tests, an example test is also provided for reference. However solution, project & namespace must be renamed before writing tests.

## Automated SpecFlow Tests:
Acceptance Tests must be written in Feature files (Project/Tests/Features/) using standard Gherkin language using Given, When, Then format with an associated step definition for each test step. Test steps in the scenarios explains the business conditions/behaviour and the associated step definition defines how the individual scenario steps should be automated.

A tag must be provided (ex: @Regression, @Smoke) for each test scenario which groups the tests, this provides the option to select which group of tests to execute.

## Running Tests:
Once the solution is imported and built, open Test Explorer window (Test->Windows->Test Explorer) which shows all the tests generated from the feature files using the scenario titles. From Test Explorer, we can choose to run
1. All Tests
2. Failed/Passed/NotRun Tests
3. Select a particular scenario to Run/Debug

## Framework:

### Multiple Environments:
The framework is designed to execute the tests on multiple environments.
1. All the default details specific to environment (Ex: Url, Credentials etc) are defined in App.config file.
2. EnvironmentConfigurator (Project/Tests/TestSupport/) reads the data from App.Config and stores the values in variables. Which then can be used during the tests.
3. Tests can be executed on multiple environments by replacing the default values provided in App.Config using Configuration Manager and transforming the data

### Supported Browsers: The framework can currently work on the following browsers
1. Chrome
2. Firefox
3. PhantomJs (Headless browser)

Note: Tests can be executed on different browsers using BrowserStack

### Standards/Rules:
1. The framework is designed using Page Object Model
2. Every class must implement single responsible principle. Where,
	a. Every Page class is responsible for only one web page and identifying the elements within the page and implementing methods a user can do on that page
	b. Every Test Class is responsible to access the methods from Page Classes and execute the test steps with required data
	c. Helper classes are just responsible for assisting the user with reusable methods to easily interact with the web page, Database and API.
3. Each test must be independent of other tests
4. Where possible create the users/data on runtime and clear the users/data at the end of the tests
5. Every Page class must extend BasePage (Project/Tests/TestSupport/BasePage) and implement the methods from it, which initiate the elements and waits for the page to load and verifies the current page
6. Every Test class must extend BaseTest (Project/Tests/TestSupport/BaseTest), which provides the instance of WebDriver to the test classes

### Helpers: The framework has the following helper classes to assist the testing (Project/Framework/Helpers/)
1. FormCompletionHelper - Which helps most of the user actions on a page
2. PageInteraction - Helps verifying data and elements on the page
3. RandomDataHelper - Helps creating random data to use
4. HttpClientRequestHelper - Helps making some HTTP requests (POST, PUT, GET, DELETE, PATCH)
5. SqlDatabaseConnectionHelper - Helps connecting to the SQL Database to read and write the data from Database

## Some selenium best practices:
1. Use PageObject pattern
2. Preferred selector order: id > name > css > xpath
3. Avoid Thread.sleep prefer WebDriverWaits
4. Create your data set
5. Tests must be independent from other tests
6. Don't use static user/data, create a user/data for every test and delete the user/data after the test is completed