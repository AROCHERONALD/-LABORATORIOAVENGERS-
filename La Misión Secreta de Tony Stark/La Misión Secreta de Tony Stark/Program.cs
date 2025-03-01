using System;
using System.IO;

class Program
{
    // Ruta del archivo
    static string archivo = "inventos.txt";
    static string directorio = "LaboratorioAvengers";

    static void Main()
    {
        // Crear la carpeta del laboratorio si no existe
        CrearDirectorioSiNoExiste(directorio);

        // Menú interactivo
        bool continuar = true;
        while (continuar)
        {
            MostrarMenu();
            string opcion = Console.ReadLine();
            continuar = ProcesarOpcion(opcion);
        }
    }

    // Método para crear el directorio si no existe
    static void CrearDirectorioSiNoExiste(string path)
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
    }

    // Método para mostrar el menú
    static void MostrarMenu()
    {
        Console.Clear();
        Console.WriteLine("Bienvenido a la misión secreta de Tony Stark.");
        Console.WriteLine("Seleccione una opción:");
        Console.WriteLine("1. Crear archivo de inventos");
        Console.WriteLine("2. Agregar invento");
        Console.WriteLine("3. Leer archivo línea por línea");
        Console.WriteLine("4. Leer todo el archivo");
        Console.WriteLine("5. Copiar archivo");
        Console.WriteLine("6. Mover archivo");
        Console.WriteLine("7. Crear carpeta");
        Console.WriteLine("8. Eliminar archivo");
        Console.WriteLine("9. Listar archivos");
        Console.WriteLine("10. Salir");
        Console.Write("Ingrese una opción: ");
    }

    // Método para procesar la opción seleccionada
    static bool ProcesarOpcion(string opcion)
    {
        switch (opcion)
        {
            case "1":
                CrearArchivo();
                break;
            case "2":
                AgregarInvento();
                break;
            case "3":
                LeerLineaPorLinea();
                break;
            case "4":
                LeerTodoElTexto();
                break;
            case "5":
                CopiarArchivo();
                break;
            case "6":
                MoverArchivo();
                break;
            case "7":
                CrearCarpeta();
                break;
            case "8":
                EliminarArchivo();
                break;
            case "9":
                ListarArchivos();
                break;
            case "10":
                return false;
            default:
                Console.WriteLine("Opción no válida.");
                break;
        }

        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
        return true;
    }

    // 1. Crear un archivo plano
    static void CrearArchivo()
    {
        try
        {
            string rutaCompleta = Path.Combine(directorio, archivo);
            if (!File.Exists(rutaCompleta))
            {
                File.WriteAllText(rutaCompleta, "Inventos de Tony Stark:\n");
                Console.WriteLine("Archivo 'inventos.txt' creado con éxito.");
            }
            else
            {
                Console.WriteLine("El archivo 'inventos.txt' ya existe.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // 2. Agregar líneas al archivo
    static void AgregarInvento()
    {
        try
        {
            string rutaCompleta = Path.Combine(directorio, archivo);
            if (File.Exists(rutaCompleta))
            {
                Console.Write("Ingrese el nombre del invento a agregar: ");
                string invento = Console.ReadLine();
                File.AppendAllText(rutaCompleta, invento + Environment.NewLine);
                Console.WriteLine("Invento agregado exitosamente.");
            }
            else
            {
                Console.WriteLine("Error: El archivo 'inventos.txt' no existe.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // 3. Leer el archivo línea por línea
    static void LeerLineaPorLinea()
    {
        try
        {
            string rutaCompleta = Path.Combine(directorio, archivo);
            if (File.Exists(rutaCompleta))
            {
                string[] lineas = File.ReadAllLines(rutaCompleta);
                foreach (var linea in lineas)
                {
                    Console.WriteLine(linea);
                }
            }
            else
            {
                Console.WriteLine("Error: El archivo 'inventos.txt' no existe.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // 4. Leer todo el texto del archivo
    static void LeerTodoElTexto()
    {
        try
        {
            string rutaCompleta = Path.Combine(directorio, archivo);
            if (File.Exists(rutaCompleta))
            {
                string texto = File.ReadAllText(rutaCompleta);
                Console.WriteLine(texto);
            }
            else
            {
                Console.WriteLine("Error: El archivo 'inventos.txt' no existe.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // 5. Copiar archivo
    static void CopiarArchivo()
    {
        try
        {
            string rutaCompleta = Path.Combine(directorio, archivo);
            if (File.Exists(rutaCompleta))
            {
                string destino = Path.Combine(directorio, "Backup", archivo);
                Directory.CreateDirectory(Path.Combine(directorio, "Backup"));
                File.Copy(rutaCompleta, destino, true);
                Console.WriteLine("Archivo copiado exitosamente.");
            }
            else
            {
                Console.WriteLine("Error: El archivo 'inventos.txt' no existe.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // 6. Mover archivo
    static void MoverArchivo()
    {
        try
        {
            string rutaCompleta = Path.Combine(directorio, archivo);
            if (File.Exists(rutaCompleta))
            {
                string destino = Path.Combine(directorio, "ArchivosClasificados", archivo);
                Directory.CreateDirectory(Path.Combine(directorio, "ArchivosClasificados"));
                File.Move(rutaCompleta, destino);
                Console.WriteLine("Archivo movido exitosamente.");
            }
            else
            {
                Console.WriteLine("Error: El archivo 'inventos.txt' no existe.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // 7. Crear carpeta
    static void CrearCarpeta()
    {
        try
        {
            string nuevaCarpeta = Path.Combine(directorio, "ProyectosSecretos");
            if (!Directory.Exists(nuevaCarpeta))
            {
                Directory.CreateDirectory(nuevaCarpeta);
                Console.WriteLine("Carpeta 'ProyectosSecretos' creada.");
            }
            else
            {
                Console.WriteLine("La carpeta 'ProyectosSecretos' ya existe.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // 8. Eliminar archivo
    static void EliminarArchivo()
    {
        try
        {
            string rutaCompleta = Path.Combine(directorio, archivo);
            if (File.Exists(rutaCompleta))
            {
                File.Delete(rutaCompleta);
                Console.WriteLine("Archivo eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine("Error: El archivo 'inventos.txt' no existe.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // 9. Listar archivos en el directorio
    static void ListarArchivos()
    {
        try
        {
            if (Directory.Exists(directorio))
            {
                string[] archivos = Directory.GetFiles(directorio);
                Console.WriteLine("Archivos en el directorio 'LaboratorioAvengers':");
                foreach (var archivo in archivos)
                {
                    Console.WriteLine(Path.GetFileName(archivo));
                }
            }
            else
            {
                Console.WriteLine("Error: El directorio 'LaboratorioAvengers' no existe.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
