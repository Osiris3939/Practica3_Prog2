using System;
using System.Collections.Generic;
using System.Linq;

namespace Practica3_Prog2
{
    // =========================================================================
    // INSTITUTO TECNOLÓGICO DE LAS AMÉRICAS (ITLA)
    // ASIGNATURA: Programación 2
    // DOCENTE: Eduandy Isabel Cruz Abreu
    // ESTUDIANTE: Franklyn Enmanuel Santana Rodríguez (Matrícula: 2025-2089)
    // PRÁCTICA 3: Estructuras de Datos (Listas, Pilas y Colas)
    // =========================================================================

    /// <summary>
    /// Clase que representa a un estudiante con su nombre completo y calificación.
    /// </summary>
    public class Estudiante
    {
        public string Nombre { get; set; } = string.Empty;
        public double Calificacion { get; set; }

        public Estudiante() { }

        public Estudiante(string nombre, double calificacion)
        {
            Nombre = nombre;
            Calificacion = calificacion;
        }
    }

    class Program
    {
        // Estructuras de datos principales en memoria para los tres módulos
        private static readonly List<Estudiante> listaEstudiantes = new List<Estudiante>();
        private static readonly Queue<string> colaClientes = new Queue<string>();
        private static readonly Stack<string> pilaTareas = new Stack<string>();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "Práctica 3 - Estructuras de Datos (Listas, Pilas y Colas) | ITLA";

            bool continuarEnSistema = true;

            while (continuarEnSistema)
            {
                Console.WriteLine("================================================================================");
                Console.WriteLine("           INSTITUTO TECNOLÓGICO DE LAS AMÉRICAS (ITLA)");
                Console.WriteLine("        PRÁCTICA 3: ESTRUCTURAS DE DATOS (LISTAS, PILAS Y COLAS)");
                Console.WriteLine("         Estudiante: Franklyn Enmanuel Santana Rodríguez (2025-2089)");
                Console.WriteLine("================================================================================");
                Console.WriteLine("MENÚ PRINCIPAL:");
                Console.WriteLine("  1. Módulo de Lista de Estudiantes (List<Estudiante>)");
                Console.WriteLine("  2. Módulo de Cola de Atención al Cliente - FIFO (Queue<string>)");
                Console.WriteLine("  3. Módulo de Pila de Tareas Pendientes - LIFO (Stack<string>)");
                Console.WriteLine("  4. Ejecutar Demostración Completa de los 3 Módulos");
                Console.WriteLine("  0. Salir del sistema");
                Console.WriteLine("--------------------------------------------------------------------------------");
                Console.Write("Seleccione una opción del menú principal: ");

                string? opcion = Console.ReadLine()?.Trim();
                Console.WriteLine();

                switch (opcion)
                {
                    case "1":
                        MenuEstudiantes();
                        break;
                    case "2":
                        MenuColaClientes();
                        break;
                    case "3":
                        MenuPilaTareas();
                        break;
                    case "4":
                        EjecutarDemostracionCompleta();
                        break;
                    case "0":
                        continuarEnSistema = false;
                        Console.WriteLine("Gracias por utilizar el sistema de estructuras de datos. ¡Hasta luego!");
                        break;
                    default:
                        Console.WriteLine("[Aviso]: Opción no válida. Por favor, elija una opción entre 0 y 4.\n");
                        break;
                }
            }
        }

        // =====================================================================
        // MÓDULO 1: LISTA DE ESTUDIANTES (List<Estudiante>)
        // =====================================================================
        private static void MenuEstudiantes()
        {
            bool volverAlMenuPrincipal = false;

            while (!volverAlMenuPrincipal)
            {
                Console.WriteLine("--------------------------------------------------------------------------------");
                Console.WriteLine(">>> SUBMENÚ 1: GESTIÓN DE LISTA DE ESTUDIANTES <<<");
                Console.WriteLine("  1. Agregar nuevo estudiante");
                Console.WriteLine("  2. Eliminar estudiante por nombre");
                Console.WriteLine("  3. Mostrar lista completa de estudiantes");
                Console.WriteLine("  0. Volver al menú principal");
                Console.Write("Seleccione una opción: ");

                string? opcion = Console.ReadLine()?.Trim();
                Console.WriteLine();

                switch (opcion)
                {
                    case "1":
                        AgregarEstudianteInteractivo();
                        break;
                    case "2":
                        EliminarEstudianteInteractivo();
                        break;
                    case "3":
                        MostrarListaEstudiantes();
                        break;
                    case "0":
                        volverAlMenuPrincipal = true;
                        break;
                    default:
                        Console.WriteLine("[Aviso]: Opción no reconocida en el submenú de estudiantes.\n");
                        break;
                }
            }
        }

