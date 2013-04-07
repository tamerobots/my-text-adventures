CREATE TABLE mta.PlayerRoomStateRecord (
   PlayerRoomStateRecordId VARCHAR(36) NOT NULL,
    PlayerId VARCHAR(36) NOT NULL,
   RoomStateId VARCHAR(36) NOT NULL,
   RoomId VARCHAR(36)
) ENGINE = InnoDB ROW_FORMAT = DEFAULT;