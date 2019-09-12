# Debtor Application

Based on article from Yaser Al-Najjar - Implementation of the demo task he was provided

[Link to Al-Najjar's Post](https://dev.to/yaser/are-you-a-mediocre-developer-me-too-34ed)``


I changed some of the requirements. Instead of Python, I will use c#/Dotnet. I will also use MySql instead of PostgresSQL.

## Requirements

* C#/Dotnet
* MySql
* Set up execution environment using docker-compose to run the test task locally
* Write Documentation on how to setup, run and use

### Functionality

* Admins should authenticate via Google
* Admins should be able to (CRUD) debtors though web front end.
* Debtors visible to admins through list: email, count of open, paid, overdue invoices.
* Restrict modification to Debtor creator
* Debtor consist of: First Name, Last Name, email, and IBAN. (VALIDATED)
* Invoices consist of: STATE: {Open, Paid, Overdue}, amount, date due (VAILIDATED)
* API endpoint -> debtors with email, iban, and count of invoices by state. allow filter by state and count.
* Api endpoint -> invoices with state,amount,due date, and debtor email. Order and filter.
* Api restricted to Admins.
