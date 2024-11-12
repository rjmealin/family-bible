CREATE TABLE [dbo].[Verses]
(
  [Id] INT NOT NULL PRIMARY KEY Identity(1,1),
  [Chapter] int not null,
  [Verse] int not null,
  [Text] NVARCHAR (MAX) not null,
  [Book] int not NULL,
  [Version] nvarchar(MAX) not null
)
