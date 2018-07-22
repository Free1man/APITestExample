Feature: SpecFlowExample
	In order to pass the assessment
	I want to validate json  

@mytag
Scenario: ValidateJsonSpecflow
	When I send a request to v1/Categories/6327/Details.json?catalogue=false
	Then I should see value in the response at specific path
		| Path        | Value          |
		| $.Name      | Carbon credits |
		| $.CanRelist | True           |
	Then Value in the response at specific path should contain
		| Path                                           | Value           |
		| $.Promotions[?(@.Name=='Gallery')].Description | 2x larger image |

