/*======================================================*/
/*  Created in April 2020                                 */
/*  WEB 2020 April Semester					            */
/*  Diploma in IT/FI                                    */
/*                                                      */
/*  Database Script for setting up the database         */
/*  required for WEB Assignment.                        */
/*======================================================*/

Create Database Air_Flights_DB
GO

Use Air_Flights_DB
GO

/***************************************************************/
/***           Delete tables before creating                 ***/
/***************************************************************/

/* Table: dbo.FlightCrew */
if exists (select * from sysobjects 
  where id = object_id('dbo.FlightCrew') and sysstat & 0xf = 3)
  drop table dbo.FlightCrew
GO

/* Table: dbo.Booking */
if exists (select * from sysobjects 
  where id = object_id('dbo.Booking') and sysstat & 0xf = 3)
  drop table dbo.Booking
GO

/* Table: dbo.FlightSchedule */
if exists (select * from sysobjects 
  where id = object_id('dbo.FlightSchedule') and sysstat & 0xf = 3)
  drop table dbo.FlightSchedule
GO

/* Table: dbo.Aircraft */
if exists (select * from sysobjects 
  where id = object_id('dbo.Aircraft') and sysstat & 0xf = 3)
  drop table dbo.Aircraft
GO

/* Table: dbo.FlightRoute */
if exists (select * from sysobjects 
  where id = object_id('dbo.FlightRoute') and sysstat & 0xf = 3)
  drop table dbo.FlightRoute
GO

/* Table: dbo.Staff */
if exists (select * from sysobjects 
  where id = object_id('dbo.Staff') and sysstat & 0xf = 3)
  drop table dbo.Staff
GO

/* Table: dbo.Customer */
if exists (select * from sysobjects 
  where id = object_id('dbo.Customer') and sysstat & 0xf = 3)
  drop table dbo.Customer
GO


/***************************************************************/
/***                     Creating tables                     ***/
/***************************************************************/

/* Table: dbo.Customer */
CREATE TABLE dbo.Customer
(
  CustomerID 			int IDENTITY (1,1),
  CustomerName			varchar(50) 	NOT NULL,
  Nationality			varchar(50) 	NULL,
  BirthDate				datetime		NULL,
  TelNo					varchar(20)		NULL,
  EmailAddr		    	varchar(50)  	NOT NULL,
  [Password]		    varchar(255)  	NOT NULL DEFAULT ('p@55Cust'),
  CONSTRAINT PK_Customer PRIMARY KEY NONCLUSTERED (CustomerID)
)
GO

/* Table: dbo.Staff */
CREATE TABLE dbo.Staff
(
  StaffID 				int IDENTITY (1,1),
  StaffName				varchar(50) 	NOT NULL,
  Gender				char(1) 		NULL	CHECK (Gender IN ('M','F')),
  DateEmployed			datetime		NULL,
  Vocation				varchar(50)		NULL,
  EmailAddr		    	varchar(50)  	NOT NULL,
  [Password]		    varchar(255)  	NOT NULL DEFAULT ('p@55Staff'),
  [Status]				varchar(50)		NOT NULL DEFAULT ('Active')	
 										CHECK ([Status] IN ('Active','Inactive')), 
  CONSTRAINT PK_Staff PRIMARY KEY NONCLUSTERED (StaffID)
)
GO

/* Table: dbo.FlightRoute */
CREATE TABLE dbo.FlightRoute
(
  RouteID				int IDENTITY (1,1),
  DepartureCity			varchar(50) 	NOT NULL,
  DepartureCountry		varchar(50) 	NOT NULL,
  ArrivalCity			varchar(50) 	NOT NULL,
  ArrivalCountry		varchar(50) 	NOT NULL,
  FlightDuration		int  			NULL,
  CONSTRAINT PK_FlightRoute PRIMARY KEY NONCLUSTERED (RouteID)
)
GO

