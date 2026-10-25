USE [TPI_HamburgueseriaDB];
GO

-- =========================================================================================
-- ¡ADVERTENCIA: ZONA DE BORRADO!
-- Este script elimina los datos existentes de las tablas indicadas.
-- Ejecutar únicamente en la base de pruebas.
-- =========================================================================================

DELETE FROM DetallesPedido;
DELETE FROM Pedidos;
DELETE FROM Precio;
DELETE FROM HamburguesaIngrediente;
DELETE FROM Hamburguesas;
DELETE FROM Ingredientes;
DELETE FROM PreciosDelivery;
DELETE FROM Deliveries;
DELETE FROM Clientes;

-- =========================================================================================
-- 1. CLIENTES
-- IDs 901 al 905
-- =========================================================================================

SET IDENTITY_INSERT Clientes ON;

INSERT INTO Clientes (Id, Nombre, Apellido, Email, Telefono, Password, Activo)
VALUES
(901, 'Juan', 'Prueba', 'prueba901@email.com', '3410000000',
 'PBKDF2-SHA256$100000$RlQQJ3M8TUda97RPcX2y+g==$eFPxF55dpQv14PRn7VAsEeCpzYip/x4lkbDO9MTPKSs=', 1),
(902, 'Maria', 'Gomez', 'maria902@email.com', '3412345678',
 'PBKDF2-SHA256$100000$RlQQJ3M8TUda97RPcX2y+g==$eFPxF55dpQv14PRn7VAsEeCpzYip/x4lkbDO9MTPKSs=', 1),
(903, 'Pedro', 'Lopez', 'pedro903@email.com', '3413456789',
 'PBKDF2-SHA256$100000$RlQQJ3M8TUda97RPcX2y+g==$eFPxF55dpQv14PRn7VAsEeCpzYip/x4lkbDO9MTPKSs=', 1),
(904, 'Sofia', 'Martinez', 'sofia904@email.com', '3414567890',
 'PBKDF2-SHA256$100000$RlQQJ3M8TUda97RPcX2y+g==$eFPxF55dpQv14PRn7VAsEeCpzYip/x4lkbDO9MTPKSs=', 1),
(905, 'Lucas', 'Fernandez', 'lucas905@email.com', '3415678901',
 'PBKDF2-SHA256$100000$RlQQJ3M8TUda97RPcX2y+g==$eFPxF55dpQv14PRn7VAsEeCpzYip/x4lkbDO9MTPKSs=', 0);

SET IDENTITY_INSERT Clientes OFF;


-- =========================================================================================
-- 2. DELIVERIES
-- IDs 901 al 903
-- =========================================================================================

SET IDENTITY_INSERT Deliveries ON;

INSERT INTO Deliveries (IdDelivery, Nombre, Apellido, Telefono, Dni, Activo)
VALUES
(901, 'Carlos', 'Repartidor', '3411111111', 30901901, 1),
(902, 'Lucia', 'Repartidora', '3412222222', 30902902, 1),
(903, 'Marcos', 'Delivery', '3413333333', 30903903, 0);

SET IDENTITY_INSERT Deliveries OFF;


-- =========================================================================================
-- 3. PRECIOS DEL DELIVERY
-- =========================================================================================

SET IDENTITY_INSERT PreciosDelivery ON;

INSERT INTO PreciosDelivery (Id, FechaDesde, FechaFin, Monto)
VALUES
(901, DATEADD(DAY, -90, GETDATE()), DATEADD(DAY, -30, GETDATE()), 1200.00),
(902, DATEADD(DAY, -30, GETDATE()), NULL, 1500.00);

SET IDENTITY_INSERT PreciosDelivery OFF;


-- =========================================================================================
-- 4. INGREDIENTES
-- =========================================================================================

SET IDENTITY_INSERT Ingredientes ON;

INSERT INTO Ingredientes (Id, Nombre, Descripcion, Stock)
VALUES
(901, 'Pan Brioche', 'Pan de hamburguesa artesanal', 100),
(902, 'Medallon 120g', 'Medallon de carne vacuna', 200),
(903, 'Cheddar', 'Fetas de queso cheddar', 300),
(904, 'Bacon', 'Panceta ahumada en tiras', 150),
(905, 'Lechuga', 'Hojas de lechuga fresca', 100),
(906, 'Tomate', 'Rodajas de tomate fresco', 100),
(907, 'Cebolla', 'Cebolla fresca cortada', 100);

SET IDENTITY_INSERT Ingredientes OFF;


-- =========================================================================================
-- 5. HAMBURGUESAS
-- =========================================================================================

SET IDENTITY_INSERT Hamburguesas ON;

