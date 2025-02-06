Tr: Yetkilendirme işlemlerinde EntityFramework.Identity kullanıldığından iki farklı context bulunmaktadır. Migration eklerken veya veritabanını güncellerken Package Manager Console üzerinde -Context parametresi ile context adı belirtilmelidir.

*Admin kullanıcı eklemek için Entities.Data.IdentityContext içerisinde bulunan yorum satırı olan data seed üzerinden admin şifresi ve emaili belirlenebilir

En: Since EntityFramework.Identity is used for authorization, there are two different contexts. When adding a migration and updating the database in the Package Manager Console, the -Context parameter must be specified along with the context name

To add an admin user, the admin password and email can be set in the data seed section within Entities.Data.IdentityContext, where the comment section is located.
