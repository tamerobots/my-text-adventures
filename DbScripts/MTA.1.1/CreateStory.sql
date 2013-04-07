CREATE TABLE mta.Story (
   StoryId VARCHAR(36) NOT NULL,
   StoryName VARCHAR(120) NOT NULL,
   AuthorId VARCHAR(36) NOT NULL,
   Description VARCHAR(20000),
   isPublished BIT,
   CreatedOn DATETIME NOT NULL,
   PublishedOn DATETIME NOT NULL,
    PRIMARY KEY (StoryId),
    CONSTRAINT fk_Author_Story FOREIGN KEY (AuthorId)
REFERENCES Author(AuthorId)
)
