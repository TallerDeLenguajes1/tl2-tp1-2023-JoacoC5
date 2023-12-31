using System.Text.Json;
using System.IO;
using EspacioPedido;

namespace Empresa;

public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> listaCadetes;
    private List<Pedido> listaPedidos;


    public string Nombre { get => nombre; set => nombre = value; }
    //Creo q tanto el atributo nombre como el telefono podrian ser unicamente con get
    public string Telefono { get => telefono; set => telefono = value; }
    public List<Pedido> ListaPedidos { get => listaPedidos; set => listaPedidos = value; }

    public List<Cadete> ListaCadetes { get => listaCadetes; set => listaCadetes = value; }

    public Cadeteria(string nombre, string telefono, List<Cadete> lista)
    {
        this.nombre = nombre;
        this.telefono = telefono;
        this.listaCadetes = new List<Cadete>();
        this.listaCadetes.AddRange(lista);
    }



    public void AgregarCadete(Cadete cadete)
    {
        listaCadetes.Add(cadete);
    }

    public void AsignarPedido(Pedido pedido, Cadete cad)
    {
        if (listaCadetes.Contains(cad))
        {
            cad.ListadoPedidos.Add(pedido);
        }
        else
        {
            listaCadetes.Add(cad);
            cad.ListadoPedidos.Add(pedido);
        }
    }

    public void ReasignarPedido(Pedido pedido, Cadete cad1, Cadete cad2)
    {
        if (cad1.ListadoPedidos.Contains(pedido))
        {
            cad1.ListadoPedidos.RemoveAt(pedido.Nro);
            cad2.ListadoPedidos.Add(pedido);
        }
        else
        {
            cad2.ListadoPedidos.Add(pedido);
        }
    }

    public void AltaPedido(int num, string obser, Estado estado, string nomCLi, string telCLi, string dirCli, string datosDir)
    {
        Pedido auxPedido = new(num, obser, estado, CargarCliente(nomCLi, telCLi, dirCli, datosDir));
        listaPedidos.Add(auxPedido);
    }

    public Cliente CargarCliente(string nombre, string telefono, string direc, string datosDirec)
    {
        Cliente auxCliente = new(nombre, telefono, direc, datosDirec);
        return auxCliente;
    }

    public void CambiarEstadoPedido(int nroPedido, int cambio) // cambio = 0 cancelado, = 1 encamino, = 2 entregado
    {
        foreach (var pedido in listaPedidos)
        {
            if (pedido.Nro == nroPedido)
            {
                if (cambio == 0)
                {
                    pedido.Est = Estado.Cancelado;
                    listaPedidos.RemoveAt(pedido.Nro);
                }
                else
                {
                    if (cambio == 1)
                    {
                        pedido.Est = Estado.EnCamino;
                    }
                    else
                    {
                        if (cambio == 2)
                        {
                            pedido.Est = Estado.Entregado;
                        }
                    }
                }
                break;
            }
        }
    }

    public float Recaudacion()
    {
        float recaudacion = 0;
        foreach (var item in listaCadetes)
        {
            recaudacion += item.JornalACobrar();
        }

        return recaudacion;
    }

    public void MostrarInfo()
    {
        foreach (var item in listaCadetes)
        {
            float aux = item.JornalACobrar();
            Console.WriteLine(item.Nombre);
            Console.WriteLine("Ganacia del cadete: " + aux);

        }
    }

    public void EstadoPedido()
    {
        foreach (var item in listaCadetes)
        {
            Console.WriteLine("Nombre del cadete: " + item.Nombre);
            foreach (var cad in item.ListadoPedidos)
            {
                Console.WriteLine("Pedido nro: " + cad.Nro);
                Console.WriteLine("Estado: " + cad.Est);
            }
            Console.WriteLine("Jornal a cobrar por el cadete: " + item.JornalACobrar());
        }
    }

}