/* Table: dbo.Aircraft */
CREATE TABLE dbo.Aircraft
(
  AircraftID 			int IDENTITY (1,1),
  MakeModel				varchar(50) 	NOT NULL,
  NumEconomySeat		int				NULL,
  NumBusinessSeat		int				NULL,
  DateLastMaintenance	datetime		NULL,
  [Status]				varchar(50)		NOT NULL DEFAULT ('Operational')	
 										CHECK ([Status] IN ('Operational','Under Maintenance')),
  CONSTRAINT PK_Student PRIMARY KEY NONCLUSTERED (AircraftID),
)
GO

/* Table: dbo.FlightSchedule */
CREATE TABLE dbo.FlightSchedule
(
  ScheduleID 			int IDENTITY (1,1),
  FlightNumber			varchar(20) 	NOT NULL,
  RouteID				int 	        NOT NULL,
  AircraftID			int				NULL,
  DepartureDateTime		datetime		NULL,
  ArrivalDateTime		datetime		NULL,
  EconomyClassPrice		money			NOT NULL DEFAULT (0),
  BusinessClassPrice	money			NOT NULL DEFAULT (0),
  [Status]				varchar(20) 	NOT NULL DEFAULT ('Opened') 
										CHECK ([Status] IN ('Opened','Full', 'Delayed','Cancelled')),  
  CONSTRAINT PK_FlightSchedule PRIMARY KEY NONCLUSTERED (ScheduleID),
  CONSTRAINT FK_FlightSchedule_RouteID FOREIGN KEY (RouteID) 
  REFERENCES dbo.FlightRoute(RouteID),
  CONSTRAINT FK_FlightSchedule_AircraftID FOREIGN KEY (AircraftID) 
  REFERENCES dbo.Aircraft(AircraftID)
)
GO

/* Table: dbo.FlightCrew */
CREATE TABLE dbo.FlightCrew
(
  ScheduleID			int  			NOT NULL,
  StaffID				int				NOT NULL,
  [Role]				varchar(50) 	NULL,
  CONSTRAINT FK_FlightCrew_ScheduleID FOREIGN KEY (ScheduleID) 
  REFERENCES dbo.FlightSchedule(ScheduleID),
  CONSTRAINT FK_FlightCrew_StaffID  FOREIGN KEY (StaffID) 
  REFERENCES dbo.Staff(StaffID)
)
GO

/* Table: dbo.Booking */
CREATE TABLE dbo.Booking
(
  BookingID				int IDENTITY (1,1),
  CustomerID			int  			NOT NULL,
  ScheduleID			int  			NOT NULL,
  PassengerName			varchar(50) 	NOT NULL,
  PassportNumber		varchar(20) 	NOT NULL,
  Nationality			varchar(50) 	NOT NULL,
  SeatClass				varchar(20) 	NOT NULL DEFAULT ('Economy') 
										CHECK (SeatClass IN ('Economy','Business')), 
  AmtPayable			money			NOT NULL DEFAULT (0),
  [Remarks]				varchar(3000)	NULL,
  DateTimeCreated		datetime		NOT NULL DEFAULT (getdate()),
  CONSTRAINT PK_Booking PRIMARY KEY NONCLUSTERED (BookingID),
  CONSTRAINT FK_Booking_CustomerID  FOREIGN KEY (CustomerID) 
  REFERENCES dbo.Customer(CustomerID),
  CONSTRAINT FK_Booking_ScheduleID  FOREIGN KEY (ScheduleID) 
  REFERENCES dbo.FlightSchedule(ScheduleID)
)
GO


/***************************************************************/
/***                Populate Sample Data                     ***/
/***************************************************************/

SET IDENTITY_INSERT [dbo].[Customer] ON 
INSERT [dbo].[Customer] ([CustomerID], [CustomerName], [Nationality], [BirthDate], [TelNo], [EmailAddr], [Password]) 
VALUES (1, 'Peter Ghim', 'Singapore', '31-Aug-1991', '+6592468012', 'pg91@hotmail.com', 'p@55PG')
INSERT [dbo].[Customer] ([CustomerID], [CustomerName], [Nationality], [BirthDate], [TelNo], [EmailAddr], [Password]) 
VALUES (2, 'Fatimah Bte Ahmad', 'Malaysia', '21-Jun-1992', '+6581234567', 'Fatimah92@gmail.com', 'p@55Cust')
INSERT [dbo].[Customer] ([CustomerID], [CustomerName], [Nationality], [BirthDate], [TelNo], [EmailAddr], [Password]) 
VALUES (3, 'Benjamin Bean', 'United Kingdom', '05-May-1970', '+6598765432', 'BBean@yahoo.com', 'p@55Cust')
SET IDENTITY_INSERT [dbo].[Customer] OFF

