-- Script Date: 29/01/2022 00:14  - ErikEJ.SqlCeScripting version 3.5.2.90
-- Database information:
-- Database: D:\Projects\_Winstanley\Expenditure\src\Winstanley.Expenditure.Database\Data\main.db
-- ServerVersion: 3.35.5
-- DatabaseSize: 20 KB
-- Created: 29/01/2022 00:09

-- User Table information:
-- Number of tables: 4
-- Groups: -1 row(s)
-- PaymentFrequency: -1 row(s)
-- PaymentItem: -1 row(s)
-- Persons: -1 row(s)

SELECT 1;
PRAGMA foreign_keys=OFF;
BEGIN TRANSACTION;
CREATE TABLE [Persons] (
  [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [Name] text NOT NULL
, [Salary] numeric(53,0) NOT NULL
, [SortOrder] bigint NOT NULL
);
CREATE TABLE [PaymentItem] (
  [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [Name] text NOT NULL
, [Description] text NOT NULL
, [Amount] numeric(53,0) NOT NULL
, [SortOrder] bigint NOT NULL
, [GroupId] bigint NOT NULL
, [PaymentFrequencyId] bigint NOT NULL
);
CREATE TABLE [PaymentFrequency] (
  [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [Name] text NOT NULL
, [SortOrder] bigint NOT NULL
);
CREATE TABLE [Groups] (
  [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [Name] text NOT NULL
, [Description] text NOT NULL
, [SortOrder] bigint NOT NULL
);
COMMIT;

