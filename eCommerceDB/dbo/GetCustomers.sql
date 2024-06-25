CREATE PROCEDURE [dbo].[GetCustomers]
@SearchString varchar(10)
AS
BEGIN
	SELECT * FROM Customers where CustomerID like '%'+@SearchString+'%'
END
