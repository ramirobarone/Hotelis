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

