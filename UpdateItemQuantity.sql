Select * from tblEquipments
select * from tblEquipmentsTypes
select * from tblPlayers_Equipments_Join

create procedure UpdateItemQuantity
@PlayerID int,
@EquipmentID int,
@quantity int
as
     Begin
	      update 
	            tblPlayers_Equipments_Join
		  set
		        Quantity=@quantity
          where
		        Player_ID=@PlayerID and Equipments_ID=@EquipmentID
	 End