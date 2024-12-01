# Car Shop But In .Net

This is the project that marks the entry of my journey into .Net. This project is a simple car shop that allows users to add cars to the shop and view the cars in the shop. 
I have followed proper standards and practices to make this project as clean as possible.
the project structure is inspired by the [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html) by Uncle Bob.

## Startup

1. Restore Dependencies
```bash
dotnet restore
```

2. Update Database
```bash
dotnet ef database update
```

3. Run the project
```bash
dotnet run
```

## Standard Project Structure 

```text
YourProjectName/
│
├── src/
│   ├── YourProjectName.API/
│   │   ├── Controllers/
│   │   │   ├── UsersController.cs
│   │   │   ├── ProductsController.cs
│   │   │   └── AuthController.cs
│   │   ├── Middlewares/
│   │   │   ├── ErrorHandlingMiddleware.cs
│   │   │   └── RequestLoggingMiddleware.cs
│   │   ├── Extensions/
│   │   │   ├── ServiceCollectionExtensions.cs
│   │   │   └── ApplicationBuilderExtensions.cs
│   │   ├── appsettings.json
│   │   ├── appsettings.Development.json
│   │   └── Program.cs
│   │
│   ├── YourProjectName.Application/
│   │   ├── Services/
│   │   │   ├── Interfaces/
│   │   │   │   ├── IUserService.cs
│   │   │   │   └── IProductService.cs
│   │   │   ├── Implementation/
│   │   │   │   ├── UserService.cs
│   │   │   │   └── ProductService.cs
│   │   ├── DTOs/
│   │   │   ├── UserDto.cs
│   │   │   ├── CreateUserDto.cs
│   │   │   ├── ProductDto.cs
│   │   │   └── CreateProductDto.cs
│   │   ├── Mappings/
│   │   │   └── MappingProfile.cs
│   │   └── Validators/
│   │       ├── UserValidator.cs
│   │       └── ProductValidator.cs
│   │
│   ├── YourProjectName.Domain/
│   │   ├── Entities/
│   │   │   ├── User.cs
│   │   │   ├── Product.cs
│   │   │   └── BaseEntity.cs
│   │   ├── Interfaces/
│   │   │   ├── IRepository.cs
│   │   │   └── IUnitOfWork.cs
│   │   └── Enums/
│   │       ├── UserRole.cs
│   │       └── ProductCategory.cs
│   │
│   ├── YourProjectName.Infrastructure/
│   │   ├── Data/
│   │   │   ├── ApplicationDbContext.cs
│   │   │   ├── Configurations/
│   │   │   │   ├── UserConfiguration.cs
│   │   │   │   └── ProductConfiguration.cs
│   │   ├── Repositories/
│   │   │   ├── GenericRepository.cs
│   │   │   ├── UserRepository.cs
│   │   │   └── ProductRepository.cs
│   │   ├── Services/
│   │   │   ├── AuthService.cs
│   │   │   └── EmailService.cs
│   │   └── Migrations/
│   │
│   └── YourProjectName.Tests/
│       ├── UnitTests/
│       │   ├── Services/
│       │   │   ├── UserServiceTests.cs
│       │   │   └── ProductServiceTests.cs
│       │   └── Controllers/
│       │       ├── UsersControllerTests.cs
│       │       └── ProductsControllerTests.cs
│       └── IntegrationTests/
│           ├── Repositories/
│           └── Services/
│
├── docs/
│   ├── API.md
│   └── ARCHITECTURE.md
│
├── scripts/
│   ├── database/
│   │   └── migrate.sh
│   └── deploy/
│       └── deploy.sh
│
├── YourProjectName.sln
└── README.md
```

## Technologies Used

- .Net 9
- Entity Framework Core
- FluentValidation
- AutoMapper
- Swagger
- Sqlite