// See https://aka.ms/new-console-template for more information

using Empresa;
using EspacioPedido;

Random ran = new Random();


string archivoCadeterias = @"C:\Repos\TALLER2\tl2-tp1-2023-JoacoC5\Cadeterias.csv";
StreamReader archivo = new StreamReader(archivoCadeterias);
string linea;
string[] nomCadeteria = new string[5];
string[] telCadeteria = new string[5];
Console.WriteLine("LISTADO DE CADETERIAS");
int indice = 0;
while ((linea = archivo.ReadLine()) != null)
{
    string[] fila = linea.Split(",").ToArray();
    nomCadeteria[indice] = fila[0];
    telCadeteria[indice] = fila[1];
    Console.WriteLine("\n Nro: " + indice + " || Cadeteria: " + nomCadeteria[indice] + " || Telefono: " + telCadeteria[indice]);
    indice++;
}

int auxSeleccion, cantCadetes;
Console.WriteLine("\n\nSeleccione la Empresa con la que desea trabajar: ");
int.TryParse(Console.ReadLine(), out auxSeleccion);

archivoCadeterias = @"C:\Repos\TALLER2\tl2-tp1-2023-JoacoC5\Cadetes.csv";
archivo = new StreamReader(archivoCadeterias);
List<Cadete> listaCadetes = new List<Cadete>();
int cont = 1;
while ((linea = archivo.ReadLine()) != null)
{
    string[] fila = linea.Split(",").ToArray();
    //Console.WriteLine(fila[0] + fila[1] + fila[2] + fila[3]);
    Cadete auxCadete = new(cont, fila[1], fila[2], fila[3]);
    listaCadetes.Add(auxCadete);
    cont++;
}

Console.WriteLine("\nIngrese cuantos cadetes tendra la cadeteria: ");
int.TryParse(Console.ReadLine(), out cantCadetes);
List<Cadete> selecCadetes = new List<Cadete>();
for (int i = 0; i < cantCadetes; i++)
{
    selecCadetes.Add(listaCadetes[i]);
}

for (int i = 0; i < cantCadetes; i++)
{

}
Cadeteria empresa = new(nomCadeteria[auxSeleccion], telCadeteria[auxSeleccion], selecCadetes);

//empresa.MostrarCadetes();

int accion = 5;

do
{
    Console.WriteLine("----GESTION DE PEDIDOS----");
    Console.WriteLine("Seleccione la accion a ejecutar: ");
    Console.WriteLine("\n1. Dar de alta pedidos");
    Console.WriteLine("\n2. Asignar pedido a cadete");
    Console.WriteLine("\n3. Cambiar estado de pedido");
    Console.WriteLine("\n4. Reasignar el pedido");
    Console.WriteLine("\n0. Salir");
    int.TryParse(Console.ReadLine(), out accion);

    switch (accion)
    {
        case 1:
            int num;
            string obser, nomCli, telCli, dirCli, datoDir;
            Console.WriteLine("\nCargar info del cliente\n");
            Console.WriteLine("Nombre del ciente: ");
            nomCli = Console.ReadLine();
            Console.WriteLine("Telefono del cliente: ");
            telCli = Console.ReadLine();
            Console.WriteLine("Direccion del cliente: ");
            dirCli = Console.ReadLine();
            Console.WriteLine("Datos extras de la direccion: ");
            datoDir = Console.ReadLine();
            Console.WriteLine("\nCargar info pedido\n");
            Console.WriteLine("Numero del pedido: ");
            num = Console.Read();
            Console.WriteLine("Observacion del pedido: ");
            obser = Console.ReadLine();
            empresa.AltaPedido(num, obser, Estado.Pendiente, nomCli, telCli, dirCli, datoDir);

            break;

    }

} while (accion != 0);









