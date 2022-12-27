@ECHO OFF
cd..
cd Ecommerce.Application
dotnet tool update dotnet-ef --global
dotnet ef dbcontext scaffold name=DefaultConnection Microsoft.EntityFrameworkCore.SqlServer -o ../Ecommerce.Data/Entities --context AppDbContext --project ../Ecommerce.Data --force --no-build                                              
ECHO DATABASE SCAFFOLDING DONE...
PAUSE