## DB Configuration
1. Rename file from App.config.example to App.config
2. Change configuration string to your DB connection
3. Migrate database, in package manager insert commands:
    1. dotnet ef migration [migration-name]
    2. gotnet ef database update