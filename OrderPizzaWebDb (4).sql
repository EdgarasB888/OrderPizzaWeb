-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Oct 23, 2023 at 09:39 PM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `OrderPizzaWebDb`
--

-- --------------------------------------------------------

--
-- Table structure for table `Toppings`
--

CREATE TABLE `Toppings` (
  `Id` int(11) NOT NULL,
  `Name` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `Toppings`
--

INSERT INTO `Toppings` (`Id`, `Name`) VALUES
(1, 'Pepperoni'),
(2, 'Mushrooms'),
(3, 'Green Peppers'),
(4, 'Onions'),
(5, 'Black Olives'),
(6, 'Sausage'),
(7, 'Bacon'),
(8, 'Ham'),
(9, 'Pineapple'),
(10, 'Anchovies'),
(11, 'Tomatoes'),
(12, 'Jalapeños'),
(13, 'Spinach'),
(14, 'Feta Cheese'),
(15, 'Artichoke Hearts'),
(16, 'Red Onions'),
(17, 'Green Olives'),
(18, 'Basil'),
(19, 'Sun-Dried Tomatoes'),
(20, 'BBQ Chicken'),
(21, 'Salami'),
(22, 'Pesto'),
(23, 'Caramelized Onions'),
(24, 'Goat Cheese'),
(25, 'Pulled Pork'),
(26, 'Shrimp'),
(27, 'Gorgonzola'),
(28, 'Buffalo Sauce'),
(29, 'Eggplant'),
(30, 'Avocado'),
(31, 'Sliced Almonds'),
(32, 'Chicken Tikka'),
(33, 'Paneer'),
(34, 'Mango Chutney'),
(35, 'Sundried Tomatoes'),
(36, 'Brie Cheese'),
(37, 'Fresh Mozzarella'),
(38, 'Gouda'),
(39, 'Parmesan'),
(40, 'Cheddar Cheese'),
(41, 'Crispy Onions'),
(42, 'Pickles'),
(43, 'Gyros'),
(44, 'Beef'),
(45, 'Cucumber'),
(46, 'Corn'),
(47, 'Garlic'),
(48, 'Oregano'),
(49, 'Chorizo'),
(50, 'Kale'),
(51, 'Scallions'),
(52, 'Tofu'),
(53, 'Cherry Tomatoes'),
(54, 'Pickled Jalapeños'),
(55, 'Chili'),
(56, 'Clams'),
(57, 'Crab Meat'),
(58, 'Salmon'),
(59, 'Bok Choy'),
(60, 'Wasabi');

-- --------------------------------------------------------

--
-- Table structure for table `__EFMigrationsHistory`
--

CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `__EFMigrationsHistory`
--

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`) VALUES
('20231022181258_Initial migration', '7.0.12'),
('20231022184326_Initial migration 2', '7.0.12');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `Toppings`
--
ALTER TABLE `Toppings`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `__EFMigrationsHistory`
--
ALTER TABLE `__EFMigrationsHistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `Toppings`
--
ALTER TABLE `Toppings`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=61;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
