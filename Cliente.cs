using System.Text.Json;
using System.IO;

public class Cliente
{
    private string nombre;
    private string direccion;
    private string telefono;
    private string referenciaDireccion;

    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public string ReferenciaDireccion { get => referenciaDireccion; set => referenciaDireccion = value; }
}