CREATE TABLE mta.EntityState (
   EntityStateId VARCHAR(36) NOT NULL,
   EntityStateName VARCHAR(36) NOT NULL,
   EntityId VARCHAR(36) NOT NULL,
   Description VARCHAR(20000),
    LongDescription VARCHAR(20000),
   ItemAvailableId VARCHAR(36) NOT NULL,
   Visible BIT NOT NULL,
   ActivationVerb VARCHAR(60),
   PointsAwardedOnActivation int not null,
   VerbUpdatesRoomState BIT NOT NULL,
   Hint VARCHAR(20000),
   NextEntityStateId VARCHAR(36),
   ItemIdRequiredforRoomStateUpdate VARCHAR(36)
) ENGINE = InnoDB ROW_FORMAT = DEFAULT;