go
/*������*/
create table [dbo].[SalesOrder]
(
[Id] [int] primary key identity(1,1) /*���������� �������������. ��������� ����*/
, [OrderDate] [datetime] not null /*���� ������*/
, [StatusId] [int] not null /*������ ������ (��. [dbo].[SalesStatus])*/
, [CustomerId] [int] not null /*������������� �������� (c�. [dbo].[Customer])*/
, [Comment] [nvarchar](2000) /*�����������*/
)
go

/*������� � ������*/
create table [dbo].[SalesOrderDetail]
(
[Id] [int] primary key identity(1,1) /*���������� �������������. ��������� ����*/
, [SalesOrderId] [int] not null /*������������� ������*/
, [ProductId] [int] not null /*������������ ��������*/
, [OrderQty] [int] not null /*����������*/
, [UnitPrice] [money] not null /*���� �� ������ �� ������ ������������ ������*/
, [ModifyDate] [datetime] not null /*���� ���������*/
)

go
/*��������*/
create table [dbo].[Product]
(
[Id] [int] primary key identity(1,1) /*���������� �������������. ��������� ����*/
, [Name] [nvarchar](2000) not null /*������������ ��������*/
, [ListPrice] [money] not null /*���� ��������*/
, [Comment] [nvarchar](2000) /*�����������*/
)
go
/*������� ������*/
create table [dbo].[SalesStatus]
(
[Id] [int] primary key identity(1,1) /*���������� �������������. ��������� ����*/
, [Name] [nvarchar](2000) not null /*�������� �������*/
)
go
/*�������*/
create table [dbo].[Customer]
(
[Id] [int] primary key identity(1,1) /*���������� �������������. ��������� ����*/
, [Name] [nvarchar](2000) not null /*������������ �������*/
)
go

