CREATE TABLE `mta`.`Player` (
  `PlayerId` VARCHAR(36) NOT NULL,
  `PlayerFirstName` VARCHAR(36) ,
  `PlayerLastName` VARCHAR(36) ,
  `AuthorId` VARCHAR(36),
  `CurrentRoomId` VARCHAR(36) NOT NULL,
  `Points` INTEGER UNSIGNED NOT NULL,
  `PlayerInventoryId` VARCHAR(36) NOT NULL,
  `CreatedOn` DATETIME NOT NULL,
  `LastPlayed` DATETIME NOT NULL,
  PRIMARY KEY (`PlayerId`)
)