SET IDENTITY_INSERT [dbo].[Staff] ON 
INSERT [dbo].[Staff] ([StaffID], [StaffName], [Gender], [DateEmployed], [Vocation], [EmailAddr], [Password], [Status]) 
VALUES (1, 'Alice Avin', 'F', '01-Mar-2015', 'Administrator', 's1234567@lca.com', 'p@55Staff', 'Active')
INSERT [dbo].[Staff] ([StaffID], [StaffName], [Gender], [DateEmployed], [Vocation], [EmailAddr], [Password], [Status]) 
VALUES (2, 'Ali Imran', 'M', '01-Jun-1990', 'Pilot', 's1234502@lca.com', 'p@55Staff', 'Active')
INSERT [dbo].[Staff] ([StaffID], [StaffName], [Gender], [DateEmployed], [Vocation], [EmailAddr], [Password], [Status]) 
VALUES (3, 'K Kannan', 'M', '01-Jul-1995', 'Pilot', 's1234503@lca.com', 'p@55Staff', 'Active')
INSERT [dbo].[Staff] ([StaffID], [StaffName], [Gender], [DateEmployed], [Vocation], [EmailAddr], [Password], [Status]) 
VALUES (4, 'Howard Johnson', 'M', '01-Nov-2000', 'Pilot', 's1234504@lca.com', 'p@55Staff', 'Active')
INSERT [dbo].[Staff] ([StaffID], [StaffName], [Gender], [DateEmployed], [Vocation], [EmailAddr], [Password], [Status]) 
VALUES (5, 'John Tan', 'M', '01-Jul-2008', 'Pilot', 's1234505@lca.com', 'p@55Staff', 'Active')
INSERT [dbo].[Staff] ([StaffID], [StaffName], [Gender], [DateEmployed], [Vocation], [EmailAddr], [Password], [Status]) 
VALUES (6, 'Edward Lee', 'M', '01-Aug-2016', 'Pilot', 's1234506@lca.com', 'p@55Staff', 'Inactive')
INSERT [dbo].[Staff] ([StaffID], [StaffName], [Gender], [DateEmployed], [Vocation], [EmailAddr], [Password], [Status]) 
VALUES (7, 'Lisa Lee', 'F', '01-Oct-2010', 'Flight Attendant', 's1234507@lca.com', 'p@55Staff', 'Active')
INSERT [dbo].[Staff] ([StaffID], [StaffName], [Gender], [DateEmployed], [Vocation], [EmailAddr], [Password], [Status]) 
VALUES (8, 'Xu Yazhi', 'F', '01-Jul-2012', 'Flight Attendant', 's1234508@lca.com', 'p@55Staff', 'Active')
INSERT [dbo].[Staff] ([StaffID], [StaffName], [Gender], [DateEmployed], [Vocation], [EmailAddr], [Password], [Status]) 
VALUES (9, 'Eliza Wong', 'F', '01-Feb-2013', 'Flight Attendant', 's1234509@lca.com', 'p@55Staff', 'Active')
INSERT [dbo].[Staff] ([StaffID], [StaffName], [Gender], [DateEmployed], [Vocation], [EmailAddr], [Password], [Status]) 
VALUES (10, 'Phobe Pander', 'F', '01-Mar-2014', 'Flight Attendant', 's1234510@lca.com', 'p@55Staff', 'Active')
INSERT [dbo].[Staff] ([StaffID], [StaffName], [Gender], [DateEmployed], [Vocation], [EmailAddr], [Password], [Status]) 
VALUES (11, 'Jane Greenspan', 'F', '01-Dec-2015', 'Flight Attendant', 's1234511@lca.com', 'p@55Staff', 'Active')
INSERT [dbo].[Staff] ([StaffID], [StaffName], [Gender], [DateEmployed], [Vocation], [EmailAddr], [Password], [Status]) 
VALUES (12, 'Ang Bee Chin', 'F', '01-Apr-2016', 'Flight Attendant', 's1234512@lca.com', 'p@55Staff', 'Active')
INSERT [dbo].[Staff] ([StaffID], [StaffName], [Gender], [DateEmployed], [Vocation], [EmailAddr], [Password], [Status]) 
VALUES (13, 'Mary Gould', 'F', '01-Oct-2017', 'Flight Attendant', 's1234513@lca.com', 'p@55Staff', 'Active')
INSERT [dbo].[Staff] ([StaffID], [StaffName], [Gender], [DateEmployed], [Vocation], [EmailAddr], [Password], [Status]) 
VALUES (14, 'Geetha', 'F', '01-Jul-2018', 'Flight Attendant', 's1234514@lca.com', 'p@55Staff', 'Active')
INSERT [dbo].[Staff] ([StaffID], [StaffName], [Gender], [DateEmployed], [Vocation], [EmailAddr], [Password], [Status]) 
VALUES (15, 'Amy Ng', 'F', '01-Oct-2010', 'Flight Attendant', 's1234515@lca.com', 'p@55Staff', 'Inactive')
SET IDENTITY_INSERT [dbo].[Staff] OFF

