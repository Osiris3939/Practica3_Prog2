# Práctica 3: Estructuras de Datos (Listas, Pilas y Colas) en C#

**Institución:** Instituto Tecnológico de Las Américas (ITLA)  
**Asignatura:** Programación 2  
**Docente:** Eduandy Isabel Cruz Abreu  
**Estudiante:** Franklyn Enmanuel Santana Rodríguez (Matrícula: 2025-2089)  

---

## Descripción del Proyecto
Este repositorio contiene el desarrollo completo de la Práctica 3 de la asignatura Programación 2. Se trata de una aplicación de consola en C# que implementa un sistema modular con menú principal, submenús especializados y validaciones de datos para la gestión de las tres estructuras de datos fundamentales: Listas (`List<T>`), Colas (`Queue<T>`) y Pilas (`Stack<T>`).

---

## Módulos Implementados

### 1. Lista de Estudiantes (`List<Estudiante>`)
* Definición de la clase `Estudiante` con propiedades `Nombre` y `Calificacion`.
* Registro de nuevos estudiantes validando campos vacíos, rango de calificaciones (0 a 100) y prevención de duplicados.
* Eliminación de estudiantes mediante búsqueda por nombre.
* Visualización completa del listado de estudiantes con formato tabulado.

### 2. Cola de Atención al Cliente - FIFO (`Queue<string>`)
* Gestión de turnos bajo el principio FIFO (*First In, First Out* - Primero en entrar, primero en salir).
* Registro de clientes en orden de llegada mediante el método `Enqueue()`.
* Simulación del proceso de atención mostrando y retirando al primer cliente en turno mediante `Dequeue()`.
* Visualización completa de los clientes en espera.

### 3. Pila de Tareas Pendientes - LIFO (`Stack<string>`)
* Gestión de tareas bajo el principio LIFO (*Last In, First Out* - Último en entrar, primero en salir).
* Inserción de nuevas tareas en el tope de la pila mediante el método `Push()`.
* Marcado de tareas como completadas extrayendo el elemento superior mediante `Pop()`.
* Visualización completa de las tareas pendientes ordenadas desde la más reciente hasta la más antigua.

---

## Cómo Ejecutar el Proyecto

```bash
# 1. Clonar el repositorio
git clone https://github.com/Osiris3939/Practica3_Prog2.git

# 2. Acceder al directorio del proyecto
cd Practica3_Prog2

# 3. Compilar y ejecutar la aplicación
dotnet run
```
