// See https://aka.ms/new-console-template for more information

using Empresa;
using EspacioPedido;
using EspacioDatos;

internal class Program
{
    private static void Main(string[] args)
    {
        Random ran = new Random();

        int tipoarchivo;
        Console.WriteLine("Seleccione el tipo de archivo con el que desea trabajar:\n CSV(1) o JSON(2): ");
        int.TryParse(Console.ReadLine(), out tipoarchivo);

        List<Cadeteria> listadoCadeterias = new List<Cadeteria>();
        List<Cadete> listadoCadetes = new List<Cadete>();
        int auxSeleccion, cantCadetes;
        Cadeteria empresaSelec = new(null, null, null);

        if (tipoarchivo == 1)
        {
            CSV archivo = new CSV();
            listadoCadeterias = archivo.LeerCadeterias();
            auxSeleccion = SeleccionEmpresa(listadoCadeterias);
            cantCadetes = CantidadCadetes();

            listadoCadetes = archivo.LeerCadetes(cantCadetes);

            empresaSelec = new(listadoCadeterias[auxSeleccion].Nombre, listadoCadeterias[auxSeleccion].Telefono,
                                listadoCadetes);
        }
        else
        {
            if (tipoarchivo == 2)
            {
                JSON archivo = new JSON();
                listadoCadeterias = archivo.LeerCadeterias();
                auxSeleccion = SeleccionEmpresa(listadoCadeterias);
                cantCadetes = CantidadCadetes();

                listadoCadetes = archivo.LeerCadetes(cantCadetes);

                empresaSelec = new(listadoCadeterias[auxSeleccion].Nombre, listadoCadeterias[auxSeleccion].Telefono,
                                    listadoCadetes);

            }
            else
            {
                Console.WriteLine("\nNo se selecciono una opcion valida");
            }
        }

        if (empresaSelec != null)
        {



            int accion = 5;
            empresaSelec.ListaPedidos = new List<Pedido>();

            do
            {
                Console.WriteLine("\n----GESTION DE PEDIDOS----");
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
                        empresaSelec.AltaPedido(num, obser, Estado.Pendiente, nomCli, telCli, dirCli, datoDir);
                        break;

                    case 2:
                        int numPedido = NumeroPedido();
                        int indicador = ran.Next(1, empresaSelec.ListaCadetes.Count()) - 1;
                        empresaSelec.AsignarPedido(numPedido - 1, indicador);
                        Console.WriteLine("El pedido fue asignado al cadete " + empresaSelec.ListaCadetes[indicador].Nombre);
                        break;
                    case 3:
                        int numPed = NumeroPedido();
                        int cambio;
                        Console.WriteLine("\nEstado actual del pedido: " + empresaSelec.ListaPedidos[numPed - 1].Est);
                        Console.WriteLine("\nIngrese a que estado desea cambiarlo: \n(0 = cancelado, 1 = encamino, 2 = entregado)");
                        int.TryParse(Console.ReadLine(), out cambio);
                        empresaSelec.CambiarEstadoPedido(numPed, cambio);
                        break;
                    case 4:
                        int numPedi = NumeroPedido(), cad1, cad2;
                        Console.WriteLine("Cadete actual: ");
                        int.TryParse(Console.ReadLine(), out cad1);
                        Console.WriteLine("Cadete nuevo: ");
                        int.TryParse(Console.ReadLine(), out cad2);
                        empresaSelec.ReasignarPedido(empresaSelec.ListaPedidos[numPedi - 1],
                                                empresaSelec.ListaCadetes[cad1 - 1], empresaSelec.ListaCadetes[cad2 - 1]);
                        break;

                }

            } while (accion != 0);

            Informe info = new Informe();
            info.CargarInforme(empresaSelec);

        }
    }

    private static int SeleccionEmpresa(List<Cadeteria> listadoCadeterias)
    {
        int num, indice = 0;
        Console.WriteLine("\n\nSeleccione la Empresa con la que desea trabajar: ");
        foreach (var item in listadoCadeterias)
        {
            Console.WriteLine("\n Nro: " + indice + " || Cadeteria: " + item.Nombre + " || Telefono: " + item.Telefono);
            indice++;
        }

        int.TryParse(Console.ReadLine(), out num);

        return num;
    }

    private static int CantidadCadetes()
    {
        int num;
        Console.WriteLine("\nIngrese cuantos cadetes tendra la cadeteria: ");
        int.TryParse(Console.ReadLine(), out num);

        return num;
    }

    private static int NumeroPedido()
    {
        int num;
        Console.WriteLine("Numero del pedido: ");
        int.TryParse(Console.ReadLine(), out num);

        return num;

    }
}

