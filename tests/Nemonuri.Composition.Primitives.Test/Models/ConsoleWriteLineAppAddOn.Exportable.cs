namespace Nemonuri.Composition.Test.Models;

public partial class ConsoleWriteLineAppAddOn
{
    public static class Exportable
    {
        public class ComponentANull(string? v) : ContractableProvider<string?>(v, null);
        public class ComponentA0(string? v) : ContractableProvider<string?>(v, 0);
        public class ComponentA1(string? v) : ContractableProvider<string?>(v, 1);
        public class ComponentA2(string? v) : ContractableProvider<string?>(v, 2);
        public class ComponentA3(string? v) : ContractableProvider<string?>(v, 3);
        public class ComponentA4(string? v) : ContractableProvider<string?>(v, 4);
        public class ComponentA5(string? v) : ContractableProvider<string?>(v, 5);
        public class ComponentAHidden(string? v) : ContractableProvider<string?>(v, 1);
    }
}