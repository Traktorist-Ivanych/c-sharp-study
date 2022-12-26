CREATE TABLE [dbo].[Products] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [email]       NVARCHAR (50) NOT NULL,
    [productId]   INT           NOT NULL,
    [productName] NVARCHAR (50) NOT NULL
);

