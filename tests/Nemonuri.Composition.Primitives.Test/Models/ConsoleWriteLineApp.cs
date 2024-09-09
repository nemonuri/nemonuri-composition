namespace Nemonuri.Composition.Test.Models;

public partial class ConsoleWriteLineApp : IComponentImporter
{
    private readonly ComponentImporter _innerImporter;

    public ConsoleWriteLineApp(Func<IConsoleWriteLineAppSettingFacade, ConsoleWriteLineAppImporterBuilder, ComponentImporter>? alterImporterBuilder)
    {
        if (alterImporterBuilder != null)
        {
            _innerImporter = alterImporterBuilder.Invoke(new SettingFacade(this), new ConsoleWriteLineAppImporterBuilder());
        }
        else
        {
            var builder = new ConsoleWriteLineAppImporterBuilder();
            builder.Param0.WithOnReceivedCallback((_, v) => {Param0 = v;});
            builder.Param1.WithOnReceivedCallback((_, v) => {Param1 = v;});
            builder.Param2.WithOnReceivedCallback((_, v) => {Param2 = v;});
            _innerImporter = builder.Build();
        }
    }

    public string? Param0 {get; set;}
    public string? Param1 {get; set;}
    public string? Param2 {get; set;}
    IEnumerable<IContractableReceiver> IComponentImporter.ContractableReceivers => _innerImporter.ContractableReceivers;

    public string? GetParam(int id) =>
        id switch 
        {
            0 => Param0,
            1 => Param1,
            2 => Param2,
            _ => throw new IndexOutOfRangeException()
        };

    public static IComponentExporter CreateComponentServiceProvider
    (
        Action<ComponentExporter.Builder>? builderConfig = null
    )
    {
        var builder = ComponentExporter.CreateBuilder();
        builderConfig?.Invoke(builder);
        return builder.Build();
    }
}
