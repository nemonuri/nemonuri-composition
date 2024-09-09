namespace Nemonuri.Composition.Test.Models;

public class ConsoleWriteLineAppImporterBuilder
{
    public ConsoleWriteLineAppImporterBuilder() {}

    public DefaultContractableReceiver<string>.Builder Param0 {get;} = 
        DefaultContractableReceiver<string>.CreateBuilder().WithAdditionalContract(0);

    public DefaultContractableReceiver<string>.Builder Param1 {get;} = 
        DefaultContractableReceiver<string>.CreateBuilder().WithAdditionalContract(1);

    public DefaultContractableReceiver<string>.Builder Param2 {get;} = 
        DefaultContractableReceiver<string>.CreateBuilder().WithAdditionalContract(2);
    
    public DefaultComponentServiceReceiver Build()
    {
        return DefaultComponentServiceReceiver.CreateBuilder()
            .AddIfNotNull(Param0.BuildOrNull())
            .AddIfNotNull(Param1.BuildOrNull())
            .AddIfNotNull(Param2.BuildOrNull())
            .Build();
    }
}
