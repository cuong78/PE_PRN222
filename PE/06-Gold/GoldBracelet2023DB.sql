USE master
GO

CREATE DATABASE GoldBracelet2023DB
GO

USE GoldBracelet2023DB
GO

CREATE TABLE Account(
  AccountID int primary key,
  AccountPassword nvarchar(40) not null,
  FullName nvarchar(60) not null,
  EmailAddress nvarchar(60) unique, 
  Gender bit,
  AccountRole int
)
GO

INSERT INTO Account VALUES(55 ,N'@7', N'Administrator', 'admin@GoldBracelet.info', 1 , 1);
INSERT INTO Account VALUES(56 ,N'@7', N'Staff', 'staff@GoldBracelet.info', 0, 2);
INSERT INTO Account VALUES(57 ,N'@7', N'Manager', 'manager@GoldBracelet.info', 1, 3);
INSERT INTO Account VALUES(58 ,N'@7', N'Customer', 'customer@GoldBracelet.info', 1, 4);
GO


CREATE TABLE ProductType(
  TypeId nvarchar(30) primary key,
  TypeName nvarchar(100) not null,
  TypeDescription nvarchar(250) not null
)
GO
INSERT INTO ProductType VALUES(N'PT0323', N'Bangles', N'Our collection of sterling silver and 18k yellow, white and rose gold bangles feature eye-catching details and sparkling diamonds—a must-have to transform any day or night ensemble.')
GO
INSERT INTO ProductType VALUES(N'PT0324', N'Chain Bracelets', N'With sleek silhouettes or bold links, our chain bracelets are a worthy addition to your jewelry collection.')
GO
INSERT INTO ProductType VALUES(N'PT0325', N'Cuff Bracelets', N'From larger-than-life cuffs to sleek designs, these are the pieces you’ll find yourself reaching for again and again.')
GO
INSERT INTO ProductType VALUES(N'PT0326', N'Stacking Bracelets', N'Curate a signature bracelet stack with our most-wanted designs. From delicate chains to statement cuffs, these pieces work well together.')
GO
INSERT INTO ProductType VALUES(N'PT0327', N'Tennis Bracelets', N'An iconic design that was originally sported by players on the court, the tennis bracelet has become an elegant style staple.')
GO


CREATE TABLE GoldBracelet(
 BraceletId int primary key,
 BraceletName nvarchar(100) not null,
 BraceletDescription nvarchar(250),
 Price decimal,
 ProductionYear int, 
 CreatedDate Datetime,
 TypeId nvarchar(30) references ProductType(TypeId) on delete cascade on update cascade
)
GO

INSERT INTO GoldBracelet VALUES(911, N'Elsa Peretti Diamonds', N'Elsa Peretti Diamonds by the Yard bracelet in 18k gold with a diamond.', 1712, 2023, CAST(N'2023-10-16' AS DateTime), 'PT0323')
GO

INSERT INTO GoldBracelet VALUES(912, N'Tiffany HardWear Medium', N'Tiffany HardWear Medium Link Bracelet in Yellow Gold', 6700, 2022, CAST(N'2023-10-16' AS DateTime), 'PT0323')
GO

INSERT INTO GoldBracelet VALUES(913, N'Atlas X Closed Narrow', N'Atlas X Closed Narrow Hinged Bangle in Yellow Gold', 9000, 2021, CAST(N'2023-10-16' AS DateTime), 'PT0323')
GO

INSERT INTO GoldBracelet VALUES(914, N'Tiffany Victoria Cluster Tennis', N'Tiffany Victoria Cluster Tennis Bracelet in Platinum with Diamonds', 5400, 2020, CAST(N'2023-10-16' AS DateTime), 'PT0327')
GO

INSERT INTO GoldBracelet VALUES(915, N'Tiffany & Co. Schlumberger 36 Stone bracelet', N'Tiffany & Co. Schlumberger 36 Stone bracelet in 18k gold with diamonds.', 34050, 2023, CAST(N'2023-10-16' AS DateTime), 'PT0327')
GO

INSERT INTO GoldBracelet VALUES(916, N'Tiffany Metro hinged bangle', N'Tiffany Metro hinged bangle in 18k white gold with diamonds, large.', 8430, 2021, CAST(N'2023-10-16' AS DateTime), 'PT0327')
GO

INSERT INTO GoldBracelet VALUES(917, N'Tiffany HardWear with Freshwater Pearls', N'Tiffany HardWear Link Bracelet in Yellow Gold with Freshwater Pearls', 2285, 2023, CAST(N'2023-10-16' AS DateTime), 'PT0324')
GO

INSERT INTO GoldBracelet VALUES(918, N'Tiffany HardWear Rose Gold with Pave Diamonds', N'iffany HardWear Large Link Bracelet in Rose Gold with Pave Diamonds', 12230, 2019, CAST(N'2023-10-16' AS DateTime), 'PT0324')
GO

INSERT INTO GoldBracelet VALUES(919, N'Paloma Picasso Olive Leaf ', N'Paloma Picasso Olive Leaf cuff in 18k gold, small.', 3200, 2023, CAST(N'2023-10-16' AS DateTime), 'PT0325')
GO

INSERT INTO GoldBracelet VALUES(961, N'Elsa Peretti large Bone', N'Elsa Peretti large Bone cuff in 18k rose gold, 95 mm wide.', 1850, 2022, CAST(N'2023-10-16' AS DateTime), 'PT0325')
GO