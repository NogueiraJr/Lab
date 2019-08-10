-- MySQL dump 10.13  Distrib 5.7.17, for macos10.12 (x86_64)
--
-- Host: 127.0.0.1    Database: VestBemDb
-- ------------------------------------------------------
-- Server version	8.0.11

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
-- Table structure for table `Clientes`
--

CREATE DATABASE IF NOT EXISTS `VestBemDb`;
USE `VestBemDb`;

DROP TABLE IF EXISTS `Clientes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Clientes` (
  `Clientes_id` int(11) NOT NULL AUTO_INCREMENT,
  `nomeCliente` varchar(256) NOT NULL,
  PRIMARY KEY (`Clientes_id`),
  UNIQUE KEY `unique_id_clientes` (`Clientes_id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 /*COLLATE=utf8mb4_0900_ai_ci*/;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `Locacoes`
--

DROP TABLE IF EXISTS `Locacoes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Locacoes` (
  `Locacoes_id` int(11) NOT NULL AUTO_INCREMENT,
  `Clientes_id` int(11) NOT NULL,
  `dtReserva` datetime NOT NULL,
  `dtRetirada` datetime NOT NULL,
  `dtDevolucao` datetime NOT NULL,
  PRIMARY KEY (`Locacoes_id`),
  UNIQUE KEY `unique_id_locacoes` (`Locacoes_id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 /*COLLATE=utf8mb4_0900_ai_ci*/;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `LocacoesProdutos`
--

DROP TABLE IF EXISTS `LocacoesProdutos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `LocacoesProdutos` (
  `LocacoesProdutos_id` int(11) NOT NULL AUTO_INCREMENT,
  `Locacoes_id` int(11) NOT NULL,
  `Produtos_id` int(11) NOT NULL,
  PRIMARY KEY (`LocacoesProdutos_id`),
  UNIQUE KEY `unique_id_locacoes_produtos` (`LocacoesProdutos_id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 /*COLLATE=utf8mb4_0900_ai_ci*/;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `Produtos`
--

DROP TABLE IF EXISTS `Produtos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Produtos` (
  `Produtos_id` int(11) NOT NULL AUTO_INCREMENT,
  `nomeProduto` varchar(256) NOT NULL,
  PRIMARY KEY (`Produtos_id`),
  UNIQUE KEY `unique_id_produtos` (`Produtos_id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 /*COLLATE=utf8mb4_0900_ai_ci*/;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-05-06  8:12:41
