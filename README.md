<h1 align="center">
  DevReviews - Jornada .NET Direto ao Ponto
</h1>
<p align="center">
  <a href="#tecnologias-e-práticas-utilizadas">Tecnologias e práticas utilizadas</a> •
  <a href="#funcionalidades">Funcionalidades</a> •
  <a href="#comandos">Comandos</a>
</p>

Foi desenvolvida uma API REST completa de gerenciamento de produtos e suas avaliações de um e-Commerce.

## Tecnologias e práticas utilizadas
- ASP.NET Core com .NET 5
- Entity Framework Core
- SQL Server / SQLite / In-Memory database
- Swagger
- AutoMapper
- Injeção de Dependência
- Programação Orientada a Objetos
- Padrão Repository
- Logs com Serilog
- Testes com xUnit, AutoFixture, Moq e Shouldly
- Clean Code
- Publicação

## Funcionalidades
- Cadastro, Listagem, Detalhes, Atualização e Remoção de Produto
- Cadastro e Detalhes de uma Avaliação

###

![alt text](https://raw.githubusercontent.com/samuel-oldra/DevReviews.API/main/README_IMGS/swagger_ui.png)

## Comandos

### Comandos básicos
```
dotnet new gitignore
dotnet new webapi -o DevReviews.API
dotnet build
dotnet run
dotnet watch run
dotnet test
dotnet publish
```

### Comandos user-secrets
```
dotnet user-secrets init
dotnet user-secrets set "DevReviewsCn" "Server=***;Database=***;User ID=***;Password=***;"
dotnet user-secrets remove "DevReviewsCn"
dotnet user-secrets clear
dotnet user-secrets list
```

### Tool Entity Framework Core (migrations)
```
dotnet tool install --global dotnet-ef
dotnet tool uninstall --global dotnet-ef
```

### Migrations
```
dotnet ef migrations add InitialMigration -o Persistence/Migrations
dotnet ef database update
```
