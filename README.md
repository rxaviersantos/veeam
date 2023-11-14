<h1 align="center"> Veeam </h1>

<p align="center">
  Test Task
</p>

<p align="center">
  <img alt="License" src="https://img.shields.io/badge/License-MIT-green.svg">
</p>

Please create a tiny C# utility to monitor Windows processes and kill the processes that work longer than the threshold specified:


This command line utility expects three arguments: a process name, its maximum lifetime (in minutes) and a monitoring frequency (in minutes, as
well). When you run the program, it starts monitoring processes with the frequency specified. If a process of interest lives longer than the allowed
duration, the utility kills the process and adds the corresponding record to the log. When no process exists at any given moment, the utility continues
monitoring (new processes might appear later). The utility stops when a special keyboard button is pressed (say, q).


Here is the example: monitor.exe notepad 5 1 – every other minute, the program verifies if a notepad process lives longer than 5 minutes, and if it does, the program kills the process.


When the first part of the task is completed, please cover the code with NUnit tests that you find necessary for this program.

---------

### Resumo do Projeto: Monitor de Processos com Limite de Tempo

Este projeto consiste em um utilitário de linha de comando para monitorar processos no sistema operacional Windows e encerrá-los automaticamente se excederem um determinado tempo de vida. O projeto é desenvolvido em C# utilizando o .NET Core 7.0 e NUnit para testes.

### Como Usar:

1. Pré-requisitos:

[.NET Core 7.0 SDK](https://dotnet.microsoft.com/pt-br/download/dotnet/7.0) instalado.

2. Clonar o Repositório:

```bash
git clone https://github.com/seu-usuario/veeam.git
cd ProcessMonitor
```
3. Compilar e Executar:

- Compilar o projeto:

```bash
dotnet build
```
- Ao executar o utilitário (substituir "notepad" pelo nome do processo desejado, 5 pelo tempo de vida máximo e 1 pela frequência de monitoramento):

```bash
dotnet run -- notepad 5 1
```
4. Rodar Testes:

- Executar testes NUnit:

```bash
dotnet test
```











