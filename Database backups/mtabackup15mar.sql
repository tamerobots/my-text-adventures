-- MySQL dump 10.13  Distrib 5.1.38, for Win32 (ia32)
--
-- Host: localhost    Database: mta
-- ------------------------------------------------------
-- Server version	5.1.38-community

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `author`
--

DROP TABLE IF EXISTS `author`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `author` (
  `AuthorId` varchar(36) NOT NULL,
  `UserName` varchar(60) NOT NULL,
  `FirstName` varchar(20) DEFAULT NULL,
  `LastName` varchar(20) DEFAULT NULL,
  `Password` varchar(20) NOT NULL,
  `Email` varchar(80) DEFAULT NULL,
  `CreatedOn` datetime NOT NULL,
  PRIMARY KEY (`AuthorId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `author`
--

LOCK TABLES `author` WRITE;
/*!40000 ALTER TABLE `author` DISABLE KEYS */;
INSERT INTO `author` VALUES ('b4d89faa-3cee-4f6e-95b0-f5357bb45816','David','David','','zap','bleep@bloop.com','2010-01-28 16:06:33');
/*!40000 ALTER TABLE `author` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `entity`
--

DROP TABLE IF EXISTS `entity`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `entity` (
  `EntityId` varchar(36) NOT NULL,
  `EntityName` varchar(60) NOT NULL,
  `Description` varchar(2000) DEFAULT NULL,
  `RoomId` varchar(36) DEFAULT NULL,
  `RoomStateId` varchar(36) DEFAULT NULL,
  `Visible` bit(1) NOT NULL,
  `StartEntityStateId` varchar(36) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `entity`
--

LOCK TABLES `entity` WRITE;
/*!40000 ALTER TABLE `entity` DISABLE KEYS */;
INSERT INTO `entity` VALUES ('0b08f8eb-0d36-4058-a215-3f6d02ea7d4c','2nd entity','aaslidfjp','','dcb8d6f3-7f1b-4247-a7db-1002b4735066','\0','abeea757-9054-4c07-a3b3-f73b9b12d8c3'),('eeaeb8f9-65d9-4d87-8778-333d761377b4','Roomentity1','asdf','68fb1e09-3abe-4cd0-9f3a-91c0f17daa2c','','',''),('49c36490-3df5-49f9-89e1-7cd8b7fac4f6','room1rs1e1','sadpfoiu','','10d39200-435b-434b-8e9e-98672484cfd6','',''),('7df7180d-646b-4ed9-bc5f-2d1652a9439d','Light','It is an ordinary light switch.','','15884f50-f599-4028-b773-a6df5a0ca067','','0ff05f69-6430-4255-a959-c97ab57481d6'),('1717c9d7-e341-4bf4-8a88-bc0d2b3a4381','Table','It is just an oak table. There are a few drawers in it.','66220775-05ff-4862-9842-30aa941fb5dd','','','3f51816f-971e-4dfc-8059-f3ed0caf35e8'),('62ced89d-df62-44c5-935a-0c78414335cf','mp3 player','Small mp3 player, integrated speakers','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41','','','565c3bcb-3b31-47e6-8d07-fa77b99477a9'),('7a738d6d-ba17-4978-b666-8f68716a03b3','Tap','it is not dripping so it is ok.','453a87d8-def5-40c8-9b69-36cc4527e301','','','e95d585a-ff3b-4078-8b1a-fcd0699a38f5'),('0c83f046-694d-4da1-ba26-71a3556520e9','Newspaper','Old','','352f36d6-7f9a-48a6-ac51-5b7364f1167c','',''),('b347c3c4-8b92-45fd-b929-0615016f564f','1-1entity1','bloop entity1 desc','','eb148c11-23ab-4ef6-8f2a-b50307f8433e','',''),('77856ab7-0da6-4637-902d-f0e2112db10e','blah','blah','','a2c84689-c035-4937-a3c0-e25727bbf552','','');
/*!40000 ALTER TABLE `entity` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `entitystate`
--

DROP TABLE IF EXISTS `entitystate`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `entitystate` (
  `EntityStateId` varchar(36) NOT NULL,
  `EntityStateName` varchar(36) NOT NULL,
  `EntityId` varchar(36) NOT NULL,
  `Description` varchar(10000) DEFAULT NULL,
  `LongDescription` varchar(20000) DEFAULT NULL,
  `Visible` bit(1) NOT NULL,
  `ActivationVerb` varchar(60) DEFAULT NULL,
  `ActivationText` varchar(10000) DEFAULT NULL,
  `PointsAwarded` int(11) NOT NULL,
  `VerbUpdatesRoomState` bit(1) NOT NULL,
  `Hint` varchar(20000) DEFAULT NULL,
  `NextEntityStateId` varchar(36) DEFAULT NULL,
  `ItemIdRequiredforRoomStateUpdate` varchar(36) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `entitystate`
--

LOCK TABLES `entitystate` WRITE;
/*!40000 ALTER TABLE `entitystate` DISABLE KEYS */;
INSERT INTO `entitystate` VALUES ('4e746356-4dc0-42c5-b50a-5b2683fde837','bookalook','234de5cb-6485-41c8-967b-a8c702cd47b4','fasdfpoiu','f','\0','f',NULL,23,'\0','asd','',''),('abeea757-9054-4c07-a3b3-f73b9b12d8c3','book','0b08f8eb-0d36-4058-a215-3f6d02ea7d4c','asdfasdf','asdf','\0','sit',NULL,0,'\0','floor','',''),('f37ddc33-a0a9-4e37-a100-862a8ede2c6b','test','4268e0ec-691d-4665-b146-c04fadbaed44','f','f','','vvc',NULL,12,'\0','asdf','',''),('2cb0611d-4f9e-412c-bb8d-9c445a079055','roomentity1state1','eeaeb8f9-65d9-4d87-8778-333d761377b4','sadf234','fxxcvxc2xxcv','\0','',NULL,1,'\0','1234x','','fa4b8574-ee86-443b-b098-54803569f23f'),('6635dd87-7507-4978-ac7c-778f638b2fae','r1-rs1-e1-es1','49c36490-3df5-49f9-89e1-7cd8b7fac4f6','asdkjfpo','i;alsjdfpoi222222','','',NULL,1,'\0','asdf123','',''),('0ff05f69-6430-4255-a959-c97ab57481d6','Light off','7df7180d-646b-4ed9-bc5f-2d1652a9439d','It is a light.','It is a light. It looks kind of well used. You could ACTIVATE it?','','activate','You turned on the light! well done.',12,'','ACTIVATE LIGHT','de41e811-d89b-411e-af9c-a8cbda9beb97',''),('de41e811-d89b-411e-af9c-a8cbda9beb97','Light on','7df7180d-646b-4ed9-bc5f-2d1652a9439d','The light is on','you cannot turn it off.. for some reason.. spooky.','\0','',NULL,0,'\0','','',''),('3f51816f-971e-4dfc-8059-f3ed0caf35e8','closed','1717c9d7-e341-4bf4-8a88-bc0d2b3a4381','The drawers of the table are shut.','All the drawers on the table are shut. You could search the table for things if you were nosy..','','search','You search the drawers of the table. You could not be more nosy! You find a lot of different odd things within: some fluff, a weird book and a gold ring.',3,'\0','you could SEARCH the TABLE?','',''),('565c3bcb-3b31-47e6-8d07-fa77b99477a9','off','62ced89d-df62-44c5-935a-0c78414335cf','it is dead.','there are no lights on the mp3 active, but a big button with activate on it.','','activate','the mp3 player comes to life! it starts blaring out some random R Kelly music. This cannot be good.',3,'\0','activate','0f2c0e9a-c97d-46df-acd7-92d99090db04','8592f4f5-76c3-4e82-aa0a-2a6b5e08a4b9'),('0f2c0e9a-c97d-46df-acd7-92d99090db04','on','62ced89d-df62-44c5-935a-0c78414335cf','it\'s doing something like blaring out r n b','it is blaring out some godwaful r n b rubbish','','','',0,'\0','','',''),('e95d585a-ff3b-4078-8b1a-fcd0699a38f5','off','7a738d6d-ba17-4978-b666-8f68716a03b3','the tap is off.','the tap is off. it\'s not even dripping.','','turn','water starts flowing out the tap! this is awesome, you could probably drink it if you were thirsty.',1,'','turn it','88594ec1-bbfc-4783-ba38-ba7ba10e8757','bc02f6a4-f058-43aa-9087-b25e49048cf8'),('88594ec1-bbfc-4783-ba38-ba7ba10e8757','on','7a738d6d-ba17-4978-b666-8f68716a03b3','water is coming out of the tap.','Loads of water is gushing out the tap.','','turn','you turned it off.',0,'\0','turn it','e95d585a-ff3b-4078-8b1a-fcd0699a38f5',''),('53b6418d-7057-40ac-9ad1-8960b42f7d21','News paper melting','0c83f046-694d-4da1-ba26-71a3556520e9','Words sliding across the floor like something out of a salvador dahli painting.','The news paper through sever overuseage has begun to melt! The presence of toxic fumes has speeded up the melting process.','','read','It tells you a hint of where the slippers are! beware! the ninjas are coming! go east!!!',5,'\0','the newspaper demands you go east! be quick!','',''),('a9a84811-fa24-4595-a32f-5bb002d7c83a','first-es1','b347c3c4-8b92-45fd-b929-0615016f564f','blah ent stat 1','blah ent stat 1','','move','you moved it.',10,'','move','',''),('461cdc55-27c6-4692-99d8-e8445baa2588','entstat','e500783a-d26d-4666-b116-2462cd90507b','brrorok','blook','','open','it opened',0,'\0','','','');
/*!40000 ALTER TABLE `entitystate` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `item`
--

DROP TABLE IF EXISTS `item`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `item` (
  `ItemId` varchar(36) NOT NULL,
  `ItemName` varchar(60) NOT NULL,
  `Description` varchar(20000) DEFAULT NULL,
  `LongDescription` varchar(20000) DEFAULT NULL,
  `ParentStateId` varchar(36) NOT NULL,
  `Hint` varchar(20000) DEFAULT NULL,
  `StoryId` varchar(36) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `item`
--

LOCK TABLES `item` WRITE;
/*!40000 ALTER TABLE `item` DISABLE KEYS */;
INSERT INTO `item` VALUES ('9bf7792b-bbd5-458e-94da-bc09c4083f2e','entity state item','asdoij','as;ldifujpoiasud','abeea757-9054-4c07-a3b3-f73b9b12d8c3','asdopfiuasdf',''),('52de1058-4619-4445-8361-31d46026185b','bookentitystateitem','asdfasdfas BAAA BAAA','fasdfsxcx23zxc','abeea757-9054-4c07-a3b3-f73b9b12d8c3','fasdf',''),('78227bf9-36bd-4b05-ba82-ac2f7e3bd2a7','cloop','asdf','fasdf','dcb8d6f3-7f1b-4247-a7db-1002b4735066','fasdf',''),('fa4b8574-ee86-443b-b098-54803569f23f','roomentity1-es1-item1','asdf','asdf4','2cb0611d-4f9e-412c-bb8d-9c445a079055','asdfddf3',''),('138b80f9-de4c-41a7-82b6-9e3f0e32b7f0','room1rs1-item1','asdf','fasdf`','10d39200-435b-434b-8e9e-98672484cfd6','fxcxc',''),('49d365c7-59a5-41ad-b162-bf28aaca3ff9','r1-rs1-e1-es1-i1','asdfxxxxxxxxxxxxxxxxxxxx','asdf','6635dd87-7507-4978-ac7c-778f638b2fae','asdfasdf',''),('6a1efcef-4b60-408a-bceb-e12f6c615ee1','book','It is an interesting looking book. Black leather colour with just a weird symbol on the side.','This odd, creepy book makes you a little spooked out when you look at it. The symbol on the outside looks kind of gothic, and the book looks so weathered it must be at least 100 years old. You feel like you should give this to someone, or put it somewhere.','3f51816f-971e-4dfc-8059-f3ed0caf35e8','',''),('8592f4f5-76c3-4e82-aa0a-2a6b5e08a4b9','bits of fluff','they are bits of fluff. not very interesting really.','They are bits of fluff. You found them on the floor. You cannot really do anything with them. In fact.. why did you pick them up, are you nuts?\r\nthat\'s kablamo','42fa99c7-9c40-417c-bb63-951d380c863b','','07b876f9-98cc-48fb-bef9-295b251e2848'),('bc02f6a4-f058-43aa-9087-b25e49048cf8','Green lantern','It\'s a green lantern','It\'s a green lantern. It probably means you can do something else.','20090338-5205-488c-862f-4968bc7e4d83','','07b876f9-98cc-48fb-bef9-295b251e2848'),('4706cabe-f0bf-4dd4-a4e3-34025852bc3b','book','it\'s just a book','it\'s just a book','a9a84811-fa24-4595-a32f-5bb002d7c83a','put it somewhere?','77f28abb-5011-4cbe-bff1-a70e0ba6c7bb'),('2e5e48a8-dd6b-42f7-bc2f-aede35a15a39','myitem','','','461cdc55-27c6-4692-99d8-e8445baa2588','','6650dc61-c6ad-44bf-9e22-45786422ddb6');
/*!40000 ALTER TABLE `item` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `player`
--

DROP TABLE IF EXISTS `player`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `player` (
  `PlayerId` varchar(36) NOT NULL,
  `PlayerFirstName` varchar(36) DEFAULT NULL,
  `PlayerLastName` varchar(36) DEFAULT NULL,
  `AuthorId` varchar(36) DEFAULT NULL,
  `CurrentRoomId` varchar(36) NOT NULL,
  `Points` int(10) unsigned NOT NULL,
  `CreatedOn` datetime NOT NULL,
  `LastPlayed` datetime NOT NULL,
  PRIMARY KEY (`PlayerId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `player`
--

LOCK TABLES `player` WRITE;
/*!40000 ALTER TABLE `player` DISABLE KEYS */;
INSERT INTO `player` VALUES ('0144893a-26db-4724-be11-32fbc7273700','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 22:44:08','2010-03-08 22:44:09'),('0544b92d-f95a-4c1c-b1e1-fe4438a4a9df','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 15:11:17','2010-03-08 15:11:20'),('060d3e6b-eded-4c65-949a-8b6263f7a63f','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 21:09:12','2010-03-08 21:09:13'),('074c1849-4213-4312-be95-89d705691320','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 22:14:57','2010-03-08 22:14:58'),('075ead1c-e057-4747-b811-90cc47ac3d2c','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-10 17:06:13','2010-03-10 17:06:14'),('076b2b8e-3918-4229-9455-47810cb9c203','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-10 17:12:07','2010-03-10 17:12:07'),('078aaf49-775b-467f-8a72-c72089ac8415','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-07 18:58:20','2010-03-07 18:58:20'),('092302bb-0297-4bbf-a2ad-89585b0d28b1','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 00:36:27','2010-03-08 00:37:33'),('0a2f641c-6201-4e0d-8206-f386ff46ecdd','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-10 02:11:35','2010-03-10 02:11:35'),('0f68417b-d336-49e3-8ad4-218c9aa5f2f7','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-07 22:57:15','2010-03-07 22:57:15'),('119640cb-1967-4031-b42e-4805bd080b65','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-09 00:01:34','2010-03-09 00:01:34'),('1290d0ee-c1a6-4f0c-9538-57712647f1a6','','','','66220775-05ff-4862-9842-30aa941fb5dd',4,'2010-03-10 01:51:01','2010-03-10 01:51:15'),('131c658c-3666-48a9-9cd9-040ff0b1378c','','','','',0,'2010-03-11 21:59:45','2010-03-11 21:59:45'),('136966fb-5c57-4717-83b1-ac5b6ec179b8','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 20:10:54','2010-03-08 20:10:54'),('14a5412b-4fe6-4ed4-929b-f9945257e8c3','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 21:35:14','2010-03-08 21:35:14'),('15a2019f-50af-457a-9e10-f8dd2ff2fd9e','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 16:58:58','2010-03-08 16:58:58'),('196f008b-77d9-4a33-b672-516e32edfcbc','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 22:43:21','2010-03-08 22:43:22'),('1cd0ab83-c2c1-4a38-a3cd-922a7accb8d4','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-07 22:57:30','2010-03-07 22:57:30'),('1e50f67f-4d92-4563-b8fc-f05c7f0eca2b','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-10 17:40:13','2010-03-10 17:40:13'),('1f07ff37-aa84-4d0e-954a-46bd2ea6dc31','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 17:11:21','2010-03-08 17:11:22'),('1fe4969a-9da8-4d41-bee7-d3d22bbdbdde','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-07 20:10:08','2010-03-07 20:10:08'),('1ff61f43-1de5-4687-8d8c-fffe55fdd027','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 00:25:14','2010-03-08 00:25:41'),('202c06c4-7086-4cbc-8255-6802dcd81598','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 15:21:54','2010-03-08 15:21:54'),('245505b1-3379-4917-a786-72b973c86f7d','','','','',0,'2010-03-07 16:13:53','2010-03-07 16:13:53'),('2750bac7-c9e2-44e5-a05c-a7d3f2dc1094','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 23:00:56','2010-03-08 23:00:56'),('281686a0-899e-4b79-8970-c85629a8f0ed','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-09 00:16:07','2010-03-09 00:16:07'),('29a1881c-9b12-4646-9b4d-3a418ef9ce44','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 22:45:16','2010-03-08 22:45:16'),('2a51e58b-e27f-467a-af1e-50f862377c1b','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-10 02:30:31','2010-03-10 02:30:32'),('2b29e37b-bed9-4b46-8e9e-f0f4e3570ea2','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 22:26:06','2010-03-08 22:26:06'),('32911c56-5b0c-4702-9fdd-193a302d5120','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-07 21:38:19','2010-03-07 21:38:20'),('33d19023-878b-43e5-8374-a48ec1547db4','','','','',0,'2010-03-07 18:32:09','2010-03-07 18:32:09'),('35ec71bc-bf85-4d85-ae5d-7a2c62fdff04','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 22:24:27','2010-03-08 22:24:28'),('3676b831-b8b1-4c01-8efa-cdbfdbf5250b','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 21:29:51','2010-03-08 21:29:51'),('394d0dad-4e7b-40e3-9a15-c1069df844eb','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-10 17:09:09','2010-03-10 17:09:09'),('39984f63-bf61-4121-bef2-db58df45e4e0','','','','',0,'2010-03-07 16:04:35','2010-03-07 16:04:35'),('3b19800a-827f-416f-9752-03910dc99c41','','','','66220775-05ff-4862-9842-30aa941fb5dd',4,'2010-03-14 23:05:56','2010-03-14 23:06:12'),('3cc7b11a-a036-4172-9934-5c28338fac27','','','','',0,'2010-03-07 18:33:20','2010-03-07 18:33:20'),('3d709e67-57aa-44b9-b497-93207381107c','','','','',0,'2010-03-07 18:36:37','2010-03-07 18:36:37'),('3dabbc54-0bb9-44c7-ae42-d0e7963ff4ca','','','','',0,'2010-03-07 21:06:32','2010-03-07 21:06:32'),('3fe6719e-6523-4c17-8123-add0f20b5601','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-07 18:36:02','2010-03-07 18:36:02'),('41ed2f8b-8877-4f23-9ecd-463c24b0667a','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 23:49:39','2010-03-08 23:49:39'),('42e03c23-d8c9-41b3-a10f-4144d1e53231','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 15:25:38','2010-03-08 15:25:39'),('44648e65-9665-4719-ad23-4a582d9e89be','','','','',0,'2010-03-07 16:09:48','2010-03-07 16:09:48'),('496c53e4-cf3e-46dd-9cb2-d2f4750b4c71','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 22:41:21','2010-03-08 22:41:21'),('4a2b412c-2a94-4360-846d-33ff64c057cd','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-07 21:08:05','2010-03-07 21:08:06'),('4e7cb2ed-b96e-4c31-8802-1e3c8a78ee73','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-07 20:04:16','2010-03-07 20:04:16'),('54e4f2cc-46a1-48ea-96ae-acdf3060ada4','','','','66220775-05ff-4862-9842-30aa941fb5dd',4,'2010-03-10 01:52:43','2010-03-10 01:52:57'),('55ab8b5f-7464-4ef9-a01b-76c13eff46da','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 21:40:10','2010-03-08 21:40:10'),('55d4b3bf-9e27-4159-8ee5-48d52198a53c','','','','453a87d8-def5-40c8-9b69-36cc4527e301',4,'2010-03-10 02:14:49','2010-03-10 02:18:44'),('56745074-a81f-4dd0-b74b-baaa5bb3d3f1','','','','66220775-05ff-4862-9842-30aa941fb5dd',4,'2010-03-09 00:08:11','2010-03-09 00:10:52'),('60976b1e-d821-4528-8dc4-e67382706b46','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 23:16:41','2010-03-08 23:16:42'),('62e92dcf-512f-496c-bf26-eff6b4c81762','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-07 23:20:03','2010-03-07 23:20:03'),('65589627-fa66-430c-9ce9-be39885bccb6','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 20:18:38','2010-03-08 20:18:38'),('67199506-df78-4012-9232-cc0b17a023f0','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 22:27:49','2010-03-08 22:27:49'),('68cf873b-ad29-4cbe-b2c7-fb8a636c3f3a','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 21:31:29','2010-03-08 21:31:29'),('6a535cf6-dc4d-4b50-a744-bcbfeb2722a2','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 23:54:00','2010-03-08 23:54:00'),('6c5cc284-7f75-49e7-adaa-3fc954e7f332','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-10 17:06:39','2010-03-10 17:06:39'),('6c7bd26d-f4a5-444e-b8fd-5c0601cf0547','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 21:16:42','2010-03-08 21:16:42'),('71d88f32-8b78-4cdd-83c0-85131233563a','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 22:57:00','2010-03-08 22:57:00'),('731f43fd-1696-43ae-846b-ac9402222b1a','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 22:15:28','2010-03-08 22:15:28'),('73effe04-0324-461f-a657-2d9aada338dd','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 22:06:41','2010-03-08 22:06:41'),('765e425a-ab00-42a8-a825-9f712dd87b5f','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-10 17:37:41','2010-03-10 17:37:41'),('773cf7ff-f84d-4e4c-8623-93559fd869d5','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-10 17:05:27','2010-03-10 17:05:27'),('7adb57b9-4971-4a98-b126-2562ee2b344e','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 21:14:37','2010-03-08 21:14:37'),('7db23b7e-236d-4702-87aa-975c41175f58','','','','',0,'2010-03-07 18:30:14','2010-03-07 18:30:14'),('7db414ff-9180-4a56-af4e-d3496a243a50','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-07 22:15:28','2010-03-07 22:15:45'),('7e8de0ad-4b41-48f5-9a06-552a3a632c19','','','','',0,'2010-03-07 18:41:03','2010-03-07 18:41:03'),('80b32d6f-a858-4a5d-a3c4-c31bce8bd56d','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 21:15:09','2010-03-08 21:15:10'),('85c972e4-faa7-4fbe-a8c8-9893893211d0','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-07 18:36:22','2010-03-07 18:36:22'),('85d9c9aa-07a3-489f-80d7-7b3c3a6d0a0d','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-07 18:35:55','2010-03-07 18:35:56'),('8a674d9f-960e-4fde-9c88-ad4f2c9f4f51','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-07 23:21:13','2010-03-07 23:21:13'),('8a822e5c-033d-4f0c-9df4-3714780fd22c','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-07 23:08:02','2010-03-07 23:08:02'),('8c8b2533-9d23-48e8-b892-b74318209569','','','b4d89faa-3cee-4f6e-95b0-f5357bb45816','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',4,'2010-03-10 01:00:56','2010-03-15 17:09:53'),('9073bb27-662a-46dc-ac70-21359ddffe19','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-07 23:17:03','2010-03-07 23:17:03'),('910d079c-e737-4df6-aeb4-34b3a45257e2','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-07 23:05:14','2010-03-07 23:05:15'),('921617e8-7997-4edc-87ac-78c9dba0048e','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-07 22:04:10','2010-03-07 22:04:10'),('963a8138-52ba-4090-8cff-acbd4c9cd35f','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 21:44:37','2010-03-08 21:44:37'),('9744b2db-d815-43e3-b08e-1e30f7494ff3','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 22:18:10','2010-03-08 22:18:10'),('97d41e78-7b8e-47ec-85f6-8759df499442','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 22:23:00','2010-03-08 22:23:01'),('98bfebe7-521f-4abc-bc39-45fdd317d24a','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 22:22:34','2010-03-08 22:22:34'),('9925c1f5-fbb4-4a9b-a9f2-354b82afff80','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 21:05:59','2010-03-08 21:05:59'),('9a62e5d9-c4f3-4ad9-b548-5e02a21a71e3','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 15:10:31','2010-03-08 15:10:33'),('9f80941d-1931-4bd7-9804-645ef5817d9c','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 20:55:31','2010-03-08 20:55:31'),('9f9e5eb4-7091-435d-a8ad-95c863e9c1d8','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-07 22:10:54','2010-03-07 22:10:54'),('A45383B0-22E9-4da2-AA6A-484EBC68745A','David','','1830b077-99af-4c2d-8a17-b525202e033c','48fb265d-c007-46ba-975d-3f64f9829771',12,'2010-01-28 16:06:35','2010-01-28 16:06:35'),('a5578f7f-813b-482c-a724-d01fedf709cc','','','','',0,'2010-03-07 22:11:28','2010-03-07 22:11:28'),('a5f8c2a2-2e40-498d-832d-76ac741ce43b','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-10 16:59:29','2010-03-10 16:59:30'),('a670f7d1-1ec8-4005-b445-af02f5c19ea2','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-10 01:43:26','2010-03-10 01:43:27'),('aa32c69f-b1ed-4526-b79e-f962d097e7c6','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 22:42:12','2010-03-08 22:42:12'),('aaf97102-d817-4801-a425-5a33167ec150','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-07 22:15:14','2010-03-07 22:15:14'),('ab933353-f193-4b92-996e-da3ded0a0ff2','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 20:56:40','2010-03-08 20:56:40'),('ac8b7ede-b065-407e-aaf5-d43bd310f442','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-07 21:08:44','2010-03-07 21:08:44'),('ae4e9340-9c8a-4d94-9548-46ef669e6fec','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 23:04:17','2010-03-08 23:04:17'),('aef32006-1b55-4e44-905a-76489018ef2d','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 14:55:01','2010-03-08 14:55:04'),('b299d4e3-9442-42a5-b46d-f0a3373b638d','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 21:32:46','2010-03-08 21:32:47'),('b420b84c-d197-4d83-b160-3d0e350d2fd4','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 22:47:29','2010-03-08 22:47:29'),('b470c8f4-9b39-4e06-a178-440551f67f41','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 20:17:03','2010-03-08 20:17:04'),('b7069d15-73c1-43f6-94fe-20dafa3effff','','','','',0,'2010-03-07 18:54:57','2010-03-07 18:54:57'),('b7704482-ce1a-477b-a474-51787fbc9352','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 17:17:19','2010-03-08 17:17:19'),('b8c8d379-a313-48fa-a45e-0bbc3fb5af7d','','','','',0,'2010-03-07 22:12:05','2010-03-07 22:12:05'),('bcb4809f-df45-4435-b671-80635c778bee','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-09 00:13:18','2010-03-09 00:13:18'),('bf19fdcb-e7b4-40e8-a5ae-9c37af0ae213','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-07 23:12:17','2010-03-07 23:12:17'),('bf4c4281-0d34-413a-9def-31aa76d4fec4','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-09 00:21:13','2010-03-09 00:21:13'),('c32e39a5-f245-42af-b51a-5dca960e8207','','','','',0,'2010-03-07 16:02:01','2010-03-07 16:02:01'),('c900f5b3-7a25-4193-be3c-18cd6a3559f2','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 16:14:23','2010-03-08 16:14:27'),('ca016b19-2d30-4526-94f6-71d6b02dcbff','','','','',0,'2010-03-07 18:40:51','2010-03-07 18:40:51'),('ca3714df-0dfa-4029-acc7-c1341a43b62b','','','','',0,'2010-03-07 22:11:12','2010-03-07 22:11:12'),('cccd5d90-d4ca-499d-8e7c-9cc31d64f54a','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-07 21:49:24','2010-03-07 21:49:24'),('cd024a9d-510c-46bd-a932-5d17389fd98b','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-07 21:55:21','2010-03-07 21:55:21'),('cd3788b3-7dcd-4080-b4ca-498dfbf710c4','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 20:08:51','2010-03-08 20:08:52'),('ce8213e6-0aee-4e3e-ad0e-8b9a0fc1a564','','','','',0,'2010-03-07 16:01:07','2010-03-07 16:01:07'),('cee3772c-c600-4344-a50c-0ab606615a56','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-10 02:13:53','2010-03-10 02:13:53'),('d3f5a838-2a7b-4d2f-ab79-92986f359506','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 21:43:15','2010-03-08 21:43:16'),('d965839d-ec3f-4bd4-89ea-c089099d82f0','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 17:15:13','2010-03-08 17:15:13'),('d9cd3247-331a-4ed3-a354-c14ed0ce6b63','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 23:52:02','2010-03-08 23:52:02'),('dc2dff85-f487-42ad-bf99-6c61bb111fdf','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 21:11:49','2010-03-08 21:11:49'),('dd764897-2cd4-4d38-b236-8e4aca773643','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 22:58:50','2010-03-08 22:58:50'),('dd825ae0-fb1d-4693-981f-8895b7d290b1','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 23:56:34','2010-03-08 23:56:34'),('dd85ae5b-bb32-49eb-a027-0e6a1a042fc7','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 21:10:59','2010-03-08 21:10:59'),('ddf01984-fbf2-486c-b52a-7f908dc6e53a','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 21:08:27','2010-03-08 21:08:27'),('dffe809b-2a22-422c-924e-d1671bd7b9ce','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 23:50:35','2010-03-08 23:50:35'),('e6643b16-565f-44e4-b547-d3e5f440583e','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-07 22:09:35','2010-03-07 22:09:36'),('e78070ae-d3e0-4373-a3f1-e9a298719bd8','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 15:10:23','2010-03-08 15:10:26'),('e85431da-c16c-4cfa-a7e6-89aec1d9e480','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-11 21:58:15','2010-03-11 21:58:15'),('e98a000e-4641-438b-ab66-bb7d42b6e819','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 23:12:23','2010-03-08 23:12:23'),('ebea9091-fced-491e-9a4e-ac987a1e7720','','','','66220775-05ff-4862-9842-30aa941fb5dd',4,'2010-03-09 21:58:23','2010-03-09 22:01:03'),('f01e1b70-cc3d-42e0-b8fb-72bf94e21dd9','','','b4d89faa-3cee-4f6e-95b0-f5357bb45816','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 15:41:17','2010-03-08 15:44:07'),('f03b8dfd-c5eb-4553-995a-f2dfd7fdfe40','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-07 22:06:33','2010-03-07 22:06:34'),('f0aeea2d-4e5d-40c1-9a0c-76186df136a3','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 20:23:43','2010-03-08 20:23:43'),('f159723f-b46b-4e9d-b652-136ad97cc4b9','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 22:29:28','2010-03-08 22:29:29'),('f2d76154-bea5-4ac9-9d27-49a9cfbd26cb','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 21:16:24','2010-03-08 21:16:25'),('f3678f7c-e2c6-4f18-bd1b-aaf31095d350','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 20:11:52','2010-03-08 20:11:53'),('f77e505c-9795-43a0-8e27-89d18010e4ca','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-07 20:04:28','2010-03-07 20:04:28'),('fa430179-4078-4075-a938-8ba7bcd0b6b1','','','b4d89faa-3cee-4f6e-95b0-f5357bb45816','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 15:39:56','2010-03-08 15:40:00'),('fb03c098-a51d-462e-a9d5-912c193e0871','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-07 23:17:11','2010-03-07 23:17:11'),('fd2ae45e-1279-4bcc-89b3-de2f42d686f3','','','b4d89faa-3cee-4f6e-95b0-f5357bb45816','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 16:15:32','2010-03-08 16:15:34'),('fd9ef269-254e-4790-8712-0f92125796ad','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-10 17:16:14','2010-03-10 17:16:14'),('fe6c8e4b-ba1a-4497-b625-62f6e8840509','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-07 23:10:03','2010-03-07 23:10:03'),('fee5aa8f-a7ff-44e5-95f8-e9aadeae991b','','','','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41',0,'2010-03-08 23:09:44','2010-03-08 23:09:44');
/*!40000 ALTER TABLE `player` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `playerentitystaterecord`
--

DROP TABLE IF EXISTS `playerentitystaterecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `playerentitystaterecord` (
  `PlayerEntityStateRecordId` varchar(36) NOT NULL,
  `PlayerId` varchar(36) NOT NULL,
  `EntityStateId` varchar(36) NOT NULL,
  `EntityId` varchar(36) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `playerentitystaterecord`
--

LOCK TABLES `playerentitystaterecord` WRITE;
/*!40000 ALTER TABLE `playerentitystaterecord` DISABLE KEYS */;
INSERT INTO `playerentitystaterecord` VALUES ('e4d3a1e4-bb60-4fda-954a-4e19f13c5668','8c8b2533-9d23-48e8-b892-b74318209569','565c3bcb-3b31-47e6-8d07-fa77b99477a9','62ced89d-df62-44c5-935a-0c78414335cf'),('c7378dff-4786-4cf8-ae3c-afbd273c1649','8c8b2533-9d23-48e8-b892-b74318209569','de41e811-d89b-411e-af9c-a8cbda9beb97','7df7180d-646b-4ed9-bc5f-2d1652a9439d');
/*!40000 ALTER TABLE `playerentitystaterecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `playerinventory`
--

DROP TABLE IF EXISTS `playerinventory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `playerinventory` (
  `PlayerInventoryId` varchar(36) NOT NULL,
  `PlayerId` varchar(36) NOT NULL,
  `ItemId` varchar(36) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `playerinventory`
--

LOCK TABLES `playerinventory` WRITE;
/*!40000 ALTER TABLE `playerinventory` DISABLE KEYS */;
INSERT INTO `playerinventory` VALUES ('0fae5391-98c3-49ee-ad2e-2d6721425e84','8c8b2533-9d23-48e8-b892-b74318209569','8592f4f5-76c3-4e82-aa0a-2a6b5e08a4b9');
/*!40000 ALTER TABLE `playerinventory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `playerroomstaterecord`
--

DROP TABLE IF EXISTS `playerroomstaterecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `playerroomstaterecord` (
  `PlayerRoomStateRecordId` varchar(36) NOT NULL,
  `PlayerId` varchar(36) NOT NULL,
  `RoomStateId` varchar(36) NOT NULL,
  `RoomId` varchar(36) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `playerroomstaterecord`
--

LOCK TABLES `playerroomstaterecord` WRITE;
/*!40000 ALTER TABLE `playerroomstaterecord` DISABLE KEYS */;
INSERT INTO `playerroomstaterecord` VALUES ('f124f465-7a18-4094-87a3-c83b8e406e0a','8c8b2533-9d23-48e8-b892-b74318209569','42fa99c7-9c40-417c-bb63-951d380c863b','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41');
/*!40000 ALTER TABLE `playerroomstaterecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `room`
--

DROP TABLE IF EXISTS `room`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `room` (
  `RoomId` varchar(36) NOT NULL,
  `StoryId` varchar(36) NOT NULL,
  `RoomName` varchar(60) NOT NULL,
  `StartRoomStateId` varchar(36) DEFAULT NULL,
  `NorthRoomId` varchar(36) DEFAULT NULL,
  `EastRoomId` varchar(36) DEFAULT NULL,
  `SouthRoomId` varchar(36) DEFAULT NULL,
  `WestRoomId` varchar(36) DEFAULT NULL,
  PRIMARY KEY (`RoomId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `room`
--

LOCK TABLES `room` WRITE;
/*!40000 ALTER TABLE `room` DISABLE KEYS */;
INSERT INTO `room` VALUES ('01d051eb-56c6-4a27-8b7d-dbd34337010d','6650dc61-c6ad-44bf-9e22-45786422ddb6','dasfg','','','','',''),('08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41','07b876f9-98cc-48fb-bef9-295b251e2848','Entry','15884f50-f599-4028-b773-a6df5a0ca067','','','','66220775-05ff-4862-9842-30aa941fb5dd'),('0c8d3125-5bcd-4614-b10a-7ab7197ad670','14ebea1e-20f1-4c4c-854e-505cb9422032','3wbookatronic','','5ce12166-46d9-4564-b9ef-a0caa039bb54','','',''),('453a87d8-def5-40c8-9b69-36cc4527e301','07b876f9-98cc-48fb-bef9-295b251e2848','Kitchen','20090338-5205-488c-862f-4968bc7e4d83','','','66220775-05ff-4862-9842-30aa941fb5dd',''),('57f96dd3-a2d9-487b-aba1-0f30c3590014','14ebea1e-20f1-4c4c-854e-505cb9422032','testingroom','dcb8d6f3-7f1b-4247-a7db-1002b4735066','ec949a54-1516-4170-bd35-a5a7d6885469','5ce12166-46d9-4564-b9ef-a0caa039bb54','',''),('5ce12166-46d9-4564-b9ef-a0caa039bb54','14ebea1e-20f1-4c4c-854e-505cb9422032','boosanagoia','','','','',''),('66220775-05ff-4862-9842-30aa941fb5dd','07b876f9-98cc-48fb-bef9-295b251e2848','Hallway','30488523-ec5b-487c-8ebc-913a4e347121','453a87d8-def5-40c8-9b69-36cc4527e301','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41','',''),('68fb1e09-3abe-4cd0-9f3a-91c0f17daa2c','72261807-e4be-4b4f-9e8f-14a7c00cedd3','Balloos','','','','',''),('6cc4823f-e07e-4d76-b211-728308747a17','','','blahvasdf','','','',''),('77e4f2ea-c289-4673-a162-2fa21e2b4d9c','14ebea1e-20f1-4c4c-854e-505cb9422032','ienosdf','','','','',''),('80f81ba1-483d-46c1-853a-4586c3e5664d','77f28abb-5011-4cbe-bff1-a70e0ba6c7bb','first room','eb148c11-23ab-4ef6-8f2a-b50307f8433e','','','',''),('b54126b4-ea87-447c-aff9-2c2278f316f5','','','test room 2','','','',''),('b8f9fb81-d918-4fad-bc01-390f77dc72eb','6650dc61-c6ad-44bf-9e22-45786422ddb6','room1','a2c84689-c035-4937-a3c0-e25727bbf552','','','',''),('dabcefda-3846-499a-b9aa-a910e5364080','','asdf','','','','',''),('e6195c95-29d5-4cae-bbf5-3003d35a6d7e','1b647f6d-f4cd-4fd5-a5b3-50e1cf5626b0','Emporer\'s bed chamber','352f36d6-7f9a-48a6-ac51-5b7364f1167c','','','',''),('ec949a54-1516-4170-bd35-a5a7d6885469','14ebea1e-20f1-4c4c-854e-505cb9422032','randomroom','','','','','');
/*!40000 ALTER TABLE `room` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roomstate`
--

DROP TABLE IF EXISTS `roomstate`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `roomstate` (
  `RoomStateId` varchar(36) NOT NULL,
  `RoomStateName` varchar(60) NOT NULL,
  `ParentRoomId` varchar(36) NOT NULL,
  `CanGoNorth` bit(1) NOT NULL,
  `CanGoEast` bit(1) NOT NULL,
  `CanGoSouth` bit(1) NOT NULL,
  `CanGoWest` bit(1) NOT NULL,
  `PointsAwarded` int(11) NOT NULL,
  `Description` varchar(20000) DEFAULT NULL,
  `LongDescription` varchar(20000) DEFAULT NULL,
  `IsEndGameTrigger` bit(1) NOT NULL,
  `NextRoomStateId` varchar(36) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roomstate`
--

LOCK TABLES `roomstate` WRITE;
/*!40000 ALTER TABLE `roomstate` DISABLE KEYS */;
INSERT INTO `roomstate` VALUES ('dcb8d6f3-7f1b-4247-a7db-1002b4735066','test room state','57f96dd3-a2d9-487b-aba1-0f30c3590014','','\0','','\0',23,'blah description','blah long description','','dcb8d6f3-7f1b-4247-a7db-1002b4735066'),('15884f50-f599-4028-b773-a6df5a0ca067','room1s1','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41','\0','\0','\0','\0',12,'It is dark. You cannot see anything at all.','You are in a really dark room.\r\nLook around, there is probably a LIGHT of some kind you might be able to ACTIVATE..','\0','42fa99c7-9c40-417c-bb63-951d380c863b'),('42fa99c7-9c40-417c-bb63-951d380c863b','room1rs2','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41','\0','\0','\0','',4,'It is light. There is a door to the west.','There are many bits of fluff on the floor. It is light. there is a door to the west.','\0',''),('30488523-ec5b-487c-8ebc-913a4e347121','1','66220775-05ff-4862-9842-30aa941fb5dd','\0','','\0','\0',6,'You are in a large hallway. There is a table in the centre.','You are in a large hallway. There are various odd-looking paintings hanging on the walls, along with a strange-looking table in the centre. There is not much else to look at, except for pair of slippers next to a big chair.','\0',''),('352f36d6-7f9a-48a6-ac51-5b7364f1167c','The toilet throne','e6195c95-29d5-4cae-bbf5-3003d35a6d7e','','','\0','\0',5,'You have come back to the royal toilet throne','You have reached the royal toilet throne. It smells a bit. There is little ventilation except one boarded window','\0',''),('20090338-5205-488c-862f-4968bc7e4d83','first','453a87d8-def5-40c8-9b69-36cc4527e301','\0','\0','','\0',12,'you\'re in a kitchen with a tap and a green lantern.','You\'re in a kitchen, it\'s kind of dull. There\'s a tap. Think there\'s a green lantern as well..','\0','9bbe3a0b-1046-4778-bceb-69d4aefafe65'),('9bbe3a0b-1046-4778-bceb-69d4aefafe65','Endgame state','453a87d8-def5-40c8-9b69-36cc4527e301','\0','\0','\0','\0',23,'','You ended the game! Nice one. You did well! Thanks - David','',''),('eb148c11-23ab-4ef6-8f2a-b50307f8433e','1-1','80f81ba1-483d-46c1-853a-4586c3e5664d','\0','\0','\0','\0',12,'first room state','just the first room state','\0',''),('a2c84689-c035-4937-a3c0-e25727bbf552','rs1','b8f9fb81-d918-4fad-bc01-390f77dc72eb','\0','','\0','\0',3,'blah','blah','\0',''),('8cf7d1e6-ef97-4300-b590-fed74bd0bc19','asdf','b8f9fb81-d918-4fad-bc01-390f77dc72eb','\0','\0','\0','\0',54,'','','\0','');
/*!40000 ALTER TABLE `roomstate` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `story`
--

DROP TABLE IF EXISTS `story`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `story` (
  `StoryId` varchar(36) NOT NULL,
  `StoryName` varchar(120) NOT NULL,
  `AuthorId` varchar(36) NOT NULL,
  `Description` varchar(20000) DEFAULT NULL,
  `isPublished` bit(1) DEFAULT NULL,
  `CreatedOn` datetime NOT NULL,
  `PublishedOn` datetime NOT NULL,
  `StartRoomId` varchar(36) DEFAULT NULL,
  PRIMARY KEY (`StoryId`),
  KEY `fk_Author_Story` (`AuthorId`),
  CONSTRAINT `fk_Author_Story` FOREIGN KEY (`AuthorId`) REFERENCES `author` (`AuthorId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `story`
--

LOCK TABLES `story` WRITE;
/*!40000 ALTER TABLE `story` DISABLE KEYS */;
INSERT INTO `story` VALUES ('07b876f9-98cc-48fb-bef9-295b251e2848','The Weird Hotel','b4d89faa-3cee-4f6e-95b0-f5357bb45816','a story, made for testing. It should be easy.','','2010-02-25 19:10:10','2010-02-27 15:00:30','08bc3a51-2f1a-4c26-8ed4-5b5a5de59d41'),('14ebea1e-20f1-4c4c-854e-505cb9422032','abadcous','b4d89faa-3cee-4f6e-95b0-f5357bb45816','foof','','2010-02-10 18:38:08','2010-02-17 21:27:19','57f96dd3-a2d9-487b-aba1-0f30c3590014'),('1b647f6d-f4cd-4fd5-a5b3-50e1cf5626b0','The creaky chair','b4d89faa-3cee-4f6e-95b0-f5357bb45816','Can you find the slippers before the ninjas do?','','2010-03-09 22:09:16','2010-03-09 22:29:34',''),('6650dc61-c6ad-44bf-9e22-45786422ddb6','blankdeleteit','b4d89faa-3cee-4f6e-95b0-f5357bb45816','\' delete from player where playerid=','\0','2010-03-11 02:12:56','0001-01-01 00:00:00',''),('77f28abb-5011-4cbe-bff1-a70e0ba6c7bb','delete me quick','b4d89faa-3cee-4f6e-95b0-f5357bb45816','sadfpoiu rubbish','\0','2010-03-10 20:46:24','0001-01-01 00:00:00',''),('f5c73bb1-36f1-47fc-a6ef-b70a090df6fd','The Mysterious Spoon','b4d89faa-3cee-4f6e-95b0-f5357bb45816','Just an empty story','\0','2010-03-09 00:24:00','0001-01-01 00:00:00','');
/*!40000 ALTER TABLE `story` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2010-03-15 17:22:22
