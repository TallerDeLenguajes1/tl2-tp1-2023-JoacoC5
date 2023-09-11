using System.Text.Json;
using System.IO;
using EspacioPedido;
using Empresa;


class AccesoADatos
{
    public void CargarInforme(Cadeteria cadeteria)
    {
        StreamWriter archivo = new StreamWriter("C:\\Repos\\TALLER2\\tl2-tp1-2023-JoacoC5\\Informe.txt", true);
        archivo.WriteLine("Nombre de la cadeteria: " + cadeteria.Nombre);

        float porcentaje;
        int cantIndividual;
        archivo.WriteLine("\nListado de Cadetes");
        foreach (var item in cadeteria.ListaCadetes)
        {
            archivo.WriteLine("\nId: " + item.Id);
            archivo.WriteLine("Nombre: " + item.Nombre);
            archivo.WriteLine("Telefono: " + item.Telefono);
            archivo.WriteLine("Direccion: " + item.Direccion);
            string jsonString = JsonSerializer.Serialize(item.ListadoPedidos);
            archivo.WriteLine("Listado de Pedidos: \n" + jsonString);
            cantIndividual = item.ListadoPedidos.Count();
            porcentaje = (cantIndividual * 100) / cadeteria.ListaPedidos.Count();
            archivo.WriteLine("\nCantidad de pedidos: " + cantIndividual);
            archivo.WriteLine("Ganacia individual: " + item.JornalACobrar());
            archivo.WriteLine("Porcentaje de pedido: " + porcentaje);


        }

        archivo.WriteLine("\n\nRecaudacion total: " + cadeteria.Recaudacion());

        archivo.Close();
    }
}