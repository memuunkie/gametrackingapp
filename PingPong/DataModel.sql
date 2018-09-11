CREATE TABLE Players (
    Id int not null primary key identity(1,1),
    LastName varchar(255) not null,
    FirstName varchar(255) not null,
	CreationDate datetime not null,
);

-- constraints to make sure same player/team not added twice

CREATE TABLE Teams (
    Id int not null primary key identity(1,1),
	Player1Id int not null foreign key references Players(Id),
	Player2Id int not null foreign key references Players(Id),
	TeamName varchar(255) unique not null,
	CreationDate datetime not null,

	constraint TeamPlayers_Unique check (
		Player1Id <> Player2Id
    )
);

CREATE TABLE SingleGames (
	Id int not null primary key identity(1,1),
	Player1Id int not null foreign key references Players(Id),
	Player2Id int not null foreign key references Players(Id),
	Player1Score int not null,
	Player2Score int not null,
	CreationDate datetime not null,

	constraint SinglePlayers_Unique check (
		Player1Id <> Player2Id
	)
);

CREATE TABLE TeamGames (
	Id int not null primary key identity(1,1),
	Team1Id int not null foreign key references Teams(Id),
	Team2Id int not null foreign key references Teams(Id),
	Team1Score int not null,
	Team2Score int not null,
	CreationDate datetime not null,

	constraint Teams_Unique check (
		Team1Id <> Team2Id
	)
);


