create procedure GetStoryCheckPoint
@StoryCheckPointID int
as
begin
select [Description] from [dbo].[tblStoryCheckPoints] where id=@StoryCheckPointID
end

create procedure GetStoryChoises
@StoryCheckPointID int
as
begin
select Description, DestinationStoryCheckPoints_ID from [dbo].[tblStoryChoises] where SourceStoryCheckPoints_ID = @StoryCheckPointID
end