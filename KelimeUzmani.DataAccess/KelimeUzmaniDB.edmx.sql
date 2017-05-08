
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/08/2017 22:12:54
-- Generated from EDMX file: E:\projects\KelimeUzmani\KelimeUzmani.DataAccess\KelimeUzmaniDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [master];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_SampleSentence_Word]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SampleSentence] DROP CONSTRAINT [FK_SampleSentence_Word];
GO
IF OBJECT_ID(N'[dbo].[FK_WordListList_Word]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WordListList] DROP CONSTRAINT [FK_WordListList_Word];
GO
IF OBJECT_ID(N'[dbo].[FK_WordListList_WordList]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WordListList] DROP CONSTRAINT [FK_WordListList_WordList];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[SampleSentence]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SampleSentence];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[Word]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Word];
GO
IF OBJECT_ID(N'[dbo].[WordList]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WordList];
GO
IF OBJECT_ID(N'[dbo].[WordListList]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WordListList];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'SampleSentence'
CREATE TABLE [dbo].[SampleSentence] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [WordID] int  NOT NULL,
    [Sentence] varchar(max)  NULL
);
GO

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(100)  NOT NULL,
    [Surname] varchar(100)  NOT NULL,
    [UserName] varchar(100)  NOT NULL,
    [Password] varchar(12)  NOT NULL
);
GO

-- Creating table 'Word'
CREATE TABLE [dbo].[Word] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [WordBody] varchar(255)  NULL,
    [Description] varchar(max)  NULL
);
GO

-- Creating table 'WordList'
CREATE TABLE [dbo].[WordList] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(100)  NOT NULL,
    [UserID] int  NOT NULL
);
GO

-- Creating table 'WordListList'
CREATE TABLE [dbo].[WordListList] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [WordID] int  NOT NULL,
    [WordListID] int  NOT NULL,
    [isPublic] bit  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'SampleSentence'
ALTER TABLE [dbo].[SampleSentence]
ADD CONSTRAINT [PK_SampleSentence]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Word'
ALTER TABLE [dbo].[Word]
ADD CONSTRAINT [PK_Word]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'WordList'
ALTER TABLE [dbo].[WordList]
ADD CONSTRAINT [PK_WordList]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'WordListList'
ALTER TABLE [dbo].[WordListList]
ADD CONSTRAINT [PK_WordListList]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [WordID] in table 'SampleSentence'
ALTER TABLE [dbo].[SampleSentence]
ADD CONSTRAINT [FK_SampleSentence_Word]
    FOREIGN KEY ([WordID])
    REFERENCES [dbo].[Word]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SampleSentence_Word'
CREATE INDEX [IX_FK_SampleSentence_Word]
ON [dbo].[SampleSentence]
    ([WordID]);
GO

-- Creating foreign key on [WordID] in table 'WordListList'
ALTER TABLE [dbo].[WordListList]
ADD CONSTRAINT [FK_WordListList_Word]
    FOREIGN KEY ([WordID])
    REFERENCES [dbo].[Word]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WordListList_Word'
CREATE INDEX [IX_FK_WordListList_Word]
ON [dbo].[WordListList]
    ([WordID]);
GO

-- Creating foreign key on [WordListID] in table 'WordListList'
ALTER TABLE [dbo].[WordListList]
ADD CONSTRAINT [FK_WordListList_WordList]
    FOREIGN KEY ([WordListID])
    REFERENCES [dbo].[WordList]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WordListList_WordList'
CREATE INDEX [IX_FK_WordListList_WordList]
ON [dbo].[WordListList]
    ([WordListID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------