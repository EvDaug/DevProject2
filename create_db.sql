-- phpMyAdmin SQL Dump
-- version 4.6.6deb5
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Oct 22, 2019 at 08:54 AM
-- Server version: 5.7.27-0ubuntu0.18.04.1
-- PHP Version: 7.2.19-0ubuntu0.18.04.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `big_pharma`
--

-- --------------------------------------------------------

--
-- Table structure for table `current_sales`
--

CREATE TABLE `current_sales` (
  `order_no` int(11) NOT NULL,
  `product_id` int(5) NOT NULL,
  `sale_datetime` datetime NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `current_sales`
--

INSERT INTO `current_sales` (`order_no`, `product_id`, `sale_datetime`) VALUES
(1, 34, '2019-09-16 09:20:00'),
(2, 74, '2019-09-16 09:20:00'),
(3, 34, '2019-09-16 09:20:00'),
(4, 22, '2019-09-16 10:30:00'),
(5, 4, '2019-09-16 10:30:00'),
(6, 22, '2019-09-16 10:32:00'),
(17, 44, '2019-10-22 12:16:01'),
(8, 13, '2019-09-19 11:11:00'),
(9, 44, '2019-09-20 12:30:00'),
(10, 34, '2019-09-19 11:11:00'),
(11, 34, '2019-10-21 15:06:17'),
(12, 44, '2019-10-21 15:06:28'),
(13, 32, '2019-10-21 09:56:02'),
(14, 44, '2019-10-21 10:23:23'),
(15, 13, '2019-10-21 10:24:02'),
(19, 44, '2019-10-22 08:49:12');

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE `products` (
  `product_id` int(10) NOT NULL,
  `item_name` varchar(255) NOT NULL,
  `brand_name` varchar(100) NOT NULL,
  `category` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`product_id`, `item_name`, `brand_name`, `category`) VALUES
(4, 'band-aid clear', 'band-aid', 'first aid'),
(13, 'nurofen fast pain relief', 'nurofen', 'medicines'),
(22, 'optislim vlcd shakes', 'optislim', 'weight loss'),
(32, 'blackmores brain health', 'blackmores', 'vitamins'),
(34, 'Nature\'s Own Omega-3', 'Nature\'s Own', 'vitamins'),
(44, 'panadol optizorb', 'panadol', 'medicines'),
(74, 'Cenovis colds and immunity', 'cenovis', 'vitamins');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `current_sales`
--
ALTER TABLE `current_sales`
  ADD PRIMARY KEY (`order_no`),
  ADD KEY `product_ref` (`product_id`);

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`product_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `current_sales`
--
ALTER TABLE `current_sales`
  MODIFY `order_no` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
