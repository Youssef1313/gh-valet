using System.CommandLine;

namespace Valet.Commands.Circle;

public class Forecast : ContainerCommand
{
    public Forecast(string[] args) : base(args)
    {
    }

    protected override string Name => "circle-ci";
    protected override string Description => "Forecasts GitHub Actions usage from historical CircleCI pipeline utilization.";

    private static readonly Option<FileInfo[]> SourceFilePath = new("--source-file-path")
    {
        Description = "The file path(s) to existing jobs data.",
        IsRequired = false,
        AllowMultipleArgumentsPerToken = true,
    };

    protected override List<Option> Options => new()
    {
        Common.Organization,
        Common.Project,
        Common.InstanceUrl,
        Common.AccessToken,
        Common.SourceGitHubAccessToken,
        Common.SourceGitHubInstanceUrl,
        SourceFilePath
    };
}
