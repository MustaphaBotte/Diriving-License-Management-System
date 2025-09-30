create database Driving_License_Management
use Driving_License_Management

create table Customers
(
CustomerID int primary key identity(1,1),
NationalNumber nvarchar(15) unique not null,
FirstName  nvarchar(20)not null,
LastName   nvarchar(20)not null,
MiddleName nvarchar(20) null,
BirthDate date not null,
AddressInfo nvarchar(50) not null,
Phone nvarchar(15) unique not null,
Email nvarchar(50) unique not null,
NationalityID int not null,
Picture varbinary(max) not null
)

create table Nationality
(
NationalityID int primary key identity(1,1),
NationalityName nvarchar(20) unique not null
)

create table MainServices
(ServiceID int primary key identity(1,1),
ServiceName nvarchar(35)unique not null,
Servicedescription nvarchar(500) null,
ServicePrice decimal(10,2) not null
)

create table Orders
(OrderId int primary key identity(1,1),
OrderDate datetime not null,
ApplicantID int not null,
ServiceID int not null,
OrderStatus nvarchar(10) not null,
FeesPaid decimal(10,2) null
)

create table Licensing_categories
(LicenseClassID int primary key identity(1,1),
ClassName nvarchar(30) unique not null,
ClassDescription nvarchar(500) not null,
MinimumAllowedAge int not null,
Expire_Date date not null,
ClassFees decimal(10,2)
)

create table TestsFees
(TestFeeID int primary key identity(1,1),
TestName nvarchar(50) unique not null,
TestFees decimal(10,2) not null
)

create table EyeTest
(EyeTestID int primary key identity(1,1),
ApplicantID int not null,
TestDate date not null,
Teststatus nvarchar(30) not null,
TestFeesID int not null
)

create table Theoretical_Test
(Theoretical_TestID int primary key identity(1,1),
ApplicantID int not null,
TestDate date not null,
Teststatus nvarchar(30) not null,
TestMark tinyint not null,
TestFeesID int not null
)

create table Driving_Test
(Driving_TestID int primary key identity(1,1),
ApplicantID int not null,
TestDate date not null,
Teststatus nvarchar(30) not null,
DrivingServiceID int not null,
PaymentTtatus nvarchar(30) not null
)

create table Licenses
(LicenseID int primary key identity(1,1),
HolderNationalNumber nvarchar(15) unique not null,
HodlderPicture varbinary(max)not null ,
HolderFirstName  nvarchar(20)not null,
HolderLastName   nvarchar(20)not null,
HolderMiddleName nvarchar(20) null,
HolderBirthDate date not null,
LicenseClassID int not null,
Issue_Date date not null,
Expiration_Date date not null, 
License_Conditions nvarchar(max) ,
License_Issuance_Status nvarchar(30) default('new') not null
)

create table Users
(
UserID int primary key identity(1,1),
NationalNumber nvarchar(15) unique not null,
FirstName  nvarchar(20)not null,
LastName   nvarchar(20)not null,
MiddleName nvarchar(20) null,
BirthDate date not null,
AddressInfo nvarchar(50) not null,
Phone nvarchar(15) unique not null,
Email nvarchar(50) unique not null,
NationalityID int not null,
Picture varbinary(max)not null,
UserName nvarchar(30) not null,
Pass_Word nvarchar(255) not null
)