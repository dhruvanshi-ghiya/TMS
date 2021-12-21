CREATE DATABASE tms;
use TMS;

create table Orders (
  `OrderID` varchar(100) primary key not null,
  `Origin` varchar(15) not null,
  `Destination` varchar(15) not null,
  `Client` varchar(25) not null,
  `JobType` int(1) not null,
  `Quantity` int(200) not null,
  `VanType` int(1) not null,
  `Active` int(1) not null,
  `CompletionDate` datetime
);

create table Rates (
	`ClientName` varchar(30) not null,
    `dCity` varchar(20) not null,
	`FTLA` int(3) not null,
    `LTLA` int(3) not null,
    `FTLRate` double not null,
    `LTLRate` double not null,
    `reefCharge` double not null
);

create table Invoices (
  `OrderID` varchar(100) not null,
  `Origin` varchar(15) not null,
  `Destination` varchar(15) not null,
  `Client` varchar(25) not null,
  `JobType` int(1) not null,
  `Quantity` int(200) not null,
  `VanType` int(1) not null,
   `CompletionDate` datetime,
   `DaysToComplete` int(3) not null,
  `TotalCost` double not null,
  `TotalKM` int(3) not null,
  `TotalTime` double not null,
  `Surcharge` int(4) not null
);

-- INSERT INTO Invoices VALUES("d23wrcw3w3rrdv", "Ottawa", "Kingtson", "Space J", 1, 1, 1, '2021-10-12 04:35:00', 54, 89.3, 245, 134.23, 150);
-- DELETE FROM Invoices;

create table Users(
    `UserName` varchar(30) not null,
    `Password` varchar(20) not null,
    `UserRole` varchar(20) not null
); 

INSERT INTO Users VALUES ('Patrick', 'SoftQual', 'Admin');
INSERT INTO Users VALUES ('Travis', 'SoftQual', 'Planner');
INSERT INTO Users VALUES ('Dhruvanshi', 'SoftQual', 'Buyer');


-- Select * FROM Users;
-- drop table orders;
-- select * from orders;





