CREATE TABLE mta.Item (
   ItemId VARCHAR(36) NOT NULL,
   ItemName VARCHAR(60) NOT NULL,
   Description VARCHAR(20000),
   LongDescription VARCHAR(20000),
   ParentStateId VARCHAR(36) NOT NULL,
   Hint VARCHAR(20000)
) ENGINE = InnoDB ROW_FORMAT = DEFAULT;