namespace Nemonuri.Composition.Test.Models;

public partial class ConsoleWriteLineAppAddOn
{
    public static class Exportable
    {
        public class ComponentANull(string? v) : DefaultContractableProvider<string?>(v, null);
        public class ComponentA0(string? v) : DefaultContractableProvider<string?>(v, 0);
        public class ComponentA1(string? v) : DefaultContractableProvider<string?>(v, 1);
        public class ComponentA2(string? v) : DefaultContractableProvider<string?>(v, 2);
        public class ComponentA3(string? v) : DefaultContractableProvider<string?>(v, 3);
        public class ComponentA4(string? v) : DefaultContractableProvider<string?>(v, 4);
        public class ComponentA5(string? v) : DefaultContractableProvider<string?>(v, 5);
        public class ComponentAHidden(string? v) : DefaultContractableProvider<string?>(v, 1);
    }
}