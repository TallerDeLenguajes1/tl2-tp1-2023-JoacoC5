using System.Text.Json;
using System.IO;

public class Pedido
{
    private int nro;
    private string obs;
    private Estado est;
    private Cliente cliente;


    public int Nro { get => nro; set => nro = value; }
    public string Obs { get => obs; set => obs = value; }
    public Cliente Cliente { get => cliente; set => cliente = value; }
    internal Estado Est { get => est; set => est = value; }

    public Pedido(int nro, string obs, Estado est, Cliente cliente)
    {
        this.nro = nro;
        this.obs = obs;
        this.est = est;
        this.cliente = cliente;
    }

    public enum Estado
    {
        Pendiente,
        Cancelado,
        EnCamino,
        Entregado,
    }

    private void VerDireccionCliente(Cliente cliente)
    {
        Console.WriteLine("Direccion cliente: " + cliente.Direccion);
    }

    private void VerDatosCliente(Cliente cliente)
    {
        Console.WriteLine("Referencia de direccion: " + cliente.ReferenciaDireccion);
    }


}

