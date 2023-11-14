using System;
using System.Diagnostics;
using System.Threading;

class ProcessMonitor
{
    private static bool monitoramento = true;

    static void Main(string[] args)
    {

        StartMonitoring(args);
    }

    public static void StartMonitoring(string[] args)
    {
        if (args.Length != 3)
        {
            Console.WriteLine("Uso: monitor.exe <monitoramento> <tempo de vida máximo> <frequência de monitoramento>");
            Console.ReadKey();
            return;
        }

        string processo = args[0];
        int duraçãoMáxima = int.Parse(args[1]);
        int frequênciaMonitoramento = int.Parse(args[2]);

        Console.WriteLine($"Monitorando processo: {processo} com tempo de vida máximo de {duraçãoMáxima} minutos, a cada {frequênciaMonitoramento} minutos.");

        monitoramento = true;

        while (monitoramento)
        {
            MonitorandoProcesso(processo, duraçãoMáxima);
            Thread.Sleep(frequênciaMonitoramento * 60 * 1000);
        }
    }

    private static void MonitorandoProcesso(string processo, int duraçãoMáxima)
    {
        Process[] processes = Process.GetProcessesByName(processo);

        foreach (Process processos in processes)
        {
            TimeSpan processoAtual = DateTime.Now - processos.StartTime;

            if (processoAtual.TotalMinutes > duraçãoMáxima)
            {
                Console.WriteLine($"Encerrando o processo {processos.ProcessName} (ID: {processos.Id}) com tempo de vida {processoAtual.TotalMinutes} minutos.");
                processos.Kill();
            }
        }

        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo key = Console.ReadKey(intercept: true);
            if (key.Key == ConsoleKey.Q)
            {
                Console.WriteLine("Monitoramento interrompido.");
                monitoramento = false;
            }
        }
    }
}