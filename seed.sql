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
DELETE FROM HamburguesaIngrediente;
DELETE FROM Hamburguesas;
DELETE FROM Ingredientes;
DELETE FROM PreciosDelivery;
DELETE FROM Deliveries;
DELETE FROM Clientes;
-- =========================================================================================
-- FIN DE LA ZONA DE BORRADO
-- =========================================================================================
-- 1. Insertamos los Clientes (IDs 901 y 902 con la columna Activo)
SET IDENTITY_INSERT Clientes ON;
INSERT INTO Clientes (
    Id,
    Nombre,
    Apellido,
    Email,
    Telefono,
    Password,
    Activo
  )
VALUES (
    901,
    'Juan',
    'Prueba',
    'prueba901@email.com',
    '3410000000',
    'PBKDF2-SHA256$100000$RlQQJ3M8TUda97RPcX2y+g==$eFPxF55dpQv14PRn7VAsEeCpzYip/x4lkbDO9MTPKSs=',
    1
  ),
  (
    902,
    'María',
    'Gómez',
    'maria902@email.com',
    '3412345678',
    'PBKDF2-SHA256$100000$RlQQJ3M8TUda97RPcX2y+g==$eFPxF55dpQv14PRn7VAsEeCpzYip/x4lkbDO9MTPKSs=',
    1
  );
SET IDENTITY_INSERT Clientes OFF;
-- 2. Insertamos dos Deliveries (Repartidores - ID 901 y 902 con la columna Activo)
SET IDENTITY_INSERT Deliveries ON;
INSERT INTO Deliveries (
    IdDelivery,
    Nombre,
    Apellido,
    Telefono,
    Dni,
    Activo
  )
VALUES (
    901,
    'Carlos',
    'Repartidor',
    '3411111111',
    30901901,
    1
  ),
  (
    902,
    'Lucía',
    'Repartidora',
    '3412222222',
    30902902,
    1
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
-- 4. Insertamos los Ingredientes (ID 901 al 904)
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
-- 5. Insertamos las Hamburguesas (ID 901 y 902 con la columna Activo)
SET IDENTITY_INSERT Hamburguesas ON;
INSERT INTO Hamburguesas (Id, Nombre, Descripcion, Activo)
VALUES (
    901,
    'Cheeseburger Prueba',
    'Medallón 120g, cheddar, pan brioche',
    1
  ),
  (
    902,
    'Doble Bacon Prueba',
    'Doble medallón, cheddar, bacon',
    1
  );
SET IDENTITY_INSERT Hamburguesas OFF;
-- 6. Insertamos las relaciones entre Hamburguesas e Ingredientes
INSERT INTO HamburguesaIngrediente (HamburguesaId, IngredientesId)
VALUES (901, 901),
  (901, 902),
  (901, 903),
  (902, 901),
  (902, 902),
  (902, 903),
  (902, 904);
-- 7. Insertamos los Precios de las Hamburguesas
SET IDENTITY_INSERT Precio ON;
INSERT INTO Precio (Id, HamburguesaId, PrecioFechaDesde, Precio)
VALUES (901, 901, DATEADD(MONTH, -1, GETDATE()), 5500.00),
  (902, 902, DATEADD(MONTH, -1, GETDATE()), 7800.00);
SET IDENTITY_INSERT Precio OFF;
-- 8. Insertamos los Pedidos
SET IDENTITY_INSERT Pedidos ON;
INSERT INTO Pedidos (
    Id,
    Fecha,
    Comentario,
    Direccion,
    Modalidad,
    Estado,
    ComentarioFinal,
    PrecioTotal,
    ClienteId,
    DeliveryId,
    CalificacionPedido,
    CalificacionDelivery
  )
VALUES -- TAKE AWAY - Pendiente, 1 línea
  (
    901,
    GETDATE(),
    'Sin aderezos',
    NULL,
    0,
    0,
    NULL,
    5500.00,
    901,
    NULL,
    NULL,
    NULL
  ),
  -- DELIVERY - Pendiente, sin repartidor asignado
  (
    902,
    GETDATE(),
    'Tocar timbre fuerte',
    'Bv. Oroño 456',
    1,
    0,
    NULL,
    9300.00,
    901,
    NULL,
    NULL,
    NULL
  ),
  -- DELIVERY - Asignado (repartidor 901)
  (
    903,
    GETDATE(),
    NULL,
    'Mendoza 789',
    1,
    3,
    NULL,
    9300.00,
    901,
    901,
    NULL,
    NULL
  ),
  -- TAKE AWAY - En proceso
  (
    904,
    DATEADD(MINUTE, -40, GETDATE()),
    'Sin cebolla',
    NULL,
    0,
    1,
    NULL,
    11000.00,
    901,
    NULL,
    NULL,
    NULL
  ),
  -- TAKE AWAY - Listo
  (
    905,
    DATEADD(MINUTE, -30, GETDATE()),
    NULL,
    NULL,
    0,
    2,
    NULL,
    7800.00,
    901,
    NULL,
    NULL,
    NULL
  ),
  -- DELIVERY - En camino (repartidor 901), 2 líneas
  (
    906,
    DATEADD(MINUTE, -20, GETDATE()),
    NULL,
    'Italia 250',
    1,
    4,
    NULL,
    14800.00,
    901,
    901,
    NULL,
    NULL
  ),
  -- DELIVERY - Entregado (repartidor 902), con calificación, de ayer
  (
    907,
    DATEADD(DAY, -1, GETDATE()),
    'Dejar con el encargado',
    'Salta 980',
    1,
    5,
    'Excelente servicio',
    17100.00,
    901,
    902,
    5,
    4
  ),
  -- TAKE AWAY - Cancelado
  (
    908,
    DATEADD(MINUTE, -10, GETDATE()),
    'Pedido cancelado por el cliente',
    NULL,
    0,
    6,
    NULL,
    5500.00,
    901,
    NULL,
    NULL,
    NULL
  ),
  -- DELIVERY - Pendiente, sin repartidor, 2 líneas
  (
    909,
    DATEADD(MINUTE, -5, GETDATE()),
    'Agregar servilletas',
    'Rioja 77',
    1,
    0,
    NULL,
    22600.00,
    901,
    NULL,
    NULL,
    NULL
  );
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
  (902, 1, 7800.00, 902, 902),
  (903, 1, 7800.00, 903, 902),
  (904, 2, 5500.00, 904, 901),
  (905, 1, 7800.00, 905, 902),
  (906, 1, 5500.00, 906, 901),
  (907, 1, 7800.00, 906, 902),
  (908, 2, 7800.00, 907, 902),
  (909, 1, 5500.00, 908, 901),
  (910, 1, 5500.00, 909, 901),
  (911, 2, 7800.00, 909, 902);
SET IDENTITY_INSERT DetallesPedido OFF;
GO