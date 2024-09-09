namespace Nemonuri.Composition.Test.Models;

public partial class ConsoleWriteLineApp
{
    private class SettingFacade : IConsoleWriteLineAppSettingFacade
    {
        private readonly ConsoleWriteLineApp _source;

        public SettingFacade(ConsoleWriteLineApp source)
        {
            _source = source;
        }

        public string? Param0 { get => _source.Param0; set => _source.Param0 = value; }
        public string? Param1 { get => _source.Param1; set => _source.Param1 = value; }
        public string? Param2 { get => _source.Param2; set => _source.Param2 = value; }
    }
}
