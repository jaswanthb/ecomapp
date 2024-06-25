CREATE TABLE [dbo].[OrderDetails] (
    [OrderDetailsId] INT      IDENTITY (1, 1) NOT NULL,
    [OrderID]        INT      NOT NULL,
    [ProductID]      INT      NOT NULL,
    [UnitPrice]      MONEY    NOT NULL,
    [Quantity]       SMALLINT NOT NULL,
    [Discount]       REAL     NOT NULL,
    PRIMARY KEY CLUSTERED ([OrderDetailsId] ASC),
    FOREIGN KEY ([OrderID]) REFERENCES [dbo].[Orders] ([OrderID]),
    FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Products] ([ProductID])
);

