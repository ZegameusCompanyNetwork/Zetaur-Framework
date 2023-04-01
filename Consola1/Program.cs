using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace Zetaur
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Zetaur"; //Establecemos un título a nuestra consola
            const string line = "(c) Zegameus Company Network Records\nZetaur.";
            Console.ForegroundColor = ConsoleColor.Green; //Cambiamos el color de letra a verde
            Console.WriteLine(line);
            Console.WriteLine("\nCargando");
            string[] tmp = GetConfig();
            Console.Write("Obteniendo configuración [.");
            string[] conf = new string[tmp.Length + 1];
            conf[0] = "true";
            Console.Write("...");
            for (int i = 0; i < tmp.Length; i++)
            {
                conf[i + 1] = tmp[i];
                Console.Write("...");

            }
            Console.Write(".]");
            Console.WriteLine("\nCargado con éxito");
            //Ahora declaramos un nombre directo a una clase de otro archivo
            Comandos cmd = new Comandos();
            Console.Clear();
            cmd.Comand(conf);
        }
        static string[] GetConfig()
        {
            string[] config;
            string path = Directory.GetCurrentDirectory();
            Console.WriteLine(path);
            path = path + @"\config.ini";
            Console.WriteLine(path);
            if (File.Exists(path))
            {
                //Si existe el archivo de configuración, lo primero que haremos será leer todas las lineas.
                //Posteriormente asignaremos la longitud del array de configuración al numero leido.
                //Luego cada linea, tendrá la forma "variable = valor".
                string[] tmplines = File.ReadAllLines(path);
                config = new string[tmplines.Length];
                Console.WriteLine("El archivo de configuración existe y tiene como longitud: " + config.Length);
                for (int i = 0; i < tmplines.Length; i++)
                {
                    string tmp = tmplines[i];
                    string[] tmp1 = tmp.Split('=');
                    string[] tmp2 = new string[tmp1.Length];
                    for (int j = 0; j < tmp1.Length; j++)
                    {
                        tmp2[j] = tmp1[j].Trim();
                    }
                    //Console.WriteLine(tmp2[0] + " Tiene como valor:" +tmp2[1]);

                    config[i] = tmp2[1];
                }
                if (SetConfig() == 1){//Hacemos un setConfig para comprobar la version
                    config[tmplines.Length - 1] = "version = " + FileVersionInfo.GetVersionInfo(Directory.GetCurrentDirectory() + @"\Zetaur.exe").FileVersion;
                }
            }
            else
            {
                Console.WriteLine("No se encuentra el archivo de configuración, creando uno para tí.");
                SetConfig();
                string[] downconfig;
                downconfig = DownConfig();
                Debug.WriteLine("El archivo de configuración tiene: " + downconfig.Length);
                config = new string[downconfig.Length];
                config = downconfig;
            }

            return config;
        }
        /// <summary>
        /// Guardamos la configuración y comprobamos si esta es la última version o no.
        /// </summary>
        /// <returns>
        /// <list type="bullet">
        /// <item>0 Si las versiones coinciden</item>
        /// <item>1 Si las versiones son diferentes (hay que volver a leer la config)</item>
        /// <item>-1 Sí ha ocurrido algun error</item>
        /// </list>
        /// </returns>
        static int SetConfig()
        {
            string path = Directory.GetCurrentDirectory();
            if (File.Exists(path + @"\config.ini"))
            {
                Debug.WriteLine("Vamos a comprobar la version");
                //Comprobamos si el contenido local es el mismo que el del servidor
                string[] localLines = File.ReadAllLines(path + @"\config.ini");
                string[] extLines = DownConfig();
                string[] tmplocal = localLines[localLines.Length - 1].Split('=');//Separamos los valores por el igual
                string[] tmpext = extLines[extLines.Length - 1].Split('=');
                tmplocal[0] = tmplocal[0].Trim(); //Quitamos los espacios
                tmplocal[1] = tmplocal[1].Trim();
                Console.WriteLine(tmplocal[0] + "Local " + tmplocal[1] + " " + extLines[extLines.Length - 1]+" servidor");
                
                if (tmplocal[0].Trim() == "version" && tmpext[0].Trim() == "version")
                {
                    //Realizo esta configuración por si está en una version, que no tenía la variable version
                    if (tmplocal[1] != tmpext[1])
                    {
                        //Si las versiones son distintas, comprobamos cual es mayor, si la del servidor o la del cliente. Para ello usamos FileVersionInfo
                        System.Diagnostics.FileVersionInfo file = System.Diagnostics.FileVersionInfo.GetVersionInfo(path + @"\Zetaur.exe");
                        /*la verion está compuesta por MajorPart.MinorPart.BuildPart.PrivatePart
                            MajorPart: es la versión principal X.0
                            MinorPart: es la versión secundaria 1.X
                            BuildPart: es el número de veces compiladas en producción
                            PrivatePart: es el número de veces compiladas en desarrollo o de revisión
                        */
                        if (file.FileVersion != tmplocal[1] || file.FileVersion != tmpext[1])//Si la version local es diferente que la existente en config.ini y es diferente que la del servidor 
                        {
                            Console.WriteLine("Version del ejecutable: " + file.FileVersion);
                            Console.ReadKey();
                            string[] tmp1 = (file.FileVersion.Split('.')); //Separamos las versiones local como la obtenida del servidor por los puntos
                            string[] tmp2 = tmpext[1].Split('.');
                            int[] localVer = new int[4];//Tiene que ser 4 (1.2.0.1 por ejemplo)
                            int[] extVer = new int[4];
                            for (int i = 0; i < tmp1.Length; i++)
                            {
                                localVer[i] = int.Parse(tmp1[i].Trim());
                                extVer[i] = int.Parse(tmp2[i].Trim());
                                if(localVer[i] < extVer[i])
                                {
                                    Console.WriteLine($"Las versiones no son las mismas, hay una nueva versión ({tmpext[1]}).");
                                }
                                else
                                {
                                    string tofile = "";//Iniciamos la cadena de texto donde vamos a ir almacenando la información
                                    for (int j = 0; j < localLines.Length-1; j++)
                                    {
                                        tofile = tofile + localLines[j] + "\n";//a cada linea descargada la concatenamos con lo guardado y un salto de linea
                                    }
                                    tofile = tofile + "version = " + file.FileVersion+"\n";
                                    Debug.WriteLine("He generado la información:\n" + tofile);
                                    File.WriteAllText((path + @"\config.ini"), tofile);//guardamos la información en el archivo config.ini con el contenido generado
                                    return 1;
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("La version es la última");
                        return 0;
                    }
                }
                else
                {
                    //esto es si las primera linea del archivo de configuración y del externo no coinciden
                    string tofile = "";
                    for (int i = 0; i < extLines.Length; i++)
                    {
                        tofile = tofile + extLines[i] + "\n";
                    }
                    File.WriteAllText((path + @"\config.ini"), tofile);
                    return 1;
                }
            }
            else
            {
                string[] lineas = DownConfig();//descargamos la información desde el servidor
                string tofile = "";//Iniciamos la cadena de texto donde vamos a ir almacenando la información
                for (int i = 0; i < lineas.Length; i++)
                {
                    tofile = tofile + lineas[i] + "\n";//a cada linea descargada la concatenamos con lo guardado y un salto de linea
                }
                Debug.WriteLine("He generado la información:\n"+tofile);
                File.WriteAllText((path + @"\config.ini"), tofile);//guardamos la información en el archivo config.ini con el contenido generado
                return 1;

            }
            return -1;
        }
        /// <summary>
        /// Descarga del servidor el archivo de configuración, lo lee y lo devuevle como un string array
        /// </summary>
        /// <returns></returns>
        static string[] DownConfig()
        {
            string[] config;
            try
            {
                WebClient webClient = new WebClient();
                string content = webClient.DownloadString(@"https://raw.githubusercontent.com/ZegameusCompanyNetwork/Zetaur-Framework/master/Consola1/config.ini");
                string[] tmplines = content.Split('\n');
                config = new string[tmplines.Length];
                config = tmplines;
                for (int i = 0; i < config.Length; i++)
                {
                    Console.WriteLine(config[i]);
                }
            }
            catch
            {
                config = new string[0];
                Console.WriteLine("Ocurrió un error descargando la configuración, puede que el servidor esté apagado o no tengas conexión a internet");
            }
            return config;
        }
    }
}
