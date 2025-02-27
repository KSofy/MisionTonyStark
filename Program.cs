using System;
using System.IO;

public class InventosTony
{
    public static void Main(string[] args)
    {
        string rutaArchivo = "inventos.txt";
        string carpetaBackup = "Backup";
        string carpetaClasificados = "Archivos Clasificados";
        string carpetaSecretos = "Proyectos Secretos";
        string carpetaLaboratorio = "Laboratorio Avengers";
        
        CrearCarpeta(carpetaLaboratorio);

        while (true) 
        {
            MostrarMenu();
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    CrearArchivo(rutaArchivo);
                    break;
                case "2":
                    AgregarInvento(rutaArchivo);
                    break;
                case "3":
                    LeerLineaPorLinea(rutaArchivo);
                    break;
                case "4":
                    LeerTodoElTexto(rutaArchivo);
                    break;
                case "5":
                    CopiarArchivo(rutaArchivo, carpetaBackup);
                    break;
                case "6":
                    MoverArchivo(rutaArchivo, carpetaClasificados);
                    break;
                case "7":
                    CrearCarpeta(carpetaSecretos);
                    break;
                case "8":
                    ListarArchivos(carpetaLaboratorio);
                    break;
                case "9":
                    EliminarArchivo(rutaArchivo);
                    break;
                case "10":
                    Console.WriteLine("Saliendo del programa...");
                    return;
                default:
                    Console.WriteLine("Opción no válida. Intenta de nuevo.");
                    break;
            }

            Console.WriteLine("Presiona cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    public static void CrearArchivo(string rutaArchivo)
    {
        if (!File.Exists(rutaArchivo))
        {
            File.Create(rutaArchivo).Close();
            Console.WriteLine($"Archivo '{rutaArchivo}' creado.");
        }
    }

    public static void AgregarInvento(string rutaArchivo)
    {
        Console.WriteLine("Tony ingresa el nombre del invento:");
        string invento = Console.ReadLine();
        try
        {
            File.AppendAllText(rutaArchivo, invento + Environment.NewLine);
            Console.WriteLine($"Invento '{invento}' agregado a '{rutaArchivo}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"¡Extraño! Estoy detectando interferencias de ondas desconocidas.Podría se una señal de algo... o simplemente un error: {ex.Message}");
        }
    }

    public static void LeerLineaPorLinea(string rutaArchivo)
    {
        try
        {
            Console.WriteLine("\nInventos (línea por línea):");
            using (StreamReader reader = new StreamReader(rutaArchivo))
            {
                string linea;
                while ((linea = reader.ReadLine()) != null)
                {
                    Console.WriteLine(linea);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al leer línea por línea: {ex.Message}");
        }
    }

    public static void LeerTodoElTexto(string rutaArchivo)
    {
        try
        {
            Console.WriteLine("\nInventos (todo el texto):");
            string contenido = File.ReadAllText(rutaArchivo);
            Console.WriteLine(contenido);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al leer todo el texto: {ex.Message}");
        }
    }

    public static void CopiarArchivo(string rutaArchivo, string carpetaDestino)
    {
        try
        {
            if (!Directory.Exists(carpetaDestino))
            {
                Directory.CreateDirectory(carpetaDestino);
            }
            string rutaDestino = Path.Combine(carpetaDestino, Path.GetFileName(rutaArchivo));
            File.Copy(rutaArchivo, rutaDestino, true);
            Console.WriteLine($"Archivo '{rutaArchivo}' copiado a '{rutaDestino}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al copiar archivo: {ex.Message}");
        }
    }

    public static void MoverArchivo(string rutaArchivo, string carpetaDestino)
    {
        try
        {
            if (!Directory.Exists(carpetaDestino))
            {
                Directory.CreateDirectory(carpetaDestino);
            }
            string rutaDestino = Path.Combine(carpetaDestino, Path.GetFileName(rutaArchivo));
            File.Move(rutaArchivo, rutaDestino);
            Console.WriteLine($"Archivo '{rutaArchivo}' movido a '{rutaDestino}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al mover archivo: {ex.Message}");
        }
    }

    public static void CrearCarpeta(string nombreCarpeta)
    {
        try
        {
            if (!Directory.Exists(nombreCarpeta))
            {
                Directory.CreateDirectory(nombreCarpeta);
                Console.WriteLine($"Carpeta '{nombreCarpeta}' creada.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al crear carpeta: {ex.Message}");
        }
    }

    public static void ListarArchivos(string rutaCarpeta)
    {
        try
        {
            if (Directory.Exists(rutaCarpeta))
            {
                Console.WriteLine($"\nArchivos en '{rutaCarpeta}':");
                string[] archivos = Directory.GetFiles(rutaCarpeta);
                foreach (string archivo in archivos)
                    { 
                    Console.WriteLine(Path.GetFileName(archivo));
                }
            }
            else
            {
                Console.WriteLine($"La carpeta '{rutaCarpeta}' no existe, Ultron pudo estar aquí.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al listar archivos: {ex.Message}");
        } 
    }
    public static void EliminarArchivo(string rutaArchivo)
    {
        try
        {
            if (File.Exists(rutaArchivo))
            {
                File.Delete(rutaArchivo);
                Console.WriteLine($"Tony el archivo ha sido'{rutaArchivo}' eliminado, estás a salvo.");
            }
            else
            {
                Console.WriteLine($"Tony parece que el archivo '{rutaArchivo}' no existe, ten cuidado Ultron puede estar husmeando.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al eliminar el archivo: {ex.Message}" );      
        }
    }

    public static void MostrarMenu()
    {
        Console.WriteLine("Gestión de Archivos");
        Console.WriteLine("--- Menú ---");
        Console.WriteLine("1. Crear archivo");
        Console.WriteLine("2. Agregar invento");
        Console.WriteLine("3. Leer archivo (línea por línea)");
        Console.WriteLine("4. Leer archivo (todo el texto)");
        Console.WriteLine("5. Copiar archivo");
        Console.WriteLine("6. Mover archivo");
        Console.WriteLine("7. Crear carpeta");
        Console.WriteLine("8. Listar archivos");
        Console.WriteLine("9. Eliminar archivo");
        Console.WriteLine("10. Salir");
        Console.Write("Tony selecciona una opción: ");
    }
}