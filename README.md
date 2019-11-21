# ContactPage

ContactPage is a simple ASP.NET MVC website (basic contact form).

# Features

  - Storing contact messages in a Database,
  - Sending contact informations as a mail to provided e-mail address

### Tech requirements

Software:

* Visual Studio (VS 2019 was used)
* MSSQL 2017

Project packages:

* Microsoft.EntityFrameworkCore.Tools (3.0.1)
* Microsoft.EntityFrameworkCore.SqlServer (3.0.1)
* Microsoft.NET.Test.Sdk (16.4.0)
* NUnit (3.12.0)
* NUnit3TestAdapter (3.13.0)
* Moq (4.13.1)

Libraries:

* Twitter Bootstrap (4.3.1)

### Development

Create ContactDB database, tables and populate MessagesAreaOfInterest table using sql script provided in this folder:
```sh
ContactPage/ConfigScripts
```
Open the solution.
Install all needed packages.
Configure connection strings here:
```sh
appsettings.json -> ConnectionStrings -> DefaultConnection
```
Configure e-mail reciever options here:
```sh
appsettings.json -> MailOptions
```
Run the code.

### Testing

Unit tests are stored in ContactPageTests subproject.
Framework: NUnit + Moq.
They can be runned via VisualStudio "Test" tab.