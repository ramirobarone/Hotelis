CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    PRIMARY KEY (`MigrationId`)
);

START TRANSACTION;

CREATE TABLE `Address` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Street` longtext NULL,
    `Number` longtext NULL,
    `PostalCode` longtext NULL,
    `Latitud` longtext NULL,
    `Longitud` longtext NULL,
    `IdCity` int NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `Costs` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `CostPerTime` decimal(18,2) NOT NULL,
    `Hour` int NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `Countries` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` longtext NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `TimesAvialable` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Time` longtext NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `Hotels` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` longtext NOT NULL,
    `Description` longtext NOT NULL,
    `MetaDescription` longtext NOT NULL,
    `AddressHotelId` int NOT NULL,
    `Email` longtext NOT NULL,
    `CodeArea` int NOT NULL,
    `PhoneNumber` int NOT NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Hotels_Address_AddressHotelId` FOREIGN KEY (`AddressHotelId`) REFERENCES `Address` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `Users` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` longtext NULL,
    `SecondName` longtext NULL,
    `LastName` longtext NULL,
    `Password` longtext NULL,
    `Email` longtext NULL,
    `IdAddress` longtext NULL,
    `CodeArea` longtext NULL,
    `PhoneNumber` longtext NULL,
    `AddressId` int NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Users_Address_AddressId` FOREIGN KEY (`AddressId`) REFERENCES `Address` (`Id`)
);

CREATE TABLE `Provincies` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` longtext NOT NULL,
    `CountryId` int NOT NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Provincies_Countries_CountryId` FOREIGN KEY (`CountryId`) REFERENCES `Countries` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `HotelPicture` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Path` longtext NOT NULL,
    `HotelId` int NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_HotelPicture_Hotels_HotelId` FOREIGN KEY (`HotelId`) REFERENCES `Hotels` (`Id`)
);

CREATE TABLE `Rooms` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` longtext NULL,
    `Description` longtext NULL,
    `BedNumbers` int NOT NULL,
    `AvialableNow` tinyint(1) NOT NULL,
    `HotelsId` int NOT NULL,
    `CostId` int NOT NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Rooms_Costs_CostId` FOREIGN KEY (`CostId`) REFERENCES `Costs` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_Rooms_Hotels_HotelsId` FOREIGN KEY (`HotelsId`) REFERENCES `Hotels` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `Bookings` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `DateReserved` datetime(6) NOT NULL,
    `IdRoom` int NOT NULL,
    `Price` decimal(18,2) NOT NULL,
    `IdUser` int NOT NULL,
    `CheckInTimeId` int NOT NULL,
    `UserId` int NOT NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Bookings_TimesAvialable_CheckInTimeId` FOREIGN KEY (`CheckInTimeId`) REFERENCES `TimesAvialable` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_Bookings_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `Users` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `PreBooking` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `TimeToExpire` datetime(6) NOT NULL,
    `IdRoom` int NOT NULL,
    `UserId` longtext NOT NULL,
    `UserId1` int NOT NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_PreBooking_Users_UserId1` FOREIGN KEY (`UserId1`) REFERENCES `Users` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `Cities` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` longtext NULL,
    `ProvinceId` int NOT NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Cities_Provincies_ProvinceId` FOREIGN KEY (`ProvinceId`) REFERENCES `Provincies` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `RoomPictures` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` longtext NOT NULL,
    `RoomId` int NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_RoomPictures_Rooms_RoomId` FOREIGN KEY (`RoomId`) REFERENCES `Rooms` (`Id`)
);

CREATE INDEX `IX_Bookings_CheckInTimeId` ON `Bookings` (`CheckInTimeId`);

CREATE INDEX `IX_Bookings_UserId` ON `Bookings` (`UserId`);

CREATE INDEX `IX_Cities_ProvinceId` ON `Cities` (`ProvinceId`);

CREATE INDEX `IX_HotelPicture_HotelId` ON `HotelPicture` (`HotelId`);

