-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 21-02-2026 a las 04:47:28
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
-- Base de datos: `siga`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `estadoservicio`
--

CREATE TABLE `estadoservicio` (
  `IDEstadoServicio` int(11) NOT NULL,
  `NombreEstado` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `estadoservicio`
--

INSERT INTO `estadoservicio` (`IDEstadoServicio`, `NombreEstado`) VALUES
(1, 'Registrado'),
(2, 'En proceso'),
(3, 'Concluido');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `estatus`
--

CREATE TABLE `estatus` (
  `IDEstatus` int(11) NOT NULL,
  `NombreEstatus` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `estatus`
--

INSERT INTO `estatus` (`IDEstatus`, `NombreEstatus`) VALUES
(1, 'Activo'),
(2, 'Baja'),
(3, 'Suspendido'),
(4, 'Egresado');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `estudiantes`
--

CREATE TABLE `estudiantes` (
  `Matricula` varchar(20) NOT NULL,
  `NombreEstudiante` varchar(50) NOT NULL,
  `Carrera` varchar(50) NOT NULL,
  `IDEstatus` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `estudiantes`
--

INSERT INTO `estudiantes` (`Matricula`, `NombreEstudiante`, `Carrera`, `IDEstatus`) VALUES
('ES231109257', 'Daniel Mendoza ', 'Ingenieria en Desarrollo de software', 1),
('ES23468908', 'Paco Luis', 'Ciencias aplicadas', 2),
('ES3456780943', 'Lucas Alvarez', 'Arquitectura', 1),
('ES34568907', 'Alberto Perez', 'Administración de Empresas', 4);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `inscripciones`
--

CREATE TABLE `inscripciones` (
  `IdInscripcion` int(11) NOT NULL,
  `Matricula` varchar(20) NOT NULL,
  `Materia` varchar(50) NOT NULL,
  `Horario` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `inscripciones`
--

INSERT INTO `inscripciones` (`IdInscripcion`, `Matricula`, `Materia`, `Horario`) VALUES
(1, 'ES231109257', 'Programacion net', '10:00 am - 11: 00 pm'),
(2, 'ES231109257', 'Bases de datos ', '12:00 pm- 13:00 pm'),
(4, 'ES3456780943', 'Diseño de interiores ', '14:00 pm - 15:00 pm');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `pagos`
--

CREATE TABLE `pagos` (
  `IdPago` int(11) NOT NULL,
  `Matricula` varchar(20) NOT NULL,
  `SubTotal` decimal(10,2) NOT NULL,
  `IVA` decimal(10,2) NOT NULL,
  `ISR` decimal(10,2) NOT NULL,
  `Total` decimal(10,2) NOT NULL,
  `Fecha` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `pagos`
--

INSERT INTO `pagos` (`IdPago`, `Matricula`, `SubTotal`, `IVA`, `ISR`, `Total`, `Fecha`) VALUES
(1, 'ES231109257', 250.00, 40.00, 25.00, 315.00, '2026-02-20'),
(5, 'ES3456780943', 150.00, 24.00, 15.00, 189.00, '2026-02-20');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `roles`
--

CREATE TABLE `roles` (
  `IDRol` int(11) NOT NULL,
  `TipoRol` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `roles`
--

INSERT INTO `roles` (`IDRol`, `TipoRol`) VALUES
(1, 'Docente'),
(2, 'Administrativo'),
(3, 'Finanzas');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `servicios`
--

CREATE TABLE `servicios` (
  `IDServicios` int(11) NOT NULL,
  `Matricula` varchar(20) NOT NULL,
  `Tipo` varchar(20) NOT NULL,
  `ClaficacionServicio` tinyint(1) NOT NULL,
  `Costo` decimal(10,2) NOT NULL,
  `Estado` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `servicios`
--

INSERT INTO `servicios` (`IDServicios`, `Matricula`, `Tipo`, `ClaficacionServicio`, `Costo`, `Estado`) VALUES
(1, 'ES231109257', 'Reposición credencia', 1, 250.00, 'Registrado'),
(4, 'ES3456780943', 'Certificado', 1, 150.00, 'Concluido');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tiposervicios`
--

CREATE TABLE `tiposervicios` (
  `IDTipoServicio` int(11) NOT NULL,
  `NombreServicio` varchar(50) NOT NULL,
  `EsAdministrativo` tinyint(1) NOT NULL,
  `Costo` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `tiposervicios`
--

INSERT INTO `tiposervicios` (`IDTipoServicio`, `NombreServicio`, `EsAdministrativo`, `Costo`) VALUES
(1, 'Constancia', 0, 50.00),
(2, 'Kardex', 0, 100.00),
(3, 'Certificado', 1, 150.00),
(4, 'Reposición credencial', 1, 250.00);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

CREATE TABLE `usuarios` (
  `IdUsuario` int(11) NOT NULL,
  `Usuario` varchar(50) NOT NULL,
  `Contraseña` varchar(15) NOT NULL,
  `IDRol` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `usuarios`
--

INSERT INTO `usuarios` (`IdUsuario`, `Usuario`, `Contraseña`, `IDRol`) VALUES
(1, 'docente', '2468', 1),
(2, 'admin', '3689', 2),
(3, 'Finanzas', '7097', 3);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `estadoservicio`
--
ALTER TABLE `estadoservicio`
  ADD PRIMARY KEY (`IDEstadoServicio`);

--
-- Indices de la tabla `estatus`
--
ALTER TABLE `estatus`
  ADD PRIMARY KEY (`IDEstatus`);

--
-- Indices de la tabla `estudiantes`
--
ALTER TABLE `estudiantes`
  ADD PRIMARY KEY (`Matricula`),
  ADD KEY `IDEstatus` (`IDEstatus`);

--
-- Indices de la tabla `inscripciones`
--
ALTER TABLE `inscripciones`
  ADD PRIMARY KEY (`IdInscripcion`),
  ADD KEY `Matricula` (`Matricula`);

--
-- Indices de la tabla `pagos`
--
ALTER TABLE `pagos`
  ADD PRIMARY KEY (`IdPago`),
  ADD KEY `Matricula` (`Matricula`);

--
-- Indices de la tabla `roles`
--
ALTER TABLE `roles`
  ADD PRIMARY KEY (`IDRol`);

--
-- Indices de la tabla `servicios`
--
ALTER TABLE `servicios`
  ADD PRIMARY KEY (`IDServicios`),
  ADD KEY `Matricula` (`Matricula`);

--
-- Indices de la tabla `tiposervicios`
--
ALTER TABLE `tiposervicios`
  ADD PRIMARY KEY (`IDTipoServicio`);

--
-- Indices de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`IdUsuario`),
  ADD KEY `IDRol` (`IDRol`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `estadoservicio`
--
ALTER TABLE `estadoservicio`
  MODIFY `IDEstadoServicio` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `estatus`
--
ALTER TABLE `estatus`
  MODIFY `IDEstatus` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de la tabla `inscripciones`
--
ALTER TABLE `inscripciones`
  MODIFY `IdInscripcion` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de la tabla `pagos`
--
ALTER TABLE `pagos`
  MODIFY `IdPago` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de la tabla `roles`
--
ALTER TABLE `roles`
  MODIFY `IDRol` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `servicios`
--
ALTER TABLE `servicios`
  MODIFY `IDServicios` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de la tabla `tiposervicios`
--
ALTER TABLE `tiposervicios`
  MODIFY `IDTipoServicio` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `IdUsuario` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `estudiantes`
--
ALTER TABLE `estudiantes`
  ADD CONSTRAINT `estudiantes_ibfk_1` FOREIGN KEY (`IDEstatus`) REFERENCES `estatus` (`IDEstatus`);

--
-- Filtros para la tabla `inscripciones`
--
ALTER TABLE `inscripciones`
  ADD CONSTRAINT `inscripciones_ibfk_1` FOREIGN KEY (`Matricula`) REFERENCES `estudiantes` (`Matricula`);

--
-- Filtros para la tabla `pagos`
--
ALTER TABLE `pagos`
  ADD CONSTRAINT `pagos_ibfk_1` FOREIGN KEY (`Matricula`) REFERENCES `estudiantes` (`Matricula`);

--
-- Filtros para la tabla `servicios`
--
ALTER TABLE `servicios`
  ADD CONSTRAINT `servicios_ibfk_1` FOREIGN KEY (`Matricula`) REFERENCES `estudiantes` (`Matricula`);

--
-- Filtros para la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD CONSTRAINT `usuarios_ibfk_1` FOREIGN KEY (`IDRol`) REFERENCES `roles` (`IDRol`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