SET IDENTITY_INSERT [dbo].[FlightRoute] ON 
INSERT [dbo].[FlightRoute] ([RouteID], [DepartureCity], [DepartureCountry], [ArrivalCity], [ArrivalCountry], [FlightDuration]) 
VALUES (1, 'Singapore', 'Singapore', 'Kuala Lumpur', 'Malaysia', 1)
INSERT [dbo].[FlightRoute] ([RouteID], [DepartureCity], [DepartureCountry], [ArrivalCity], [ArrivalCountry], [FlightDuration]) 
VALUES (2, 'Kuala Lumpur', 'Malaysia', 'Singapore', 'Singapore', 1)
INSERT [dbo].[FlightRoute] ([RouteID], [DepartureCity], [DepartureCountry], [ArrivalCity], [ArrivalCountry], [FlightDuration]) 
VALUES (3, 'Singapore', 'Singapore', 'London', 'United Kingdom', 14)
INSERT [dbo].[FlightRoute] ([RouteID], [DepartureCity], [DepartureCountry], [ArrivalCity], [ArrivalCountry], [FlightDuration]) 
VALUES (4, 'London', 'United Kingdom', 'Singapore', 'Singapore', 14)
INSERT [dbo].[FlightRoute] ([RouteID], [DepartureCity], [DepartureCountry], [ArrivalCity], [ArrivalCountry], [FlightDuration]) 
VALUES (5, 'Singapore', 'Singapore', 'Sydney', 'Australia', 8)
INSERT [dbo].[FlightRoute] ([RouteID], [DepartureCity], [DepartureCountry], [ArrivalCity], [ArrivalCountry], [FlightDuration]) 
VALUES (6, 'Sydney', 'Australia', 'Singapore', 'Singapore', 8)
SET IDENTITY_INSERT [dbo].[FlightRoute] OFF

