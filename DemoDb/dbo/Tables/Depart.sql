CREATE TABLE [dbo].[Depart] (
    [ID]           BIGINT         IDENTITY (1, 1) NOT NULL,
    [DepId]        VARCHAR (4)    NOT NULL,
    [DepName]      VARCHAR (30)   NOT NULL,
    [Desccription] NVARCHAR (200) NULL,
    CONSTRAINT [PK_Depart] PRIMARY KEY CLUSTERED ([ID] ASC)
);



