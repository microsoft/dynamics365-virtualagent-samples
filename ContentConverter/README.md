# Overview  
This tool will convert Dynamics365 Virtual Agent topics and trigger phrases into intents and utterances to LU file formats which can be used to create LUIS models.  

# Prerequistes  
[Getting Virtual Agent Content](https://docs.microsoft.com/en-us/dynamics365/ai/customer-service-virtual-agent/gdpr-export)  
[LU Tool](https://github.com/microsoft/botbuilder-tools/tree/master/packages/Ludown)
[NuGet Package Manager](https://www.nuget.org/downloads)  
[.Net Core 2.2 Runtime](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.300-windows-x64-installer)

# Usage  
Open cmd prompt and navigate to .csproj directory  
Run this command  
```dotnet run –project ContentConverter.csproj - c Release -- -i <path for msdynce_botcontents.csv>  -c <path for annotations.csv> -b <bot id> ```   
This will generate **Content.lu** file in same directory as the project.  
Please follow this document to learn more about this.[link](https://docs.microsoft.com/en-us/dynamics365/ai/customer-service-virtual-agent/how-to-use-dispatcher)

