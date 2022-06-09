using Spectre.Console;

AnsiConsole.Write(
    new FigletText("Scaffold-demo")
        .LeftAligned()
        .Color(Color.Red));

var answerReadme = AnsiConsole.Confirm("Generate a [green]README[/] file?");

var answerGitIgnore = AnsiConsole.Confirm("Generate a [yellow].gitignore[/] file?");

var framework = AnsiConsole.Prompt(
  new SelectionPrompt<string>()
      .Title("Select [green]test framework[/] to use")
      .PageSize(10)
      .MoreChoicesText("[grey](Move up and down to reveal more frameworks)[/]")
      .AddChoices(new[] {
          "XUnit", "NUnit","MSTest"
      }));

AnsiConsole.MarkupLine($"[green]{framework} selected.[/]");

AnsiConsole.Status()
.Start("Generating project...", ctx =>
{
  if(answerReadme) 
  {
    ctx.Spinner(Spinner.Known.Aesthetic);
    ctx.SpinnerStyle(Style.Parse("green"));

    AnsiConsole.MarkupLine("LOG: Creating README ...");
    Thread.Sleep(1000);
    // Update the status and spinner
    ctx.Status("Next task");
    Thread.Sleep(1000);
    // Update the status and spinner
    ctx.Status("Another task" + Environment.NewLine + "With multiple lines");
    Thread.Sleep(1000);
    // Update the status and spinner
    ctx.Status("And the last task");
  }

  if(answerGitIgnore) 
  {
    ctx.Spinner(Spinner.Known.Dots8Bit);
    ctx.SpinnerStyle(Style.Parse("orange1"));

    AnsiConsole.MarkupLine("LOG: Creating .gitignore ...");
    Thread.Sleep(1000);
    // Update the status and spinner
    ctx.Status("Next task");
  }

  // Simulate some work
  AnsiConsole.MarkupLine("LOG: Configuring test framework...");
  Thread.Sleep(2000);
});

// Synchronous
AnsiConsole.Progress()
    .Start(ctx => 
    {
        // Define tasks
        var task1 = ctx.AddTask("[green]Reticulating splines[/]");
        var task2 = ctx.AddTask("[green]Folding space[/]");

        while(!ctx.IsFinished) 
        {
            task1.Increment(1.5);
            task2.Increment(0.5);
            Thread.Sleep(100);
        }
    });