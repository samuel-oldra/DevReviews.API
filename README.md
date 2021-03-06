# Projeto de API usando C# e .NET 5

## DevReviews - Jornada .NET Direto ao Ponto

Foi desenvolvida uma API REST completa de gerenciamento de produtos e suas avaliações de um e-Commerce.

## Tecnologias e práticas utilizadas
- ASP.NET Core com .NET 5
- Entity Framework Core
- SQL Server / In-Memory database
- Swagger
- AutoMapper
- Injeção de Dependência
- Programação Orientada a Objetos
- Padrão Repository
- Logs com Serilog
- Clean Code
- Publicação

## Funcionalidades
- Cadastro, Listagem, Detalhes, Atualização e Remoção de Produto
- Cadastro e Detalhes de uma Avaliação

###

![alt text](https://raw.githubusercontent.com/samuel-oldra/DevReviews.API/main/README_IMGS/swagger_ui.png)

## Comandos básicos
```
dotnet new gitignore
dotnet new webapi -o DevReviews.API
dotnet build
dotnet run
dotnet watch run
dotnet publish
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

## Migrations
```
dotnet ef migrations add InitialMigration -o Persistence/Migrations
dotnet ef database update
```