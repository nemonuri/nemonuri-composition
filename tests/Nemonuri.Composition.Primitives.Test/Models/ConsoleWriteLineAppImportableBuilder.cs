namespace Nemonuri.Composition.Test.Models;

public class ConsoleWriteLineAppImporterBuilder
{
    public ConsoleWriteLineAppImporterBuilder() {}

    public ContractableReceiver<string>.Builder Param0 {get;} = 
        ContractableReceiver<string>.CreateBuilder().WithAdditionalContract(0);

    public ContractableReceiver<string>.Builder Param1 {get;} = 
        ContractableReceiver<string>.CreateBuilder().WithAdditionalContract(1);

    public ContractableReceiver<string>.Builder Param2 {get;} = 
        ContractableReceiver<string>.CreateBuilder().WithAdditionalContract(2);
    
    public ComponentImporter Build()
    {
        return ComponentImporter.CreateBuilder()
            .AddIfNotNull(Param0.BuildOrNull())
            .AddIfNotNull(Param1.BuildOrNull())
            .AddIfNotNull(Param2.BuildOrNull())
            .Build();
    }
}
