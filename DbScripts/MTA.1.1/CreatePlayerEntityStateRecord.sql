CREATE TABLE mta.PlayerEntityStateRecord (
   PlayerEntityStateRecordId VARCHAR(36) NOT NULL,
    PlayerId VARCHAR(36) NOT NULL,
   EntityStateId VARCHAR(36) NOT NULL,
   EntityId VARCHAR(36)
) ENGINE = InnoDB ROW_FORMAT = DEFAULT;