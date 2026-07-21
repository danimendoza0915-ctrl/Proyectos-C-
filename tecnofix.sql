-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 04-02-2026 a las 00:53:34
-- Versión del servidor: 10.4.32-MariaDB
-- Versión de PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `tecnofix`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `clientes`
--

CREATE TABLE `clientes` (
  `IDCliente` int(11) NOT NULL,
  `NombreCompleto` varchar(100) NOT NULL,
  `Calle` varchar(100) NOT NULL,
  `Numero` varchar(100) NOT NULL,
  `Colonia` varchar(100) NOT NULL,
  `CodigoPostal` varchar(100) NOT NULL,
  `telefono` varchar(12) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `clientes`
--

INSERT INTO `clientes` (`IDCliente`, `NombreCompleto`, `Calle`, `Numero`, `Colonia`, `CodigoPostal`, `telefono`) VALUES
(1, 'Daniel Mendoza ', 'Guillermo ', '67', 'San juan ', '2378', '4535409876'),
(2, 'Luis Gutierrez', 'San antonio', '23', 'ocotal', '9023', '453218907'),
(3, 'Luis Alvaro ', 'San Antonio', '34', 'Lomas del ocotal', '5545', '5643213456');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `servicio`
--

CREATE TABLE `servicio` (
  `IDServicio` int(11) NOT NULL,
  `FechaHoraSolicitud` datetime DEFAULT NULL,
  `TipoDeServicio` varchar(100) NOT NULL,
  `Descripcion` text NOT NULL,
  `costo` decimal(10,2) NOT NULL,
  `Estado` varchar(20) NOT NULL,
  `DistanciaKm` decimal(10,2) NOT NULL,
  `TiempoEstimadohoras` double(11,2) NOT NULL,
  `HoraEstimadaLlegada` datetime DEFAULT NULL,
  `IDCliente` int(11) DEFAULT NULL,
  `IDTecnico` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `servicio`
--

INSERT INTO `servicio` (`IDServicio`, `FechaHoraSolicitud`, `TipoDeServicio`, `Descripcion`, `costo`, `Estado`, `DistanciaKm`, `TiempoEstimadohoras`, `HoraEstimadaLlegada`, `IDCliente`, `IDTecnico`) VALUES
(1, '2026-02-03 16:03:10', 'Instalacion', 'Se requiere la correcta instalacion de un router', 200.00, 'Finalizado', 0.03, 0.03, '2026-02-03 16:02:50', 1, 1),
(3, '2026-02-03 17:51:03', 'Reperacion de computadora ', 'Se requiere realizar mantenimiento y reparacion de una computadora ', 500.00, 'Asignado', 0.08, 0.07, '2026-02-03 17:50:26', 2, 2);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tecnico`
--

CREATE TABLE `tecnico` (
  `IDTecnico` int(11) NOT NULL,
  `NombreTecnico` varchar(100) NOT NULL,
  `Telefono` varchar(100) NOT NULL,
  `Especialidad` varchar(100) NOT NULL,
  `Estado` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `tecnico`
--

INSERT INTO `tecnico` (`IDTecnico`, `NombreTecnico`, `Telefono`, `Especialidad`, `Estado`) VALUES
(1, 'Paco Perez', '5690342134', 'Redes', 'En Servicio'),
(2, 'Agustin Martinez', '5432125678', 'Redes', 'En Servicio');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `clientes`
--
ALTER TABLE `clientes`
  ADD PRIMARY KEY (`IDCliente`);

--
-- Indices de la tabla `servicio`
--
ALTER TABLE `servicio`
  ADD PRIMARY KEY (`IDServicio`),
  ADD KEY `IDCliente` (`IDCliente`),
  ADD KEY `IDTecnico` (`IDTecnico`);

--
-- Indices de la tabla `tecnico`
--
ALTER TABLE `tecnico`
  ADD PRIMARY KEY (`IDTecnico`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `clientes`
--
ALTER TABLE `clientes`
  MODIFY `IDCliente` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `servicio`
--
ALTER TABLE `servicio`
  MODIFY `IDServicio` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `tecnico`
--
ALTER TABLE `tecnico`
  MODIFY `IDTecnico` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `servicio`
--
ALTER TABLE `servicio`
  ADD CONSTRAINT `servicio_ibfk_1` FOREIGN KEY (`IDCliente`) REFERENCES `clientes` (`IDCliente`),
  ADD CONSTRAINT `servicio_ibfk_2` FOREIGN KEY (`IDTecnico`) REFERENCES `tecnico` (`IDTecnico`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
