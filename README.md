## DB Configuration
1. Rename file from App.config.example to App.config
2. Change configuration string to your DB connection
3. Migrate database, in package manager insert commands:
    1. dotnet ef migrations [migration-name]
    2. dotnet ef database update
## How to regenerate DB
1. Delete migrations        
2. Drop database:
    use master
    alter database RackManager set single_user with rollback immediate
    DROP DATABASE RackManager
3. Recreate migrations (see "DB Configuration" section 3)