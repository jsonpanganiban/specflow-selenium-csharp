Feature: LoginFailure
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@loginFailure
Scenario: Invalid Login
	Given I navigate to Login
	When I enter invalid credentials
	| Field    | Value   |
	| Username | adsad   |
	| Password | qweqwew | 

	Then Message Your login details are incorrect should be displayed