using EspacioToDo;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Tarea> tareasPendientes = new List<Tarea>();
        List<Tarea> tareasRealizadas = new List<Tarea>();

        Console.Write("¿Cuántas tareas desea crear?: ");
        int cantidad = int.Parse(Console.ReadLine());
        tareasPendientes = Tarea.CrearTareasAleatorias(cantidad);

        string opcion;
        do
        {
            Console.WriteLine("\nMenú Principal:");
            Console.WriteLine("1. Ver tareas pendientes");
            Console.WriteLine("2. Ver tareas realizadas");
            Console.WriteLine("3. Mover tarea a realizadas");
            Console.WriteLine("4. Buscar tarea por descripción");
            Console.WriteLine("5. Ver todas las tareas");
            Console.WriteLine("0. Salir");

            Console.Write("Seleccione una opción: ");
            opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    MostrarTareas(tareasPendientes, "Pendientes");
                    break;
                case "2":
                    MostrarTareas(tareasRealizadas, "Realizadas");
                    break;
                case "3":
                    Console.Write("Ingrese el ID de la tarea a mover: ");
                    int id = int.Parse(Console.ReadLine());
                    Tarea tarea = tareasPendientes.Find(t => t.TareaID == id);
                    if (tarea != null)
                    {
                        tareasPendientes.Remove(tarea);
                        tareasRealizadas.Add(tarea);
                        Console.WriteLine("Tarea movida correctamente.");
                    }
                    else
                        Console.WriteLine("Tarea no encontrada.");
                    break;
                case "4":
                    Console.Write("Ingrese descripción a buscar: ");
                    string desc = Console.ReadLine();
                    var resultados = tareasPendientes.FindAll(t => t.Descripcion.Contains(desc));
                    MostrarTareas(resultados, "Coincidencias");
                    break;
                case "5":
                    MostrarTareas(tareasPendientes, "Pendientes");
                    MostrarTareas(tareasRealizadas, "Realizadas");
                    break;
            }
        } while (opcion != "0");
    }

    static void MostrarTareas(List<Tarea> lista, string titulo)
    {
        Console.WriteLine($"\nTareas {titulo}:");
        foreach (var t in lista)
        {
            Console.WriteLine($"ID: {t.TareaID}, Descripción: {t.Descripcion}, Duración: {t.Duracion} minutos");
        }
    }
}