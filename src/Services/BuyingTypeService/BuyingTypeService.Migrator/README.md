# BuyingTypeService.Migrator

## Hakkýnda

Bu proje, Entity Framework Core kullanarak veritabaný migration iþlemlerini yönetmek için geliþtirilmiþ bir console uygulamasýdýr.

- PostgreSQL veritabaný desteklenmektedir.
- Environment (ortam) bazlý `Development` ve `Production` konfigürasyonu destekler.
- Migration ve veritabaný iþlemlerini terminalden komutlarla yönetebilirsiniz.

## Kullaným

Öncelikle solution seviyesinde terminal açýn.  
Tüm komutlar `src/Services/BuyingTypeService/BuyingTypeService.Migrator` üzerinden çalýþtýrýlýr.

### Environment Belirleme

Varsayýlan environment `Development`'týr.  
Ýsterseniz `--environment Production` þeklinde belirtilebilir.

---

## Komutlar

dotnet run --project src/Services/BuyingTypeService/BuyingTypeService.Migrator -- add-migration MigrationName

dotnet run --project src/Services/BuyingTypeService/BuyingTypeService.Migrator -- update-database

dotnet run --project src/Services/BuyingTypeService/BuyingTypeService.Migrator -- list-migrations

dotnet run --project src/Services/BuyingTypeService/BuyingTypeService.Migrator -- remove-migration

dotnet run --project src/Services/BuyingTypeService/BuyingTypeService.Migrator -- reset-database

dotnet run --project src/Services/BuyingTypeService/BuyingTypeService.Migrator -- script-migrations

## Baðýmlýlýklar

Microsoft.EntityFrameworkCore.Design

Npgsql.EntityFrameworkCore.PostgreSQL

.NET 9.0 SDK

## Notlar

BuyingTypeDbContext için BuyingTypeDbContextFactory kullanýlmýþtýr.

src/Services/BuyingTypeService/BuyingTypeService.Persistence projesinde migration dosyalarý tutulur.

appsettings.json ve appsettings.Development.json gibi dosyalar environment bazlý okunur.

Her tehlikeli iþlem (drop-database, reset-database, remove-migration) öncesinde kullanýcý onayý alýnýr.





