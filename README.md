# Projeto de API usando C# e .NET Core

Jornada .NET Direto ao Ponto

## Comandos básicos:
```
dotnet new webapi -o DevReviews.API
dotnet build
dotnet run
```

## Comandos user-secrets
```
dotnet user-secrets init
dotnet user-secrets set "DevReviewsCn" "Server=localhost;Database=jornada-dotnet-db;User ID=sa;Password=senha;"
dotnet user-secrets list
```

## Tool Entity Framework Core (migrations)
```
dotnet tool install --global dotnet-ef
```

## Migratons
```
dotnet ef migrations add InitialMigration -o Persistence/Migrations
dotnet ef database update
```