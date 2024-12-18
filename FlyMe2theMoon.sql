
-- --------------------------------------------------------------------------------
USE dbFlyMe2theMoon;     
SET NOCOUNT ON;  

-- --------------------------------------------------------------------------------
--						Problem #10
-- --------------------------------------------------------------------------------

-- Drop Table Statements
IF OBJECT_ID ('TPilotFlights')			IS NOT NULL DROP TABLE TPilotFlights
IF OBJECT_ID ('TAttendantFlights')		IS NOT NULL DROP TABLE TAttendantFlights
IF OBJECT_ID ('TFlightPassengers')		IS NOT NULL DROP TABLE TFlightPassengers
IF OBJECT_ID ('TMaintenanceMaintenanceWorkers')			IS NOT NULL DROP TABLE TMaintenanceMaintenanceWorkers

IF OBJECT_ID ('TPassengers')			IS NOT NULL DROP TABLE TPassengers
IF OBJECT_ID ('TPilots')				IS NOT NULL DROP TABLE TPilots
IF OBJECT_ID ('TAttendants')			IS NOT NULL DROP TABLE TAttendants
IF OBJECT_ID ('TAdmins')				IS NOT NULL DROP TABLE TAdmins
IF OBJECT_ID ('TMaintenanceWorkers')	IS NOT NULL DROP TABLE TMaintenanceWorkers

IF OBJECT_ID ('TFlights')				IS NOT NULL DROP TABLE TFlights
IF OBJECT_ID ('TMaintenances')			IS NOT NULL DROP TABLE TMaintenances
IF OBJECT_ID ('TPlanes')				IS NOT NULL DROP TABLE TPlanes
IF OBJECT_ID ('TPlaneTypes')			IS NOT NULL DROP TABLE TPlaneTypes
IF OBJECT_ID ('TPilotRoles')			IS NOT NULL DROP TABLE TPilotRoles
IF OBJECT_ID ('TAirports')				IS NOT NULL DROP TABLE TAirports
IF OBJECT_ID ('TStates')				IS NOT NULL DROP TABLE TStates
IF OBJECT_ID ('TEmployees')				IS NOT NULL DROP TABLE TEmployees


-- --------------------------------------------------------------------------------
--	Step #1 : Create table 
-- --------------------------------------------------------------------------------

CREATE TABLE TPassengers
(
	 intPassengerID			INTEGER			NOT NULL
	,strFirstName			VARCHAR(255)	NOT NULL
	,strLastName			VARCHAR(255)	NOT NULL
	,strAddress				VARCHAR(255)	NOT NULL
	,strCity				VARCHAR(255)	NOT NULL
	,intStateID				INTEGER			NOT NULL
	,strZip					VARCHAR(255)	NOT NULL
	,strPhoneNumber			VARCHAR(255)	NOT NULL
	,strEmail				VARCHAR(255)	NOT NULL
	,dtmDateOfBirth			DateTime		NOT NULL
	,strPassword			VARCHAR(255)	NOT NULL
	,strLoginID				VARCHAR(255)			NOT NULL
	,CONSTRAINT TPassengers_PK PRIMARY KEY ( intPassengerID )
)


CREATE TABLE TPilots
(
	 intPilotID				INTEGER			NOT NULL
	,strFirstName			VARCHAR(255)	NOT NULL
	,strLastName			VARCHAR(255)	NOT NULL
	,strEmployeeID			VARCHAR(255)	NOT NULL
	,dtmDateOfHire			DATETIME		NOT NULL
	,dtmDateOfTermination	DATETIME		NOT NULL
	,dtmDateOfLicense		DATETIME		NOT NULL
	,intPilotRoleID			INTEGER			NOT NULL

	,CONSTRAINT TPilots_PK PRIMARY KEY ( intPilotID )
)


CREATE TABLE TAttendants
(
	 intAttendantID			INTEGER			NOT NULL
	,strFirstName			VARCHAR(255)	NOT NULL
	,strLastName			VARCHAR(255)	NOT NULL
	,strEmployeeID			VARCHAR(255)	NOT NULL
	,dtmDateOfHire			DATETIME		NOT NULL
	,dtmDateOfTermination	DATETIME		NOT NULL
	,CONSTRAINT TAttendants_PK PRIMARY KEY ( intAttendantID )
)


CREATE TABLE TAdmins
(
	 intAdminID			INTEGER			NOT NULL
	,strFirstName			VARCHAR(255)	NOT NULL
	,strLastName			VARCHAR(255)	NOT NULL
	,strEmployeeID			VARCHAR(255)	NOT NULL
	,dtmDateOfHire			DATETIME		NOT NULL
	,dtmDateOfTermination	DATETIME		NOT NULL
	,CONSTRAINT TAdmins_PK PRIMARY KEY ( intAdminID )
)

