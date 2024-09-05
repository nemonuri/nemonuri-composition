namespace Nemonuri.Composition.Test.Models;

public partial class ConsoleWriteLineApp
{
    public ConsoleWriteLineApp(IComponentServiceProvider? provider)
    {
        if (provider == null) {return;}

        Param0 = Importable.Param0.FindService(provider);
        Param1 = Importable.Param1.FindService(provider);
        Param2 = Importable.Param2.FindService(provider);
    }

    public string? Param0 {get;}
    public string? Param1 {get;}
    public string? Param2 {get;}

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
