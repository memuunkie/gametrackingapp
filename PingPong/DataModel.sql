CREATE TABLE Players (
    Id int not null identity(1,1),
    LastName nvarchar(100) not null,
    FirstName nvarchar(100) not null,
	CreationDate datetime not null,
);

ALTER TABLE [Players]
ADD CONSTRAINT [PK_Players] PRIMARY KEY (Id)

-- constraints to make sure same player/team not added twice

CREATE TABLE Teams (
    Id int not null identity(1,1),
	TeamName nvarchar(100) not null,
	Player1Id int not null,
	Player2Id int not null,
	CreationDate datetime not null,

	constraint TeamPlayers_Unique check (
		Player1Id <> Player2Id
    )
);

ALTER TABLE [Teams]
ADD CONSTRAINT [PK_Teams] PRIMARY KEY (Id)

ALTER TABLE [Teams]
ADD CONSTRAINT [PK_Teams_Player1] FOREIGN KEY (Player1Id) REFERENCES Players (Id)

ALTER TABLE [Teams]
ADD CONSTRAINT [PK_Teams_Player2] FOREIGN KEY (Player2Id) REFERENCES Players (Id)

ALTER TABLE [Teams]
ADD CONSTRAINT [Unique_TeamName] UNIQUE (TeamName)

CREATE TABLE SingleGames (
	Id int not null identity(1,1),
	Player1Id int not null,
	Player2Id int not null,
	Player1Score int,
	Player2Score int,
	CreationDate datetime not null,

	constraint SinglePlayers_Unique check (
		Player1Id <> Player2Id
	)
);

ALTER TABLE [SingleGames]
ADD CONSTRAINT [PK_SingleGames] PRIMARY KEY (Id)

ALTER TABLE [SingleGames]
ADD CONSTRAINT [PK_SGame_Player1] FOREIGN KEY (Player1Id) REFERENCES Players (Id)

ALTER TABLE [SingleGames]
ADD CONSTRAINT [PK_SGame_Player2] FOREIGN KEY (Player2Id) REFERENCES Players (Id)

CREATE TABLE TeamGames (
	Id int not null identity(1,1),
	Team1Id int not null,
	Team2Id int not null,
	Team1Score int,
	Team2Score int,
	CreationDate datetime not null,

	constraint Teams_Unique check (
		Team1Id <> Team2Id
	)
);

ALTER TABLE [TeamGames]
ADD CONSTRAINT [PK_TeamGames] PRIMARY KEY (Id)

ALTER TABLE [TeamGames]
ADD CONSTRAINT [PK_TGame_Team1] FOREIGN KEY (Team1Id) REFERENCES Teams (Id)

ALTER TABLE [TeamGames]
ADD CONSTRAINT [PK_TGame_Team2] FOREIGN KEY (Team2Id) REFERENCES Teams (Id)

