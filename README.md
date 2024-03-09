# UserService
![](https://img.shields.io/badge/-Csharp-262424?style=for-the-badge&logo=CSharp&logoColor=684D95)

> ### Database migrations (from root dir)
> > dotnet ef migrations add **{MigrationName}** --project UserService.Infrastructure --startup-project UserService.Api 
>
> > dotnet ef database update --project UserService.Infrastructure --startup-project UserService.Api