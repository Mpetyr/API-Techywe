# API_Techywe

API REST desarrollada en .NET para la gestión de productos, clientes y ordenes.

---

## Descripción

Este proyecto implementa una API REST con arquitectura por capas utilizando Entity Framework Core y SQL Server.

Permite gestionar:

* Productos
* Clientes
* Orden

Incluye:

* DTOs para entrada y salida de datos
* AutoMapper para mapeo de entidades
* Validaciones con DataAnnotations
* Manejo global de errores mediante middleware
* Autenticación JWT básica
* Swagger para documentación

---

## Tecnologías utilizadas

* .NET 8
* ASP.NET Core Web API
* Entity Framework Core
* SQL Server / LocalDB
* AutoMapper
* JWT Authentication
* Swagger / OpenAPI

---

## Estructura del proyecto

* Controllers: Endpoints HTTP
* Services: Lógica de negocio
* Repositories: Acceso a datos
* DTOs: Transferencia de datos
* Entities: Modelos de dominio
* Data: DbContext
* Mappings: Configuración de AutoMapper
* Middleware: Manejo global de errores
* Exceptions: Excepciones personalizadas

---

## Requisitos previos

* .NET 8 SDK
* SQL Server o LocalDB
* Visual Studio 2022 o VS Code

---

## Configuración

### Cadena de conexión

Archivo: `appsettings.json`

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=API_TecnyweDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

### Configuración JWT

```json
"Jwt": {
  "Key": "EstaEsUnaClaveMuySeguraDeMinimo32Caracteres123",
  "Issuer": "API_Tecnywe",
  "Audience": "API_TecnyweUsers",
  "ExpiresInMinutes": 60
}
```

---

## Cómo correr el proyecto

### Visual Studio

1. Abrir la solución
2. Establecer el proyecto como Startup Project
3. Ejecutar migraciones:

   ```powershell
   Update-Database
   ```
4. Ejecutar el proyecto (F5)

---

### Consola (.NET CLI)

```bash
dotnet restore
dotnet build
dotnet ef database update
dotnet run
```

---

## Migraciones

Crear migración:

```bash
dotnet ef migrations add InitialCreate
```

Aplicar migración:

```bash
dotnet ef database update
```

---

## Base de datos

Se crea automáticamente:

* API_TecnyweDb

Tablas:

* Products
* Customers
* Orders
* OrderDetails
* __EFMigrationsHistory

---

## Autenticación JWT

### Login

```http
POST /api/auth/login
```

Body:

```json
{
  "username": "admin",
  "password": "Admin123*"
}
```

Respuesta:

```json
{
  "token": "JWT_TOKEN"
}
```

### Uso del token

Header:

```http
Authorization: Bearer JWT_TOKEN
```

---

## Endpoints

### Auth

* POST /api/auth/login

---

### Products

* GET /api/products
* GET /api/products/{id}
* POST /api/products
* POST /api/products/update
* POST /api/products/delete

Ejemplo crear:

```json
{
  "name": "Mouse Gamer",
  "price": 120.5,
  "stock": 10
}
```

Ejemplo update:

```json
{
  "id": "ID_PRODUCTO",
  "name": "Mouse Pro",
  "price": 150,
  "stock": 8
}
```

Ejemplo delete:

```json
{
  "id": "ID_PRODUCTO"
}
```

---

### Customers

* GET /api/customers
* GET /api/customers/{id}
* POST /api/customers

Ejemplo:

```json
{
  "fullName": "Juan Perez",
  "email": "juan@email.com"
}
```

---

### Orders

* GET /api/orders
* GET /api/orders/{id}
* POST /api/orders

Ejemplo:

```json
{
  "customerId": "ID_CLIENTE",
  "orderDetail": [
    {
      "productId": "ID_PRODUCTO",
      "quantity": 2
    }
  ]
}
```

---

## Reglas de negocio

* Validación de existencia de cliente
* Validación de productos
* Validación de stock
* Descuento de stock al crear pedido
* Cálculo automático del total

---

## Validaciones

Se utilizan DataAnnotations para:

* Campos requeridos
* Formato de email
* Rangos de valores
* Longitud de texto

---

## Manejo de errores

Middleware global que devuelve:

* 400 Bad Request
* 401 Unauthorized
* 404 Not Found
* 500 Internal Server Error

---

## Flujo de prueba recomendado

1. Login para obtener token
2. Autorizar en Swagger o Postman
3. Crear producto
4. Crear cliente
5. Crear pedido
6. Consultar pedido
7. Verificar stock actualizado

---

## Notas

* IDs generados como GUID en formato string
* Endpoints de update y delete implementados como POST con body
* Proyecto orientado a prueba técnica con arquitectura limpia

---

## Autor
Milton Cesar Bolaños Peña
Prueba técnica desarrollada en .NET