INSERT INTO Hamburguesas (Id, Nombre, Descripcion, Activo)
VALUES
(901, 'Cheeseburger Prueba', 'Medallon, cheddar y pan brioche', 1),
(902, 'Doble Bacon Prueba', 'Doble medallon, cheddar, bacon y pan brioche', 1),
(903, 'Hamburguesa Completa', 'Medallon, cheddar, lechuga, tomate y cebolla', 1),
(904, 'Hamburguesa Especial', 'Doble medallon, cheddar y bacon extra', 0),
(905, 'Hamburguesa Clasica', 'Medallon, pan brioche y cheddar', 1);

SET IDENTITY_INSERT Hamburguesas OFF;


-- =========================================================================================
-- 6. RELACIONES ENTRE HAMBURGUESAS E INGREDIENTES
-- =========================================================================================

INSERT INTO HamburguesaIngrediente (HamburguesaId, IngredientesId)
VALUES
(901, 901), (901, 902), (901, 903),
(902, 901), (902, 902), (902, 903), (902, 904),
(903, 901), (903, 902), (903, 903), (903, 905), (903, 906), (903, 907),
(904, 901), (904, 902), (904, 903), (904, 904),
(905, 901), (905, 902), (905, 903);


-- =========================================================================================
-- 7. PRECIOS HISTORICOS Y ACTUALES
-- =========================================================================================

SET IDENTITY_INSERT Precio ON;

INSERT INTO Precio (Id, HamburguesaId, PrecioFechaDesde, Precio)
VALUES
(901, 901, DATEADD(DAY, -90, GETDATE()), 4500.00),
(902, 902, DATEADD(DAY, -90, GETDATE()), 6500.00),
(903, 903, DATEADD(DAY, -90, GETDATE()), 5900.00),
(904, 904, DATEADD(DAY, -90, GETDATE()), 7200.00),
(905, 901, DATEADD(DAY, -30, GETDATE()), 5500.00),
(906, 902, DATEADD(DAY, -30, GETDATE()), 7800.00),
(907, 903, DATEADD(DAY, -30, GETDATE()), 6900.00),
(908, 904, DATEADD(DAY, -30, GETDATE()), 8500.00),
(909, 905, DATEADD(DAY, -30, GETDATE()), 5000.00);

SET IDENTITY_INSERT Precio OFF;


-- =========================================================================================
-- 8. PEDIDOS
--
-- Modalidad: 0 = Take Away | 1 = Delivery
-- Estado: 0 = Pendiente | 1 = En proceso | 2 = Listo
--         3 = Asignado | 4 = En camino | 5 = Entregado | 6 = Cancelado
--
-- REGLA DE FECHAS:
-- * Pedidos de hoy: pueden estar en cualquier estado.
-- * Pedidos anteriores a hoy: únicamente Entregado o Cancelado.
-- =========================================================================================

SET IDENTITY_INSERT Pedidos ON;

INSERT INTO Pedidos (
    Id, Fecha, Comentario, Direccion, Modalidad, Estado,
    ComentarioFinal, PrecioTotal, ClienteId, DeliveryId,
    CalificacionPedido, CalificacionDelivery
)
VALUES
-- PEDIDOS DE HOY

-- 901: Take Away pendiente
(901, GETDATE(), 'Sin aderezos', NULL, 0, 0, NULL, 5500.00, 901, NULL, NULL, NULL),

-- 902: Delivery pendiente
(902, GETDATE(), 'Tocar timbre', 'Bv. Oroño 456', 1, 0, NULL, 9300.00, 902, NULL, NULL, NULL),

-- 903: Delivery asignado
(903, DATEADD(MINUTE, -15, GETDATE()), NULL, 'Mendoza 789', 1, 3, NULL, 9300.00, 903, 901, NULL, NULL),

-- 904: Take Away en proceso
(904, DATEADD(MINUTE, -40, GETDATE()), 'Sin cebolla', NULL, 0, 1, NULL, 11000.00, 901, NULL, NULL, NULL),

-- 905: Take Away listo
(905, DATEADD(MINUTE, -30, GETDATE()), NULL, NULL, 0, 2, NULL, 7800.00, 902, NULL, NULL, NULL),

-- 906: Delivery en camino
(906, DATEADD(MINUTE, -20, GETDATE()), NULL, 'Italia 250', 1, 4, NULL, 14800.00, 903, 901, NULL, NULL),

-- 907: Delivery entregado hoy y calificado
(907, DATEADD(HOUR, -2, GETDATE()), 'Dejar con el encargado', 'Salta 980', 1, 5, 'Excelente servicio', 17100.00, 901, 902, 5, 4),

-- 908: Take Away cancelado hoy
(908, DATEADD(MINUTE, -10, GETDATE()), 'Cancelado por el cliente', NULL, 0, 6, NULL, 5500.00, 904, NULL, NULL, NULL),

