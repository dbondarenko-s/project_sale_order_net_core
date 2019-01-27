﻿--
-- Script was generated by Devart dbForge Studio 2018 for SQL Server, Version 5.6.62.0
-- Product home page: http://www.devart.com/dbforge/sql/studio
-- Script date 28.01.2019 2:26:30
-- Server version: 12.00.2000
--

SET DATEFORMAT ymd
SET ARITHABORT, ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER, ANSI_NULLS, NOCOUNT ON
SET NUMERIC_ROUNDABORT, IMPLICIT_TRANSACTIONS, XACT_ABORT OFF
GO

SET IDENTITY_INSERT ciam_db.dbo.Customer ON
GO
INSERT ciam_db.dbo.Customer(Id, Name) VALUES (1, N'ООО Компания 1')
INSERT ciam_db.dbo.Customer(Id, Name) VALUES (2, N'ООО Компания 2')
INSERT ciam_db.dbo.Customer(Id, Name) VALUES (3, N'ООО Компания 3')
INSERT ciam_db.dbo.Customer(Id, Name) VALUES (4, N'ООО Компания 4')
INSERT ciam_db.dbo.Customer(Id, Name) VALUES (5, N'ООО Компания 5')
GO
SET IDENTITY_INSERT ciam_db.dbo.Customer OFF
GO

SET IDENTITY_INSERT ciam_db.dbo.Product ON
GO
INSERT ciam_db.dbo.Product(Id, Name, ListPrice, Comment) VALUES (1, N'Песок', 35.00, N'Сеянный в мешках')
INSERT ciam_db.dbo.Product(Id, Name, ListPrice, Comment) VALUES (2, N'Щебень', 55.00, N'5-20мм')
INSERT ciam_db.dbo.Product(Id, Name, ListPrice, Comment) VALUES (3, N'Керамзит', 100.00, N'10-20мм')
INSERT ciam_db.dbo.Product(Id, Name, ListPrice, Comment) VALUES (4, N'Чернозем', 50.00, N'Земля в мешках')
GO
SET IDENTITY_INSERT ciam_db.dbo.Product OFF
GO

SET IDENTITY_INSERT ciam_db.dbo.SalesOrder ON
GO
INSERT ciam_db.dbo.SalesOrder(Id, OrderDate, StatusId, CustomerId, Comment) VALUES (2, '2019-01-27 10:41:00.000', 1, 2, N'Первый заказ')
INSERT ciam_db.dbo.SalesOrder(Id, OrderDate, StatusId, CustomerId, Comment) VALUES (8, '2019-01-26 00:00:00.000', 1, 1, NULL)
GO
SET IDENTITY_INSERT ciam_db.dbo.SalesOrder OFF
GO

SET IDENTITY_INSERT ciam_db.dbo.SalesOrderDetail ON
GO
INSERT ciam_db.dbo.SalesOrderDetail(Id, SalesOrderId, ProductId, OrderQty, UnitPrice, ModifyDate) VALUES (11, 8, 2, 700, 55.00, '2019-01-28 02:24:41.460')
INSERT ciam_db.dbo.SalesOrderDetail(Id, SalesOrderId, ProductId, OrderQty, UnitPrice, ModifyDate) VALUES (12, 2, 1, 1, 35.00, '2019-01-28 02:24:56.183')
INSERT ciam_db.dbo.SalesOrderDetail(Id, SalesOrderId, ProductId, OrderQty, UnitPrice, ModifyDate) VALUES (13, 2, 2, 2, 55.00, '2019-01-28 02:25:05.503')
INSERT ciam_db.dbo.SalesOrderDetail(Id, SalesOrderId, ProductId, OrderQty, UnitPrice, ModifyDate) VALUES (14, 2, 4, 5, 50.00, '2019-01-28 02:25:14.660')
GO
SET IDENTITY_INSERT ciam_db.dbo.SalesOrderDetail OFF
GO

SET IDENTITY_INSERT ciam_db.dbo.SalesStatus ON
GO
INSERT ciam_db.dbo.SalesStatus(Id, Name) VALUES (1, N'Новый')
INSERT ciam_db.dbo.SalesStatus(Id, Name) VALUES (2, N'В пути')
INSERT ciam_db.dbo.SalesStatus(Id, Name) VALUES (3, N'Ждет оплаты')
INSERT ciam_db.dbo.SalesStatus(Id, Name) VALUES (4, N'Готов к выдаче')
INSERT ciam_db.dbo.SalesStatus(Id, Name) VALUES (5, N'Завершен')
INSERT ciam_db.dbo.SalesStatus(Id, Name) VALUES (6, N'Отменен')
GO
SET IDENTITY_INSERT ciam_db.dbo.SalesStatus OFF
GO