select * from tblPlayers


create procedure UpdatePlayer
@Attack int,
@Defense int,
@MaxHP int,
@ActualHP int,
@Luck int,
@XP int,
@Gold int,
@Level int,
@StoryCheckpoints int,
@MyWeapon nvarchar(100),
@Myshield nvarchar(100),
@Myarmour nvarchar(100),
@ID int
as
Begin
    update tblPlayers 
         set 
             Attack = @Attack, 
             Defense= @Defense,
             Max_HP= @MaxHP,
             Actual_HP= @ActualHP,
             Luck= @Luck,
             Xp= @XP,
             Gold= @Gold,
             [Level]= @Level,
             StoryCheckPoints_ID = @StoryCheckpoints,
			 [Equiped_Weapon] = @MyWeapon,
		     [Equiped_Shield] = @Myshield,
             [Equiped_Armour] = @Myarmour
          where ID = @ID
End

alter table tblPlayers
add 
Equiped_Weapon nvarchar(100),
Equiped_Shield nvarchar(100),
Equiped_Armour nvarchar(100)