-- 909: Delivery pendiente con dos tipos de hamburguesa
(909, DATEADD(MINUTE, -5, GETDATE()), 'Agregar servilletas', 'Rioja 77', 1, 0, NULL, 22600.00, 902, NULL, NULL, NULL),

-- 910: Take Away en proceso
(910, DATEADD(MINUTE, -25, GETDATE()), 'Sin tomate', NULL, 0, 1, NULL, 13800.00, 903, NULL, NULL, NULL),

-- 911: Delivery asignado con hamburguesa activa
(911, DATEADD(MINUTE, -18, GETDATE()), NULL, 'San Luis 1200', 1, 3, NULL, 8400.00, 904, 902, NULL, NULL),

-- 912: Delivery asignado
(912, DATEADD(MINUTE, -12, GETDATE()), 'Llamar al llegar', 'Cordoba 540', 1, 3, NULL, 12500.00, 901, 901, NULL, NULL),

-- 919: Pedido pendiente con hamburguesa clásica, útil para probar bajas
(919, DATEADD(MINUTE, -8, GETDATE()), 'Pedido de prueba para baja', 'Mitre 450', 1, 0, NULL, 6500.00, 902, NULL, NULL, NULL),

-- PEDIDOS DE FECHAS ANTERIORES: SOLO ENTREGADOS O CANCELADOS

-- 913: Entregado hace 60 días, precio histórico
(913, DATEADD(DAY, -60, GETDATE()), NULL, NULL, 0, 5, 'Pedido historico entregado', 4500.00, 902, NULL, 5, NULL),

-- 914: Delivery entregado hace 60 días, con envío histórico
(914, DATEADD(DAY, -60, GETDATE()), NULL, 'Entre Rios 300', 1, 5, 'Entregado correctamente', 7700.00, 903, 902, 4, 5),

-- 915: Delivery entregado hace 60 días
(915, DATEADD(DAY, -60, GETDATE()), 'Pedido historico', 'Pellegrini 800', 1, 5, 'Pedido finalizado', 14300.00, 901, 901, 5, 4),

-- 916: Pedido cancelado ayer
(916, DATEADD(DAY, -1, GETDATE()), 'Cancelado por falta de stock', NULL, 0, 6, 'Cancelado por falta de stock', 5000.00, 904, NULL, NULL, NULL),

-- 917: Take Away entregado hace dos días
(917, DATEADD(DAY, -2, GETDATE()), NULL, NULL, 0, 5, 'Retirado por el cliente', 17000.00, 902, NULL, 5, NULL),

-- 918: Histórico con cliente, delivery y hamburguesa inactivos
(918, DATEADD(DAY, -60, GETDATE()), 'Pedido historico', 'Italia 700', 1, 5, 'Pedido finalizado', 8400.00, 905, 903, 4, 4);

SET IDENTITY_INSERT Pedidos OFF;


-- =========================================================================================
-- 9. DETALLES DE LOS PEDIDOS
-- =========================================================================================

SET IDENTITY_INSERT DetallesPedido ON;

INSERT INTO DetallesPedido (Id, Cantidad, PrecioUnitario, PedidoId, HamburguesaId)
VALUES
(901, 1, 5500.00, 901, 901),
(902, 1, 7800.00, 902, 902),
(903, 1, 7800.00, 903, 902),
(904, 2, 5500.00, 904, 901),
(905, 1, 7800.00, 905, 902),
(906, 1, 5500.00, 906, 901),
(907, 1, 7800.00, 906, 902),
(908, 2, 7800.00, 907, 902),
(909, 1, 5500.00, 908, 901),
(910, 1, 5500.00, 909, 901),
(911, 2, 7800.00, 909, 902),
(912, 2, 6900.00, 910, 903),
(913, 1, 6900.00, 911, 903),
(914, 2, 5500.00, 912, 901),
(915, 1, 4500.00, 913, 901),
(916, 1, 6500.00, 914, 902),
(917, 1, 5900.00, 915, 903),
(918, 1, 7200.00, 915, 904),
(919, 1, 5000.00, 916, 905),
(920, 2, 8500.00, 917, 904),
(921, 1, 7200.00, 918, 904),
(922, 1, 5000.00, 919, 905);

SET IDENTITY_INSERT DetallesPedido OFF;

GO

-- =========================================================================================
-- 10. COMPROBACIONES
-- =========================================================================================

SELECT * FROM Clientes ORDER BY Id;
SELECT * FROM Deliveries ORDER BY IdDelivery;
SELECT * FROM Ingredientes ORDER BY Id;
SELECT * FROM Hamburguesas ORDER BY Id;
SELECT * FROM Precio ORDER BY HamburguesaId, PrecioFechaDesde;
SELECT * FROM PreciosDelivery ORDER BY FechaDesde;
SELECT * FROM Pedidos ORDER BY Fecha DESC, Id DESC;
SELECT * FROM DetallesPedido ORDER BY PedidoId, Id;

GO