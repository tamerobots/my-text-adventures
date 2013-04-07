CREATE TABLE mta.Room (
   RoomId VARCHAR(36) NOT NULL,
   StoryId VARCHAR(36) NOT NULL,
   RoomName VARCHAR(60) NOT NULL,
   StartRoomStateId VARCHAR(36),
   NorthRoomId VARCHAR(36),
   EastRoomId VARCHAR(36),
   SouthRoomId VARCHAR(36),
   WestRoomId VARCHAR(36),
    PRIMARY KEY (RoomId)
)
