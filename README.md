# WellsFargo.Homework
 
Application to process transactions files into order files ofr different OMSs.

The application is a web client where you can upload a transaction file.

Prerequisites Ensure you have the following installed on your development machine:

nodejs 10.16.3 (Required by npm)

Net Core 5.0 SDK

Assumptions:

You can configure the input and output paths on appsettings.json int project  WellsFargo.Homework.Web

Running the ApplicationIn Debug Mode

Navigate to the ClientApp subdirectory in project WellsFargo.Homework.Web on CMD client and run "npm install". This will download the npm dependencies.

In the ClientApp subdirectory in a CLI and run "npm start".

Navigate to WellsFargo.Homework.Web in CMD client and do following commands:
dotnet build
dotnet run

Load the Cambium.MarsRover solution in Visual Studio 2019.

press start and the application should start.