SET IDENTITY_INSERT [dbo].[Aircraft] ON
INSERT [dbo].[Aircraft] ([AircraftID], [MakeModel], [NumEconomySeat], [NumBusinessSeat], [DateLastMaintenance], [Status]) 
VALUES (1, 'Boeing 747', 56, 300, '01-Aug-2020', 'Operational')
INSERT [dbo].[Aircraft] ([AircraftID], [MakeModel], [NumEconomySeat], [NumBusinessSeat], [DateLastMaintenance], [Status]) 
VALUES (2, 'Boeing 747', 56, 300, '15-Jan-2020', 'Under Maintenance')
INSERT [dbo].[Aircraft] ([AircraftID], [MakeModel], [NumEconomySeat], [NumBusinessSeat], [DateLastMaintenance], [Status]) 
VALUES (3, 'Airbus A321', 16, 160, '01-Mar-2020', 'Operational')
INSERT [dbo].[Aircraft] ([AircraftID], [MakeModel], [NumEconomySeat], [NumBusinessSeat], [DateLastMaintenance], [Status]) 
VALUES (4, 'Boeing 757', 16, 150, '01-Oct-2020', 'Operational')
INSERT [dbo].[Aircraft] ([AircraftID], [MakeModel], [NumEconomySeat], [NumBusinessSeat], [DateLastMaintenance], [Status]) 
VALUES (5, 'Boeing 777', 42, 170, '15-May-2020', 'Operational')
INSERT [dbo].[Aircraft] ([AircraftID], [MakeModel], [NumEconomySeat], [NumBusinessSeat], [DateLastMaintenance], [Status]) 
VALUES (6, 'Airbus A380', 72, 360, '15-Oct-2020', 'Operational')
INSERT [dbo].[Aircraft] ([AircraftID], [MakeModel], [NumEconomySeat], [NumBusinessSeat], [DateLastMaintenance], [Status]) 
VALUES (7, 'Boeing 757', 16, 150, '15-Jul-2020', 'Operational')
SET IDENTITY_INSERT [dbo].[Aircraft] OFF

SET IDENTITY_INSERT [dbo].[FlightSchedule] ON
INSERT [dbo].[FlightSchedule] ([ScheduleID], [FlightNumber], [RouteID], [AircraftID], [DepartureDateTime], [ArrivalDateTime], [EconomyClassPrice], [BusinessClassPrice], [Status]) 
VALUES (1, 'LC001', 1, 2, '2019-12-01 14:00:00', '2019-12-01 15:00:00', 70.00, 300.00, 'Delayed')
INSERT [dbo].[FlightSchedule] ([ScheduleID], [FlightNumber], [RouteID], [AircraftID], [DepartureDateTime], [ArrivalDateTime], [EconomyClassPrice], [BusinessClassPrice], [Status]) 
VALUES (2, 'LC002', 2, 2, '2019-12-03 18:00:00', '2019-12-03 19:00:00', 70.00, 300.00, 'Full')
INSERT [dbo].[FlightSchedule] ([ScheduleID], [FlightNumber], [RouteID], [AircraftID], [DepartureDateTime], [ArrivalDateTime], [EconomyClassPrice], [BusinessClassPrice], [Status]) 
VALUES (3, 'LC001', 1, 1, '2020-09-01 14:00:00', '2020-09-01 15:00:00', 55.00, 230.00, 'Cancelled')
INSERT [dbo].[FlightSchedule] ([ScheduleID], [FlightNumber], [RouteID], [AircraftID], [DepartureDateTime], [ArrivalDateTime], [EconomyClassPrice], [BusinessClassPrice], [Status]) 
VALUES (4, 'LC002', 2, 1, '2020-09-03 18:00:00', '2020-09-03 19:00:00', 55.00, 230.00, 'Cancelled')
INSERT [dbo].[FlightSchedule] ([ScheduleID], [FlightNumber], [RouteID], [AircraftID], [DepartureDateTime], [ArrivalDateTime], [EconomyClassPrice], [BusinessClassPrice], [Status]) 
VALUES (5, 'LC001', 1, 1, '2020-10-01 14:00:00', '2020-10-01 15:00:00', 60.00, 250.00, 'Opened')
INSERT [dbo].[FlightSchedule] ([ScheduleID], [FlightNumber], [RouteID], [AircraftID], [DepartureDateTime], [ArrivalDateTime], [EconomyClassPrice], [BusinessClassPrice], [Status]) 
VALUES (6, 'LC002', 2, 1, '2020-10-03 18:00:00', '2020-10-03 19:00:00', 60.00, 250.00, 'Opened')
INSERT [dbo].[FlightSchedule] ([ScheduleID], [FlightNumber], [RouteID], [AircraftID], [DepartureDateTime], [ArrivalDateTime], [EconomyClassPrice], [BusinessClassPrice], [Status]) 
VALUES (7, 'LC011', 3, 6, '2020-11-05 17:00:00', '2020-11-06 07:00:00', 990.00, 3800.00, 'Opened')
INSERT [dbo].[FlightSchedule] ([ScheduleID], [FlightNumber], [RouteID], [AircraftID], [DepartureDateTime], [ArrivalDateTime], [EconomyClassPrice], [BusinessClassPrice], [Status]) 
VALUES (8, 'LC012', 4, 6, '2020-11-08 16:00:00', '2020-11-09 06:00:00', 990.00, 3800.00, 'Opened')
INSERT [dbo].[FlightSchedule] ([ScheduleID], [FlightNumber], [RouteID], [AircraftID], [DepartureDateTime], [ArrivalDateTime], [EconomyClassPrice], [BusinessClassPrice], [Status]) 
VALUES (9, 'LC021', 5, 4, '2020-11-07 14:00:00', '2020-11-07 22:00:00', 580.00, 2900.00, 'Full')
INSERT [dbo].[FlightSchedule] ([ScheduleID], [FlightNumber], [RouteID], [AircraftID], [DepartureDateTime], [ArrivalDateTime], [EconomyClassPrice], [BusinessClassPrice], [Status]) 
VALUES (10, 'LC022', 6, 4, '2020-11-10 13:00:00', '2020-11-10 21:00:00', 580.00, 2900.00, 'Full')
SET IDENTITY_INSERT [dbo].[FlightSchedule] OFF

