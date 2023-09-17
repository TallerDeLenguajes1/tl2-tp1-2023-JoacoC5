using System.Text.Json;
using System.IO;
using Empresa;

namespace EspacioDatos;

public class AccesoADatos
{
    public virtual List<Cadeteria> LeerCadeterias()
    {
        return null;
    }

    public virtual List<Cadete> LeerCadetes(int cantidad)
    {
        return null;
    }
}


public class CSV : AccesoADatos
{
    public override List<Cadeteria> LeerCadeterias()
    {
        List<Cadeteria> auxiliar = new List<Cadeteria>();

        string archivoCadeterias = @"C:\Repos\TALLER2\tl2-tp1-2023-JoacoC5\Cadeterias.csv";
        StreamReader archivo = new StreamReader(archivoCadeterias);
        string linea;
        string[] nomCadeteria = new string[5];
        string[] telCadeteria = new string[5];
        int indice = 0;
        while ((linea = archivo.ReadLine()) != null)
        {
            string[] fila = linea.Split(",").ToArray();
            nomCadeteria[indice] = fila[0];
            telCadeteria[indice] = fila[1];
            indice++;
            auxiliar.Add(new(nomCadeteria[indice], telCadeteria[indice], null));
        }


        return auxiliar;
    }


    public override List<Cadete> LeerCadetes(int cantidad)
    {
        string archivoCadetes = @"C:\Repos\TALLER2\tl2-tp1-2023-JoacoC5\Cadetes.csv";
        StreamReader archivo = new StreamReader(archivoCadetes);
        List<Cadete> listaCadetes = new List<Cadete>();
        int cont = 1;
        string linea;
        while ((linea = archivo.ReadLine()) != null)
        {
            string[] fila = linea.Split(",").ToArray();
            Cadete auxCadete = new(cont, fila[1], fila[2], fila[3]);
            listaCadetes.Add(auxCadete);
            cont++;
        }

        List<Cadete> auxiliar = new List<Cadete>();
        for (int i = 0; i < cantidad; i++)
        {
            auxiliar.Add(listaCadetes[i]);
        }


        return auxiliar;
    }
}



public class JSON : AccesoADatos
{
    public override List<Cadeteria> LeerCadeterias()
    {
        string jsonString = File.ReadAllText(@"C:\Repos\TALLER2\tl2-tp1-2023-JoacoC5\Cadeteria.json");
        List<Cadeteria> auxiliar = JsonSerializer.Deserialize<List<Cadeteria>>(jsonString);
        return auxiliar;
    }


    public override List<Cadete> LeerCadetes(int cantidad)
    {
        string jsonString = File.ReadAllText(@"C:\Repos\TALLER2\tl2-tp1-2023-JoacoC5\Cadetes.json");
        List<Cadete> listaCadetes = JsonSerializer.Deserialize<List<Cadete>>(jsonString);

        List<Cadete> auxiliar = new List<Cadete>();
        for (int i = 0; i < cantidad; i++)
        {
            auxiliar.Add(listaCadetes[i]);
        }
        return auxiliar;
    }
}