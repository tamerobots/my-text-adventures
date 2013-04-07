CREATE TABLE mta.Author (
   AuthorId VARCHAR(36) NOT NULL,
   UserName VARCHAR(60) NOT NULL,
   FirstName VARCHAR(20),
   LastName VARCHAR(20),
   Password VARCHAR(20) NOT NULL,
   Email VARCHAR(80),
   CreatedOn DATETIME NOT NULL,
    PRIMARY KEY (AuthorId)
)
