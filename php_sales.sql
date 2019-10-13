-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Oct 08, 2019 at 08:35 AM
-- Server version: 5.7.26
-- PHP Version: 7.2.18

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `php_sales`
--

-- --------------------------------------------------------

--
-- Table structure for table `2019_07m`
--

DROP TABLE IF EXISTS `2019_07m`;
CREATE TABLE IF NOT EXISTS `2019_07m` (
  `monthly_id` varchar(255) NOT NULL,
  `Order_No` int(11) NOT NULL,
  `id` int(5) NOT NULL,
  `item_name` varchar(255) NOT NULL,
  `brand_name` varchar(255) NOT NULL,
  `category` varchar(50) NOT NULL,
  `sale` int(5) NOT NULL,
  `sale_date` date NOT NULL,
  PRIMARY KEY (`Order_No`),
  KEY `monthly_id` (`monthly_id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `2019_07m`
--

INSERT INTO `2019_07m` (`monthly_id`, `Order_No`, `id`, `item_name`, `brand_name`, `category`, `sale`,`sale_date`) VALUES
('2019_07M', 1, 4, 'Nature\'s Own Omega-3', 'Nature\'s Own', 'vitamins', 131,'2019-07-01'),
('2019_07M', 2, 74, 'Cenovis colds and immunity', 'cenovis', 'vitamins', 162,'2019-07-03'),
('2019_07M', 3, 32, 'blackmores brain health', 'blackmores', 'vitamins', 98,'2019-07-04'),
('2019_07M', 4, 22, 'optislim vlcd shakes', 'optislim', 'weight loss', 89,'2019-07-06'),
('2019_07M', 5, 4, 'band-aid clear', 'band-aid', 'first aid', 227,'2019-07-08'),
('2019_07M', 6, 11, 'nicorette gum', 'nicorette', 'smoking deterrents', 154,'2019-07-11'),
('2019_07M', 7, 41, 'dulcolax tablets', 'dulcolax', 'laxatives', 98,'2019-07-21'),
('2019_07M', 8, 13, 'nurofen fast pain relief', 'nurofen', 'medicines', 417,'2019-07-21'),
('2019_07M', 9, 44, 'panadol optizorb', 'panadol', 'medicines', 401,'2019-07-24');

-- --------------------------------------------------------

--
-- Table structure for table `2019_08m`
--

DROP TABLE IF EXISTS `2019_08m`;
CREATE TABLE IF NOT EXISTS `2019_08m` (
  `monthly_id` varchar(255) NOT NULL,
  `Order_No` int(11) NOT NULL,
  `id` int(5) NOT NULL,
  `item_name` varchar(255) NOT NULL,
  `brand_name` varchar(255) NOT NULL,
  `category` varchar(50) NOT NULL,
  `sale` int(5) NOT NULL,
  `sale_date` date NOT NULL,
  PRIMARY KEY (`Order_No`),
  KEY `monthly_id` (`monthly_id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `2019_08m`
--

INSERT INTO `2019_08m` (`monthly_id`, `Order_No`, `id`, `item_name`, `brand_name`, `category`, `sale`, `sale_date`) VALUES
('2019_08M', 1, 4, 'Nature\'s Own Omega-3', 'Nature\'s Own', 'vitamins', 121,'2019-08-01'),
('2019_08M', 2, 74, 'Cenovis colds and immunity', 'cenovis', 'vitamins', 172,'2019-08-04'),
('2019_08M', 3, 32, 'blackmores brain health', 'blackmores', 'vitamins', 198,'2019-08-04'),
('2019_08M', 4, 22, 'optislim vlcd shakes', 'optislim', 'weight loss', 59,'2019-08-08'),
('2019_08M', 5, 4, 'band-aid clear', 'band-aid', 'first aid', 207,'2019-08-09'),
('2019_08M', 6, 11, 'nicorette gum', 'nicorette', 'smoking deterrents', 184,'2019-08-11'),
('2019_08M', 7, 41, 'dulcolax tablets', 'dulcolax', 'laxatives', 92,'2019-08-14'),
('2019_08M', 8, 13, 'nurofen fast pain relief', 'nurofen', 'medicines', 427,'2019-08-21'),
('2019_08M', 9, 44, 'panadol optizorb', 'panadol', 'medicines', 409,'2019-08-22');

-- --------------------------------------------------------

--
-- Table structure for table `2019_34w`
--

DROP TABLE IF EXISTS `2019_34w`;
CREATE TABLE IF NOT EXISTS `2019_34w` (
  `week_id` varchar(255) NOT NULL,
  `Order_No` int(11) NOT NULL,
  `id` int(11) NOT NULL,
  `item_name` varchar(255) NOT NULL,
  `brand_name` varchar(255) NOT NULL,
  `category` varchar(50) NOT NULL,
  `sale` int(11) NOT NULL,
  `sale_date` date NOT NULL,
  PRIMARY KEY (`Order_No`),
  KEY `week_id` (`week_id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `2019_34w`
--

INSERT INTO `2019_34w` (`week_id`, `Order_No`, `id`, `item_name`, `brand_name`, `category`, `sale`, `sale_date`) VALUES
('2019_34W', 1, 4, 'Nature\'s Own Omega-3', 'Nature\'s Own', 'vitamins', 32,'2019-08-19'),
('2019_34W', 2, 74, 'Cenovis colds and immunity', 'cenovis', 'vitamins', 33,'2019-08-19'),
('2019_34W', 3, 32, 'blackmores brain health', 'blackmores', 'vitamins', 43,'2019-08-20'),
('2019_34W', 4, 22, 'optislim vlcd shakes', 'optislim', 'weight loss', 19,'2019-08-21'),
('2019_34W', 5, 4, 'band-aid clear', 'band-aid', 'first aid', 64,'2019-08-21'),
('2019_34W', 6, 11, 'nicorette gum', 'nicorette', 'smoking deterrents', 43,'2019-08-23'),
('2019_34W', 7, 41, 'dulcolax tablets', 'dulcolax', 'laxatives', 22,'2019-08-23'),
('2019_34W', 8, 13, 'nurofen fast pain relief', 'nurofen', 'medicines', 89,'2019-08-24'),
('2019_34W', 9, 44, 'panadol optizorb', 'panadol', 'medicines', 95,'2019-08-24');

-- --------------------------------------------------------

--
-- Table structure for table `2019_35w`
--

DROP TABLE IF EXISTS `2019_35w`;
CREATE TABLE IF NOT EXISTS `2019_35w` (
  `week_id` varchar(255) DEFAULT NULL,
  `Order_No` int(11) NOT NULL,
  `id` int(11) NOT NULL,
  `item_name` varchar(255) DEFAULT NULL,
  `brand_name` varchar(255) DEFAULT NULL,
  `category` varchar(50) NOT NULL,
  `sale` int(11) DEFAULT NULL,
  `sale_date` date NOT NULL,
  PRIMARY KEY (`Order_No`),
  KEY `week_id` (`week_id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `2019_35w`
--

INSERT INTO `2019_35w` (`week_id`, `Order_No`, `id`, `item_name`, `brand_name`, `category`, `sale`, `sale_date`) VALUES
('2019_35W', 1, 4, 'Nature\'s Own Omega-3', 'Nature\'s Own', 'vitamins', 34,'2019-08-26'),
('2019_35W', 2, 74, 'Cenovis colds and immunity', 'cenovis', 'vitamins', 63,'2019-08-26'),
('2019_35W', 3, 32, 'blackmores brain health', 'blackmores', 'vitamins', 16,'2019-08-27'),
('2019_35W', 4, 22, 'optislim vlcd shakes', 'optislim', 'weight loss', 13,'2019-08-28'),
('2019_35W', 5, 4, 'band-aid clear', 'band-aid', 'first aid', 76,'2019-08-29'),
('2019_35W', 6, 11, 'nicorette gum', 'nicorette', 'smoking deterrents', 54,'2019-09-01'),
('2019_35W', 7, 41, 'dulcolax tablets', 'dulcolax', 'laxatives', 40,'2019-09-01'),
('2019_35W', 8, 13, 'nurofen fast pain relief', 'nurofen', 'medicines', 99,'2019-09-01'),
('2019_35W', 9, 44, 'panadol optizorb', 'panadol', 'medicines', 111,'2019-09-01');

-- --------------------------------------------------------

--
-- Table structure for table `2019_36w`
--

DROP TABLE IF EXISTS `2019_36w`;
CREATE TABLE IF NOT EXISTS `2019_36w` (
  `week_id` varchar(255) DEFAULT NULL,
  `Order_No` int(11) NOT NULL,
  `id` int(11) NOT NULL,
  `item_name` varchar(255) DEFAULT NULL,
  `brand_name` varchar(255) DEFAULT NULL,
  `category` varchar(50) NOT NULL,
  `sale` int(11) DEFAULT NULL,
  `sale_date` date NOT NULL,
  PRIMARY KEY (`Order_No`),
  KEY `week_id` (`week_id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `2019_36w`
--

INSERT INTO `2019_36w` (`week_id`, `Order_No`, `id`, `item_name`, `brand_name`, `category`, `sale`, `sale_date`) VALUES
('2019_36W', 1, 4, 'Nature\'s Own Omega-3', 'Nature\'s Own', 'vitamins', 40,'2019-09-02'),
('2019_36W', 2, 74, 'Cenovis colds and immunity', 'cenovis', 'vitamins', 20,'2019-09-02'),
('2019_36W', 3, 32, 'blackmores brain health', 'blackmores', 'vitamins', 52,'2019-09-04'),
('2019_36W', 4, 22, 'optislim vlcd shakes', 'optislim', 'weight loss', 11,'2019-09-05'),
('2019_36W', 5, 4, 'band-aid clear', 'band-aid', 'first aid', 70,'2019-09-06'),
('2019_36W', 6, 11, 'nicorette gum', 'nicorette', 'smoking deterrents', 39,'2019-09-07'),
('2019_36W', 7, 41, 'dulcolax tablets', 'dulcolax', 'laxatives', 23,'2019-09-07'),
('2019_36W', 8, 13, 'nurofen fast pain relief', 'nurofen', 'medicines', 123,'2019-09-08'),
('2019_36W', 9, 44, 'panadol optizorb', 'panadol', 'medicines', 98,'2019-09-08');

-- --------------------------------------------------------

--
-- Table structure for table `2019_37w`
--

DROP TABLE IF EXISTS `2019_37w`;
CREATE TABLE IF NOT EXISTS `2019_37w` (
  `week_id` varchar(255) DEFAULT NULL,
  `Order_No` int(11) NOT NULL,
  `id` int(11) NOT NULL,
  `item_name` varchar(255) DEFAULT NULL,
  `brand_name` varchar(255) DEFAULT NULL,
  `category` varchar(50) NOT NULL,
  `sale` int(11) DEFAULT NULL,
  `sale_date` date NOT NULL,
  PRIMARY KEY (`Order_No`),
  KEY `week_id` (`week_id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `2019_37w`
--

INSERT INTO `2019_37w` (`week_id`, `Order_No`, `id`, `item_name`, `brand_name`, `category`, `sale`, `sale_date`) VALUES
('2019_37W', 1, 4, 'Nature\'s Own Omega-3', 'Nature\'s Own', 'vitamins', 32,'2019-09-09'),
('2019_37W', 2, 74, 'Cenovis colds and immunity', 'cenovis', 'vitamins', 33,'2019-09-10'),
('2019_37W', 3, 32, 'blackmores brain health', 'blackmores', 'vitamins', 43,'2019-09-11'),
('2019_37W', 4, 22, 'optislim vlcd shakes', 'optislim', 'weight loss', 19,'2019-09-11'),
('2019_37W', 5, 4, 'band-aid clear', 'band-aid', 'first aid', 64,'2019-09-11'),
('2019_37W', 6, 11, 'nicorette gum', 'nicorette', 'smoking deterrents', 43,'2019-09-12'),
('2019_37W', 7, 41, 'dulcolax tablets', 'dulcolax', 'laxatives', 22,'2019-09-12'),
('2019_37W', 8, 13, 'nurofen fast pain relief', 'nurofen', 'medicines', 89,'2019-09-13'),
('2019_37W', 9, 44, 'panadol optizorb', 'panadol', 'medicines', 95,'2019-09-14');

-- --------------------------------------------------------

--
-- Table structure for table `current_sales`
--

DROP TABLE IF EXISTS `current_sales`;
CREATE TABLE IF NOT EXISTS `current_sales` (
  `Order_No` int(11) NOT NULL AUTO_INCREMENT,
  `id` int(5) NOT NULL,
  `item_name` varchar(255) NOT NULL,
  `brand_name` varchar(255) NOT NULL,
  `category` varchar(50) NOT NULL,
  `sale` int(11) NOT NULL,
  `sale_date` date NOT NULL,
  PRIMARY KEY (`Order_No`)
) ENGINE=MyISAM AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `current_sales`
--

INSERT INTO `current_sales` (`Order_No`, `id`, `item_name`, `brand_name`, `category`, `sale`, `sale_date`) VALUES
(1, 4, 'Nature\'s Own Omega-3', 'Nature\'s Own', 'vitamins', 15,'2019-09-16'),
(2, 74, 'Cenovis colds and immunity', 'cenovis', 'vitamins', 25,'2019-09-16'),
(3, 32, 'blackmores brain health', 'blackmores', 'vitamins', 50,'2019-09-18'),
(4, 22, 'optislim vlcd shakes', 'optislim', 'weight loss', 25,'2019-09-19'),
(5, 4, 'band-aid clear', 'band-aid', 'first aid', 100,'2019-09-19'),
(6, 11, 'nicorette gum', 'nicorette', 'smoking deterrents', 46,'2019-09-19'),
(7, 41, 'dulcolax tablets', 'dulcolax', 'laxatives', 4,'2019-09-01'),
(8, 13, 'nurofen fast pain relief', 'nurofen', 'medicines', 65,'2019-09-19'),
(9, 44, 'panadol optizorb', 'panadol', 'medicines', 33,'2019-09-20');

-- --------------------------------------------------------

--
-- Table structure for table `monthly_index`
--

DROP TABLE IF EXISTS `monthly_index`;
CREATE TABLE IF NOT EXISTS `monthly_index` (
  `monthly_id` varchar(255) NOT NULL,
  `month_date` date NOT NULL,
  PRIMARY KEY (`monthly_id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `monthly_index`
--

INSERT INTO `monthly_index` (`monthly_id`, `month_date`) VALUES
('2019_07M', '2019-07-01'),
('2019_08M', '2019-08-01');

-- --------------------------------------------------------

--
-- Table structure for table `weekly_index`
--

DROP TABLE IF EXISTS `weekly_index`;
CREATE TABLE IF NOT EXISTS `weekly_index` (
  `week_id` varchar(255) NOT NULL,
  `week_date` date NOT NULL,
  PRIMARY KEY (`week_id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `weekly_index`
--

INSERT INTO `weekly_index` (`week_id`, `week_date`) VALUES
('2019_35W', '2019-08-26'),
('2019_36W', '2019-09-02'),
('2019_37W', '2019-09-09'),
('2019_34W', '2019-08-19');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
