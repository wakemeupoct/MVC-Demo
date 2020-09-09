CREATE TABLE [dbo].[Employee] (
    [ID]       BIGINT       IDENTITY (1, 1) NOT NULL,
    [EmpId]    VARCHAR (8)  NOT NULL,
    [EmpName]  VARCHAR (20) NOT NULL,
    [Ext]      VARCHAR (3)  NULL,
    [Birthday] DATE         NULL,
    [DepId]    VARCHAR (4)  NULL,
    CONSTRAINT [PK_Employee_1] PRIMARY KEY CLUSTERED ([ID] ASC)
);



