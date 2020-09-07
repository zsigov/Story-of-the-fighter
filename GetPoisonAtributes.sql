Select * from tblEquipments
select * from tblEquipmentsTypes
select * from tblPlayers_Equipments_Join

create procedure GetPoisonAtributes 
@EquipmentID int
as
    Begin
	      select 
		        id,
				name,
				TYPEID,
				weight,
				goldvalue,
				Hpmodifier
		 from
				tblEquipments
		 where
				id=@EquipmentID
    End