-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Sep 17, 2019 at 04:39 AM
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
-- Database: `sales`
--

-- --------------------------------------------------------

--
-- Table structure for table `2019_07m`
--

DROP TABLE IF EXISTS `2019_07m`;
CREATE TABLE IF NOT EXISTS `2019_07m` (
  `monthly_id` varchar(10) NOT NULL,
  `id` int(5) NOT NULL,
  `item_name` varchar(50) NOT NULL,
  `brand_name` varchar(50) NOT NULL,
  `category` varchar(50) NOT NULL,
  `stock_sold` int(5) NOT NULL,
  `monthly_date` date NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `2019_07m`
--

INSERT INTO `2019_07m` (`monthly_id`, `id`, `item_name`, `brand_name`, `category`, `stock_sold`, `monthly_date`) VALUES
('2019_07m', 1, 'Nature\'s Own Omega-3', 'Nature\'s Own', 'vitamins', 131, '2019-07-01'),
('2019_07m', 2, 'Cenovis colds and immunity', 'cenovis', 'vitamins', 162, '2019-07-01'),
('2019_07m', 3, 'blackmores brain health', 'blackmores', 'vitamins', 98, '2019-07-01'),
('2019_07m', 4, 'optislim vlcd shakes', 'optislim', 'weight loss', 89, '2019-07-01'),
('2019_07m', 5, 'band-aid clear', 'band-aid', 'first aid', 227, '2019-07-01'),
('2019_07m', 6, 'nicorette gum', 'nicorette', 'smoking deterrents', 154, '2019-07-01'),
('2019_07m', 7, 'dulcolax tablets', 'dulcolax', 'laxatives', 98, '2019-07-01'),
('2019_07m', 8, 'nurofen fast pain relief', 'nurofen', 'medicines', 417, '2019-07-01'),
('2019_07m', 9, 'panadol optizorb', 'panadol', 'medicines', 401, '2019-07-01');

-- --------------------------------------------------------

--
-- Table structure for table `2019_08m`
--

DROP TABLE IF EXISTS `2019_08m`;
CREATE TABLE IF NOT EXISTS `2019_08m` (
  `monthly_id` varchar(10) NOT NULL,
  `id` int(5) NOT NULL,
  `item_name` varchar(50) NOT NULL,
  `brand_name` varchar(50) NOT NULL,
  `category` varchar(50) NOT NULL,
  `stock_sold` int(5) NOT NULL,
  `monthly_date` date NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `2019_08m`
--

INSERT INTO `2019_08m` (`monthly_id`, `id`, `item_name`, `brand_name`, `category`, `stock_sold`, `monthly_date`) VALUES
('2019_08m', 1, 'Nature\'s Own Omega-3', 'Nature\'s Own', 'vitamins', 121, '2019-08-01'),
('2019_08m', 2, 'Cenovis colds and immunity', 'cenovis', 'vitamins', 154, '2019-08-01'),
('2019_08m', 3, 'blackmores brain health', 'blackmores', 'vitamins', 87, '2019-08-01'),
('2019_08m', 4, 'optislim vlcd shakes', 'optislim', 'weight loss', 103, '2019-08-01'),
('2019_08m', 5, 'band-aid clear', 'band-aid', 'first aid', 210, '2019-08-01'),
('2019_08m', 6, 'nicorette gum', 'nicorette', 'smoking deterrents', 164, '2019-08-01'),
('2019_08m', 7, 'dulcolax tablets', 'dulcolax', 'laxatives', 102, '2019-08-01'),
('2019_08m', 8, 'nurofen fast pain relief', 'nurofen', 'medicines', 376, '2019-08-01'),
('2019_08m', 9, 'panadol optizorb', 'panadol', 'medicines', 356, '2019-08-01');

-- --------------------------------------------------------

--
-- Table structure for table `2019_34w`
--

DROP TABLE IF EXISTS `2019_34w`;
CREATE TABLE IF NOT EXISTS `2019_34w` (
  `week_id` varchar(10) NOT NULL,
  `id` int(5) NOT NULL,
  `item_name` varchar(50) NOT NULL,
  `brand_name` varchar(50) NOT NULL,
  `category` varchar(50) NOT NULL,
  `stock_sold` int(5) NOT NULL,
  `week_date` date NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `2019_34w`
--

INSERT INTO `2019_34w` (`week_id`, `id`, `item_name`, `brand_name`, `category`, `stock_sold`, `week_date`) VALUES
('2019_34w', 1, 'Nature\'s Own Omega-3', 'Nature\'s Own', 'vitamins', 32, '2019-08-19'),
('2019_34w', 2, 'Cenovis colds and immunity', 'cenovis', 'vitamins', 33, '2019-08-19'),
('2019_34w', 3, 'blackmores brain health', 'blackmores', 'vitamins', 43, '2019-08-19'),
('2019_34w', 4, 'optislim vlcd shakes', 'optislim', 'weight loss', 19, '2019-08-19'),
('2019_34w', 5, 'band-aid clear', 'band-aid', 'first aid', 64, '2019-08-19'),
('2019_34w', 6, 'nicorette gum', 'nicorette', 'smoking deterrents', 43, '2019-08-19'),
('2019_34w', 7, 'dulcolax tablets', 'dulcolax', 'laxatives', 22, '2019-08-19'),
('2019_34w', 8, 'nurofen fast pain relief', 'nurofen', 'medicines', 89, '2019-08-19'),
('2019_34w', 9, 'panadol optizorb', 'panadol', 'medicines', 95, '2019-08-19');

-- --------------------------------------------------------

--
-- Table structure for table `2019_35w`
--

DROP TABLE IF EXISTS `2019_35w`;
CREATE TABLE IF NOT EXISTS `2019_35w` (
  `week_id` varchar(10) NOT NULL,
  `id` int(5) NOT NULL,
  `item_name` varchar(50) NOT NULL,
  `brand_name` varchar(50) NOT NULL,
  `category` varchar(50) NOT NULL,
  `stock_sold` int(5) NOT NULL,
  `week_date` date NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `2019_35w`
--

INSERT INTO `2019_35w` (`week_id`, `id`, `item_name`, `brand_name`, `category`, `stock_sold`, `week_date`) VALUES
('2019_35w', 1, 'Nature\'s Own Omega-3', 'Nature\'s Own', 'vitamins', 34, '2019-08-26'),
('2019_35w', 2, 'Cenovis colds and immunity', 'cenovis', 'vitamins', 63, '2019-08-26'),
('2019_35w', 3, 'blackmores brain health', 'blackmores', 'vitamins', 16, '2019-08-26'),
('2019_35w', 4, 'optislim vlcd shakes', 'optislim', 'weight loss', 13, '2019-08-26'),
('2019_35w', 5, 'band-aid clear', 'band-aid', 'first aid', 76, '2019-08-26'),
('2019_35w', 6, 'nicorette gum', 'nicorette', 'smoking deterrents', 54, '2019-08-26'),
('2019_35w', 7, 'dulcolax tablets', 'dulcolax', 'laxatives', 40, '2019-08-26'),
('2019_35w', 8, 'nurofen fast pain relief', 'nurofen', 'medicines', 99, '2019-08-26'),
('2019_35w', 9, 'panadol optizorb', 'panadol', 'medicines', 111, '2019-08-26');

-- --------------------------------------------------------

--
-- Table structure for table `2019_36w`
--

DROP TABLE IF EXISTS `2019_36w`;
CREATE TABLE IF NOT EXISTS `2019_36w` (
  `week_id` varchar(10) NOT NULL,
  `id` int(5) NOT NULL,
  `item_name` varchar(50) NOT NULL,
  `brand_name` varchar(50) NOT NULL,
  `category` varchar(50) NOT NULL,
  `stock_sold` int(5) NOT NULL,
  `week_date` date NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `2019_36w`
--

INSERT INTO `2019_36w` (`week_id`, `id`, `item_name`, `brand_name`, `category`, `stock_sold`, `week_date`) VALUES
('2019_36w', 1, 'Nature\'s Own Omega-3', 'Nature\'s Own', 'vitamins', 34, '2019-09-02'),
('2019_36w', 2, 'Cenovis colds and immunity', 'cenovis', 'vitamins', 40, '2019-09-02'),
('2019_36w', 3, 'blackmores brain health', 'blackmores', 'vitamins', 43, '2019-09-02'),
('2019_36w', 4, 'optislim vlcd shakes', 'optislim', 'weight loss', 23, '2019-09-02'),
('2019_36w', 5, 'band-aid clear', 'band-aid', 'first aid', 76, '2019-09-02'),
('2019_36w', 6, 'nicorette gum', 'nicorette', 'smoking deterrents', 48, '2019-09-02'),
('2019_36w', 7, 'dulcolax tablets', 'dulcolax', 'laxatives', 32, '2019-09-02'),
('2019_36w', 8, 'nurofen fast pain relief', 'nurofen', 'medicines', 90, '2019-09-02'),
('2019_36w', 9, 'panadol optizorb', 'panadol', 'medicines', 89, '2019-09-02');

-- --------------------------------------------------------

--
-- Table structure for table `2019_37w`
--

DROP TABLE IF EXISTS `2019_37w`;
CREATE TABLE IF NOT EXISTS `2019_37w` (
  `week_id` varchar(10) NOT NULL,
  `id` int(5) NOT NULL,
  `item_name` varchar(50) NOT NULL,
  `brand_name` varchar(50) NOT NULL,
  `category` varchar(50) NOT NULL,
  `stock_sold` int(5) NOT NULL,
  `week_date` date NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `2019_37w`
--

INSERT INTO `2019_37w` (`week_id`, `id`, `item_name`, `brand_name`, `category`, `stock_sold`, `week_date`) VALUES
('2019_37w', 1, 'Nature\'s Own Omega-3', 'Nature\'s Own', 'vitamins', 40, '2019-09-09'),
('2019_37w', 2, 'Cenovis colds and immunity', 'cenovis', 'vitamins', 20, '2019-09-09'),
('2019_37w', 3, 'blackmores brain health', 'blackmores', 'vitamins', 52, '2019-09-09'),
('2019_37w', 4, 'optislim vlcd shakes', 'optislim', 'weight loss', 11, '2019-09-09'),
('2019_37w', 5, 'band-aid clear', 'band-aid', 'first aid', 70, '2019-09-09'),
('2019_37w', 6, 'nicorette gum', 'nicorette', 'smoking deterrents', 39, '2019-09-09'),
('2019_37w', 7, 'dulcolax tablets', 'dulcolax', 'laxatives', 23, '2019-09-09'),
('2019_37w', 8, 'nurofen fast pain relief', 'nurofen', 'medicines', 123, '2019-09-09'),
('2019_37w', 9, 'panadol optizorb', 'panadol', 'medicines', 98, '2019-09-09');

-- --------------------------------------------------------

--
-- Table structure for table `current_sales`
--

DROP TABLE IF EXISTS `current_sales`;
CREATE TABLE IF NOT EXISTS `current_sales` (
  `id` int(5) DEFAULT NULL,
  `item_name` varchar(50) NOT NULL,
  `brand_name` varchar(50) NOT NULL,
  `category` varchar(50) NOT NULL,
  `current_stock` int(4) NOT NULL,
  `sold_stock` int(4) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `current_sales`
--

INSERT INTO `current_sales` (`id`, `item_name`, `brand_name`, `category`, `current_stock`, `sold_stock`) VALUES
(1, 'Nature\'s Own Omega-3', 'Nature\'s Own', 'vitamins', 29, 15),
(2, 'Cenovis colds and immunity', 'cenovis', 'vitamins', 20, 25),
(3, 'blackmores brain health', 'blackmores', 'vitamins', 3, 50),
(4, 'optislim vlcd shakes', 'optislim', 'weight loss', 20, 25),
(5, 'band-aid clear', 'band-aid', 'first aid', 30, 100),
(6, 'nicorette gum', 'nicorette', 'smoking deterrents', 4, 46),
(7, 'dulcolax tablets', 'dulcolax', 'laxatives', 20, 4),
(8, 'nurofen fast pain relief', 'nurofen', 'medicines', 20, 65),
(9, 'panadol optizorb', 'panadol', 'medicines', 12, 33);

-- --------------------------------------------------------

--
-- Table structure for table `monthly_index`
--

DROP TABLE IF EXISTS `monthly_index`;
CREATE TABLE IF NOT EXISTS `monthly_index` (
  `monthly_id` varchar(10) NOT NULL,
  `month_date` date NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `monthly_index`
--

INSERT INTO `monthly_index` (`monthly_id`, `month_date`) VALUES
('2019_07m', '2019-07-01'),
('2019_08m', '2019-08-01');

-- --------------------------------------------------------

--
-- Table structure for table `weekly_index`
--

DROP TABLE IF EXISTS `weekly_index`;
CREATE TABLE IF NOT EXISTS `weekly_index` (
  `week_id` varchar(10) NOT NULL,
  `week_date` date NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `weekly_index`
--

INSERT INTO `weekly_index` (`week_id`, `week_date`) VALUES
('2019_35w', '2019-08-26'),
('2019_36w', '2019-09-02'),
('2019_37w', '2019-09-09'),
('2019_34w', '2019-08-19');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

