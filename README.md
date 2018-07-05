# Project Title

Color Resistor Calculator

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.
The solution consists of ApplicationCore, Web, and Test projects.
### Prerequisites

This project built using .NET Core 2.0 MVC.You also need to rebuild solution in order to download all dependencies.
Beside that, I used Moq, XUnit test, and Selenium Webdriver for test projects.

## Running the tests

There are three different types of automated test; Unit Test, Functional Test, and Integration UI Test.


### UI Test

Before running Integration UI test, you simply need to start project in IIS Express or local IIS, and then change the url test variable in Integration UI test project.

The default test URL was set to
```
 string testUrl = @"http://localhost:50337/";
```

The Integration UI test used Selenium webdriver; ChromeDriver. You may also need to change the chrome driver directory where you put it.
In the code, I set chrome directory to the environment folder.

### Unit Test & Functional Test

I have wrote some test cases for automated unit test. Mock framework has been used to mock dependencies for the ApplicationCore.


## Built With

* [.NET Core 2.0] - The web framework used
* [XUnit Test] - Test framework used
* [Moq] - Mocking framework used
* [Selenium Webdriver] - Used for UI automated test

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details
