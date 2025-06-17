namespace EspacioToDo
{
    public class Tarea
    {
        public int TareaID { get; set; }
        public string Descripcion { get; set; }
        public int Duracion { get; set; } // entre 10 y 100

        public Tarea(int id, string descripcion, int duracion)
        {
            TareaID = id;
            Descripcion = descripcion;
            Duracion = duracion;
        }

        public static List<Tarea> CrearTareasAleatorias(int cantidad)
        {
            List<Tarea> lista = new List<Tarea>();
            Random rand = new Random();
            for (int i = 0; i < cantidad; i++)
            {
                int id = i + 1;
                string desc = $"Tarea {id}";
                int duracion = rand.Next(10, 101);
                lista.Add(new Tarea(id, desc, duracion));
            }
            return lista;
        }
    }
}