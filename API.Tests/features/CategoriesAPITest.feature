@Categories
Feature: To verify the data present in the response sent by Categories API endpoint

Background: Set API endpoint
    Given there is a categories API endpoint

@Smoke
Scenario Outline: To verify the status code of the response
    When a GET request is made to a <specificCategory>
    Then the status code is <statusCode>

    Examples:
        | specificCategory | statusCode |
        | 6327            | 200        |

Scenario Outline: To verify the data of certain properties returned in the repsonse from the endpoint
    When a GET request is made to a <specificCategory>
    Then the name property is <name>
    And  the category can relist
    And  the promotions element contains <promotionName> with description <promotionDescription>

    Examples:
        | specificCategory | name           | promotionName | promotionDescription      |
        | 6327            | Carbon credits | Gallery       | Good position in category |