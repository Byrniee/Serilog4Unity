# Serilog4Unity

A package which connects Serilog to the logging abstraction.

### Install
This package depends on the Unity Logging, Unity Json and Unity Configuration package. Add all packages to your manifest.json file located under the Packages folder. 

```
  "dependencies": {
    "com.byrniee.serilog4unity": "git@github.com:Byrniee/Serilog4Unity.git",
    "com.byrniee.unitylogging": "git@github.com:Byrniee/UnityLogging.git",
    "com.byrniee.unityconfiguration": "git@github.com:Byrniee/UnityConfiguration.git",
    "com.byrniee.unityjson": "git@github.com:Byrniee/UnityJson.git",
```

### Config
The package can be configured using the UnityConfiguration package.

```
  "Serilog": {
      "GlobalMinimumLoggingLevel": "Information",
      "Unity": {
          "MinimumLoggingLevel": "Information",
          "OutputTemplate": "[{Timestamp:HH:mm:ss.fff} [{Level}] {SourceContext}] {Message:lj}{NewLine}{Exception}"
      },
      "File": {
          "MinimumLoggingLevel": "Information",
          "OutputTemplate": "[{Timestamp:HH:mm:ss.fff} [{Level}] {SourceContext}] {Message:lj}{NewLine}{Exception}",
          "FileName": "Logs/log.txt",
          "FileRetensionDays": 7
      },
      "Graylog": {
          "BaseUrl": "http://localhost",
          "Port": 12201,
      }
  }
```