CREATE TABLE TMaintenanceWorkers
(
	 intMaintenanceWorkerID	INTEGER			NOT NULL
	,strFirstName			VARCHAR(255)	NOT NULL
	,strLastName			VARCHAR(255)	NOT NULL
	,strEmployeeID			VARCHAR(255)	NOT NULL
	,dtmDateOfHire			DATETIME		NOT NULL
	,dtmDateOfTermination	DATETIME		NOT NULL
	,dtmDateOfCertification	DATETIME		NOT NULL
	,CONSTRAINT TMaintenanceWorkers_PK PRIMARY KEY ( intMaintenanceWorkerID )
)


CREATE TABLE TStates
(
	 intStateID			INTEGER			NOT NULL
	,strState			VARCHAR(255)	NOT NULL
	,CONSTRAINT TStates_PK PRIMARY KEY ( intStateID )
)


CREATE TABLE TFlights
(
	 intFlightID			INTEGER			NOT NULL
	,strFlightNumber		VARCHAR(255)	NOT NULL
	,dtmFlightDate			DATETIME		NOT NULL
	,dtmTimeofDeparture		TIME			NOT NULL
	,dtmTimeOfLanding		TIME			NOT NULL
	,intFromAirportID		INTEGER			NOT NULL
	,intToAirportID			INTEGER			NOT NULL
	,intMilesFlown			INTEGER			NOT NULL
	,intPlaneID				INTEGER			NOT NULL
	,CONSTRAINT TFlights_PK PRIMARY KEY ( intFlightID )
)


CREATE TABLE TMaintenances
(
	 intMaintenanceID		INTEGER			NOT NULL
	,strWorkCompleted		VARCHAR(8000)	NOT NULL
	,dtmMaintenanceDate		DATETIME		NOT NULL
	,intPlaneID				INTEGER			NOT NULL
	,CONSTRAINT TMaintenances_PK PRIMARY KEY ( intMaintenanceID )
)


CREATE TABLE TPlanes
(
	 intPlaneID				INTEGER			NOT NULL
	,strPlaneNumber			VARCHAR(255)	NOT NULL
	,intPlaneTypeID			INTEGER			NOT NULL
	,CONSTRAINT TPlanes_PK PRIMARY KEY ( intPlaneID )
)


CREATE TABLE TPlaneTypes	
(
	 intPlaneTypeID			INTEGER			NOT NULL
	,strPlaneType			VARCHAR(255)	NOT NULL
	,CONSTRAINT TPlaneTypes_PK PRIMARY KEY ( intPlaneTypeID )
)


CREATE TABLE TPilotRoles	
(
	 intPilotRoleID			INTEGER			NOT NULL
	,strPilotRole			VARCHAR(255)	NOT NULL
	,CONSTRAINT TPilotRoles_PK PRIMARY KEY ( intPilotRoleID )
)


CREATE TABLE TAirports
(
	 intAirportID			INTEGER			NOT NULL
	,strAirportCity			VARCHAR(255)	NOT NULL
	,strAirportCode			VARCHAR(255)	NOT NULL
	,CONSTRAINT TAirports_PK PRIMARY KEY ( intAirportID )
)


CREATE TABLE TPilotFlights
(
	 intPilotFlightID		INTEGER			NOT NULL
	,intPilotID				INTEGER			NOT NULL
	,intFlightID			INTEGER			NOT NULL
	,CONSTRAINT TPilotFlights_PK PRIMARY KEY ( intPilotFlightID )
)


CREATE TABLE TAttendantFlights
(
	 intAttendantFlightID		INTEGER			NOT NULL
	,intAttendantID				INTEGER			NOT NULL
	,intFlightID				INTEGER			NOT NULL
	,CONSTRAINT TAttendantFlights_PK PRIMARY KEY ( intAttendantFlightID )
)


CREATE TABLE TFlightPassengers
(
	 intFlightPassengerID		INTEGER			NOT NULL
	,intFlightID				INTEGER			NOT NULL
	,intPassengerID				INTEGER			NOT NULL
	,strSeat					VARCHAR(255)	NOT NULL
	,strCost					VARCHAR(255)	NOT NULL
	,CONSTRAINT TFlightPassengers_PK PRIMARY KEY ( intFlightPassengerID )
)

CREATE TABLE TEmployees
(
	intEmployeesID				INTEGER			NOT NULL
	,strEmployeeLoginID			VARCHAR(255)			NOT NULL
	,strEmployeePassword		VARCHAR(255)			NOT NULL
	,strEmployeeRole			VARCHAR(255)			NOT NULL
	,intEmployeeID				INTEGER			NOT NULL
	CONSTRAINT EMPLOYEE_PK PRIMARY KEY (intEmployeesID)
)

