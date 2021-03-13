using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;

namespace test_arana.wpf.Class
{
    public static class Resources
    {
        public static string GetSO()
        {
            try
            {
                string SOName = string.Empty;
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    SOName = "Windows";
                }
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    SOName = "Linux";
                }
                if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    SOName = "MAC";
                }
                SOName = $"{SOName}|{RuntimeInformation.OSDescription}";
                return SOName;
            }
            catch (Exception)
            {
                return new NotImplementedException("Error No se encontro SO").ToString();
            }
        }
        public static string GetMachine()
        {
            try
            {
                return Environment.MachineName;
            }
            catch (Exception)
            {

                return new NotImplementedException("Error No se encontro Nombre Maquina").ToString();
            }


        }
        public static string GetIP()
        {
            try
            {
                string Ips = string.Empty;
                string Host = Dns.GetHostName();
                IPAddress[] ip = Dns.GetHostAddresses(Host);
                foreach (var item in ip)
                {
                    if (item.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        Ips = item.ToString();
                        break;
                    }
                }
                return Ips;
            }
            catch (Exception)
            {

                return new NotImplementedException("Error No se encontro Nombre Maquina").ToString();
            }


        }
        public static string GetProcesador()
        {
            try
            {
                return RuntimeInformation.ProcessArchitecture.ToString();
            }
            catch (Exception)
            {

                return new NotImplementedException("Error No se encontro Nombre Maquina").ToString();
            }


        }
        public static string GetDD()
        {
            try
            {
                string DiscosDuros = string.Empty;
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    //La unidad C viene con este formato C:\\
                    //espacio disponible
                    long EspacioDisponible = drive.AvailableFreeSpace;
                    //espacio total
                    long EspacioTotal = drive.TotalSize;
                    DiscosDuros += $"{drive.Name} Espacio Disponible: {EspacioDisponible} - Espacio Total: {EspacioTotal}\n";

                }
                return DiscosDuros;
            }
            catch (Exception)
            {

                return new NotImplementedException("Error No se encontro Nombre Maquina").ToString();
            }


        }

        public static string GetMemory()
        {
            try
            {
                var isUnix = RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ||
                     RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

                MemoryMetrics memoria = new MemoryMetrics();
                if (isUnix)
                {
                    memoria = GetUnixMemory();
                }
                else
                {
                    memoria = GetWindowsMetrics();
                }

                return $"TOTAL -> {memoria.Total} MB,  LIBRE->{memoria.Free} MB, USADA -> {memoria.Used} MB";
            }
            catch (Exception)
            {

                return new NotImplementedException("Error No se encontro Nombre Maquina").ToString();
            }


        }


        // Este código es reuitlizado de  https://gunnarpeipman.com/dotnet-core-system-memory/
        private static MemoryMetrics GetUnixMemory()
        {
            var output = "";

            var info = new ProcessStartInfo("free -m");
            info.FileName = "/bin/bash";
            info.Arguments = "-c \"free -m\"";
            info.RedirectStandardOutput = true;

            using (var process = Process.Start(info))
            {
                output = process.StandardOutput.ReadToEnd();
                Console.WriteLine(output);
            }

            var lines = output.Split("\n");
            var memory = lines[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var metrics = new MemoryMetrics();
            metrics.Total = double.Parse(memory[1]);
            metrics.Used = double.Parse(memory[2]);
            metrics.Free = double.Parse(memory[3]);

            return metrics;
        }

        // Este código es reuitlizado de  https://gunnarpeipman.com/dotnet-core-system-memory/
        private static MemoryMetrics GetWindowsMetrics()
        {
            var output = "";

            var info = new ProcessStartInfo();
            info.FileName = "wmic";
            info.Arguments = "OS get FreePhysicalMemory,TotalVisibleMemorySize /Value";
            info.RedirectStandardOutput = true;

            using (var process = Process.Start(info))
            {
                output = process.StandardOutput.ReadToEnd();
            }

            var lines = output.Trim().Split("\n");
            var freeMemoryParts = lines[0].Split("=", StringSplitOptions.RemoveEmptyEntries);
            var totalMemoryParts = lines[1].Split("=", StringSplitOptions.RemoveEmptyEntries);

            var metrics = new MemoryMetrics();
            metrics.Total = Math.Round(double.Parse(totalMemoryParts[1]) / 1024, 0);
            metrics.Free = Math.Round(double.Parse(freeMemoryParts[1]) / 1024, 0);
            metrics.Used = metrics.Total - metrics.Free;

            return metrics;
        }


    }
}
