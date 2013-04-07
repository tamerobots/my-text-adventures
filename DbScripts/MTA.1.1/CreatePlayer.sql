CREATE TABLE `mta`.`Player` (
  `PlayerId` VARCHAR(36) NOT NULL,
  `UserName` VARCHAR(36) NOT NULL,
  `PlayerFirstName` VARCHAR(36) NOT NULL,
  `PlayerLastName` VARCHAR(36) NOT NULL,
  `AuthorId` VARCHAR(36) NULL,
  `CurrentRoom` VARCHAR(36) NOT NULL,
  `Points` INTEGER UNSIGNED NOT NULL,
  `PlayerInventoryId` VARCHAR(36) NOT NULL,
  `CreatedOn` DATETIME DEFAULT CURRENT_DATE,
  PRIMARY KEY (`PlayerId`)
)

