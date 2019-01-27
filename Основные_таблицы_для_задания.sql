go
/*Заказы*/
create table [dbo].[SalesOrder]
(
[Id] [int] primary key identity(1,1) /*Уникальный идентификатор. Первичный ключ*/
, [OrderDate] [datetime] not null /*Дата заказа*/
, [StatusId] [int] not null /*Статус заказа (см. [dbo].[SalesStatus])*/
, [CustomerId] [int] not null /*Идентификатор клииента (cм. [dbo].[Customer])*/
, [Comment] [nvarchar](2000) /*Комментарий*/
)
go

/*Позиции в заказе*/
create table [dbo].[SalesOrderDetail]
(
[Id] [int] primary key identity(1,1) /*Уникальный идентификатор. Первичный ключ*/
, [SalesOrderId] [int] not null /*Идентификатор заказа*/
, [ProductId] [int] not null /*Идентфикатор продукта*/
, [OrderQty] [int] not null /*Количество*/
, [UnitPrice] [money] not null /*Цена по прайсу на момент формирования заказа*/
, [ModifyDate] [datetime] not null /*Дата изменения*/
)

go
/*Продукты*/
create table [dbo].[Product]
(
[Id] [int] primary key identity(1,1) /*Уникальный идентификатор. Первичный ключ*/
, [Name] [nvarchar](2000) not null /*Наименование продукта*/
, [ListPrice] [money] not null /*Цена продукта*/
, [Comment] [nvarchar](2000) /*Комментарий*/
)
go
/*Статусы заказа*/
create table [dbo].[SalesStatus]
(
[Id] [int] primary key identity(1,1) /*Уникальный идентификатор. Первичный ключ*/
, [Name] [nvarchar](2000) not null /*Название статуса*/
)
go
/*Клиенты*/
create table [dbo].[Customer]
(
[Id] [int] primary key identity(1,1) /*Уникальный идентификатор. Первичный ключ*/
, [Name] [nvarchar](2000) not null /*Наименование клиента*/
)
go

