select * from [dbo].[tblEquipments]
select * from [dbo].[tblEquipmentsTypes]

create procedure GetEquipmentTypeID 
@ID int
as
begin
select [dbo].[tblEquipments].TypeID from [dbo].[tblEquipments]
where [dbo].[tblEquipments].ID = @ID
end
