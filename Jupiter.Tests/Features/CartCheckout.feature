Feature: Shop
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario Outline: Cart Checkout
	Given  I navigate to Shopping page
	When I buy item
	| Item        |
	| Teddy Bear  |
	| Smiley Face |
	And I capture item price
	| Item        |
	| Teddy Bear  |
	| Smiley Face |
	And I navigate to Cart page
	Then Correct price for item is displayed
	| Item        |
	| Teddy Bear  |
	| Smiley Face |

	When I update quantity of item
	| Item        | Quantity |
	| Teddy Bear  | 2        |
	| Smiley Face | 3        | 
	Then Subtotal for each item should be correct
	| Item        |
	| Teddy Bear  |
	| Smiley Face |

	Given I proceed to check out
	When I fill out delivery and payment details
	| Forename | Email                         | Address  | Card Type | Card Number         |
	| Jayson   | jpanganiban@planittesting.com | St Kilda | Visa      | 1234 9876 1234 9876 |
	
	And I submit order
	Then Success message should be displayed