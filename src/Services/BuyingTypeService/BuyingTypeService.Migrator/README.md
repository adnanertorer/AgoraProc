# BuyingTypeService.Migrator

## Hakk�nda

Bu proje, Entity Framework Core kullanarak veritaban� migration i�lemlerini y�netmek i�in geli�tirilmi� bir console uygulamas�d�r.

- PostgreSQL veritaban� desteklenmektedir.
- Environment (ortam) bazl� `Development` ve `Production` konfig�rasyonu destekler.
- Migration ve veritaban� i�lemlerini terminalden komutlarla y�netebilirsiniz.

## Kullan�m

�ncelikle solution seviyesinde terminal a��n.  
T�m komutlar `src/Services/BuyingTypeService/BuyingTypeService.Migrator` �zerinden �al��t�r�l�r.

### Environment Belirleme

Varsay�lan environment `Development`'t�r.  
�sterseniz `--environment Production` �eklinde belirtilebilir.

---

## Komutlar

dotnet run --project src/Services/BuyingTypeService/BuyingTypeService.Migrator -- add-migration MigrationName

dotnet run --project src/Services/BuyingTypeService/BuyingTypeService.Migrator -- update-database

dotnet run --project src/Services/BuyingTypeService/BuyingTypeService.Migrator -- list-migrations

dotnet run --project src/Services/BuyingTypeService/BuyingTypeService.Migrator -- remove-migration

dotnet run --project src/Services/BuyingTypeService/BuyingTypeService.Migrator -- reset-database

dotnet run --project src/Services/BuyingTypeService/BuyingTypeService.Migrator -- script-migrations

## Ba��ml�l�klar

Microsoft.EntityFrameworkCore.Design

Npgsql.EntityFrameworkCore.PostgreSQL

.NET 9.0 SDK

## Notlar

BuyingTypeDbContext i�in BuyingTypeDbContextFactory kullan�lm��t�r.

src/Services/BuyingTypeService/BuyingTypeService.Persistence projesinde migration dosyalar� tutulur.

appsettings.json ve appsettings.Development.json gibi dosyalar environment bazl� okunur.

Her tehlikeli i�lem (drop-database, reset-database, remove-migration) �ncesinde kullan�c� onay� al�n�r.





