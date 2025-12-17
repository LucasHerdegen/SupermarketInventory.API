# Supermarket Inventory API

Una API RESTful robusta y escalable diseñada para la gestión de inventario de supermercados, permitiendo administrar productos y categorías de manera eficiente.

Este proyecto fue desarrollado siguiendo las mejores prácticas de la industria, enfocándose en una arquitectura desacoplada, código limpio y mantenibilidad.

## Tecnologías y Herramientas

* **Core:** .NET 8 (C#)
* **ORM:** Entity Framework Core (Code-First Approach)
* **Base de Datos:** SQL Server
* **Mapeo:** AutoMapper
* **Validación:** FluentValidation
* **Documentación:** Swagger UI (OpenAPI)
* **Control de Versiones:** Git & GitHub

## Arquitectura y Patrones de Diseño

El sistema está construido sobre una arquitectura de **N-Capas** para asegurar la separación de responsabilidades:

1.  **Controllers:** Maneja las peticiones HTTP y respuestas.
2.  **Services:** Contiene la lógica de negocio y orquestación.
3.  **Repository:** Abstrae el acceso a datos (Patrón Repositorio Genérico).
4.  **Models:** Contexto de base de datos y entidades.

**Patrones clave implementados:**
* **Repository Pattern:** Para desacoplar la lógica de negocio del acceso a datos.
* **Dependency Injection (DI):** Para promover la testabilidad y flexibilidad.
* **DTOs (Data Transfer Objects):** Para proteger las entidades de dominio y optimizar la transferencia de datos.
* **Asynchronous Programming:** Uso extensivo de `async/await` para I/O no bloqueante.

## Funcionalidades Principales

* **Gestión de Productos:** CRUD completo (Crear, Leer, Actualizar, Borrar) con validaciones de stock y precio.
* **Gestión de Categorías:** Clasificación de productos.
* **Relaciones:** Integridad referencial entre Productos y Categorías.
* **Validaciones Avanzadas:** Reglas de negocio (ej. precios no negativos) aplicadas con FluentValidation.

## Cómo ejecutar el proyecto localmente

### Prerrequisitos
* [.NET 8 SDK](https://dotnet.microsoft.com/download)
* SQL Server (Express, Developer o LocalDB)

### Pasos
1.  **Clonar el repositorio:**
    ```bash
    git clone [https://github.com/LucasHerdegen/SupermarketInventory.API.git](https://github.com/LucasHerdegen/SupermarketInventory.API.git)
    ```

2.  **Configurar la Base de Datos:**
    Abrí el archivo `appsettings.json` y ajustá la cadena de conexión `ConnectionStrings:DefaultConnection` según tu instancia local de SQL Server.

3.  **Aplicar Migraciones:**
    Abrí una terminal en la carpeta del proyecto y ejecutá:
    ```bash
    dotnet ef database update
    ```
    *Esto creará la base de datos y las tablas automáticamente.*

4.  **Ejecutar la API:**
    ```bash
    dotnet run
    ```

5.  **Explorar:**
    Navegá a `http://localhost:5037/swagger` (o el puerto que indique tu consola) para ver la documentación interactiva.
---
**Desarrollado por [Lucas Herdegen](https://github.com/LucasHerdegen)** - *Ingeniería en Sistemas de Información UTN-FRBA*
---
## Esquema de Base de Datos (Entity-Relationship)

```mermaid
erDiagram
    CATEGORY ||--|{ PRODUCT : "contiene"
    
    CATEGORY {
        int Id PK "Primary Key"
        string Name "Nombre de la categoría"
    }

    PRODUCT {
        int Id PK "Primary Key"
        string Name "Nombre del producto"
        decimal Price "Precio unitario"
        int Stock "Cantidad disponible"
        int CategoryId FK "Foreign Key"
    }
