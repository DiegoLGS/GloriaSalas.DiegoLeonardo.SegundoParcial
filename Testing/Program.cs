using PrimerParcial;

internal class Program
{
    private static void Main(string[] args)
    {
        Mesero meseroUno = new Mesero("Jony", 1111, ETurnos.MañanaPartTime, "Patio", 6);
        Mesero meseroDos = new Mesero("Ferrari", 1211, ETurnos.MañanaPartTime, "Sector A", 8);
        Mesero meseroTres = new Mesero("Abel", 1131, ETurnos.MañanaPartTime, "Sector B", 10);
        Cocinero cocinero = new Cocinero("Pepe", 9555, ETurnos.NochePartTime, "Pasteleria", "Chef Profesional");
        Cajero cajero = new Cajero("Luis", 5000, ETurnos.MañanaFullTime, 2000, 1);
        ListadoEmpleados listaNueva = new ListadoEmpleados();
                

        _ = listaNueva + meseroUno;
        _ = listaNueva + meseroDos;
        _ = listaNueva + meseroTres;
        _ = listaNueva + cajero;

        if(listaNueva + cocinero)
        {
            Console.WriteLine("Agregado con exito");
        }
        else
        {
            Console.WriteLine("No se pudo agregar");
        }

        if (listaNueva + cocinero)
        {
            Console.WriteLine("Agregado con exito");
        }
        else
        {
            Console.WriteLine("No se pudo agregar");
        }

        Console.WriteLine(cocinero.DisponibleHorasExtras);
        cocinero.CambiarDisponibilidadHorasExtras();
        Console.WriteLine(cocinero.DisponibleHorasExtras);
    }
}