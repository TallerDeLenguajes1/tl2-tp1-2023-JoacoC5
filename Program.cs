// See https://aka.ms/new-console-template for more information

using Empresa;
using EspacioPedido;

internal class Program
{
    private static void Main(string[] args)
    {
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
                    int num; //Debe coincidir con el indice de la lista arrancando en 1
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
                    num = NumeroPedido();
                    Console.WriteLine("Observacion del pedido: ");
                    obser = Console.ReadLine();
                    empresa.AltaPedido(num, obser, Estado.Pendiente, nomCli, telCli, dirCli, datoDir);
                    break;

                case 2:
                    int numPedido = NumeroPedido();
                    empresa.AsignarPedido(empresa.ListaPedidos[numPedido - 1],
                                            empresa.ListaCadetes[ran.Next(1, empresa.ListaCadetes.Count())]);
                    break;
                case 3:
                    int numPed = NumeroPedido();
                    int cambio;
                    Console.WriteLine("\nEstado actual del pedido: " + empresa.ListaPedidos[numPed - 1].Est);
                    Console.WriteLine("\nIngrese a que estado desea cambiarlo: \n(0 = cancelado, 1 = encamino, 2 = entregado)");
                    int.TryParse(Console.ReadLine(), out cambio);
                    empresa.CambiarEstadoPedido(numPed, cambio);
                    break;
                case 4:
                    int numPedi = NumeroPedido(), cad1, cad2;
                    Console.WriteLine("Cadete actual: ");
                    int.TryParse(Console.ReadLine(), out cad1);
                    Console.WriteLine("Cadete nuevo: ");
                    int.TryParse(Console.ReadLine(), out cad2);
                    empresa.ReasignarPedido(empresa.ListaPedidos[numPedi - 1],
                                            empresa.ListaCadetes[cad1 - 1], empresa.ListaCadetes[cad2 - 1]);
                    break;

            }

        } while (accion != 0);








    }

    private static int NumeroPedido()
    {
        int num;
        Console.WriteLine("Numero del pedido: ");
        int.TryParse(Console.ReadLine(), out num);

        return num;

    }
}

