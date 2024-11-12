CREATE TABLE [dbo].[HyperLinks]
(
  [Id] INT NOT NULL PRIMARY KEY,
  [SourceVerseId] INT not null,
  [LinkedVerseId] INT not null,
  [Comment] nvarchar (MAX) null,
  [DateCreated] DATETIME not null,
  [Upvotes] int not null DEFAULT 0,
  [Downvotes] int not null DEFAULT 0,
  [CreatedBy] UNIQUEIDENTIFIER not null
  CONSTRAINT FK_USER_LINK FOREIGN KEY (CreatedBy) REFERENCES Users(Id),
  CONSTRAINT FK_SOURCE_VERSE FOREIGN KEY (SourceVerseId) REFERENCES Verses(Id),
  CONSTRAINT FK_LINKED_VERSE FOREIGN KEY (LinkedVerseId) REFERENCES Verses(Id),

)
