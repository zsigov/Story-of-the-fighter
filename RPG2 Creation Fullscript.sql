create database RPG2

Create table tblStoryCheckPoints 
( ID int not null primary key, 
Description nvarchar(max) )

create table tblStoryChoises
(ID int not null primary key identity(1,1),
Description nvarchar(max),
SourceStoryCheckPoints_ID int not null foreign key references tblStoryCheckPoints(ID),
DestinationStoryCheckPoints_ID int not null foreign key references tblStoryCheckPoints(ID))

create table tblPlayers
(ID int not null primary key identity(1,1),
Name nvarchar(50) unique,
Attack int,
Defense int,
Max_HP int,
Actual_HP int,
Luck int,
Xp int,
Gold int,
Level int,
StoryCheckPoints_ID int not null foreign key references tblStoryCheckPoints(ID),
Equiped_Weapon nvarchar(100),
Equiped_Shield nvarchar(100),
Equiped_Armour nvarchar(100))

create table tblIncidents
(ID int not null primary key identity(1,1),
Type nvarchar(50))
 
 Create table tblEquipmentsTypes
 (ID int not null primary key identity(1,1),
 Name nvarchar(50))

 Create table tblEquipments
 (ID int not null primary key identity(1,1),
 Name nvarchar(50),
 TypeID int foreign key references tblEquipmentsTypes(ID),
 Weight float,
 GoldValue int,
 AP int,
 DP int,
 DMGReduction int,
 HPModifier int)

 create table tblEnemies
 (ID int not null primary key identity(1,1),
 Name nvarchar(50),
 Attack int,
 Defense int,
 HP int,
 WeaponID int foreign key references tblEquipments(ID))

 create table tblStoryCheckPoints_Incidents_Join
 (ID int not null primary key identity(1,1),
 StoryCheckPoint_ID int foreign key references tblStoryCheckPoints(ID),
 Incidents_ID int foreign key references tblIncidents(ID),
 AddXP int,
 Damage int)

 Create table tblPlayers_Equipments_Join
 (ID int not null primary key identity(1,1),
 Player_ID int foreign key references tblPlayers(ID),
 Equipments_ID int foreign key references tblEquipments(ID),
 Quantity int)

 create table tblIncidents_Equipments_Join
 (ID int not null primary key identity(1,1),
 Incidents_ID int foreign key references tblIncidents(ID),
 Equipments_ID int foreign key references tblEquipments(ID))

 Create table tblCheckPoints_Enemies_Join
 (ID int not null primary key identity(1,1),
 Checkpoints_ID int foreign key references tblStoryCheckPoints(ID),
 Enemies_ID int foreign key references tblEnemies(ID))