        private static void AgregarEstudianteInteractivo()
        {
            Console.Write("Ingrese el nombre del estudiante: ");
            string? nombre = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("[Validación]: El nombre del estudiante no puede estar vacío.\n");
                return;
            }

            // Validamos que el estudiante no se encuentre duplicado en la lista
            if (listaEstudiantes.Any(e => e.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine($"[Validación]: Ya existe un estudiante registrado con el nombre '{nombre}'.\n");
                return;
            }

            Console.Write("Ingrese la calificación del estudiante (0 - 100): ");
            string? entradaNota = Console.ReadLine()?.Trim();

            if (!double.TryParse(entradaNota, out double calificacion) || calificacion < 0 || calificacion > 100)
            {
                Console.WriteLine("[Validación]: La calificación debe ser un valor numérico válido entre 0 y 100.\n");
                return;
            }

            listaEstudiantes.Add(new Estudiante(nombre, calificacion));
            Console.WriteLine($"[Éxito]: Estudiante '{nombre}' agregado correctamente con calificación {calificacion:F2}.\n");
        }

        private static void EliminarEstudianteInteractivo()
        {
            if (listaEstudiantes.Count == 0)
            {
                Console.WriteLine("[Validación]: La lista de estudiantes se encuentra vacía actualmente.\n");
                return;
            }

            Console.Write("Ingrese el nombre del estudiante que desea eliminar: ");
            string? nombre = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("[Validación]: Debe indicar un nombre válido para proceder con la eliminación.\n");
                return;
            }