CREATE TABLE TMaintenanceMaintenanceWorkers
(
	 intMaintenanceMaintenanceWorkerID		INTEGER			NOT NULL
	,intMaintenanceID						INTEGER			NOT NULL
	,intMaintenanceWorkerID					INTEGER			NOT NULL
	,intHours								INTEGER			NOT NULL
	,CONSTRAINT TMaintenanceMaintenanceWorkers_PK PRIMARY KEY ( intMaintenanceMaintenanceWorkerID )
)

-- --------------------------------------------------------------------------------
--	Step #2 : Establish Referential Integrity 
-- --------------------------------------------------------------------------------
--
-- #	Child							Parent						Column
-- -	-----							------						---------
-- 1	TPassengers						TStates						intStateID	
-- 2	TFlightPassenger				TPassengers					intPassengerID
-- 3	TFlights						TPlanes						intPlaneID
-- 4	TFlights						TAirports					intFromAiportID
-- 5	TFlights						TAirports					intToAiportID
-- 6	TPilotFlights					TFlights					intFlightID
-- 7	TAttendantFlights				TFlights					intFlightID
-- 8	TPilotFlights					TPilots						intPilotID
-- 9	TAttendantFlights				TAttendants					intAttendantID
-- 10	TPilots							TPilotRoles					intPilotRoleID
-- 11	TPlanes							TPlaneTypes					intPlaneTypeID
-- 12	TMaintenances					TPlanes						intPlaneID
-- 13	TMaintenanceMaintenanceWorkers	TMaintenance				intMaintenanceID
-- 14	TMaintenanceMaintenanceWorkers	TMaintenanceWorker			intMaintenanceWorkerID
-- 15	TFlightPassenger				TFlights					intFlightID

--1
ALTER TABLE TPassengers ADD CONSTRAINT TPassengers_TStates_FK 
FOREIGN KEY ( intStateID ) REFERENCES TStates ( intStateID )

--2
ALTER TABLE TFlightPassengers ADD CONSTRAINT TPFlightPassengers_TPassengers_FK 
FOREIGN KEY ( intPassengerID ) REFERENCES TPassengers ( intPassengerID )

--3
ALTER TABLE TFlights	 ADD CONSTRAINT TFlights_TPlanes_FK 
FOREIGN KEY ( intPlaneID ) REFERENCES TPlanes ( intPlaneID )

--4
ALTER TABLE TFlights	 ADD CONSTRAINT TFlights_TFromAirports_FK 
FOREIGN KEY ( intFromAirportID ) REFERENCES TAirports ( intAirportID )

--5
ALTER TABLE TFlights	 ADD CONSTRAINT TFlights_TToAirports_FK 
FOREIGN KEY ( intToAirportID ) REFERENCES TAirports ( intAirportID )

--6
ALTER TABLE TPilotFlights	 ADD CONSTRAINT TPilotFlights_TFlights_FK 
FOREIGN KEY ( intFlightID ) REFERENCES TFlights (intFlightID )  

--7
ALTER TABLE TAttendantFlights	 ADD CONSTRAINT TAttendantFlights_TFlights_FK 
FOREIGN KEY ( intFlightID ) REFERENCES TFlights (intFlightID ) 

--8
ALTER TABLE TPilotFlights	 ADD CONSTRAINT TPilotFlights_TPilots_FK 
FOREIGN KEY ( intPilotID ) REFERENCES TPilots (intPilotID ) 

--9
ALTER TABLE TAttendantFlights	 ADD CONSTRAINT TAttendantFlights_TAttendants_FK 
FOREIGN KEY ( intAttendantID ) REFERENCES TAttendants (intAttendantID )

--10
ALTER TABLE TPilots	 ADD CONSTRAINT TPilots_TPilotRoles_FK 
FOREIGN KEY ( intPilotRoleID ) REFERENCES TPilotRoles (intPilotRoleID )  

--11
ALTER TABLE TPlanes	 ADD CONSTRAINT TPlanes_TPlaneTypes_FK 
FOREIGN KEY ( intPlaneTypeID ) REFERENCES TPlaneTypes (intPlaneTypeID )  

--12
ALTER TABLE TMaintenances	 ADD CONSTRAINT TMaintenances_TPlanes_FK 
FOREIGN KEY ( intPlaneID ) REFERENCES TPlanes (intPlaneID )  

--13
ALTER TABLE TMaintenanceMaintenanceWorkers	 ADD CONSTRAINT TMaintenanceMaintenanceWorkers_TMaintenances_FK 
FOREIGN KEY ( intMaintenanceID ) REFERENCES TMaintenances (intMaintenanceID ) 

