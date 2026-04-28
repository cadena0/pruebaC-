# Sistema de Gestión de Complejo Deportivo

## Descripción

Este sistema permite la gestión de usuarios, espacios deportivos y reservas dentro de un complejo deportivo.  
Está desarrollado en **ASP.NET Core MVC** con **C#**, **Entity Framework Core** y **MySQL (Pomelo)**.

El objetivo es reemplazar procesos manuales (agendas y hojas de cálculo) que generan problemas como:

- Doble reserva de espacios deportivos
- Cruce de horarios entre usuarios
- Falta de control de disponibilidad
- Inconsistencias en la información

---

## Tecnologías utilizadas

- ASP.NET Core MVC
- C#
- Entity Framework Core
- Pomelo.EntityFrameworkCore.MySql
- MySQL
- LINQ
- Dependency Injection

---

## Estructura del sistema (Modelo Entidad-Relación)

### Usuario
- Id (PK)
- Nombre
- Documento
- Teléfono
- Email

### Espacio Deportivo
- Id (PK)
- Nombre
- Tipo (Fútbol, Baloncesto, Piscina, etc.)
- Capacidad

### Reserva
- Id (PK)
- Fecha
- HoraInicio
- HoraFin
- Estado (Activa, Cancelada, Finalizada)
- UsuarioId (FK)
- EspacioDeportivoId (FK)

---

## Relaciones

- Un Usuario puede tener muchas Reservas (1:N)
- Un Espacio Deportivo puede tener muchas Reservas (1:N)
- La entidad Reserva relaciona Usuario y Espacio Deportivo

---

## Requisitos del sistema

- .NET 6 o superior
- MySQL Server
- Visual Studio o Visual Studio Code

---

## Instalación y ejecución

### 1. Crear el proyecto

```bash
dotnet new mvc -n ComplejoDeportivo
cd ComplejoDeportivo
```
### 2. instalacion de dependecias
```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Pomelo.EntityFrameworkCore.MySql
```
### 3. arrancar el proyecto 
```bash
dotnet run
```
## Funcionalidades

### Gestión de usuarios
- Crear usuarios
- Editar usuarios
- Listar usuarios
- Validación de documento y correo único

---

### Gestión de espacios deportivos
- Crear espacios deportivos
- Editar espacios
- Listar espacios
- Validación de duplicados

---

### Gestión de reservas
- Crear reservas con usuario y espacio
- Cancelar reservas
- Listar reservas por usuario
- Listar reservas por espacio

---

### Reglas de negocio
- No se permiten reservas solapadas en el mismo espacio
- Un usuario no puede tener dos reservas en el mismo horario
- No se permiten reservas en el pasado
- El estado de la reserva debe ser consistente

---

### Manejo de errores
- Uso de try-catch en operaciones críticas
- Validaciones de negocio en servicios
- Mensajes de error claros para el usuario

---

### Persistencia de datos
- Uso de Entity Framework Core
- Consultas con LINQ
- Uso de List<> y Dictionary<> en lógica de negocio
- Base de datos MySQL  