create procedure Get_Player
@PlayerName Nvarchar(100) 
as
begin
   select 
        id, 
		Name, 
		Attack,
		[Defense], 
		[Max_HP],
		[Actual_HP], 
		[Luck],[Xp],
		[Gold],
		[Level],
		[StoryCheckPoints_ID],
		[Equiped_Weapon],
		[Equiped_Shield], 
		[Equiped_Armour] 
    from 
	     tblPlayers
    where 
	     name like @PlayerName
end

alter procedure Get_PlayerByID
@PlayerID int 
as
begin
   select       
		Name, 
		Attack,
		[Defense], 
		[Actual_HP], 	
		[Equiped_Weapon],
		[Equiped_Shield], 
		[Equiped_Armour] 
    from 
	     tblPlayers
    where 
	     id = @PlayerID
end

