# Overview  
This tool will convert Dynamics365 Virtual Agent topics and trigger phrases into intents and utterances to LU file formats which can be used to create LUIS models.  

# Prerequistes  
[Getting Virtual Agent Content](https://docs.microsoft.com/en-us/dynamics365/ai/customer-service-virtual-agent/gdpr-export)  
[LU Tool](https://github.com/microsoft/botbuilder-tools/tree/master/packages/Ludown)  

# Usage  
Open cmd prompt and navigate to .csproj directory  
Run this command  
```dotnet run –project ContentConverter.csproj - c Release -- -i <path for msdynce_botcontents.csv>  -o <path for annotations.csv> -b <bot id> ```   
This will generate **content.lu** file in same directory as the project.  
Please follow this document to learn more about this.[link](insert link here)

