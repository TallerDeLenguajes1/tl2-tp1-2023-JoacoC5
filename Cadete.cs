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

    public Cadete(int id, string nombre, string direccion, string telefono)
    {
        this.id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
    }


    public float JornalACobrar()
    {
        float cont = 0;

        foreach (var ped in listadoPedidos)
        {
            if (ped.Est == Pedido.Estado.Entregado)
            {
                cont++;
            }
        }

        cont *= 500;

        return cont;
    }

    public void CambiarEstadoPedido(int nroPedido, int cambio) // cambio = 0 cancelado, = 1 encamino, = 2 entregado
    {
        foreach (var pedido in listadoPedidos)
        {
            if (pedido.Nro == nroPedido)
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
                break;
            }
        }
    }
}