--14
ALTER TABLE TMaintenanceMaintenanceWorkers	 ADD CONSTRAINT TMaintenanceMaintenanceWorkers_TMaintenanceWorkers_FK 
FOREIGN KEY ( intMaintenanceWorkerID ) REFERENCES TMaintenanceWorkers (intMaintenanceWorkerID ) 

--15
ALTER TABLE TFlightPassengers	 ADD CONSTRAINT TFlightPassengers_TFlights_FK 
FOREIGN KEY ( intFlightID ) REFERENCES TFlights (intFlightID ) 

ALTER TABLE TEmployees
ADD intPilotID INTEGER NULL,
    intAttendantID INTEGER NULL;

ALTER TABLE TEmployees
ADD CONSTRAINT FK_Employees_Pilots FOREIGN KEY (intPilotID) REFERENCES TPilots (intPilotID);

ALTER TABLE TEmployees
ADD CONSTRAINT FK_Employees_Attendants FOREIGN KEY (intAttendantID) REFERENCES TAttendants (intAttendantID);



-- --------------------------------------------------------------------------------
--	Step #3 : Add Data - INSERTS
-- --------------------------------------------------------------------------------
INSERT INTO TStates( intStateID, strState)
VALUES				(1, 'Ohio')
				   ,(2, 'Kentucky')
				   ,(3, 'Indiana')


INSERT INTO TPilotRoles( intPilotRoleID, strPilotRole)
VALUES				(1, 'Co-Pilot')
				   ,(2, 'Captain')

				
INSERT INTO TPlaneTypes( intPlaneTypeID, strPlaneType)
VALUES				(1, 'Airbus A350')
				   ,(2, 'Boeing 747-8')
				   ,(3, 'Boeing 767-300F')


INSERT INTO TPlanes( intPlaneID, strPlaneNumber, intPlaneTypeID)
VALUES				(1, '4X887G', 1)
				   ,(2, '5HT78F', 2)
				   ,(3, '5TYY65', 2)
				   ,(4, '4UR522', 1)
				   ,(5, '6OP3PK', 3)
				   ,(6, '67TYHH', 3)


INSERT INTO TAirports( intAirportID, strAirportCity, strAirportCode)
VALUES				(1, 'Cincinnati', 'CVG')
				   ,(2, 'Miami', 'MIA')
				   ,(3, 'Ft. Meyer', 'RSW')
				   ,(4, 'Louisville',  'SDF')
				   ,(5, 'Denver', 'DEN')
				   ,(6, 'Orlando', 'MCO' )


INSERT INTO TPassengers (intPassengerID, strFirstName, strLastName, strAddress, strCity, intStateID, strZip, strPhoneNumber, strEmail, dtmDateOfBirth, strPassword, strLoginID)
VALUES				  (1, 'Knelly', 'Nervious', '321 Elm St.', 'Cincinnati', 1, '45201', '5135553333', 'nnelly@gmail.com', '12/1/2002', 'password1', '1')
					 ,(2, 'Orville', 'Waite', '987 Oak St.', 'Cleveland', 1, '45218', '5135556333', 'owright@gmail.com', '12/1/2002', 'password1', '2')
					 ,(3, 'Eileen', 'Awnewe', '1569 Windisch Rd.', 'Dayton', 1, '45069', '5135555333', 'eonewe1@yahoo.com', '12/1/2002', 'password1', '3')
					 ,(4, 'Bob', 'Eninocean', '44561 Oak Ave.', 'Florence', 2, '45246', '8596663333', 'bobenocean@gmail.com', '12/1/2002', 'password1', '4')
					 ,(5, 'Ware', 'Hyjeked', '44881 Pine Ave.', 'Aurora', 3, '45546', '2825553333', 'Hyjekedohmy@gmail.com', '12/1/2002', 'password1', '5')
					 ,(6, 'Kay', 'Oss', '4484 Bushfield Ave.', 'Lawrenceburg', 3, '45546', '2825553333', 'wehavekayoss@gmail.com', '12/1/2002', 'password1', '6')


INSERT INTO TPilots (intPilotID, strFirstName, strLastName, strEmployeeID, dtmDateofHire, dtmDateofTermination, dtmDateofLicense, intPilotRoleID)
VALUES				  (1, 'Tip', 'Seenow', '12121', '1/1/2015', '1/1/2099', '12/1/2014', 1)
					 ,(2, 'Ima', 'Soring', '13322', '1/1/2016', '1/1/2099', '12/1/2015', 1)
					 ,(3, 'Hugh', 'Encharge', '16666', '1/1/2017', '1/1/2099', '12/1/2016', 2)
					 ,(4, 'Iwanna', 'Knapp', '17676', '1/1/2014', '1/1/2015', '12/1/2013', 1)
					 ,(5, 'Rose', 'Ennair', '19909', '1/1/2012', '1/1/2099', '12/1/2011', 2)


