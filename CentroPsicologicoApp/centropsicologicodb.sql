-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 23-02-2026 a las 05:29:11
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
-- Base de datos: `centropsicologicodb`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `pacientes`
--

CREATE TABLE `pacientes` (
  `id_paciente` int(11) NOT NULL,
  `Nombre` varchar(100) DEFAULT NULL,
  `Correo` varchar(100) DEFAULT NULL,
  `Telefono` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `pacientes`
--

INSERT INTO `pacientes` (`id_paciente`, `Nombre`, `Correo`, `Telefono`) VALUES
(1, 'Daniel Mendoza', 'daniel.mendoza@gmail.com', '5422456789'),
(2, 'Luis Perez', 'luis.perez@gmail.com', '4532235689'),
(3, 'Luisa Herrera', 'luisa.herrera@gmail.com', '7765446789');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `psicologos`
--

CREATE TABLE `psicologos` (
  `id_psicologo` int(11) NOT NULL,
  `nombre` varchar(100) DEFAULT NULL,
  `Cedula_Profesional` varchar(30) DEFAULT NULL,
  `especialidad` varchar(80) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `psicologos`
--

INSERT INTO `psicologos` (`id_psicologo`, `nombre`, `Cedula_Profesional`, `especialidad`) VALUES
(1, 'Dr. Lucas Alvares', 'ES456789', 'Psicologo familiar'),
(2, 'Dra. Maria Mora', 'ES445676', 'Psicologa Infantil');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `pacientes`
--
ALTER TABLE `pacientes`
  ADD PRIMARY KEY (`id_paciente`);

--
-- Indices de la tabla `psicologos`
--
ALTER TABLE `psicologos`
  ADD PRIMARY KEY (`id_psicologo`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `pacientes`
--
ALTER TABLE `pacientes`
  MODIFY `id_paciente` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `psicologos`
--
ALTER TABLE `psicologos`
  MODIFY `id_psicologo` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