CREATE INDEX `IX_Hotels_AddressHotelId` ON `Hotels` (`AddressHotelId`);

CREATE INDEX `IX_PreBooking_UserId1` ON `PreBooking` (`UserId1`);

CREATE INDEX `IX_Provincies_CountryId` ON `Provincies` (`CountryId`);

CREATE INDEX `IX_RoomPictures_RoomId` ON `RoomPictures` (`RoomId`);

CREATE INDEX `IX_Rooms_CostId` ON `Rooms` (`CostId`);

CREATE INDEX `IX_Rooms_HotelsId` ON `Rooms` (`HotelsId`);

CREATE INDEX `IX_Users_AddressId` ON `Users` (`AddressId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20240930005458_hotelis', '8.0.8');

COMMIT;

START TRANSACTION;

ALTER TABLE `Bookings` DROP COLUMN `IdUser`;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20240930012119_deleteUserId', '8.0.8');

COMMIT;

START TRANSACTION;

ALTER TABLE `Users` ADD `IdentityNumber` longtext NOT NULL;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20240930034731_userTableIdentity', '8.0.8');

COMMIT;

START TRANSACTION;

ALTER TABLE `Users` ADD `AccountActivate` tinyint(1) NOT NULL DEFAULT FALSE;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20241001031137_isvalidAccount', '8.0.8');

COMMIT;

START TRANSACTION;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20241002030854_docker', '8.0.8');

COMMIT;

INSERT INTO `hotelis`.`countries` (`Id`, `Name`) VALUES (5,'Argentina')

INSERT INTO `hotelis`.`provincies` (`Name`,`CountryId`)VALUES('Cordoba',5);
INSERT INTO `hotelis`.`provincies` (`Name`,`CountryId`)VALUES('Buenos Aires',5);
INSERT INTO `hotelis`.`provincies` (`Name`,`CountryId`)VALUES('Entre Rios',5);
INSERT INTO `hotelis`.`provincies` (`Name`,`CountryId`)VALUES('Misiones',5);
INSERT INTO `hotelis`.`provincies` (`Name`,`CountryId`)VALUES('Santa Fe',5);
INSERT INTO `hotelis`.`provincies` (`Name`,`CountryId`)VALUES('Mendoza',5);
INSERT INTO `hotelis`.`provincies` (`Name`,`CountryId`)VALUES('La Rioja',5);
INSERT INTO `hotelis`.`provincies` (`Name`,`CountryId`)VALUES('Santiago del Estero',5);

INSERT INTO `hotelis`.`cities`(`Name`,`ProvinceId`)VALUES('Cordoba',1);
INSERT INTO `hotelis`.`cities`(`Name`,`ProvinceId`)VALUES('Rio Cuarto',1);
INSERT INTO `hotelis`.`cities`(`Name`,`ProvinceId`)VALUES('Villa Maria',1);

INSERT INTO `hotelis`.`costs`(`CostPerTime`,`Hour`) VALUES(15000,8);
INSERT INTO `hotelis`.`costs`(`CostPerTime`,`Hour`) VALUES(10000,8);
INSERT INTO `hotelis`.`costs`(`CostPerTime`,`Hour`) VALUES(13000,6);
INSERT INTO `hotelis`.`costs`(`CostPerTime`,`Hour`) VALUES(12000,4);

INSERT INTO `hotelis`.`address`(`Street`,`Number`,`PostalCode`,`Latitud`,`Longitud`,`IdCity`)VALUES('Ruta 9 norte km 80','80','5010','54.0231031','40.903430',1);
INSERT INTO `hotelis`.`address`(`Street`,`Number`,`PostalCode`,`Latitud`,`Longitud`,`IdCity`)VALUES('Ruta 36 km 78','78','5010','54.0231031','40.903430',1);
INSERT INTO `hotelis`.`address`(`Street`,`Number`,`PostalCode`,`Latitud`,`Longitud`,`IdCity`)VALUES('Ruta 9 norte km 559','559','5010','54.0231031','40.903430',1);

INSERT INTO `hotelis`.`hotels`(`Name`,`Description`,`MetaDescription`,`AddressHotelId`,`Email`,`CodeArea`,`PhoneNumber`)VALUES( 'Peaje Cordoba Rosario','Hotel de 8 habitaciones en el peaje','Autopista Cordoba Rosario Km 400',1,'email@hotel.com',5010, 351010121);
INSERT INTO `hotelis`.`hotels`(`Name`,`Description`,`MetaDescription`,`AddressHotelId`,`Email`,`CodeArea`,`PhoneNumber`)VALUES( 'Peaje Cordoba Rosario','Hotel de 8 habitaciones en el peaje','Autopista Cordoba Rosario Km 400',2,'email@hotel.com',5010, 351010121);
INSERT INTO `hotelis`.`hotels`(`Name`,`Description`,`MetaDescription`,`AddressHotelId`,`Email`,`CodeArea`,`PhoneNumber`)VALUES( 'Peaje Cordoba Rosario','Hotel de 8 habitaciones en el peaje','Autopista Cordoba Rosario Km 400',3,'email@hotel.com',5010, 351010121);

INSERT INTO `hotelis`.`rooms`(`Name`,`Description`,`BedNumbers`,`AvialableNow`,`HotelsId`,`CostId`)VALUES('Habitacion 1','1 cama matrimonial, 2 camas una plaza',3,true,1,1);
INSERT INTO `hotelis`.`rooms`(`Name`,`Description`,`BedNumbers`,`AvialableNow`,`HotelsId`,`CostId`)VALUES('Habitacion 2','1 cama matrimonial, 2 camas una plaza',3,true,1,1);
INSERT INTO `hotelis`.`rooms`(`Name`,`Description`,`BedNumbers`,`AvialableNow`,`HotelsId`,`CostId`)VALUES('Habitacion 3','1 cama matrimonial, 2 camas una plaza',3,true,1,1);
INSERT INTO `hotelis`.`rooms`(`Name`,`Description`,`BedNumbers`,`AvialableNow`,`HotelsId`,`CostId`)VALUES('Habitacion 4','1 cama matrimonial',1,true,1,2);

INSERT INTO `hotelis`.`roompictures` (`Name`,`RoomId`)VALUES('https://www.google.com/url?sa=i&url=https%3A%2F%2Flistado.mercadolibre.com.ar%2Fcontenedores-habitables&psig=AOvVaw2eKfyG0B9MGt22mgnbfmR6&ust=1718888770730000&source=images&cd=vfe&opi=89978449&ved=0CBEQjRxqFwoTCOCU-Pzc54YDFQAAAAAdAAAAABAE',1);
INSERT INTO `hotelis`.`roompictures` (`Name`,`RoomId`)VALUES('https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.puntal.com.ar%2Fviviendas%2Fcontainers-habitables-n131504&psig=AOvVaw2eKfyG0B9MGt22mgnbfmR6&ust=1718888770730000&source=images&cd=vfe&opi=89978449&ved=0CBEQjRxqFwoTCOCU-Pzc54YDFQAAAAAdAAAAABAI',2);
INSERT INTO `hotelis`.`hotelpicture`(`Path`,`HotelId`)VALUES('https://http2.mlstatic.com/D_NQ_NP_717264-MLA71778184380_092023-O.webp',1);
INSERT INTO `hotelis`.`hotelpicture`(`Path`,`HotelId`)VALUES('https://http2.mlstatic.com/D_NQ_NP_717264-MLA71778184380_092023-O.webp',2);
INSERT INTO `hotelis`.`hotelpicture`(`Path`,`HotelId`)VALUES('https://http2.mlstatic.com/D_NQ_NP_717264-MLA71778184380_092023-O.webp',3);


update `hotelis`.`roompictures` set Name = 'https://http2.mlstatic.com/D_NQ_NP_717264-MLA71778184380_092023-O.webp' where Id in (1,2)

