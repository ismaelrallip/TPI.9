# Sistema de Gestión de Pedidos - Hamburguesería 🍔

**Trabajo Práctico Integrador - Tecnologías de Desarrollo de Software IDE**

## Integrantes
* **Rallip Sanchez, Ismael** - Legajo: 51392 - Ismaelrasa@gmail.com
* **Bertotti, Santino** - Legajo: 52967 - santinobertotti1@gmail.com
* **Tessore, Marco** - Legajo: 53126 - marcoeltrebol@gmail.com

## Descripción
Este repositorio contiene la el sistema  para gestionar los pedidos, clientes y delivery de una hamburguesería. 

La API está construida con una **arquitectura en capas** en C# .NET .

## 📄 Documentación
* [Documentación con requisitos, reglas de negocio y modelo de datos](https://docs.google.com/document/d/1YfdhHR1HZWSLFLJvm5I7DLrj5C67ysH38pvzBC0-3eA/edit?tab=t.0)
* [Informe Uso de IA Entrega 1](https://docs.google.com/document/d/1Tp7xP2-oaNi9mdo0L2RLI9TjgrSsXH8p6cauEkaLaj8/edit?usp=sharing)

## 🔑 Credenciales de acceso
Para ingresar al sistema como **Administrador**:
* **Usuario:** `admin`
* **Contraseña:** `admin`

### 📋 Plantilla para el archivo `.env`
Crea un archivo llamado `.env` en la raíz del proyecto utilizando el siguiente formato como plantilla:

```env
TPI9_JWT_SECRET_KEY=<tu_clave_secreta_jwt>
TPI9_ADMIN_USERNAME=<tu_usuario_admin>
TPI9_ADMIN_PASSWORD=<tu_password_admin>
TPI_API_BASE_URL=<url_base_api>