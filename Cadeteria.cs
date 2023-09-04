using System.Text.Json;
using System.IO;

namespace Empresa;

public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> listaCadetes;


    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    //public List<Cadete> ListaCadetes { get => listaCadetes; set => listaCadetes = value; }

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

    public void MostrarCadetes()
    {
        foreach (var item in listaCadetes)
        {
            Console.WriteLine(item.Nombre);
        }
    }

}


