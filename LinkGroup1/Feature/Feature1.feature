﻿ Feature: Link Group(Required)
 

Scenario: Smoke test
		When I open the home page
		Then the page is displayed

Scenario: Search results
		Given I open the home page
		And I have agreed to the cookie policy
		When I search for 'Leeds'
		Then the search results are displayed