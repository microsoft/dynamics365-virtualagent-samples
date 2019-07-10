# Overview  
This tool will convert Dynamics365 Virtual Agent topics and trigger phrases into intents and utterances to LU file formats which can be used to create LUIS models.  

# Prerequistes  
* [Retrieve topics and utterances from your Dynamics 365 Virtual Agent](https://docs.microsoft.com/en-us/dynamics365/ai/customer-service-virtual-agent/how-to-use-dispatcher#retrieve-topics-and-utterances-from-your-bot)  
* [Microsoft Bot Framework LUDown utility](https://github.com/microsoft/botbuilder-tools/tree/master/packages/Ludown)
* [NuGet Package Manager](https://www.nuget.org/downloads)  
* .NET Core 2.2 runtime: [x86](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.300-windows-x86-installer) | [x64](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.300-windows-x64-installer)

# Usage
1. Open `cmd` prompt and navigate to .csproj directory  
2. Run the following command

    ```
    dotnet run -p ContentConverter.csproj -c Release -- -i <path to msdynce_botcontents.csv> -c <path to annotations.csv> -b <your bot id>
    ```
This utility will generate `Content.lu` file in same directory as the project.  

# Related articles
* [Use a Microsoft Bot Framework bot with Dynamics 365 Virtual Agent for Customer Service](https://docs.microsoft.com/en-us/dynamics365/ai/customer-service-virtual-agent/how-to-use-dispatcher)

