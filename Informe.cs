using System.Text.Json;
using System.IO;
using EspacioPedido;
using Empresa;


class Informe
{
    public void CargarInforme(Cadeteria cadeteria)
    {
        StreamWriter archivo = new StreamWriter("C:\\Repos\\TALLER2\\tl2-tp1-2023-JoacoC5\\Informe.txt", true);
        archivo.WriteLine("Nombre de la cadeteria: " + cadeteria.Nombre);

        //float porcentaje;
        //int cantIndividual;
        archivo.WriteLine("\nListado de Pedidos");
        foreach (var item in cadeteria.ListaPedidos)
        {
            archivo.WriteLine("\n Numero de pedido: " + item.Nro);
            archivo.WriteLine("Estado: " + item.Est);
        }
        archivo.WriteLine("\nListado de Cadetes");
        foreach (var item in cadeteria.ListaCadetes)
        {
            archivo.WriteLine("\nID del cadete: " + item.Id);
            archivo.WriteLine("Nombre del cadete: " + item.Nombre);
            //archivo.WriteLine("Ganacia individual: " + cadeteria.JornalACobrar(item.Id));
            //NO SE PASA EL ID POR ALGUNA RAZON
        }

        archivo.WriteLine("\n\nRecaudacion total: " + cadeteria.Recaudacion());

        archivo.Close();
    }
}