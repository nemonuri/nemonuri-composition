using Nemonuri.Composition.Infrastructure;

namespace Nemonuri.Composition.Test.Models;

public partial class ConsoleWriteLineApp : IComponentServiceReceiver
{
    private readonly DefaultComponentServiceReceiver _importer;

    public ConsoleWriteLineApp(Func<IConsoleWriteLineAppSettingFacade, ConsoleWriteLineAppImporterBuilder, DefaultComponentServiceReceiver>? alterImporterBuilder)
    {
        if (alterImporterBuilder != null)
        {
            _importer = alterImporterBuilder.Invoke(new SettingFacade(this), new ConsoleWriteLineAppImporterBuilder());
        }
        else
        {
            var builder = new ConsoleWriteLineAppImporterBuilder();
            builder.Param0.WithOnReceivedCallback((_, v) => {Param0 = v;});
            builder.Param1.WithOnReceivedCallback((_, v) => {Param1 = v;});
            builder.Param2.WithOnReceivedCallback((_, v) => {Param2 = v;});
            _importer = builder.Build();
        }
    }

    public string? Param0 {get; set;}
    public string? Param1 {get; set;}
    public string? Param2 {get; set;}
    IEnumerable<IContractableReceiver> IComponentServiceReceiver.ContractableReceivers => _importer.ContractableReceivers;

    public string? GetParam(int id) =>
        id switch 
        {
            0 => Param0,
            1 => Param1,
            2 => Param2,
            _ => throw new IndexOutOfRangeException()
        };

    public static IComponentServiceProvider CreateComponentServiceProvider
    (
        Action<DefaultComponentServiceProvider.Builder>? builderConfig = null
    )
    {
        var builder = DefaultComponentServiceProvider.CreateBuilder();
        builderConfig?.Invoke(builder);
        return builder.Build();
    }
}
