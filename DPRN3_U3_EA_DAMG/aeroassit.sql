-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 05-03-2026 a las 01:24:07
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
-- Base de datos: `aeroassit`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `agentes`
--

CREATE TABLE `agentes` (
  `IDAgente` int(11) NOT NULL,
  `NombreAgente` varchar(50) DEFAULT NULL,
  `Rol` varchar(25) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `agentes`
--

INSERT INTO `agentes` (`IDAgente`, `NombreAgente`, `Rol`) VALUES
(1, 'Daniel Mendoza', 'Puertas');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `flujopasajeros`
--

CREATE TABLE `flujopasajeros` (
  `IDFlujo` int(11) NOT NULL,
  `Zona` varchar(50) DEFAULT NULL,
  `Hora` time DEFAULT NULL,
  `Cantidad` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `flujopasajeros`
--

INSERT INTO `flujopasajeros` (`IDFlujo`, `Zona`, `Hora`, `Cantidad`) VALUES
(1, 'Check-in A', '14:00:00', 120),
(2, 'Puerta 12', '14:00:00', 95);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `incidentes`
--

CREATE TABLE `incidentes` (
  `IDIncidente` int(11) NOT NULL,
  `Descripcion` varchar(200) DEFAULT NULL,
  `Zona` varchar(12) DEFAULT NULL,
  `Nivel` varchar(20) DEFAULT NULL,
  `Resuelto` tinyint(1) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `incidentes`
--

INSERT INTO `incidentes` (`IDIncidente`, `Descripcion`, `Zona`, `Nivel`, `Resuelto`) VALUES
(1, 'Fila saturada en Check-in', 'Check-in A', 'Alto', 0),
(2, 'Retraso en abordaje', 'Puerta 12', 'Medio', 1),
(3, 'Fila saturada en Seguridad', 'Seguridad', 'Alto', 0),
(4, 'Exceso de pasajeros', 'Check-in B', 'Alto', 0),
(5, 'Retraso leve en abordaje', 'Puerta 8', 'Bajo', 0),
(6, 'Fila saturada en Check-in', 'Check-in A', 'Alto', 0),
(7, 'Retraso en abordaje', 'Puerta 12', 'Medio', 1),
(8, 'Fila saturada en Seguridad', 'Seguridad', 'Alto', 0),
(9, 'Exceso de pasajeros', 'Check-in B', 'Alto', 0),
(10, 'Retraso leve en abordaje', 'Puerta 8', 'Bajo', 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `recomendaciones`
--

CREATE TABLE `recomendaciones` (
  `IDRecomendacion` int(11) NOT NULL,
  `IDAgente` int(11) DEFAULT NULL,
  `Mensaje` varchar(200) DEFAULT NULL,
  `Valor` int(11) DEFAULT NULL,
  `Fecha` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `recomendaciones`
--

INSERT INTO `recomendaciones` (`IDRecomendacion`, `IDAgente`, `Mensaje`, `Valor`, `Fecha`) VALUES
(32, 1, 'Se han reportado 376 puntos de incidentes puntos. Se recomienda priorizar la atención en las zonas afectadas.', 376, '2026-03-04 17:12:37'),
(33, 1, 'Se han detectado 120 puntos por vuelos retrasado puntos. Se recomienda coordinar con el personal de tierra para gestionar los retrasos.', 120, '2026-03-04 17:12:37'),
(34, 1, 'Se han reportado 326 puntos de incidentes puntos. Se recomienda priorizar la atención en las zonas afectadas.', 326, '2026-03-04 17:15:25'),
(35, 1, 'Se han detectado 120 puntos por vuelos retrasado puntos. Se recomienda coordinar con el personal de tierra para gestionar los retrasos.', 120, '2026-03-04 17:15:25');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tareas`
--

CREATE TABLE `tareas` (
  `IDTarea` int(11) NOT NULL,
  `IDAgente` int(11) DEFAULT NULL,
  `Descripcion` varchar(200) DEFAULT NULL,
  `Prioridad` varchar(15) DEFAULT NULL,
  `Estado` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `tareas`
--

INSERT INTO `tareas` (`IDTarea`, `IDAgente`, `Descripcion`, `Prioridad`, `Estado`) VALUES
(1, 1, 'Revisar equipaje especial', 'Alta', 'Pendiente'),
(2, 1, 'Asistir pasajero con discapacidad', 'Alta', 'Completada'),
(3, 1, 'atencion a persona con discapacidad', 'Alta', 'Pendiente'),
(4, 1, 'Atención urgente a pasajero con su equipaje', 'Alta', 'Pendiente'),
(6, 1, 'Asistencia a usuario con su equipaje', 'Media', 'Pendiente');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `vuelos`
--

CREATE TABLE `vuelos` (
  `IDVuelo` int(11) NOT NULL,
  `NumeroVuelo` varchar(16) DEFAULT NULL,
  `Destino` varchar(25) DEFAULT NULL,
  `Puerta` varchar(20) DEFAULT NULL,
  `Horario` time DEFAULT NULL,
  `Estatus` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `vuelos`
--

INSERT INTO `vuelos` (`IDVuelo`, `NumeroVuelo`, `Destino`, `Puerta`, `Horario`, `Estatus`) VALUES
(1, 'AR344', 'Yucatan', '78', '07:15:00', 'A tiempo'),
(2, 'AM234', 'Baja California', '12', '12:30:00', 'Retrasado'),
(3, 'VB102', 'Cancún', '05', '13:15:00', 'A tiempo'),
(4, 'ZM021', 'Ciudad de Méxio', '27', '17:45:00', 'Retrasado');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `agentes`
--
ALTER TABLE `agentes`
  ADD PRIMARY KEY (`IDAgente`);

--
-- Indices de la tabla `flujopasajeros`
--
ALTER TABLE `flujopasajeros`
  ADD PRIMARY KEY (`IDFlujo`);

--
-- Indices de la tabla `incidentes`
--
ALTER TABLE `incidentes`
  ADD PRIMARY KEY (`IDIncidente`);

--
-- Indices de la tabla `recomendaciones`
--
ALTER TABLE `recomendaciones`
  ADD PRIMARY KEY (`IDRecomendacion`),
  ADD KEY `IDAgente` (`IDAgente`);

--
-- Indices de la tabla `tareas`
--
ALTER TABLE `tareas`
  ADD PRIMARY KEY (`IDTarea`),
  ADD KEY `IDAgente` (`IDAgente`);

--
-- Indices de la tabla `vuelos`
--
ALTER TABLE `vuelos`
  ADD PRIMARY KEY (`IDVuelo`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `agentes`
--
ALTER TABLE `agentes`
  MODIFY `IDAgente` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `flujopasajeros`
--
ALTER TABLE `flujopasajeros`
  MODIFY `IDFlujo` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `incidentes`
--
ALTER TABLE `incidentes`
  MODIFY `IDIncidente` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT de la tabla `recomendaciones`
--
ALTER TABLE `recomendaciones`
  MODIFY `IDRecomendacion` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=36;

--
-- AUTO_INCREMENT de la tabla `tareas`
--
ALTER TABLE `tareas`
  MODIFY `IDTarea` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT de la tabla `vuelos`
--
ALTER TABLE `vuelos`
  MODIFY `IDVuelo` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `recomendaciones`
--
ALTER TABLE `recomendaciones`
  ADD CONSTRAINT `recomendaciones_ibfk_1` FOREIGN KEY (`IDAgente`) REFERENCES `agentes` (`IDAgente`);

--
-- Filtros para la tabla `tareas`
--
ALTER TABLE `tareas`
  ADD CONSTRAINT `tareas_ibfk_1` FOREIGN KEY (`IDAgente`) REFERENCES `agentes` (`IDAgente`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
