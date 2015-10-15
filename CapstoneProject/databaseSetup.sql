﻿CREATE DATABASE UTSDB

CREATE TABLE UTSServer (
	ServerID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY
	,ServerName VARCHAR(100) NULL
	,Encrypted VARCHAR(100) NULL
	)

CREATE TABLE Share (
	ShareID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY
	,ShareServerID INT NOT NULL
	,FOREIGN KEY (ShareServerID) REFERENCES UTSServer(ServerID)
	,ShareName VARCHAR(100) NULL
	,Quota VARCHAR(100) NULL
	,OWNER VARCHAR(100) NULL
	)

CREATE TABLE Share_Groups (
	Share_GroupID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY
	,Share_GroupShareID INT NOT NULL
	,FOREIGN KEY (Share_GroupShareID) REFERENCES Share(ShareID)
	)

CREATE TABLE Groups (
	GroupsID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY
	,GroupsName VARCHAR(100) NULL
	,GroupsManager VARCHAR(100) NULL
	)

CREATE TABLE USERS (
	UsersID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY
	,UsersName VARCHAR(100) NULL
	)

CREATE TABLE Groups_User (
	Groups_UserID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY
	,GroupsIDGroups_User INT NOT NULL
	,UserIDGroups_User INT NOT NULL
	,FOREIGN KEY (GroupsIDGroups_User) REFERENCES Groups(GroupsID)
	,FOREIGN KEY (UserIDGroups_User) REFERENCES Users(UsersID)
	)