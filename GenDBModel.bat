@echo off
cd Infrastructure
dotnet ef dbcontext scaffold "Server=103.168.54.3;Database=nhaphangvippro;User Id=nhaphangvippro;Password=mona@123;MultipleActiveResultSets=true;Persist Security Info=true;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer --output-dir "..\Domain\Entities" --context AppDbContext --context-dir "DBContexts" --namespace Domain.Entities --context-namespace Infrastructure.DbContexts --force --no-onconfiguring 
if %errorlevel%==0 (echo Done!) else (echo Failed!)
pause