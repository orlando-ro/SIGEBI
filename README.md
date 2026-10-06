# SIGEBI — Sistema Gestor de Biblioteca

SIGEBI es un sistema para la gestión integral de una biblioteca: administra usuarios, el catálogo bibliográfico, los préstamos y devoluciones, las penalizaciones, las notificaciones y los reportes de auditoría. Está desarrollado en **C# y .NET**, organizado en capas bajo los principios de **Clean Architecture** y **Domain-Driven Design (DDD)**, y ofrece una **API**, una **aplicación web** y una **aplicación de escritorio**.

---

## Módulos principales

| Módulo | Descripción |
|---|---|
| **Gestión de usuarios** | Registro, autenticación y administración de los usuarios del sistema. |
| **Catálogo bibliográfico** | Administración de los recursos y materiales de la biblioteca. |
| **Gestión de préstamos** | Registro y control de los préstamos de recursos. |
| **Devoluciones y penalizaciones** | Registro de devoluciones y aplicación de penalizaciones. |
| **Notificaciones** | Avisos a los usuarios sobre el estado de sus préstamos y otros eventos. |
| **Reportes y auditorías** | Consulta de reportes y trazabilidad de las operaciones del sistema. |

> [COMPLETAR: elimina de la tabla los módulos que no estén implementados y ajusta las descripciones a lo que hace cada uno.]

---

## Arquitectura

El proyecto sigue una arquitectura en capas con separación estricta de responsabilidades:

| Proyecto | Responsabilidad |
|---|---|
| `SIGEBI.Domain` | Entidades, reglas de negocio y lógica del dominio. No depende de ninguna otra capa. |
| `SIGEBI.Application` | Casos de uso, servicios de aplicación y contratos (interfaces). |
| `SIGEBI.Infrastructure` | Acceso a datos con Entity Framework Core y SQL Server, y servicios externos. |
| `SIGEBI.Api` | API que expone la funcionalidad del sistema y gestiona la autenticación con JWT. |
| `SIGEBI.AppWeb` | Aplicación web (cliente del sistema). |
| `SIGEBI.AppEscritorio` | Aplicación de escritorio (cliente del sistema). |

Las dependencias apuntan hacia el dominio: las capas externas conocen a las internas, y el dominio permanece aislado de los detalles tecnológicos.

---

## Tecnologías

- **Lenguaje:** C#
- **Plataforma:** .NET
- **Acceso a datos:** Entity Framework Core
- **Base de datos:** SQL Server
- **Seguridad:** autenticación y autorización con JWT
- [COMPLETAR: otras tecnologías del frontend web y de escritorio, por ejemplo el framework o las librerías que usaste]

## Principios y patrones aplicados

- Programación Orientada a Objetos (POO)
- Principios SOLID
- Patrones de diseño
- Domain-Driven Design (DDD)
- Clean Architecture

---

## Estructura del repositorio

```
SIGEBI/
├── SIGEBI.Api/              # API y autenticación JWT
├── SIGEBI.AppEscritorio/    # Aplicación de escritorio
├── SIGEBI.AppWeb/           # Aplicación web
├── SIGEBI.Application/      # Casos de uso y contratos
├── SIGEBI.Domain/           # Entidades y reglas de negocio
├── SIGEBI.Infrastructure/   # Persistencia (EF Core + SQL Server)
└── SIGEBI.slnx              # Solución
```

---

## Requisitos previos

- SDK de .NET [COMPLETAR: versión]
- SQL Server (local o remoto)
- Git
- Visual Studio o Visual Studio Code

## Cómo ejecutar el proyecto

1. **Clona el repositorio**

   ```bash
   git clone https://github.com/orlando-ro/SIGEBI.git
   cd SIGEBI
   ```

2. **Configura la conexión a la base de datos**

   Ajusta la cadena de conexión de SQL Server y la clave secreta de JWT en la configuración de `SIGEBI.Api`. [COMPLETAR: nombre del archivo y de las claves, por ejemplo `appsettings.json` o variables de entorno]

3. **Crea la base de datos**

   [COMPLETAR: comando de migraciones, por ejemplo `dotnet ef database update --project SIGEBI.Infrastructure --startup-project SIGEBI.Api`]

4. **Ejecuta la API**

   ```bash
   dotnet run --project SIGEBI.Api
   ```

5. **Ejecuta el cliente** [COMPLETAR: indica cómo iniciar `SIGEBI.AppWeb` y `SIGEBI.AppEscritorio`]

---

## Flujo de trabajo con Git

El desarrollo se organiza con ramas:

- `main`: versión estable del proyecto.
- `develop`: rama de integración.
- `feature/*`: una rama por funcionalidad (por ejemplo, `feature/GestionPrestamos`), que se integra a `develop` mediante **Pull Request**.

---

## Autores

- Juan Ramón De Los Santos Ramírez — [COMPLETAR: tus módulos o tu rol en el proyecto]
- [COMPLETAR: demás integrantes del equipo]
