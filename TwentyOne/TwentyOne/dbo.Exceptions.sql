CREATE TABLE [dbo].[Exceptions] (
    [Id]               INT          IDENTITY (1, 1) NOT NULL,
    [ExceptionType]    VARCHAR (50) NULL,
    [ExceptionMessage] VARCHAR(200)  NULL,
    [TimeStamp]        DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

