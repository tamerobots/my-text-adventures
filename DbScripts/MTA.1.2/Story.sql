ALTER TABLE mta.story
 DROP FOREIGN KEY fk_Author_Story,
 ADD StartRoomId VARCHAR(36) AFTER PublishedOn;
ALTER TABLE mta.story
 ADD CONSTRAINT fk_Author_Story FOREIGN KEY (AuthorId) REFERENCES mta.author (AuthorId) ON UPDATE RESTRICT ON DELETE RESTRICT;
