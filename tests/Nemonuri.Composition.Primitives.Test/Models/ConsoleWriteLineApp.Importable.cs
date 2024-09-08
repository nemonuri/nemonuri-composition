namespace Nemonuri.Composition.Test.Models;

partial class ConsoleWriteLineApp
{
    public static class Importable
    {
        public readonly static IComponentServiceReceiver<string, int> Param0 = new DefaultContractableReceiver<string>(0);

        public readonly static IComponentServiceReceiver<string, int> Param1 = new DefaultComponentServiceReceiver<string, int>(1);

        public readonly static IComponentServiceReceiver<string, int> Param2 = new DefaultComponentServiceReceiver<string, int>(2);
    }
}