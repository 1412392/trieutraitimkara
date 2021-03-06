
create database TrieuTraiTimKara
go
use TrieuTraiTimKara
go
create table MediaType --video hay bài hát
(
	id int identity(1,1) primary key,
	name nvarchar(100),
	isDelete int default 0	 
	
)
create table Category
(
	id int identity(1,1) primary key,
	name nvarchar(100),
	views int,
	imageurl nvarchar(1000),
	createDate datetime	default GETDATE(),
	
	seotitle nvarchar(100),
	keyword nvarchar(500),
	metadescription nvarchar(500),
	isDelete int default 0	 
	
)
create table Singer
(
	id int identity(1,1) primary key,
	name nvarchar(100),
	description ntext,
	imageurl nvarchar(500),
	views int,
	
	seotitle nvarchar(100),
	keyword nvarchar(500),
	metadescription nvarchar(500),
	isDelete int default 0,
	createDate datetime	default GETDATE(),
	deleteDate datetime
	
)
create table KaraReqest
(
	id int identity(1,1) primary key,
	medianame nvarchar(500),
	singer nvarchar(500),
	urlDemo nvarchar(1000),
	
	guestname nvarchar(100),
	guestemail varchar(100),
	guestphone varchar(100),
	
	description nvarchar(2000),
	isDelete int default 0,
	createDate datetime,
	deleteDate datetime
)
create table Account
(
	id int identity(1,1) primary key,
	email varchar(100),
	password varchar(200),
	name nvarchar(100),
	phone varchar(20),
	isDelete int default 0,
	createDate datetime	,
	deleteDate datetime,
	role int --1 admin, 2 user
)

create table Media
(
	id int identity(1,1) primary key,
	name nvarchar(500),
	categoryid int,--khóa ngoại
	url nvarchar(1000),
	imageurl nvarchar(500),
	description ntext,
	mediatype int,--khóa ngoại, loại: video hay bài hát
	displayorder int,--xếp hạng
	composer nvarchar(100),--nhạc sĩ
	--score int,--điểm yêu thích: mỗi lượt thích lên 1 điểm
	views int,--lượt xem, lượt nghe
	ListSingerID text,
	ListSingerName ntext,
	ListAccountID text,
	ListAccountName ntext,
	
	
	seotitle nvarchar(100),
	keyword nvarchar(500),
	metadescription nvarchar(500),	
	
	
	isDelete int default 0,
	createDate datetime	,
	deleteDate datetime	
	
)
create table Media_Singer--1 bài hát có nhiều ca sĩ trình bày, 1 ca sĩ trình bày nhiều bài hát
(
	mediaid int,
	singerid int,
	primary key (mediaid,singerid)
	
)

create table Media_Account--1 người thích nhiều bài, 1 bài được nhiều người thích
(
	mediaid int,
	accountid int,
	primary key (mediaid,accountid)
)

alter table Media
add constraint FK1
foreign key (categoryid) references Category(id)

alter table Media
add constraint FK2
foreign key (mediatype) references MediaType(id)

--===================INSERT -=================
INSERT INTO Account(email,password,name,phone,isDelete,role)
VALUES('nguyenthanhphi0401@gmail.com','a50748d5f2420956ed3d04e1e4370b4f',N'Nguyễn Thanh Phi','01265190526',0,1)

INSERT INTO MediaType(name,isDelete)
VALUES('Karaoke',0)
INSERT INTO MediaType(name,isDelete)
VALUES('MP3',0)
INSERT INTO MediaType(name,isDelete)
VALUES('MusicVideo',0)

