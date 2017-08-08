CREATE TABLE [Episode] (
	[EpisodeId] INT IDENTITY (1, 1) NOT NULL,
	[ShowId] INT NOT NULL,
	[SeasonNumber] INT NOT NULL,
	[EpisodeNumber] INT NOT NULL,
	[Description] VARCHAR(MAX),
	[Rating] FLOAT NOT NULL
);
GO