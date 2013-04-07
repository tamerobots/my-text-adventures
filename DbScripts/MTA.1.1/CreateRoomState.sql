CREATE TABLE mta.RoomState (
   RoomStateId VARCHAR(36) NOT NULL,
   RoomStateName VARCHAR(60) NOT NULL,
   ParentRoomId VARCHAR(36) NOT NULL,
   CanGoNorth BIT NOT NULL,
   CanGoEast BIT NOT NULL,  
   CanGoSouth BIT NOT NULL,
   CanGoWest BIT NOT NULL,
   PointsAwarded int NOT NULL,
   Description VARCHAR(20000),
   LongDescription VARCHAR(20000),
   IsEndGameTrigger BIT,
   ItemAvailableId VARCHAR(36)
) ENGINE = InnoDB ROW_FORMAT = DEFAULT;