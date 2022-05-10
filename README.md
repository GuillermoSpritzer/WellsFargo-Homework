# WellsFargo.Homework
 
Application to process transactions files into order files for different OMSs.

The application is a web client where you can upload a transaction file and it will create order files on the output folder.

You can configure the input and output paths on appsettings.json in project  WellsFargo.Homework.Web

Prerequisites Ensure you have the following installed on your development machine:

nodejs 10.16.3 (Required by npm)

Net Core 5.0 SDK


## To run locally, follow next steps

System requirements:

.Net Core v5.0.4 --- installation ( https://dotnet.microsoft.com/download/dotnet/5.0 )

nodejs 10.16.3 (Required by npm)

Once installed donwload repository and open the folder on console

```
$ cd ../WellsFargo.Homework.Web/ClientApp

$ npm install

$ cd ../WellsFargo.Homework.Web

$ dotnet build

$ dotnet run
```

Application will run on port 5001:8080

