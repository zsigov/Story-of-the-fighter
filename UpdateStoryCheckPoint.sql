Select * from tblPlayers
select * from tblStoryCheckPoints

create procedure UpdateStoryCheckpoint
@AcualStoryCheckPoint int,
@ID int
as
begin
    update 
	    tblPlayers 
     set 
        StoryCheckPoints_ID = @AcualStoryCheckPoint
    where 
	    ID = @ID
end