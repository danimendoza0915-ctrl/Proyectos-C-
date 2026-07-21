-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 15-02-2026 a las 06:52:33
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
-- Base de datos: `coworking`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cliente`
--

CREATE TABLE `cliente` (
  `IDCliente` int(11) NOT NULL,
  `Nombre` varchar(100) NOT NULL,
  `Telefono` varchar(10) NOT NULL,
  `Correo` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `cliente`
--

INSERT INTO `cliente` (`IDCliente`, `Nombre`, `Telefono`, `Correo`) VALUES
(1, 'Daniel Mendoza', '4532125678', 'daniel.mendoza@gmail.com'),
(2, 'Luis Perez', '3422467890', 'Luis@gmail.com');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `espacio`
--

CREATE TABLE `espacio` (
  `IDEspacio` int(11) NOT NULL,
  `NombreEspacio` varchar(100) NOT NULL,
  `IDTipoEspacio` int(11) DEFAULT NULL,
  `IDSucursal` int(11) DEFAULT NULL,
  `Capacidad` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `espacio`
--

INSERT INTO `espacio` (`IDEspacio`, `NombreEspacio`, `IDTipoEspacio`, `IDSucursal`, `Capacidad`) VALUES
(1, 'Salon Centro 1', 1, 1, 1),
(2, 'Sala Juntas Centro', 2, 1, 12),
(3, 'Oficina Privada Centro', 3, 1, 7),
(4, 'Centro Capacitacion', 4, 1, 25),
(5, 'Sala Juntas Norte', 2, 2, 12),
(6, 'Oficina Norte', 3, 2, 8),
(7, 'Centro Histórico', 2, 3, 6),
(8, 'Oficina Salazar', 3, 4, 3);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `reservacion`
--

CREATE TABLE `reservacion` (
  `IDReservacion` int(11) NOT NULL,
  `IDCliente` int(11) NOT NULL,
  `IDEspacio` int(11) NOT NULL,
  `Fecha` datetime NOT NULL,
  `Comentarios` varchar(300) DEFAULT NULL,
  `Notificacion` bit(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `reservacion`
--

INSERT INTO `reservacion` (`IDReservacion`, `IDCliente`, `IDEspacio`, `Fecha`, `Comentarios`, `Notificacion`) VALUES
(1, 1, 7, '2026-02-15 21:49:00', '', b'0'),
(2, 2, 7, '2026-02-16 22:46:00', '', b'1');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sucursal`
--

CREATE TABLE `sucursal` (
  `IDSucursal` int(11) NOT NULL,
  `NombreSucursal` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `sucursal`
--

INSERT INTO `sucursal` (`IDSucursal`, `NombreSucursal`) VALUES
(1, 'Colonia Centro'),
(2, 'Plaza Norte'),
(3, 'Centro historico'),
(4, 'Plaza Salazar');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tipoespacio`
--

CREATE TABLE `tipoespacio` (
  `IDTipoEspacio` int(11) NOT NULL,
  `TipoEspacio` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `tipoespacio`
--

INSERT INTO `tipoespacio` (`IDTipoEspacio`, `TipoEspacio`) VALUES
(1, 'Espacio Compartido'),
(2, 'Sala de juntas'),
(3, 'Oficina privada'),
(4, 'Sala de capacitación');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `cliente`
--
ALTER TABLE `cliente`
  ADD PRIMARY KEY (`IDCliente`);

--
-- Indices de la tabla `espacio`
--
ALTER TABLE `espacio`
  ADD PRIMARY KEY (`IDEspacio`),
  ADD KEY `IDTipoEspacio` (`IDTipoEspacio`),
  ADD KEY `IDSucursal` (`IDSucursal`);

--
-- Indices de la tabla `reservacion`
--
ALTER TABLE `reservacion`
  ADD PRIMARY KEY (`IDReservacion`),
  ADD UNIQUE KEY `unique_reserva` (`IDEspacio`,`Fecha`),
  ADD KEY `IDCliente` (`IDCliente`);

--
-- Indices de la tabla `sucursal`
--
ALTER TABLE `sucursal`
  ADD PRIMARY KEY (`IDSucursal`);

--
-- Indices de la tabla `tipoespacio`
--
ALTER TABLE `tipoespacio`
  ADD PRIMARY KEY (`IDTipoEspacio`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `cliente`
--
ALTER TABLE `cliente`
  MODIFY `IDCliente` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `espacio`
--
ALTER TABLE `espacio`
  MODIFY `IDEspacio` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT de la tabla `reservacion`
--
ALTER TABLE `reservacion`
  MODIFY `IDReservacion` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `sucursal`
--
ALTER TABLE `sucursal`
  MODIFY `IDSucursal` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de la tabla `tipoespacio`
--
ALTER TABLE `tipoespacio`
  MODIFY `IDTipoEspacio` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `espacio`
--
ALTER TABLE `espacio`
  ADD CONSTRAINT `IDSucursal` FOREIGN KEY (`IDSucursal`) REFERENCES `sucursal` (`IDSucursal`),
  ADD CONSTRAINT `IDTipoEspacio` FOREIGN KEY (`IDTipoEspacio`) REFERENCES `tipoespacio` (`IDTipoEspacio`);

--
-- Filtros para la tabla `reservacion`
--
ALTER TABLE `reservacion`
  ADD CONSTRAINT `IDCliente` FOREIGN KEY (`IDCliente`) REFERENCES `cliente` (`IDCliente`),
  ADD CONSTRAINT `IDEspacio` FOREIGN KEY (`IDEspacio`) REFERENCES `espacio` (`IDEspacio`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
