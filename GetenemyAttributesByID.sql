select * from tblEnemies

create procedure getEnemyAtributesByID 
@ID int
as
  begin
	select
		Name,
		Attack,
		Defense,
		HP,
		WeaponID
	from
		tblEnemies
	where
		id=@ID
  end