CREATE PROCEDURE [dbo].[GetBookChapterWithHyperLinks]
  @BookId int = 0
AS
  SELECT * from dbo.Books as b 
  inner join dbo.Verses as v on v.BookId = b.Id
  left join HyperLinks h on h.SourceVerseId = v.Id
  inner join Verses vl on h.LinkedVerseId = vl.Id
  where b.Id = @BookId
RETURN 0
