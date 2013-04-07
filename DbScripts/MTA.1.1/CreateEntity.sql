CREATE TABLE mta.Entity (
   EntityId VARCHAR(36) NOT NULL,
   EntityName VARCHAR(60) NOT NULL,
   Description VARCHAR(2000),
   RoomId VARCHAR(36) ,
   RoomStateId VARCHAR(36) ,
   Visible BIT NOT NULL,
   StartEntityStateId VARCHAR(36)
) ENGINE = InnoDB ROW_FORMAT = DEFAULT;