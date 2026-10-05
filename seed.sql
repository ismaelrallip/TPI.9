USE [TPI_HamburgueseriaDB];
GO -- =========================================================================================
  -- ¡ADVERTENCIA: ZONA DE BORRADO!
  -- Las siguientes sentencias DELETE vaciarán TODOS los datos de tus tablas para arrancar
  -- de cero y evitar conflictos de IDs.
  --
-- ---> SI NO QUIERES BORRAR TUS DATOS ACTUALES, ELIMINA ESTE BLOQUE ANTES DE EJECUTAR <---
  -- =========================================================================================
DELETE FROM DetallesPedido;
DELETE FROM Pedidos;
DELETE FROM Precio;
-- Si Entity Framework te creó una tabla intermedia para la relación muchos a muchos, descomenta esto:
-- DELETE FROM HamburguesaIngrediente; 
DELETE FROM Hamburguesas;
DELETE FROM Ingredientes;
DELETE FROM PreciosDelivery;
DELETE FROM Deliveries;
DELETE FROM Clientes;
-- =========================================================================================
-- FIN DE LA ZONA DE BORRADO
-- =========================================================================================
-- 1. Insertamos un Cliente (Usamos ID 901)
SET IDENTITY_INSERT Clientes ON;
INSERT INTO Clientes (Id, Nombre, Apellido, Email, Telefono, Password)
VALUES (
    901,
    'Juan',
    'Prueba',
    'prueba901@email.com',
    '3410000000',
    '123456'
  );
SET IDENTITY_INSERT Clientes OFF;
-- 2. Insertamos un Delivery (Repartidor - ID 901)
SET IDENTITY_INSERT Deliveries ON;
INSERT INTO Deliveries (IdDelivery, Nombre, Apellido, Telefono, Dni)
VALUES (
    901,
    'Carlos',
    'Repartidor',
    '3411111111',
    30901901
  );
SET IDENTITY_INSERT Deliveries OFF;
-- 3. Insertamos el Precio Histórico del Delivery (ID 901)
SET IDENTITY_INSERT PreciosDelivery ON;
INSERT INTO PreciosDelivery (Id, FechaDesde, FechaFin, Monto)
VALUES (
    901,
    DATEADD(MONTH, -1, GETDATE()),
    NULL,
    1500.00
  );
SET IDENTITY_INSERT PreciosDelivery OFF;
-- 4. Insertamos los Ingredientes (NUEVO)
SET IDENTITY_INSERT Ingredientes ON;
INSERT INTO Ingredientes (Id, Nombre, Descripcion, Stock)
VALUES (
    901,
    'Pan Brioche',
    'Pan de hamburguesa artesanal',
    100
  ),
  (
    902,
    'Medallón 120g',
    'Medallón de carne vacuna',
    200
  ),
  (903, 'Cheddar', 'Fetas de queso cheddar', 300),
  (904, 'Bacon', 'Panceta ahumada en tiras', 150);
SET IDENTITY_INSERT Ingredientes OFF;
-- 5. Insertamos las Hamburguesas (ID 901 y 902)
SET IDENTITY_INSERT Hamburguesas ON;
INSERT INTO Hamburguesas (Id, Nombre, Descripcion)
VALUES (
    901,
    'Cheeseburger Prueba',
    'Medallón 120g, cheddar, pan brioche'
  ),
  (
    902,
    'Doble Bacon Prueba',
    'Doble medallón, cheddar, bacon'
  );
SET IDENTITY_INSERT Hamburguesas OFF;
-- 6. Insertamos las relaciones entre Hamburguesas e Ingredientes (Tabla intermedia)
-- Descomenta este bloque si tu BD tiene la tabla intermedia creada por EF Core.
-- INSERT INTO HamburguesaIngrediente (HamburguesasId, IngredientesId)
-- VALUES 
-- (901, 901), -- Cheeseburger tiene Pan
-- (901, 902), -- Cheeseburger tiene Medallón
-- (901, 903), -- Cheeseburger tiene Cheddar
-- (902, 901), -- Doble Bacon tiene Pan
-- (902, 902), -- Doble Bacon tiene Medallón
-- (902, 903), -- Doble Bacon tiene Cheddar
-- (902, 904); -- Doble Bacon tiene Bacon
-- 7. Insertamos los Precios de las Hamburguesas
SET IDENTITY_INSERT Precio ON;
INSERT INTO Precio (Id, HamburguesaId, PrecioFechaDesde, Precio)
VALUES (901, 901, DATEADD(MONTH, -1, GETDATE()), 5500.00),
  (902, 902, DATEADD(MONTH, -1, GETDATE()), 7800.00);
SET IDENTITY_INSERT Precio OFF;
-- 8. Insertamos los Pedidos 
-- Modalidad: 0 = TakeAway, 1 = Delivery
-- Estado: 0 = Pendiente, 3 = Asignado
SET IDENTITY_INSERT Pedidos ON;
INSERT INTO Pedidos (
    Id,
    Fecha,
    Comentario,
    Direccion,
    Modalidad,
    Estado,
    PrecioTotal,
    ClienteId,
    DeliveryId,
    CalificacionPedido
  )
VALUES (
    901,
    GETDATE(),
    'Sin aderezos',
    'Av. Pellegrini 123',
    0,
    0,
    5500.00,
    901,
    NULL,
    0
  ),
  -- TAKE AWAY (Pendiente, sin delivery)
  (
    902,
    GETDATE(),
    'Tocar timbre fuerte',
    'Bv. Oroño 456',
    1,
    0,
    9300.00,
    901,
    NULL,
    0
  ),
  -- DELIVERY PENDIENTE (Modalidad 1, Estado 0, sin repartidor asignado)
  (
    903,
    GETDATE(),
    'Dejar en portería',
    'Mendoza 789',
    1,
    3,
    9300.00,
    901,
    901,
    0
  );
-- DELIVERY ASIGNADO (Modalidad 1, Estado 3, con repartidor 901)
SET IDENTITY_INSERT Pedidos OFF;
-- 9. Insertamos los Detalles del Pedido
SET IDENTITY_INSERT DetallesPedido ON;
INSERT INTO DetallesPedido (
    Id,
    Cantidad,
    PrecioUnitario,
    PedidoId,
    HamburguesaId
  )
VALUES (901, 1, 5500.00, 901, 901),
  -- 1 Cheeseburger para el TakeAway (Pedido 901)
  (902, 1, 7800.00, 902, 902),
  -- 1 Doble Bacon para el Delivery Pendiente (Pedido 902)
  (903, 1, 7800.00, 903, 902);
-- 1 Doble Bacon para el Delivery Asignado (Pedido 903)
SET IDENTITY_INSERT DetallesPedido OFF;
GO