            Estudiante? encontrado = listaEstudiantes.FirstOrDefault(
                e => e.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));

            if (encontrado == null)
            {
                Console.WriteLine($"[Aviso]: No se encontró ningún estudiante con el nombre '{nombre}'.\n");
                return;
            }

            listaEstudiantes.Remove(encontrado);
            Console.WriteLine($"[Éxito]: El estudiante '{encontrado.Nombre}' fue eliminado de la lista.\n");
        }

        private static void MostrarListaEstudiantes()
        {
            if (listaEstudiantes.Count == 0)
            {
                Console.WriteLine("[Información]: No hay estudiantes registrados en la lista en este momento.\n");
                return;
            }

            Console.WriteLine("LISTADO COMPLETO DE ESTUDIANTES REGISTRADOS:");
            for (int i = 0; i < listaEstudiantes.Count; i++)
            {
                Console.WriteLine($"  {i + 1}. Nombre: {listaEstudiantes[i].Nombre,-25} | Calificación: {listaEstudiantes[i].Calificacion:F2}");
            }
            Console.WriteLine();
        }

        // =====================================================================
        // MÓDULO 2: COLA DE ATENCIÓN AL CLIENTE - FIFO (Queue<string>)
        // =====================================================================
        private static void MenuColaClientes()
        {
            bool volverAlMenuPrincipal = false;

            while (!volverAlMenuPrincipal)
            {
                Console.WriteLine("--------------------------------------------------------------------------------");
                Console.WriteLine(">>> SUBMENÚ 2: COLA DE ATENCIÓN AL CLIENTE (FIFO) <<<");
                Console.WriteLine("  1. Agregar cliente a la cola de espera");
                Console.WriteLine("  2. Atender al siguiente cliente en turno");
                Console.WriteLine("  3. Mostrar cola completa de clientes en espera");
                Console.WriteLine("  0. Volver al menú principal");
                Console.Write("Seleccione una opción: ");

                string? opcion = Console.ReadLine()?.Trim();
                Console.WriteLine();

                switch (opcion)
                {
                    case "1":
                        AgregarClienteInteractivo();
                        break;
                    case "2":
                        AtenderClienteInteractivo();
                        break;
                    case "3":
                        MostrarColaClientes();
                        break;
                    case "0":
                        volverAlMenuPrincipal = true;
                        break;
                    default:
                        Console.WriteLine("[Aviso]: Opción no válida en el submenú de atención al cliente.\n");
                        break;
                }
            }
        }

        private static void AgregarClienteInteractivo()
        {
            Console.Write("Ingrese el nombre del cliente que llega a la fila: ");
            string? cliente = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(cliente))
            {
                Console.WriteLine("[Validación]: El nombre del cliente no puede estar en blanco.\n");
                return;
            }

            if (colaClientes.Any(c => c.Equals(cliente, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine($"[Validación]: El cliente '{cliente}' ya se encuentra esperando en la cola.\n");
                return;
            }

            colaClientes.Enqueue(cliente);
            Console.WriteLine($"[Éxito]: Cliente '{cliente}' agregado al final de la cola de espera.\n");
        }

        private static void AtenderClienteInteractivo()
        {
            if (colaClientes.Count == 0)
            {
                Console.WriteLine("[Validación]: No hay clientes en espera dentro de la cola para atender.\n");
                return;
            }

            // Aplicamos el principio FIFO (First In, First Out) mediante Dequeue()
            string clienteAtendido = colaClientes.Dequeue();
            Console.WriteLine($"[Atención en Curso]: Atendiendo y retirando de la fila al cliente: '{clienteAtendido}'.");
            Console.WriteLine($"[Estado]: Quedan {colaClientes.Count} cliente(s) en espera.\n");
        }

        private static void MostrarColaClientes()
        {
            if (colaClientes.Count == 0)
            {
                Console.WriteLine("[Información]: La cola de atención al cliente está vacía actualmente.\n");
                return;
            }

            Console.WriteLine("COLA COMPLETA DE CLIENTES EN ESPERA (Orden de llegada - FIFO):");
            int turno = 1;
            foreach (string cliente in colaClientes)
            {
                Console.WriteLine($"  Turno #{turno}: {cliente}");
                turno++;
            }
            Console.WriteLine();
        }

        // =====================================================================
        // MÓDULO 3: PILA DE TAREAS PENDIENTES - LIFO (Stack<string>)
        // =====================================================================
        private static void MenuPilaTareas()
        {
            bool volverAlMenuPrincipal = false;

            while (!volverAlMenuPrincipal)
            {
                Console.WriteLine("--------------------------------------------------------------------------------");
                Console.WriteLine(">>> SUBMENÚ 3: PILA DE TAREAS PENDIENTES (LIFO) <<<");
                Console.WriteLine("  1. Agregar nueva tarea a la pila");
                Console.WriteLine("  2. Marcar tarea superior como completada (eliminar de la pila)");
                Console.WriteLine("  3. Mostrar lista completa de tareas pendientes");
                Console.WriteLine("  0. Volver al menú principal");
                Console.Write("Seleccione una opción: ");

                string? opcion = Console.ReadLine()?.Trim();
                Console.WriteLine();

                switch (opcion)
                {
                    case "1":
                        AgregarTareaInteractivo();
                        break;
                    case "2":
                        CompletarTareaInteractivo();
                        break;
                    case "3":
                        MostrarPilaTareas();
                        break;
                    case "0":
                        volverAlMenuPrincipal = true;
                        break;
                    default:
                        Console.WriteLine("[Aviso]: Opción no válida en el submenú de tareas pendientes.\n");
                        break;
                }
            }
        }

        private static void AgregarTareaInteractivo()
        {
            Console.Write("Ingrese la descripción de la nueva tarea: ");
            string? descripcion = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(descripcion))
            {
                Console.WriteLine("[Validación]: La descripción de la tarea no puede estar vacía.\n");
                return;
            }

            if (pilaTareas.Any(t => t.Equals(descripcion, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine($"[Validación]: La tarea '{descripcion}' ya se encuentra registrada en la pila.\n");
                return;
            }

            // Aplicamos Push() para colocar la nueva tarea en el tope de la pila
            pilaTareas.Push(descripcion);
            Console.WriteLine($"[Éxito]: Tarea '{descripcion}' agregada en el tope de la pila.\n");
        }

        private static void CompletarTareaInteractivo()
        {
            if (pilaTareas.Count == 0)
            {
                Console.WriteLine("[Validación]: No existen tareas pendientes en la pila para completar.\n");
                return;
            }

            // Aplicamos el principio LIFO (Last In, First Out) mediante Pop()
            string tareaCompletada = pilaTareas.Pop();
            Console.WriteLine($"[Tarea Completada]: Se completó y eliminó de la pila la tarea: '{tareaCompletada}'.");
            Console.WriteLine($"[Estado]: Quedan {pilaTareas.Count} tarea(s) pendiente(s) en la pila.\n");
        }

        private static void MostrarPilaTareas()
        {
            if (pilaTareas.Count == 0)
            {
                Console.WriteLine("[Información]: No hay tareas pendientes en la pila actualmente.\n");
                return;
            }

            Console.WriteLine("LISTA COMPLETA DE TAREAS PENDIENTES EN LA PILA (De más reciente a más antigua - LIFO):");
            int posicion = 1;
            foreach (string tarea in pilaTareas)
            {
                Console.WriteLine($"  [{posicion}] {tarea}");
                posicion++;
            }
            Console.WriteLine();
        }

        // =====================================================================
        // DEMOSTRACIÓN INTEGRAL DE LOS 3 MÓDULOS
        // =====================================================================
        private static void EjecutarDemostracionCompleta()
        {
            Console.WriteLine("================================================================================");
            Console.WriteLine(">>> 1. PRUEBA DEL MÓDULO: LISTA DE ESTUDIANTES (List<Estudiante>) <<<");
            Console.WriteLine("================================================================================");

            listaEstudiantes.Clear();
            listaEstudiantes.Add(new Estudiante("Franklyn Santana", 98.50));
            listaEstudiantes.Add(new Estudiante("Ana Martínez", 92.00));
            listaEstudiantes.Add(new Estudiante("Carlos Gómez", 88.75));
            Console.WriteLine("[Acción]: Se agregaron 3 estudiantes a la lista.\n");

            MostrarListaEstudiantes();

            Console.WriteLine("[Acción]: Eliminando al estudiante 'Carlos Gómez' por nombre...");
            Estudiante? aEliminar = listaEstudiantes.FirstOrDefault(e => e.Nombre == "Carlos Gómez");
            if (aEliminar != null) listaEstudiantes.Remove(aEliminar);
            Console.WriteLine("[Éxito]: Estudiante 'Carlos Gómez' eliminado correctamente.\n");

            MostrarListaEstudiantes();

            Console.WriteLine("================================================================================");
            Console.WriteLine(">>> 2. PRUEBA DEL MÓDULO: COLA DE ATENCIÓN AL CLIENTE - FIFO (Queue<string>) <<<");
            Console.WriteLine("================================================================================");

            colaClientes.Clear();
            colaClientes.Enqueue("María Rodríguez");
            colaClientes.Enqueue("José Alcántara");
            colaClientes.Enqueue("Laura Batista");
            Console.WriteLine("[Acción]: Se registraron 3 clientes en la cola en orden de llegada.\n");

            MostrarColaClientes();

            AtenderClienteInteractivo();
            MostrarColaClientes();

            Console.WriteLine("================================================================================");
            Console.WriteLine(">>> 3. PRUEBA DEL MÓDULO: PILA DE TAREAS PENDIENTES - LIFO (Stack<string>) <<<");
            Console.WriteLine("================================================================================");

            pilaTareas.Clear();
            pilaTareas.Push("Diseñar base de datos del proyecto");
            pilaTareas.Push("Implementar validaciones en C#");
            pilaTareas.Push("Subir repositorio final a GitHub");
            Console.WriteLine("[Acción]: Se apilaron 3 tareas pendientes (LIFO).\n");

            MostrarPilaTareas();

            CompletarTareaInteractivo();
            MostrarPilaTareas();

            Console.WriteLine("================================================================================");
            Console.WriteLine("       ¡DEMOSTRACIÓN DE LOS TRES MÓDULOS COMPLETADA SATISFACTORIAMENTE!");
            Console.WriteLine("================================================================================\n");
        }
    }
}
