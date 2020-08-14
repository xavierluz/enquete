  IF EXISTS(SELECT 1 FROM information_schema.tables 
  WHERE table_name = '
'__EFMigrationsHistory'' AND table_schema = DATABASE()) 
BEGIN
CREATE TABLE `__EFMigrationsHistory` (
    `MigrationId` varchar(150) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    PRIMARY KEY (`MigrationId`)
);

END;

CREATE TABLE `Poll` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Description` varchar(100) NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `Option` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Description` varchar(100) NULL,
    `PollId` int NOT NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Option_Poll_PollId` FOREIGN KEY (`PollId`) REFERENCES `Poll` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `View` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `PollId` int NOT NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_View_Poll_PollId` FOREIGN KEY (`PollId`) REFERENCES `Poll` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `Vote` (
    `PollId` int NOT NULL,
    `OptionId` int NOT NULL,
    PRIMARY KEY (`PollId`, `OptionId`),
    CONSTRAINT `FK_Vote_Option_OptionId` FOREIGN KEY (`OptionId`) REFERENCES `Option` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_Vote_Poll_PollId` FOREIGN KEY (`PollId`) REFERENCES `Poll` (`Id`) ON DELETE CASCADE
);

CREATE INDEX `IDX_OPTION_DESCRIPTION` ON `Option` (`Description`);

CREATE INDEX `IX_Option_PollId` ON `Option` (`PollId`);

CREATE INDEX `IDX_POLL_DESCRIPTION` ON `Poll` (`Description`);

CREATE UNIQUE INDEX `IDX_VIEW_POLL_ID` ON `View` (`PollId`);

CREATE UNIQUE INDEX `IX_Vote_OptionId` ON `Vote` (`OptionId`);

CREATE UNIQUE INDEX `IX_Vote_PollId` ON `Vote` (`PollId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200814153418_InitialEnquete', '3.1.6');

