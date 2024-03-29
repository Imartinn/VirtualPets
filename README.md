﻿# VirtualPets
.Net Core 3.0 based project representing a basic API for a virtual pet shop game.

## Structure
The solution is divided into several projects:
- Api: Basically a collection of controllers exposing logic's services
- Logic: A library containing the services, helpers, projections... (also interfaces and data config which would usually be in separate projects)
- Workers: Contains the long running service we're using on background
- Tests: A collection of tests testing the services

## Technology
.Net Core 3.0, EF Core, xUnit and SQLite.

## How to run it?
1. Make sure you have .Net Core 3.0 SDK
2. Clone the repository
3. cd to VirtualPets and dotnet build
4. dotnet VirtualPets.Api\bin\Debug\netcoreapp3.0\VirtualPets.Api.dll
5. dotnet VirtualPets.Workers\bin\Debug\netcoreapp3.0\VirtualPets.Workers.dll
6. Open a browser and go to localhost:5001

You can also run it from Visual Studio or executing the '.exe' .Net Core 3.0 now creates along with '.dll'

## What can I do with it?
Once you reach the web you'll be looking at Swagger UI, there you can navigate through the exposed endpoints and interact with the API.  
First you need to create a user, go to POST User section, click 'try it out', fill the required data, execute the call and keep the generated GUID you get as a response.  
Now go GET Adoption/GetTypes to see what kind of animals you can adopt, then POST Adoption filling the JSON Swagger provides you with the user id you got before, the desired animal name and type. Save the id you just got as a response, that's your animal Id.  
Using those id's you can now use the rest of the exposed endpoints to feed, stroke, or check your animal status.  
If you didn't forget to run the worker, there's a process lowering every animal happiness and hunger levels every minute (you can edit secondInterval variable in the Worker class).

## Notes for improvement
Implement authentication and drop userIds usage  
Separate domain and data files from logic  
Handle manually thrown exceptions to return correct status codes
