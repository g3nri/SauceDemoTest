Feature: Login Form Tests

  Scenario: UC-1 - Username is required
    Given I open the login page
    When I enter username "test" and password "test"
    And I clear both username and password fields
    And I click the login button
    Then I should see the error message "Epic sadface: Username is required"

  Scenario: UC-2 - Password is required
    Given I open the login page
    When I enter username "test" and password ""
    And I click the login button
    Then I should see the error message "Epic sadface: Password is required"

  Scenario Outline: UC-3 - Successful login
    Given I open the login page
    When I enter username "<username>" and password "secret_sauce"
    And I click the login button
    Then I should see the page title "Swag Labs"

    Examples:
      | username                |
      | standard_user          |
      | problem_user           |
      | performance_glitch_user |
