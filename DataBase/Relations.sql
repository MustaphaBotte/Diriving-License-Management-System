alter table Customers
add foreign key (NationalityID) references Nationality(NationalityID)

alter table Orders
add foreign key (ApplicantID) references Customers(CustomerID)

alter table Orders
add foreign key (ServiceID) references MainServices(ServiceID)

alter table EyeTest
add foreign key (ApplicantID) references Customers(CustomerID)

alter table EyeTest
add foreign key (TestFeesID) references TestsFees(TestFeeID)

alter table Theoretical_Test
add foreign key (ApplicantID) references Customers(CustomerID)

alter table Theoretical_Test
add foreign key (TestFeesID) references TestsFees(TestFeeID)


alter table Driving_Test
add foreign key (ApplicantID) references Customers(CustomerID)

alter table Driving_Test
add foreign key (DrivingServiceID) references MainServices(ServiceID)

alter table Licenses
add foreign key (LicenseClassID) references Licensing_categories(LicenseClassID)

alter table users
add foreign key (NationalityID) references Nationality(NationalityID)


alter table Licenses
add foreign key (CustomerID) references Customers(CustomerID)
