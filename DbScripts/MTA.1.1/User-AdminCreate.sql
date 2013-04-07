GRANT USAGE ON *.* TO `adminuser`@`localhost` IDENTIFIED BY '!ifdb117' REQUIRE NONE;
GRANT Select  ON `mta`.* TO `adminuser`@`localhost`;
GRANT Insert  ON `mta`.* TO `adminuser`@`localhost`;
GRANT Update  ON `mta`.* TO `adminuser`@`localhost`;
GRANT Delete  ON `mta`.* TO `adminuser`@`localhost`;