INSERT INTO TAttendants (intAttendantID, strFirstName, strLastName, strEmployeeID, dtmDateofHire, dtmDateofTermination)
VALUES				  (1, 'Miller', 'Tyme', '22121', '1/1/2015', '1/1/2099')
					 ,(2, 'Sherley', 'Ujest', '23322', '1/1/2016', '1/1/2099')
					 ,(3, 'Buhh', 'Biy', '26666', '1/1/2017', '1/1/2099')
					 ,(4, 'Myles', 'Amanie', '27676', '1/1/2014', '1/1/2015')
					 ,(5, 'Walker', 'Toexet', '29909', '1/1/2012', '1/1/2099')

INSERT INTO TAdmins (intAdminID, strFirstName, strLastName, strEmployeeID, dtmDateofHire, dtmDateofTermination)
VALUES				  (1, 'Joe', 'Shmoe', '22234', '1/1/2017', '1/1/2099')
					 ,(2, 'Kyle', 'Myles', '23421', '1/1/2016', '1/1/2099')


INSERT INTO TEmployees (intEmployeesID, strEmployeeLoginID, strEmployeePassword, strEmployeeRole, intEmployeeID)
VALUES				  (1, 'mill', 'mill123', 'Attendant', 1)
					 ,(2, 'sher', 'sher123', 'Attendant', 2)
					 ,(3, 'buhh', 'buhh123', 'Attendant', 3)
					 ,(4, 'myles', 'spiderman123', 'Attendant', 4)
					 ,(5, 'walker', 'walk123', 'Attendant', 5)
					 ,(6, 'tip', 'tip123', 'Pilot', 1)
					 ,(7, 'ima', 'ima123', 'Pilot', 2)
					 ,(8, 'hugh', 'charge123', 'Pilot', 3)
					 ,(9, 'iwanna', 'fligh123', 'Pilot', 4)
					 ,(10, 'rose', 'rose123', 'Pilot', 5)
					 ,(11, 'joesho2', 'joe123', 'Admin', 1)
					 ,(12, 'kyle2', 'myles132', 'Admin', 2)


			

INSERT INTO TMaintenanceWorkers (intMaintenanceWorkerID, strFirstName, strLastName, strEmployeeID, dtmDateofHire, dtmDateofTermination, dtmDateOfCertification)
VALUES				  (1, 'Gressy', 'Nuckles', '32121', '1/1/2015', '1/1/2099', '12/1/2014')
					 ,(2, 'Bolt', 'Izamiss', '33322', '1/1/2016', '1/1/2099', '12/1/2015')
					 ,(3, 'Sharon', 'Urphood', '36666', '1/1/2017', '1/1/2099','12/1/2016')
					 ,(4, 'Ides', 'Racrozed', '37676', '1/1/2014', '1/1/2015','12/1/2013')
					

INSERT INTO TMaintenances (intMaintenanceID, strWorkCompleted, dtmMaintenanceDate, intPlaneID)
VALUES				  (1, 'Fixed Wing', '1/1/2022', 1)
					 ,(2, 'Repaired Flat Tire', '3/1/2022', 2)
					 ,(3, 'Added Wiper Fluid', '4/1/2022', 3)
					 ,(4, 'Tightened Engine to Wing', '5/1/2022', 2)
					 ,(5, '100,000 mile checkup', '3/10/2022', 4)
					 ,(6, 'Replaced Loose Door', '4/10/2022', 6)
					 ,(7, 'Trapped Raccoon in Cargo Hold', '5/1/2022', 6)


INSERT INTO TFlights (intFlightID, dtmFlightDate, strFlightNumber,  dtmTimeofDeparture, dtmTimeOfLanding, intFromAirportID, intToAirportID, intMilesFlown, intPlaneID)
VALUES				  (1, '4/1/2022', '111', '10:00:00', '12:00:00', 1, 2, 1200, 2)
					 ,(2, '4/4/2023', '222','13:00:00', '15:00:00', 1, 3, 1000, 2)
					 ,(3, '4/5/2024', '333','15:00:00', '17:00:00', 1, 5, 1200, 3)
					 ,(4, '4/16/2024','444', '10:00:00', '12:00:00', 4, 6, 1100, 3)
					 ,(5, '3/14/2024','555', '18:00:00', '20:00:00', 2, 1, 1200, 3)
					 ,(6, '3/21/2025','666', '19:00:00', '21:00:00', 3, 1, 1000, 1)
					 ,(7, '3/11/2025', '777','20:00:00', '22:00:00', 3, 6, 1400, 4)
					 ,(8, '3/17/2025', '888','09:00:00', '11:00:00', 6, 4, 1100, 5)
					 ,(9, '4/19/2025', '999','08:00:00', '10:00:00', 4, 2, 1000, 6)
					 ,(10, '4/22/2025', '091','10:00:00', '12:00:00', 2, 1, 1200, 6)


