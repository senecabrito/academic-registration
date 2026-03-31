# Academic Registration

API REST em ASP.NET Core para cadastro de alunos e professores, usando Entity Framework Core com SQL Server, camada de servicos, mapeamento via Mapster e logging com Serilog.

## Stack
- .NET 10.0 (TargetFramework net10.0)
- ASP.NET Core Web API + Swagger
- Entity Framework Core 10.0 com SQL Server
- Mapster para conversao Entity <-> DTO
- Serilog para logs em console/debug

## Estrutura
```
AcademicRegistration.sln
AcademicRegistration.Api/            # Endpoints HTTP, DI, Swagger e logging
  Program.cs
  Controllers/ (StudentController, TeacherController)
  Configurations/ (DatabaseConfig, LoggingConfig)
  appsettings.json
AcademicRegistration.Business/       # DTOs e servicos
  DTOs/ (StudentDTO, TeacherDTO)
  Services/ (Abstractions, Impl)
AcademicRegistration.Data/           # EF Core + repositorios
  Database/Context/MSSQLContext.cs
  Models/ (Student, Teacher, BaseEntity)
  Repositories/ (IRepository, GenericRepository)
  Migrations/ (InitialCreate)
```

## Requisitos
- .NET SDK 10.0 instalado (precisa do preview mais recente)
- SQL Server 2022+ acessivel (local ou via Docker)
- Ferramenta EF CLI: `dotnet tool install --global dotnet-ef` (se ainda nao tiver)

## Configurar conexao
1) Defina a string de conexao MSSQL usando variavel de ambiente ou edite `AcademicRegistration.Api/appsettings.json`:
```
MSSQLServerSQLConnection__MSSQLServerSQLConnectionString=Data Source=localhost,1433;Initial Catalog=aspnet10_seneca;User Id=sa;Password=<sua_senha>;TrustServerCertificate=True;
```
2) Opcional: subir SQL Server rapidamente com Docker (porta 1433):
```
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=YourStrong!Passw0rd" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest
```

## Preparar banco de dados
Ja existe a migracao inicial (`20260331165714_InitialCreate`). Para aplicar:
```
dotnet ef database update --project AcademicRegistration.Data --startup-project AcademicRegistration.Api
```

## Executar a API
```
dotnet restore
dotnet run --project AcademicRegistration.Api --launch-profile http
```
- Endereco de desenvolvimento: `http://localhost:5299` (veja a porta no console).
- Swagger UI: `http://localhost:5299/swagger`.

## Endpoints principais
Aluno (`/api/student`):
- GET `/`  -> lista todos
- GET `/{id}` -> busca por id
- POST `/` -> cria (body JSON)
- PUT `/{id}` -> atualiza
- DELETE `/{id}` -> remove

Professor (`/api/teacher`):
- GET `/`
- GET `/{id}`
- POST `/`
- PUT `/{id}`
- DELETE `/{id}`

### Exemplo de payloads
Aluno:
```json
{
  "id": "00000000-0000-0000-0000-000000000000",
  "name": "Maria Silva",
  "age": 20,
  "enrollment": "ABC123456"
}
```
Professor:
```json
{
  "id": "00000000-0000-0000-0000-000000000000",
  "name": "Joao Souza",
  "age": 35,
  "wage": 3500.00,
  "enrollment": "XYZ987654"
}
```

## Regras de validacao de dominio
- Aluno: nome obrigatorio (max 50), idade 7-100, enrollment com 9 caracteres.
- Professor: nome obrigatorio (max 50), idade 22-100, wage entre 1500 e 100000, enrollment com 9 caracteres.

## Logs
- Serilog configurado em `appsettings.json` escreve em console e debug; o logger e registrado no startup via `LoggingConfig`.

## Comandos uteis
- Nova migracao: `dotnet ef migrations add <Nome> --project AcademicRegistration.Data --startup-project AcademicRegistration.Api`
- Atualizar banco: `dotnet ef database update --project AcademicRegistration.Data --startup-project AcademicRegistration.Api`
