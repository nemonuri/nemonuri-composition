namespace Nemonuri.Composition.Test;

using Models;

public partial class ComponentServiceReceiverExtensions_FindService_Test
{
    private readonly ITestOutputHelper _output;

    public ComponentServiceReceiverExtensions_FindService_Test(ITestOutputHelper output)
    {
        _output = output;
    }
    
    [Theory]
    [MemberData(nameof(GetMemberData__ConsoleWriteLineApp__Forall_Id_Less_Or_Equal_Than_3__No_Exception))]
    public void ConsoleWriteLineApp__Forall_Id_Less_Than_3__No_Exception(int id)
    {
        // Model
        ConsoleWriteLineApp app = new ConsoleWriteLineApp(null);
        if (!(id < 3)) {throw new InvalidOperationException($"Invalid model. id: {id}");}

        // Act
        var _ = app.GetParam(id);

        // Assert
    }
    public static IEnumerable<object[]> GetMemberData__ConsoleWriteLineApp__Forall_Id_Less_Or_Equal_Than_3__No_Exception() =>
        Enumerable.Range(0, 3).Select(id => new object[]{id});

    [Theory]
    [MemberData(nameof(GetMemberData__ConsoleWriteLineApp__Forall_Id_More_Or_Equal_Than_3__Throwing_Exception))]
    public void ConsoleWriteLineApp__Forall_Id_More_Or_Equal_Than_3__Throws_IndexOutOfRangeException(int id)
    {
        // Model
        ConsoleWriteLineApp app = new ConsoleWriteLineApp(null);
        if (!(id >= 3)) {throw new InvalidOperationException($"Invalid model. id: {id}");}

        // Act
        try
        {
            var _ = app.GetParam(id);
        }
        catch (Exception e)
        {
            Assert.IsType<IndexOutOfRangeException>(e);
            return;
        }

        Assert.Fail($"Should not reach here. id: {id}");
    }
    public static IEnumerable<object[]> GetMemberData__ConsoleWriteLineApp__Forall_Id_More_Or_Equal_Than_3__Throwing_Exception() =>
        Enumerable.Range(3, 7).Select(id => new object[]{id});
    



}
