USE [RPG2]
GO
/****** Object:  UserDefinedFunction [dbo].[FuncGetStoryCheckpointIncidentXP]    Script Date: 2019. 06. 26. 21:52:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER function [dbo].[FuncGetStoryCheckpointIncidentXP] (@ID int)
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