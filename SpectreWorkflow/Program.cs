using System.Net.NetworkInformation;
using System.Net.Sockets;
using Spectre.Console;

AnsiConsole.Write(new FigletText("SpctrWrkflw").Color(Color.Turquoise4));

// var hostName = System.Net.Dns.GetHostName();
// var ips = await System.Net.Dns.GetHostAddressesAsync(hostName);
// foreach (var ip in ips)
// {
//   AnsiConsole.MarkupLine($"[yellow]{ip.ToString()}[/]");
// }


// foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
// {
//   if (item.OperationalStatus == OperationalStatus.Up && item.NetworkInterfaceType != NetworkInterfaceType.Loopback)
//   {
//     foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
//     {
//       // if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
//       // {
//       AnsiConsole.MarkupLine($"{item.Name} [yellow]{ip.Address.ToString()}[/]");
//       // }
//     }
//   }
// }

var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces()
  .Where(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback);

var address = AnsiConsole.Prompt(
  new SelectionPrompt<string>()
      .Title("Select [green]ip address[/] to use for this system")
      .PageSize(10)
      .MoreChoicesText("[grey](Move up and down to reveal more available ip addresses)[/]")
      .AddChoices(networkInterfaces.SelectMany(nic => 
        nic.GetIPProperties().UnicastAddresses.Select(ip => $"{nic.Name} {ip.Address}")
      )));

AnsiConsole.MarkupLine($"Selected IP Address: [yellow]{address}[/]");

var package = AnsiConsole.Prompt(
  new MultiSelectionPrompt<string>()
    .AddChoiceGroup("Base", new []{"Schedule", "Python"})
    .AddChoiceGroup("First", new []{"Database", "WebApp"})
    .AddChoiceGroup("Second", new []{"Database", "Gateway"})
);

AnsiConsole.MarkupLine($"Chosen selection: [yellow]{string.Join(", ", package)}[/]");