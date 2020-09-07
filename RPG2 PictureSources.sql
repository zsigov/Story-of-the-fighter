create table PicturesSources

(ID int identity not null,
 PictureName nvarchar(100),
 PictureSource nvarchar(max))

 Insert into PicturesSources
 values 
 ('BlueWhiteMinus','https://www.google.com/url?sa=i&source=images&cd=&cad=rja&uact=8&ved=2ahUKEwjIvrWaoILjAhUONhoKHexgAwAQjRx6BAgBEAU&url=%2Furl%3Fsa%3Di%26source%3Dimages%26cd%3D%26ved%3D%26url%3Dhttps%253A%252F%252Fwww.iconfinder.com%252Ficons%252F61659%252Fadd_minus_plus_icon%26psig%3DAOvVaw2aiTRyoO9ImjPsyOllT-gZ%26ust%3D1561470065133578&psig=AOvVaw2aiTRyoO9ImjPsyOllT-gZ&ust=1561470065133578'),
 ('BlueWhitePlus','https://www.google.com/url?sa=i&source=images&cd=&ved=2ahUKEwiQ4vLan4LjAhWPz4UKHQQ9D9EQjRx6BAgBEAU&url=https%3A%2F%2Ffr.wikipedia.org%2Fwiki%2FFichier%3APlus_blue.svg&psig=AOvVaw2aiTRyoO9ImjPsyOllT-gZ&ust=1561470065133578'),
 ('Black minus','https://www.google.com/url?sa=i&source=images&cd=&ved=2ahUKEwjLpLCRkILjAhVSzoUKHZoGBKYQjRx6BAgBEAU&url=https%3A%2F%2Fwww.iconfinder.com%2Ficons%2F754669%2Fminor_minus_sign_subtract_icon&psig=AOvVaw3f_X-Nv88LIovK13TgJ7Ge&ust=1561465924426484'),
 ('Black Plus','https://www.google.com/url?sa=i&source=images&cd=&cad=rja&uact=8&ved=2ahUKEwiJtaCmj4LjAhVSTBoKHWoQCvsQjRx6BAgBEAU&url=%2Furl%3Fsa%3Di%26source%3Dimages%26cd%3D%26ved%3D%26url%3D%252Furl%253Fsa%253Di%2526source%253Dimages%2526cd%253D%2526ved%253D%2526url%253Dhttps%25253A%25252F%25252Fwww.iconfinder.com%25252Ficons%25252F754671%25252Fadd_more_plus_sign_icon%2526psig%253DAOvVaw3NYTZqPl1Z2QhbR70QVHhc%2526ust%253D1561465555468343%26psig%3DAOvVaw3NYTZqPl1Z2QhbR70QVHhc%26ust%3D1561465555468343&psig=AOvVaw3NYTZqPl1Z2QhbR70QVHhc&ust=1561465555468343'),
 ('Rest Background','https://www.google.com/url?sa=i&source=images&cd=&ved=2ahUKEwia9MqNtf_iAhVEOBoKHURmB20QjRx6BAgBEAU&url=https%3A%2F%2Fwaltorious.wordpress.com%2F2012%2F04%2F27%2Fwishful-thinking-bandit-rpg%2F&psig=AOvVaw1GjltC2IjX3rmDJvFvPGiK&ust=1561372786560428'),
 ('Death Head','https://www.google.com/url?sa=i&source=images&cd=&ved=2ahUKEwiSqYjHv_3iAhUd5uAKHfoZASoQjRx6BAgBEAU&url=http%3A%2F%2Fwww.alkotojatek.hu%2Ftermek%2Fhalalfej-festosablon%2F&psig=AOvVaw180CfMHQ3WkF337-cVvBd5&ust=1561306865961841'),
 ('Battle Background', 'https://www.pinterest.com/pin/393431717441303295/'),
 ('Weak Golem', 'https://www.pinterest.com/drgoecke/fantasy-golems/'),
 ('Strong Golem', 'https://www.designspiration.net/save/1559446065246/'),
 ('Giant Bat','http://hasznaltmobil.info/mmp/e/evil-bat-drawings/'),
 ('Goblin', 'http://3drt.com/store/characters/fantasy-characters/goblin-undead-modular-kit.html'),
 ('NOT picture', 'https://irishstudies.sunygeneseoenglish.org/2014/12/12/not-the-ira/'),
 ('LuckDice1', 'https://hypixel.net/threads/and%C5%ABril-or-dice.571656/page-2'),
 ('LuckDice2', 'https://www.implay.co.uk/red-soft-play-dice.html'),
 ('LuckWiev Background','https://wall.alphacoders.com/big.php?i=359397&lang=German')

 select * from PicturesSources

 create table MusicSources

(ID int identity not null,
 MusicName nvarchar(100),
 MusicSource nvarchar(max))

 
 Insert into MusicSources
 values 
 ('LevelUpp sound','https://www.youtube.com/watch?time_continue=5&v=MO9pW3sfbTY'),
 ('Rest music','https://www.youtube.com/watch?v=FAeN2SgtNwU')


 select * from MusicSources