CREATE DATABASE ContactDB

CREATE TABLE MessagesAreaOfInterest(
ID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
AreaOfInterest varchar(100) NOT NULL
)

insert into MessagesAreaOfInterest
values('SaleQuestion');
insert into MessagesAreaOfInterest
values('SaleComplaint');

CREATE TABLE ContactMessages(
ID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
FirstName varchar(200) NOT NULL,
LastName varchar(200) NOT NULL,
Email varchar(50) NOT NULL,
Phone varchar(22),
AreaOfInterest int NOT NULL FOREIGN KEY REFERENCES MessagesAreaOfInterest(ID),
ContactMessage varchar(1000) NOT NULL
)