# Library Management System
##Setup instructions:
1- Clone repository :
Open cmd 
write git clone https://github.com/Huda0Khalil/Library-Management-System.git
**Back-end
2- Open Microsoft Visual Stadio
file -> open project/solution -> choose Library-Management-System
3- Update appsettings.json with your SQL Server connection string.
4- view -> other windows -> package manager console -> write: Update-Database -Project "Library Management System.Infrastructure" -StartupProject "Library Management System.API"
5- Execute the provided stored procedure script (DatabaseScripts/stored_procedures.sql) in SQL Server.
6- run API
**Front-End
1- Open Visual Stadio Code -> Open folde -> choose LibraryManagementSystem.FrontEnd
2- open LibraryManagementSystem.FrontEnd\src\environments\environment.ts -> change apiUrl value to Url appear when run back-end -> save.
2- Terminal -> New Terminal -> write: npm install -> ng s 

##Time Estimation vs Actual:
Estimated time: 1 week .
Actual time spent: 1 week.

##Challenges Faced:

1.Structuring the Onion Architecture with DDD correctly at the start.
2.EF migrations didn’t include stored procedures → had to create SQL manually.

##AI Tool Usage::
chatgpt:
Onion Architecture DDD Implementation: https://chatgpt.com/share/68cec027-5ee8-8006-95af-9011c3457bf5
DDD onion architecture steps: https://chatgpt.com/share/68cec027-5ee8-8006-95af-9011c3457bf5
Book and Category attributes: https://chatgpt.com/share/68cec0c0-7fb0-8006-a6c2-2c635dc48b79
Many-to-many relation implementation: https://chatgpt.com/share/68cec13c-4de4-8006-85a7-3e6669d36b75
Correct navbar code: https://chatgpt.com/share/68cec16d-8f68-8006-8006-bbc9c0196f95
Goback implementation angular: https://chatgpt.com/share/68cec19d-ccc4-8006-a01b-0814d0360e11



