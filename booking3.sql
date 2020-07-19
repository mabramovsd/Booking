-- phpMyAdmin SQL Dump
-- version 3.5.1
-- http://www.phpmyadmin.net
--
-- Хост: 127.0.0.1
-- Время создания: Июл 05 2020 г., 12:29
-- Версия сервера: 5.5.25
-- Версия PHP: 5.6.19

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- База данных: `booking3`
--

-- --------------------------------------------------------

--
-- Структура таблицы `booking`
--

CREATE TABLE IF NOT EXISTS `booking` (
  `user` varchar(60) NOT NULL,
  `dateFrom` date NOT NULL,
  `dateTo` date NOT NULL,
  `Status` varchar(10) NOT NULL,
  `room_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `booking`
--

INSERT INTO `booking` (`user`, `dateFrom`, `dateTo`, `Status`, `room_id`) VALUES
('Mikhail', '2020-06-04', '2020-06-19', 'Оплачено', 1),
('Mikhail', '2020-06-18', '2020-06-25', 'Ожидание', 2),
('Theo', '2020-06-03', '2020-06-03', 'Оплачено', 4),
('Theo', '2020-06-03', '2020-06-03', 'Ожидание', 6),
('Mikki', '2020-06-12', '2020-06-27', '', 2),
('Mikki', '2020-06-12', '2020-06-27', '', 2),
('Mikki', '2020-06-28', '2020-06-30', '', 2);

-- --------------------------------------------------------

--
-- Структура таблицы `cities`
--

CREATE TABLE IF NOT EXISTS `cities` (
  `Name` varchar(200) NOT NULL,
  `Latitude` float NOT NULL,
  `Longitude` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `cities`
--

INSERT INTO `cities` (`Name`, `Latitude`, `Longitude`) VALUES
('Новокуйбышевск', 53.1, 49.92),
('Красноярск', 56.01, 92.86),
('Ульяновск', 54.31, 48.39),
('Самара', 53.23, 50.19),
('Москва', 55.7522, 37.6156);

-- --------------------------------------------------------

--
-- Структура таблицы `defaultdesign`
--

CREATE TABLE IF NOT EXISTS `defaultdesign` (
  `Type` varchar(60) NOT NULL,
  `Parameter` varchar(60) NOT NULL,
  `Value` varchar(60) NOT NULL,
  PRIMARY KEY (`Type`,`Parameter`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `defaultdesign`
--

INSERT INTO `defaultdesign` (`Type`, `Parameter`, `Value`) VALUES
('System.Windows.Forms.Button', 'COLOR', '-279049'),
('System.Windows.Forms.Button', 'FONT', 'Arial Narrow;12'),
('System.Windows.Forms.Button', 'FONT_COLOR', '-16777216'),
('System.Windows.Forms.Button', 'LAYOUT', 'Stretch');

-- --------------------------------------------------------

--
-- Структура таблицы `hotels`
--

CREATE TABLE IF NOT EXISTS `hotels` (
  `Name` varchar(200) NOT NULL,
  `City` varchar(60) NOT NULL,
  `Rating` int(11) NOT NULL,
  `Image` varchar(400) NOT NULL,
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Description` varchar(2000) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID` (`ID`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=6 ;

--
-- Дамп данных таблицы `hotels`
--

INSERT INTO `hotels` (`Name`, `City`, `Rating`, `Image`, `ID`, `Description`) VALUES
('Гостиница "Апрель"', 'Хабаровск', 4, '093475.jpg', 1, ''),
('Гостиница "Советская"', 'Красноярск', 5, '875875.jpg', 2, 'Вытравили всех тараканов\r\nи счастливы!\r\nЗаходи к нам:)'),
('Хостел "Так надо"', 'Ульяновск', 3, '16849602.jpg', 3, 'Чтоб я так жил'),
('Хостел "Среда"', 'Красноярск', 5, 'YdTOeaWm.jpg', 4, ''),
('Хостел "Четверг"', 'Новокуйбышевск', 3, '332436-2_enl.jpg', 5, '');

-- --------------------------------------------------------

--
-- Структура таблицы `rating`
--

CREATE TABLE IF NOT EXISTS `rating` (
  `User` varchar(60) NOT NULL,
  `Hotel_ID` int(11) NOT NULL,
  `Rate` int(11) NOT NULL,
  `Comment` varchar(2000) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `rating`
--

INSERT INTO `rating` (`User`, `Hotel_ID`, `Rate`, `Comment`) VALUES
('Mikki', 3, 8, 'Норм место'),
('Mikki', 1, 0, 'Владелец - гамадрил'),
('Mikki', 1, 0, ''),
('Mikki', 3, 9, 'Меня тут напоила клофелинщица');

-- --------------------------------------------------------

--
-- Структура таблицы `room`
--

CREATE TABLE IF NOT EXISTS `room` (
  `Hotel` varchar(60) NOT NULL,
  `Name` varchar(60) NOT NULL,
  `Price` int(11) NOT NULL,
  `Image` varchar(400) NOT NULL,
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `hotel_id` int(11) NOT NULL,
  `Quantity` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=8 ;

--
-- Дамп данных таблицы `room`
--

INSERT INTO `room` (`Hotel`, `Name`, `Price`, `Image`, `ID`, `hotel_id`, `Quantity`) VALUES
('Гостиница "Апрель"', 'Одноместный номер', 1800, '1-Seat.jpeg', 1, 1, 6),
('Гостиница "Апрель"', 'Двухместный номер', 2700, '2-Seat.jpg', 2, 1, 1),
('Гостиница "Советская"', 'Одноместный номер', 4400, '1-Seat.jpeg', 4, 2, 8),
('Гостиница "Советская"', 'Двухместный номер', 6400, '2-Seat.jpg', 5, 2, 12),
('Хостел "Так надо" ', 'Номер в бараке', 500, '1-Seat.jpeg', 6, 3, 1),
('Хостел "Так надо" ', 'Номер в элитном бараке', 600, '2-Seat.jpg', 7, 3, 1);

-- --------------------------------------------------------

--
-- Структура таблицы `uniquedesign`
--

CREATE TABLE IF NOT EXISTS `uniquedesign` (
  `Type` varchar(60) NOT NULL,
  `Name` varchar(60) NOT NULL,
  `Form` varchar(60) NOT NULL,
  `Parameter` varchar(60) NOT NULL,
  `Value` varchar(60) NOT NULL,
  PRIMARY KEY (`Type`,`Parameter`,`Name`,`Form`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `uniquedesign`
--

INSERT INTO `uniquedesign` (`Type`, `Name`, `Form`, `Parameter`, `Value`) VALUES
('System.Windows.Forms.Button', 'buttonDefaultDesign', 'MainForm', 'ADMIN', '1'),
('System.Windows.Forms.Button', 'LoginButton', 'MainForm', 'COLOR', '-65536'),
('System.Windows.Forms.Button', 'buttonDefaultDesign', 'MainForm', 'FONT', 'Arial Rounded MT Bold;14,25'),
('System.Windows.Forms.Button', 'buttonDefaultDesign', 'MainForm', 'FONT_COLOR', '-16777216'),
('System.Windows.Forms.Button', 'buttonDefaultDesign', 'MainForm', 'LAYOUT', 'Zoom'),
('System.Windows.Forms.Button', 'LoginButton', 'MainForm', 'LOCATION', '420, 0'),
('System.Windows.Forms.Button', 'buttonDefaultDesign', 'MainForm', 'PICTURE_ADDRESS', 'Like.jpg'),
('System.Windows.Forms.Button', 'LoginButton', 'MainForm', 'SIZE', '84, 35');

-- --------------------------------------------------------

--
-- Структура таблицы `users`
--

CREATE TABLE IF NOT EXISTS `users` (
  `Name` varchar(50) NOT NULL,
  `City` varchar(50) NOT NULL,
  `Age` int(11) NOT NULL,
  `Login` varchar(60) NOT NULL,
  `Password` varchar(60) NOT NULL,
  `Admin` char(1) NOT NULL,
  PRIMARY KEY (`Login`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `users`
--

INSERT INTO `users` (`Name`, `City`, `Age`, `Login`, `Password`, `Admin`) VALUES
('Федор', 'Саратов', 6, '1', '', ''),
('Миша', 'Москва', 35, '22', '1', ''),
('Миша', 'Москва', 31, '3', '', ''),
('Миша', 'Ульяновск', 31, 'Mikhail', '', ''),
('Миша', 'Москва', 31, 'Mikki', '123', '1'),
('Миша', 'Москва', 31, 'Mikki1', '', ''),
('Федор', 'Саратов', 6, 'Teo', '456', ''),
('Федор', 'Ульяновск', 6, 'Teo2', '', ''),
('Федор', 'Ульяновск', 6, 'Theo', '', '');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
