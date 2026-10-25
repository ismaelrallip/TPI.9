# Sistema de Gestión de Pedidos - Hamburguesería 🍔

**Trabajo Práctico Integrador - Tecnologías de Desarrollo de Software IDE**

## Integrantes

- Rallip Sanchez, Ismael - Legajo 51392 - Ismaelrasa@gmail.com
- Bertotti, Santino - Legajo 52967 - santinobertotti1@gmail.com
- Tessore, Marco - Legajo 53126 - marcoeltrebol@gmail.com

## 📄 Documentación

- [Consigna del Trabajo Práctico](https://docs.google.com/document/d/1aHfNGXIkrtZoeUvli5Xmhj6I-O33DrE1/edit)
- [Documentación del negocio, requisitos, reglas de negocio y modelo de datos](https://docs.google.com/document/d/1YfdhHR1HZWSLFLJvm5I7DLrj5C67ysH38pvzBC0-3eA/edit?tab=t.0)
- [Informe de Uso de IA - Entrega 1](https://docs.google.com/document/d/1Tp7xP2-oaNi9mdo0L2RLI9TjgrSsXH8p6cauEkaLaj8/edit?usp=sharing)

## 🛠️ Tecnologías utilizadas

- C# y .NET
- Entity Framework Core
- SQL Server
- [Agregar las tecnologías del frontend, si corresponde]

## 📝 Descripción

Este repositorio contiene el sistema de gestión de pedidos, clientes y delivery de una hamburguesería, desarrollado como parte del Trabajo Práctico Integrador.

La aplicación utiliza una arquitectura en capas y una base de datos SQL Server.

## 🗄️ Base de datos y datos de prueba

La base de datos se crea automáticamente al iniciar el sistema si todavía no existe. Si se realizan cambios en las entidades, estos no se aplican automáticamente a una base de datos ya creada.

Una vez creada la base de datos, se puede ejecutar el archivo `seed.sql` en SQL Server para cargar datos de prueba.

**Importante:** el script `seed.sql` elimina y vuelve a insertar datos en las tablas que modifica. Se recomienda ejecutarlo únicamente en entornos de desarrollo o prueba.

## 🔑 Credenciales de acceso

- **Administrador:** usuario `admin`, contraseña `admin`.
- **Cliente de prueba:** email `prueba901@email.com`, contraseña `123456`.

## ⚙️ Variables de entorno

Crear un archivo `.env` en la raíz del proyecto con la siguiente configuración:

```env
TPI9_JWT_SECRET_KEY=Hamburgueseria-JWT-Key-Development-2026
TPI9_ADMIN_USERNAME=admin
TPI9_ADMIN_PASSWORD=admin
TPI_API_BASE_URL=http://localhost:5183/
