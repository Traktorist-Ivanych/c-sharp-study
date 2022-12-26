CREATE TABLE [dbo].[Workers] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [workerName]       NVARCHAR (50) NOT NULL,
    [workerSurname]    NVARCHAR (50) NOT NULL,
    [workerPatronymic] NVARCHAR (50) NOT NULL,
    [phoneNumber]      NVARCHAR (50) NOT NULL,
    [email]            NVARCHAR (50) NOT NULL
);

