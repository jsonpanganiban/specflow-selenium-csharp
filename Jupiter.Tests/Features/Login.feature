Feature: Login

@loginFailure
Scenario: Invalid Login
	Given I navigate to Login
	When I enter invalid credentials
	| Username		| Password |
	| trtrtttdadsad | qweqwew  | 

	Then Message Your login details are incorrect should be displayed