select * from tblplayers
select * from tblequipments
select * from [dbo].[tblPlayers_Equipments_Join]


Create procedure GetPlayerEquipments
@PlayerID int out
as
begin
select [dbo].[tblEquipments].[ID], [name] from tblequipments 
inner join [dbo].[tblPlayers_Equipments_Join]
on tblequipments.id = tblPlayers_Equipments_Join.equipments_id
where tblPlayers_Equipments_Join.[Player_ID] = @PlayerID
end


