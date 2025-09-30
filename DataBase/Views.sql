create view My_LocalDLAView  as
select
 R1.LocalDrivingLicenseApplicationID as LocDLA_ID,
 LicenseClasses.ClassName as ClassName,
 People.NationalNo as NationalNo,
 CONCAT(People.FirstName,' ', People.LastName)as FullName,
 R1.ApplicationDate as ApplicationData,
 isnull(sum (CONVERT(int,Tests.TestResult)),0) as PassedTests,

 case
 when R1.ApplicationStatus =1 then 'New'
 when R1.ApplicationStatus =2 then 'Canceled'
 when R1.ApplicationStatus =3 then 'Completed'
 end as ApplicationStatus

from
(select 
App.ApplicationDate,
App.ApplicationStatus,
Loc.LocalDrivingLicenseApplicationID, 
Loc.LicenseClassID,People.PersonID
from LocalDrivingLicenseApplications Loc
inner join Applications App on App.ApplicationID = Loc.ApplicationID
inner join People on App.ApplicantPersonID = People.PersonID
)R1 
inner join People  on R1.PersonID = People.PersonID
inner join LicenseClasses  on R1.LicenseClassID = LicenseClasses.LicenseClassID
left join TestAppointments on TestAppointments.LocalDrivingLicenseApplicationID = R1.LocalDrivingLicenseApplicationID
left join Tests on Tests.TestAppointmentID = TestAppointments.TestAppointmentID 
group by R1.LocalDrivingLicenseApplicationID,
LicenseClasses.ClassName,
  People.NationalNo,
  People.FirstName,
  People.LastName,
  R1.ApplicationDate,
  R1.ApplicationStatus


select * from LocalDrivingLicenseApplications_View

