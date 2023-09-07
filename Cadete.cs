using System.Text.Json;
using System.IO;
using EspacioPedido;

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
            if (ped.Est == Estado.Entregado)
            {
                cont++;
            }
        }

        cont *= 500;

        return cont;
    }


}