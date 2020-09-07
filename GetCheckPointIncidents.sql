select * from [dbo].[tblIncidents]

select * from [dbo].[tblStoryChoises]
select * from [dbo].[tblCheckPoints_Enemies_Join]
select * from [dbo].[tblStoryCheckPoints]
select * from [dbo].[tblStoryCheckPoints_Incidents_Join]


Create procedure GetCheckPointIncidents
@StoryCheckpoint int 
as
begin 
    select
	        A.ID,
		    A.StoryCheckPoint_ID,
		    B.[Type]
    from
	        tblStoryCheckPoints_Incidents_Join as A
            inner join tblIncidents as B on A.Incidents_ID = B.ID
    where
	         A.StoryCheckPoint_ID = @StoryCheckpoint
end

Create procedure GetStoryCheckpointIncidentXP 
@ID int
as
begin 
     select 
	     A.addxp
     from 
	     [dbo].[tblStoryCheckPoints_Incidents_Join] as A
      where
	      A.ID = @ID
end

   
Create procedure GetStoryCheckpointIncidentDamage 
@ID int
as
begin 
     select 
	     A.Damage
     from 
	     [dbo].[tblStoryCheckPoints_Incidents_Join] as A
      where
	      A.ID = @ID
end

create function FuncGetStoryCheckpointIncidentXP (@ID int)
returns int
as
begin 
     declare
	     @result int 
     select 
	     @result = A.addxp
     from 
	     [dbo].[tblStoryCheckPoints_Incidents_Join] as A
     where
	      A.ID = @ID

     if @result is null return 0;

     return
	      @result
end

declare @result int
execute @result = FuncGetStoryCheckpointIncidentXP 6
print @result

execute FuncGetStoryCheckpointIncidentXP 6

create procedure GetCheckPointEnemies
@StoryCheckpoint int 
as
begin 
    select
		[dbo].[tblCheckPoints_Enemies_Join].[Checkpoints_ID],
		[dbo].[tblCheckPoints_Enemies_Join].[Enemies_ID]
    from
	   [dbo].[tblCheckPoints_Enemies_Join]      
    where
	    [dbo].[tblCheckPoints_Enemies_Join].[Checkpoints_ID] = @StoryCheckpoint
end

select * from [dbo].[tblCheckPoints_Enemies_Join]

create procedure GetEnemyAtributes
@EnemyID int
as
Begin
       select 
	          [dbo].[tblEnemies].[ID],
              [dbo].[tblEnemies].[Name],
              [dbo].[tblEnemies].[Attack],
              [dbo].[tblEnemies].[Defense],
			  [dbo].[tblEnemies].[HP],
			  [dbo].[tblEquipments].[Name],
			  [dbo].[tblEquipments].[AP],
			  [dbo].[tblEquipments].DP,
			  [dbo].[tblEquipments].HPModifier
        from
		      [dbo].[tblEnemies]
         inner join
		       [dbo].[tblEquipments] on [dbo].[tblEnemies].WeaponID = [dbo].[tblEquipments].ID
        where 
		      [dbo].[tblEnemies].ID=@EnemyID
End

select * from tblEnemies
select * from tblEquipments

