Feature: Poker
	In order to have fun beating my friends
	As a poker player
	I want to know when I win a hand

Scenario: Flush beats straight
	Given a new hand of poker
	When player 1 has a hand with the card Two of Hearts
	And player 1 has a hand with the card Three of Clubs
	And player 1 has a hand with the card Five of Clubs
	And player 1 has a hand with the card Six of Spades
	And player 1 has a hand with the card Four of Spades

	And player 2 has a hand with the card Two of Diamonds
	And player 2 has a hand with the card Six of Diamonds
	And player 2 has a hand with the card King of Diamonds
	And player 2 has a hand with the card Ace of Diamonds
	And player 2 has a hand with the card Four of Diamonds
	Then player 2 should win

Scenario: Flush beats straight (table)
	Given a new hand of poker
	When player 1 has a hand with the cards
	| Value | Suit   |
	| Two   | Hearts |
	| Three | Clubs  |
	| Five  | Clubs  |
	| Six	| Spades |
	| Four	| Spades |
	And player 2 has a hand with the cards
	| Value| Suit     |
	| Two  | Diamonds |
	| Six  | Diamonds |
	| King | Diamonds |
	| Ace  | Diamonds |
	| Four | Diamonds |
	Then player 2 should win
