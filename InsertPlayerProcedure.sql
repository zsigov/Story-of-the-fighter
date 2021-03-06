USE [RPG2]
GO
/****** Object:  StoredProcedure [dbo].[InsertPlayer]    Script Date: 2020. 05. 15. 15:33:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[InsertPlayer]
@Name nvarchar(100),
@Attack int,
@Defense int,
@MaxHP int,
@ActualHP int,
@Luck int,
@XP int,
@Gold int,
@Level int,
@StoryCheckpoints int,
@EqupiedWeapon nvarchar(100),
@EquipedShield nvarchar(100),
@EquipedArmour nvarchar(100),

@ID int out
as
Begin
     insert into 
	       tblPlayers( [Name],[Attack],[Defense],[Max_HP],[Actual_HP],[Luck],[Xp],[Gold],[Level],[StoryCheckPoints_ID],[Equiped_Weapon],[Equiped_Shield],[Equiped_Armour])
     values 
          (@Name, 
		   @Attack, 
		   @Defense, 
		   @MaxHP, 
		   @ActualHP, 
		   @Luck , 
		   @XP, 
		   @Gold, 
		   @Level , 
		   @StoryCheckpoints,
		   @EqupiedWeapon,
		   @EquipedShield,
		   @EquipedArmour)
select @ID = SCOPE_IDENTITY()
End