-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 25-02-2026 a las 00:49:36
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
-- Base de datos: `bibliotecadb`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `libros`
--

CREATE TABLE `libros` (
  `LibroID` int(11) NOT NULL,
  `Titulo` varchar(150) NOT NULL,
  `Autor` varchar(100) NOT NULL,
  `EjemplaresDisponibles` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `libros`
--

INSERT INTO `libros` (`LibroID`, `Titulo`, `Autor`, `EjemplaresDisponibles`) VALUES
(1, 'Cien años de soledad', 'Gabriel García Márquez', 5),
(2, 'El principito', 'Antoine de Saint-Exupéry', 10),
(3, 'Don Quijote de la Mancha', 'Miguel de Cervantes', 3),
(4, 'La sombra del viento', 'Carlos Ruiz Zafón', 4),
(5, 'El caballero de la armadura oxidada', 'Robert Fisher', 5),
(7, 'Renueva tu mente ', 'Dr.Miguel Nuñez', 10);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `prestamos`
--

CREATE TABLE `prestamos` (
  `PrestamoID` int(11) NOT NULL,
  `FechaPrestamo` datetime NOT NULL,
  `LibroID` int(11) NOT NULL,
  `LectorNombre` varchar(100) DEFAULT NULL,
  `Estado` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `prestamos`
--

INSERT INTO `prestamos` (`PrestamoID`, `FechaPrestamo`, `LibroID`, `LectorNombre`, `Estado`) VALUES
(1, '2025-07-29 10:00:00', 1, 'Ana García', 'Devuelto'),
(2, '2025-07-29 11:30:00', 2, 'Luis Pérez', 'Activo');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `libros`
--
ALTER TABLE `libros`
  ADD PRIMARY KEY (`LibroID`);

--
-- Indices de la tabla `prestamos`
--
ALTER TABLE `prestamos`
  ADD PRIMARY KEY (`PrestamoID`),
  ADD KEY `LibroID` (`LibroID`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `libros`
--
ALTER TABLE `libros`
  MODIFY `LibroID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT de la tabla `prestamos`
--
ALTER TABLE `prestamos`
  MODIFY `PrestamoID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `prestamos`
--
ALTER TABLE `prestamos`
  ADD CONSTRAINT `prestamos_ibfk_1` FOREIGN KEY (`LibroID`) REFERENCES `libros` (`LibroID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