INSERT INTO TPilotFlights ( intPilotFlightID, intPilotID, intFlightID)
VALUES				 ( 1, 1, 2 )
					,( 2, 1, 3 )
					,( 3, 3, 3 )
					,( 4, 3, 2 )
					,( 5, 5, 1 )
					,( 6, 2, 1 )
					,( 7, 3, 4 )
					,( 8, 2, 4 )
					,( 9, 2, 5 )
					,( 10, 3, 5 )
					,( 11, 5, 6 )
					,( 12, 1, 6 )


INSERT INTO TAttendantFlights ( intAttendantFlightID, intAttendantID, intFlightID)
VALUES				( 1, 1, 2 )
					,( 2, 2, 3 )
					,( 3, 3, 3 )
					,( 4, 4, 2 )
					,( 5, 5, 1 )
					,( 6, 1, 1 )
					,( 7, 2, 4 )
					,( 8, 3, 4 )
					,( 9, 4, 5 )
					,( 10, 5, 5 )
					,( 11, 5, 6 )
					,( 12, 1, 6 )
					

INSERT INTO TFlightPassengers ( intFlightPassengerID, intFlightID, intPassengerID, strSeat, strCost)
VALUES				 ( 1, 1, 1, '1A', '250')
					,( 2, 1, 2, '2A', '250' )
					,( 3, 1, 3, '1B', '250' )
					,( 4, 1, 4, '1C', '250' )
					,( 5, 1, 5, '1D', '250' )
					,( 6, 2, 5, '1A', '250' )
					,( 7, 2, 4, '2A', '250' )
					,( 8, 2, 3, '1B', '250' )
					,( 9, 3, 1, '1B', '250' )
					,( 10, 3, 2, '2A', '250' )
					,( 11, 3, 3, '1B', '250' )
					,( 12, 3, 4, '1C', '250' )
					,( 13, 3, 5, '1D', '250' )
					,( 14, 4, 2, '1A', '250' )
					,( 15, 4, 3, '1B', '250' )
					,( 16, 4, 4, '1C', '250' )
					,( 17, 4, 5, '1D', '250' )
					,( 18, 5, 1, '1A', '250' )
					,( 19, 5, 2, '2A', '250' )
					,( 20, 5, 3, '1B', '250' )
					,( 21, 5, 4, '2B', '250' )
					,( 22, 6, 1, '1A', '250' )
					,( 23, 6, 2, '2A', '250' )
					,( 24, 6, 3, '3A', '250' )
					

INSERT INTO TMaintenanceMaintenanceWorkers ( intMaintenanceMaintenanceWorkerID, intMaintenanceID, intMaintenanceWorkerID, intHours)
VALUES				 ( 1, 2, 1, 2 )
					,( 2, 4, 1, 3 )
					,( 3, 2, 3, 4 )
					,( 4, 1, 4, 2 )
					,( 5, 3, 4, 2 )
					,( 6, 4, 3, 5 )
					,( 7, 5, 1, 7 )
					,( 8, 6, 1, 2 )
					,( 9, 7, 3, 4 )
					,( 10, 4, 4, 1 )
					,( 11, 3, 3, 4 )
					,( 12, 7, 3, 8 )




-- STORED PROCEDURES

-- add attendant


CREATE PROCEDURE uspAddAttendant(
  @intAttendantID				AS INTEGER OUTPUT
    ,@strFirstName				AS VARCHAR(255)
    ,@strLastName				AS VARCHAR(255)
    ,@strEmployeeID				AS VARCHAR(255)
    ,@dtmDateofHire				AS DATETIME 
    ,@dtmDateofTermination		AS DATETIME 
)
AS
BEGIN
SELECT @intAttendantID = MAX(intAttendantID) + 1 
    FROM TAttendants (TABLOCKX)
    
    SELECT @intAttendantID = COALESCE(@intAttendantID, 1)
    INSERT INTO TAttendants (intAttendantID, strFirstName, strLastName, strEmployeeID, dtmDateofHire, dtmDateofTermination)
    VALUES (@intAttendantID, @strFirstName, @strLastName, @strEmployeeID, @dtmDateofHire, @dtmDateofTermination)


END

-- add employee


CREATE PROCEDURE uspAddEmployee(
  @intEmployeesID				AS INTEGER OUTPUT
    ,@strLoginID				AS VARCHAR(255)
    ,@strPassword				AS VARCHAR(255)
    ,@strEmployeeRole			AS VARCHAR(255)
    ,@intEmployeeID				AS INTEGER
)
AS
BEGIN
SELECT @intEmployeesID = MAX(intEmployeesID) + 1 
    FROM TEmployees (TABLOCKX)
    
    SELECT @intEmployeesID = COALESCE(@intEmployeesID, 1)
    INSERT INTO TEmployees (intEmployeesID, strEmployeeLoginID, strEmployeePassword, strEmployeeRole, intEmployeeID)
    VALUES (@intEmployeesID, @strLoginID, @strPassword, @strEmployeeRole, @intEmployeeID)