INSERT [dbo].[FlightCrew] ([ScheduleID], [StaffID], [Role]) VALUES (1, 6, 'Flight Captain')
INSERT [dbo].[FlightCrew] ([ScheduleID], [StaffID], [Role]) VALUES (1, 2, 'Second Pilot')
INSERT [dbo].[FlightCrew] ([ScheduleID], [StaffID], [Role]) VALUES (1, 7, 'Cabin Crew Leader')
INSERT [dbo].[FlightCrew] ([ScheduleID], [StaffID], [Role]) VALUES (1, 8, 'Flight Attendant')
INSERT [dbo].[FlightCrew] ([ScheduleID], [StaffID], [Role]) VALUES (1, 14, 'Flight Attendant')
INSERT [dbo].[FlightCrew] ([ScheduleID], [StaffID], [Role]) VALUES (1, 15, 'Flight Attendant')
INSERT [dbo].[FlightCrew] ([ScheduleID], [StaffID], [Role]) VALUES (2, 2, 'Flight Captain')
INSERT [dbo].[FlightCrew] ([ScheduleID], [StaffID], [Role]) VALUES (2, 6, 'Second Pilot')
INSERT [dbo].[FlightCrew] ([ScheduleID], [StaffID], [Role]) VALUES (2, 8, 'Cabin Crew Leader')
INSERT [dbo].[FlightCrew] ([ScheduleID], [StaffID], [Role]) VALUES (2, 7, 'Flight Attendant')
INSERT [dbo].[FlightCrew] ([ScheduleID], [StaffID], [Role]) VALUES (2, 14, 'Flight Attendant')
INSERT [dbo].[FlightCrew] ([ScheduleID], [StaffID], [Role]) VALUES (2, 15, 'Flight Attendant')
INSERT [dbo].[FlightCrew] ([ScheduleID], [StaffID], [Role]) VALUES (5, 3, 'Flight Captain')
INSERT [dbo].[FlightCrew] ([ScheduleID], [StaffID], [Role]) VALUES (5, 2, 'Second Pilot')
INSERT [dbo].[FlightCrew] ([ScheduleID], [StaffID], [Role]) VALUES (5, 7, 'Cabin Crew Leader')
INSERT [dbo].[FlightCrew] ([ScheduleID], [StaffID], [Role]) VALUES (5, 8, 'Flight Attendant')
INSERT [dbo].[FlightCrew] ([ScheduleID], [StaffID], [Role]) VALUES (5, 14, 'Flight Attendant')
INSERT [dbo].[FlightCrew] ([ScheduleID], [StaffID], [Role]) VALUES (5, 12, 'Flight Attendant')
INSERT [dbo].[FlightCrew] ([ScheduleID], [StaffID], [Role]) VALUES (6, 2, 'Flight Captain')
INSERT [dbo].[FlightCrew] ([ScheduleID], [StaffID], [Role]) VALUES (6, 3, 'Second Pilot')
INSERT [dbo].[FlightCrew] ([ScheduleID], [StaffID], [Role]) VALUES (6, 8, 'Cabin Crew Leader')
INSERT [dbo].[FlightCrew] ([ScheduleID], [StaffID], [Role]) VALUES (6, 7, 'Flight Attendant')
INSERT [dbo].[FlightCrew] ([ScheduleID], [StaffID], [Role]) VALUES (6, 14, 'Flight Attendant')
INSERT [dbo].[FlightCrew] ([ScheduleID], [StaffID], [Role]) VALUES (6, 12, 'Flight Attendant')
INSERT [dbo].[FlightCrew] ([ScheduleID], [StaffID], [Role]) VALUES (9, 5, 'Flight Captain')
INSERT [dbo].[FlightCrew] ([ScheduleID], [StaffID], [Role]) VALUES (9, 4, 'Second Pilot')
INSERT [dbo].[FlightCrew] ([ScheduleID], [StaffID], [Role]) VALUES (9, 9, 'Cabin Crew Leader')
INSERT [dbo].[FlightCrew] ([ScheduleID], [StaffID], [Role]) VALUES (9, 10, 'Flight Attendant')
INSERT [dbo].[FlightCrew] ([ScheduleID], [StaffID], [Role]) VALUES (9, 11, 'Flight Attendant')
INSERT [dbo].[FlightCrew] ([ScheduleID], [StaffID], [Role]) VALUES (9, 13, 'Flight Attendant')
INSERT [dbo].[FlightCrew] ([ScheduleID], [StaffID], [Role]) VALUES (10, 4, 'Flight Captain')
INSERT [dbo].[FlightCrew] ([ScheduleID], [StaffID], [Role]) VALUES (10, 5, 'Second Pilot')
INSERT [dbo].[FlightCrew] ([ScheduleID], [StaffID], [Role]) VALUES (10, 10, 'Cabin Crew Leader')
INSERT [dbo].[FlightCrew] ([ScheduleID], [StaffID], [Role]) VALUES (10, 9, 'Flight Attendant')
INSERT [dbo].[FlightCrew] ([ScheduleID], [StaffID], [Role]) VALUES (10, 11, 'Flight Attendant')
INSERT [dbo].[FlightCrew] ([ScheduleID], [StaffID], [Role]) VALUES (10, 13, 'Flight Attendant')

