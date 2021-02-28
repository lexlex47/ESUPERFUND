# Cryptocurrency application
[![Codacy Badge](https://app.codacy.com/project/badge/Grade/3f1feddc49aa46c8a738730eccff7a96)](https://www.codacy.com/gh/lexlex47/ESUPERFUND/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=lexlex47/ESUPERFUND&amp;utm_campaign=Badge_Grade)

This project that ESUPERFUND data team receives raw data from the banks, brokers, and other third-party data vendors.

## Github Links
https://github.com/lexlex47/ESUPERFUND

## To-Do
1.  Import the provided csv files into the pre-designed database tables.
2.  Use the validation rules to further process the raw data imported in Requirement 1 into [Bank_Transaction] & [Bank_Balance] tables.
3.  Use a log library to log the information.
4.  Use Entity Framework to perform database CURD actions.
5.  Use ASP.NET to implement the program.
6.  Use Database first to implement.

## Stacks and Dependencies
    Asp.Net => 4.6.1
    SQL Server => 2012+
	Visual Studio => 2013+

## Files structure
    TestBank.sql
    NewApp.zip

## Setup
1.  Unzip the code
2.  Install `TestBank.sql` to local database.
3.  Run .sln file in NewApp folder.

## Running
To run the application use `ctrl+F5` or build command.

You should able to vist `localhost:port` now.

## Output
Results will output to the `localhost:port` directly.

You can download the log file via click `Download Result File` button.

## Exit
Use `CTRL + C` or close broswer command to stop server.