END

-- add passenger

CREATE PROCEDURE uspAddPassenger(
 @passenger_id AS Integer,
@first_name AS VARCHAR(255),
@last_name AS VARCHAR(255),
@address AS VARCHAR(255),
@city AS VARCHAR(255),
@state_id AS Integer,
@zip AS VARCHAR(255),
@phone_number AS VARCHAR(255),
@email AS VARCHAR(255),
@dob AS Date,
@password AS VARCHAR(255),
@loginID AS VARCHAR(255)

)
AS
BEGIN
SELECT @passenger_id = MAX(intPassengerID) + 1 
    FROM TPassengers (TABLOCKX)
    
    SELECT @passenger_id = COALESCE(@passenger_id, 1)
    INSERT INTO TPassengers (intPassengerID, strFirstName, strLastName, strAddress, strCity, intStateID, strZip, strPhoneNumber, strEmail, dtmDateOfBirth, strPassword, strLoginID)
    VALUES (@passenger_id, @first_name, @last_name, @address, @city, @state_id, @zip, @phone_number, @email, @dob, @password, @loginID)


END

-- add pilot

CREATE PROCEDURE uspAddPilot(
  @intPilotID				AS INTEGER OUTPUT
    ,@strFirstName				AS VARCHAR(255)
    ,@strLastName				AS VARCHAR(255)
    ,@strEmployeeID				AS VARCHAR(255)
    ,@dtmDateofHire				AS DATETIME 
    ,@dtmDateofTermination		AS DATETIME 
    ,@dtmDateofLicense			AS DATETIME
    ,@intPilotRoleID			AS INTEGER
)
AS
BEGIN
SELECT @intPilotID = MAX(intPilotID) + 1 
    FROM TPilots (TABLOCKX)
    
    SELECT @intPilotID = COALESCE(@intPilotID, 1)
    INSERT INTO TPilots (intPilotID, strFirstName, strLastName, strEmployeeID, dtmDateOfHire, dtmDateOfTermination, dtmDateOfLicense, intPilotRoleID)
    VALUES (@intPilotID, @strFirstName, @strLastName, @strEmployeeID, @dtmDateofHire, @dtmDateofTermination, @dtmDateofLicense, @intPilotRoleID)


END

-- attendant future flights

CREATE PROCEDURE uspAttendantFutureFlights(
	@attendant_id AS Integer,
	@date As DateTime
)
AS
BEGIN
SELECT TAttendantFlights.intAttendantFlightID, TAttendantFlights.intFlightID,
TAttendantFlights.intAttendantID,
TFlights.strFlightNumber, TFlights.dtmFlightDate, TFlights.dtmTimeofDeparture,
TFlights.dtmTimeOfLanding, TFlights.intMilesFlown
FROM TAttendantFlights
INNER JOIN TFlights ON TAttendantFlights.intFlightID = TFlights.intFlightID
WHERE TAttendantFlights.intAttendantID = @attendant_id
AND TFlights.dtmFlightDate > @date

END

-- average miles

CREATE PROCEDURE uspAverageMiles
AS
BEGIN
SELECT AVG(TF.intMilesFlown) AS AverageMiles
FROM TFlightPassengers TFP 
JOIN TFlights TF ON TFP.intFlightID = TF.intFlightID
END


-- count passengers

CREATE PROCEDURE uspCountPassengers
AS
BEGIN
SELECT COUNT(*) AS TotalPassengers FROM TPassengers
END

-- create flight

CREATE PROCEDURE uspCreateFlight(
 @flight_id AS Integer,
@flight_date AS Date,
@flight_number As VarChar(255),
@departure_time AS DateTime,
@landing_time AS DateTime,
@from_airport AS Integer,
@to_airport As Integer,
@plane_id AS Integer

)
AS
BEGIN
SELECT @flight_id = MAX(intFlightID) + 1 
    FROM TFlights (TABLOCKX)
    
    SELECT @flight_id = COALESCE(@flight_id, 1)
    INSERT INTO TFlights (intFlightID, dtmFlightDate, strFlightNumber,  dtmTimeofDeparture, dtmTimeOfLanding, intFromAirportID, intToAirportID, intMilesFlown, intPlaneID)
    VALUES (@flight_id, @flight_date, @flight_number, @departure_time, @landing_time, @from_airport, @to_airport, 0, @plane_id)


END

