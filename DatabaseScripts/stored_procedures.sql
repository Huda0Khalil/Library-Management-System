CREATE   PROCEDURE dbo.GetAllBooksWithCategories
AS
BEGIN
    SELECT 
        b.Id AS BookId,
        b.Title,
        b.Author,
        b.ISBN,
        b.PublishedYear,
        b.IsAvailable,
        b.Description,
        b.Publisher,
        b.Language,
        c.Id AS CategoryId,
        c.Name AS CategoryName,
        c.Description AS CategoryDescription
    FROM Books b
    INNER JOIN BookCategory bc ON b.Id = bc.BooksId
    INNER JOIN Categories c ON bc.CategoriesId = c.Id
    ORDER BY b.Title;
END