SET IDENTITY_INSERT [dbo].[Booking] ON
INSERT [dbo].[Booking] ([BookingID], [CustomerID], [ScheduleID], [PassengerName], [PassportNumber], [Nationality], [SeatClass], [AmtPayable], [Remarks], [DateTimeCreated]) 
VALUES (1, 2, 5, 'Fatimah Bte Ahmad', 'A01234567', 'Malaysia', 'Business', 250.00, NULL, '2020-03-05 13:03:02')
INSERT [dbo].[Booking] ([BookingID], [CustomerID], [ScheduleID], [PassengerName], [PassportNumber], [Nationality], [SeatClass], [AmtPayable], [Remarks], [DateTimeCreated]) 
VALUES (2, 1, 9, 'Peter Ghim', 'E1234567A', 'Singapore', 'Economy', 580.00, 'Please provide vegetarian foods.', '2020-03-06 10:05:01')
INSERT [dbo].[Booking] ([BookingID], [CustomerID], [ScheduleID], [PassengerName], [PassportNumber], [Nationality], [SeatClass], [AmtPayable], [Remarks], [DateTimeCreated]) 
VALUES (3, 1, 9, 'Shirley Tan', 'E1234568B', 'Singapore', 'Economy', 580.00, 'Aisle seat please.', '2020-03-06 10:06:05')
INSERT [dbo].[Booking] ([BookingID], [CustomerID], [ScheduleID], [PassengerName], [PassportNumber], [Nationality], [SeatClass], [AmtPayable], [Remarks], [DateTimeCreated]) 
VALUES (4, 1, 9, 'Jason Ghim', 'E1234569C', 'Singapore', 'Economy', 580.00, 'Infant in baby stroller', '2020-03-06 10:08:17')
SET IDENTITY_INSERT [dbo].[Booking] OFF

