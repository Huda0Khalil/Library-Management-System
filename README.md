# Library Management System
## Setup instructions:<br>
> *Clone repository :
Open cmd 
write git clone https://github.com/Huda0Khalil/Library-Management-System.git
<br>
## Back-end<br>
> * Open Microsoft Visual Stadio 
file -> open project/solution -> choose Library-Management-System
> * Update appsettings.json with your SQL Server connection string.
> * view -> other windows -> package manager console -> write: Update-Database -Project "Library Management System.Infrastructure" -StartupProject "Library Management System.API"
> * Execute the provided stored procedure script (DatabaseScripts/stored_procedures.sql) in SQL Server.
> * run API
<br>
## Front-End<br>
- Open Visual Stadio Code -> Open folde -> choose LibraryManagementSystem.FrontEnd
- open LibraryManagementSystem.FrontEnd\src\environments\environment.ts -> change apiUrl value to Url appear when run back-end -> save.
- Terminal -> New Terminal -> write: npm install -> ng s 

## Time Estimation vs Actual:<br>
Estimated time: 1 week .<br>
Actual time spent: 1 week.

## Challenges Faced:<br>

1.Structuring the Onion Architecture with DDD correctly at the start.<br>
2.EF migrations didn’t include stored procedures → had to create SQL manually.

## AI Tool Usage:
chatgpt:
Onion Architecture DDD Implementation: https://chatgpt.com/share/68cec027-5ee8-8006-95af-9011c3457bf5 <br>
DDD onion architecture steps: https://chatgpt.com/share/68cec027-5ee8-8006-95af-9011c3457bf5 <br>
Book and Category attributes: https://chatgpt.com/share/68cec0c0-7fb0-8006-a6c2-2c635dc48b79 <br>
Many-to-many relation implementation: https://chatgpt.com/share/68cec13c-4de4-8006-85a7-3e6669d36b75 <br>
Correct navbar code: https://chatgpt.com/share/68cec16d-8f68-8006-8006-bbc9c0196f95 <br>
Goback implementation angular: https://chatgpt.com/share/68cec19d-ccc4-8006-a01b-0814d0360e11 <br>



