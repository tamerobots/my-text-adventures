CREATE TABLE mta.PlayerInventory (
   PlayerInventoryId VARCHAR(36) NOT NULL,
   PlayerId VARCHAR(36) NOT NULL,
   ItemId VARCHAR(36) NOT NULL   
) ENGINE = InnoDB ROW_FORMAT = DEFAULT;