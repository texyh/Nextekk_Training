CREATE TABLE [dbo].[OrderItems]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [ProductId] INT NOT NULL, 
    [Quantity] INT NOT NULL, 
    [OrderId] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [FK_OrderItems_Products] FOREIGN KEY ([ProductId]) REFERENCES [Products]([Id]), 
    CONSTRAINT [FK_OrderItems_Orders] FOREIGN KEY ([OrderId]) REFERENCES [Orders]([Id])
)
