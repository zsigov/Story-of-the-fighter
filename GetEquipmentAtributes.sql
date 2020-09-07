select * from [dbo].[tblEquipments]
select [Quantity] from [dbo].[tblPlayers_Equipments_Join]

create procedure [dbo].[GetEquipmentAtributes]
@PlayerID int,
@EquipmentID int
as
begin
       select 
              tblEquipments.Name, 
              tblEquipments.Weight,
              tblEquipments.GoldValue, 
              Coalesce(tblEquipments.AP,'0') as AP,
              Coalesce(tblEquipments.DP,'0') as DP,
              Coalesce(tblEquipments.DMGReduction,'0') as DMGReduction,
              Coalesce(tblEquipments.HPModifier,'0') as HPModifier,
              tblPlayers_Equipments_Join.[Quantity] 
        from 
              tblPlayers_Equipments_Join
        inner join 
		      [dbo].[tblEquipments] 
        on 
		       tblPlayers_Equipments_Join.Equipments_ID = tblEquipments.ID 
        where
          tblPlayers_Equipments_Join.Player_ID=@PlayerID
          and tblPlayers_Equipments_Join.Equipments_ID=@EquipmentID
end 

create procedure GetEquipmentID
@EquipmentName nvarchar (50),
@EquipmentID int out
as
begin
select @EquipmentID=id from tblEquipments
where name like @EquipmentName
end

declare @EquipmentID int
execute GetEquipmentID 'small shield', @EquipmentID out
print @EquipmentID

Create procedure GetEquipmentPorperties 
@EquipmentName nvarchar (50)
as
  begin
       select 
	          ID,
			  [Name],
			  TypeID,
			  [Weight],
			  Goldvalue,
			  Ap,
			  DP,
			  DMGReduction,
			  HpModifier
        from
		     [tblEquipments]
        where
		     [tblEquipments].Name like @EquipmentName
  End