-- delete attendant flights

CREATE PROCEDURE uspDeleteAttendantFlights(
	@intAttendantID AS Integer
)
AS
BEGIN
DELETE FROM TAttendantFlights
	WHERE intAttendantID = @intAttendantID

END

-- find employee

CREATE PROCEDURE uspFindEmployee(
	@employee_id As Integer,
	@role As VARCHAR(255)
)
AS
BEGIN
SELECT intEmployeesID, strEmployeeLoginID, strEmployeePassword, strEmployeeRole, intEmployeeID
FROM TEmployees
WHERE intEmployeeID = @employee_id AND strEmployeeRole = @role
END

-- find passenger

CREATE PROCEDURE uspFindPassenger(
	@passenger_id AS Integer
)
AS
BEGIN
SELECT intPassengerID, strFirstName, strLastName, strAddress, strCity, intStateID, strZip, strPhoneNumber, strEmail, strLoginID, strPassword
FROM TPassengers
WHERE intPassengerID = @passenger_id
END

-- find pilot

CREATE PROCEDURE uspFindPilot(
	@pilot_id AS Integer
)
AS
BEGIN
SELECT intPilotID, strFirstName, strLastName, strEmployeeID, dtmDateofHire, dtmDateofTermination, dtmDateofLicense
FROM TPilots
WHERE intPilotID = @pilot_id
END


-- list airports

CREATE PROCEDURE uspListAirports
AS
BEGIN
SELECT 
intAirportID, strAirportCity, strAirportCode 
FROM 
TAirports 
ORDER BY 
intAirportID
END


-- list planes

CREATE PROCEDURE uspListPlanes
AS
BEGIN
SELECT 
intPlaneID, strPlaneNumber, intPlaneTypeID 
FROM 
TPlanes 
ORDER BY 
intPlaneID
END

-- list states

CREATE PROCEDURE uspListStates
AS
BEGIN
SELECT 
intStateID, strState 
FROM 
TStates 
ORDER BY 
strState
END


-- pilot future flights

CREATE PROCEDURE uspPilotFutureFlights(
	@pilot_id AS Integer,
	@date AS DateTime
)
AS
BEGIN
SELECT TPilotFlights.intPilotFlightID, TPilotFlights.intFlightID,
TPilotFlights.intPilotID,
TFlights.strFlightNumber, TFlights.dtmFlightDate, TFlights.dtmTimeofDeparture,
TFlights.dtmTimeOfLanding, TFlights.intMilesFlown
FROM TPilotFlights
INNER JOIN TFlights ON TPilotFlights.intFlightID = TFlights.intFlightID
WHERE TPilotFlights.intPilotID = @pilot_id
AND TFlights.dtmFlightDate > @date

END

-- total attendant miles

CREATE PROCEDURE uspTotalAttendantMiles
AS
BEGIN
SELECT TA.strFirstName + ' ' + TA.strLastName AS AttendantName, SUM(TF.intMilesFlown) AS TotalMiles
FROM TAttendants TA
LEFT JOIN TAttendantFlights TAF ON TA.intAttendantID = TAF.intAttendantID
LEFT JOIN TFlights TF ON TAF.intFlightID = TF.intFlightID
GROUP BY TA.intAttendantID, TA.strFirstName, TA.strLastName
ORDER BY TA.strLastName
END

-- total pilot miles

CREATE PROCEDURE uspTotalPilotMiles
AS
BEGIN
SELECT TP.strFirstName + ' ' + TP.strLastName AS PilotName, SUM(TF.intMilesFlown) AS TotalMiles
FROM TPilots TP
LEFT JOIN TPilotFlights TPF ON TP.intPilotID = TPF.intPilotID
LEFT JOIN TFlights TF ON TPF.intFlightID = TF.intFlightID
GROUP BY TP.intPilotID, TP.strFirstName, TP.strLastName
ORDER BY TP.strLastName
END


-- update passenger

CREATE PROCEDURE uspUpdatePassenger(
@passenger_id AS Integer,
@first_name AS VARCHAR(255),
@last_name AS VARCHAR(255),
@address AS VARCHAR(255),
@city AS VARCHAR(255),
@state_id AS Integer,
@zip AS VARCHAR(255),
@phone_number AS VARCHAR(255),
@email AS VARCHAR(255),
@loginid AS VARCHAR(255),
@password AS VARCHAR(255)
)
AS
BEGIN
UPDATE TPassengers SET 
		strFirstName = @first_name,
		strLastName = @last_name,	
		strAddress = @address,	
		strCity = @city,
		intStateID = @state_id,
		strZip = @zip,
		strPhoneNumber = @phone_number,
		strEmail = @email,
		strLoginID = @loginid,
		strPassword = @password

WHERE intPassengerID = @passenger_id
END
