create table tb_User
(
	Id int identity primary key,
	LoginName nvarchar(20) not null,
	Password nvarchar(20) not null,
	UserName nvarchar(50) not null,
	CreationTime datetime not null default getdate(),
	State int not null default 1
);

create table tb_MeetingRoom
(
   Id int identity primary key,
   RoomName nvarchar(10) not null,
   Location nvarchar(200) not null,
   CreationTime datetime not null default getdate(),
   State int not null default 1
);

create table tb_MeetingOrder
(
	Id int identity primary key,
	RoomId int not null foreign key references tb_MeetingRoom(Id),
	UserId int not null foreign key references tb_User(Id),
	Content nvarchar(100) not null,	
	CreationTime datetime not null default getdate(),
	State int not null default 1
);

create table tb_MeetingTime
(
	Id int identity primary key,
	OrderId int not null foreign key references tb_MeetingOrder(Id),
	MeetingDate datetime not null,
	MeetingStartTime datetime not null 
		check (MeetingStartTime between '1970-01-01 06:00:00' and '1970-01-01 22:00:00'),
	MeetingEndTime datetime not null
		check (MeetingEndTime between '1970-01-01 06:00:00' and '1970-01-01 22:00:00'),
	CreationTime datetime not null default getdate(),
	State int not null default 1
);