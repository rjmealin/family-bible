CREATE TABLE [dbo].[Users]
(
  [Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
  [Email] NVARCHAR (MAX) not null,
  [FirstName] NVARCHAR (MAX) not null,
  [LastName] NVARCHAR (MAX) not null,
  [CreatedDate] DATETIME not null,
  [Password]                    NVARCHAR (MAX)   NOT NULL,
  [Salt]                        UNIQUEIDENTIFIER NOT NULL,
  [Removed]                     BIT              NOT NULL DEFAULT 0 ,
  [Active]                      BIT              NOT NULL DEFAULT 0 ,
  [EmailVerified]               BIT              NOT NULL DEFAULT 0 ,
  [AllowTextNotifications]      BIT              NOT NULL DEFAULT 0 ,
  [PhoneVerified]               BIT              NOT NULL Default 0 ,
  [IsAdmin]                     BIT NOT NULL DEFAULT 0, 
  [ProfileImageDataUrl] NVARCHAR(MAX) NULL, 
  [ProfileImageMIME] NVARCHAR(MAX) NULL, 
  [IsTempUser] bit not null default 0 
)
