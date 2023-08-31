using System.Text.Json;
using System.IO;

public class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;
    private List<Pedido> listadoPedidos;

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }


    public float JornalACobrar()
    {
        float aux = 0;

        foreach (var ped in listadoPedidos)
        {
            if (ped.Est == Pedido.Estado.Entregado)
            {
                aux++;
            }
        }

        aux *= 500;

        return aux;
    }

    public void CambiarEstadoPedido(Pedido pedido, int cambio) // cambio = 0 cancelado, = 1 encamino, = 2 entregado
    {
        if (listadoPedidos.Contains(pedido))
        {
            if (pedido.Est == Pedido.Estado.Pendiente)
            {
                if (cambio == 0)
                {
                    pedido.Est = Pedido.Estado.Cancelado;
                    listadoPedidos.RemoveAt(pedido.Nro);
                }
                else
                {
                    pedido.Est = Pedido.Estado.EnCamino;
                }
            }
            else
            {
                if (pedido.Est == Pedido.Estado.EnCamino)
                {
                    pedido.Est = Pedido.Estado.Entregado;
                    //pasar la info al informe	
                }
            }
        }
    }
}