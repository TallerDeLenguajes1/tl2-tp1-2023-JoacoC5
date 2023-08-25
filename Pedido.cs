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
}


enum Estado
{
    Pendiente,
    Cancelado,
    Entregado,
}