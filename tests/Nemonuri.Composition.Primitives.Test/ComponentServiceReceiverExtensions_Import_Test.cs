namespace Nemonuri.Composition.Test;

using Models;
using Nemonuri.Composition.Infrastructure;

public partial class ComponentServiceReceiverExtensions_Import_Test
{
    private readonly ITestOutputHelper _output;

    public ComponentServiceReceiverExtensions_Import_Test(ITestOutputHelper output)
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

    [Theory]
    [MemberData(nameof(GetMemberData__ConsoleWriteLineApp__Forall_AddOn_Import_Result__All_Param_Values_Are_Equal_To_AddOn_Components))]
    public void ConsoleWriteLineApp__Forall_AddOn_Import_Result__All_Param_Values_Are_Equal_To_AddOn_Components
    (
        string? string0,
        string? string1,
        string? string2
    )
    {
        // Model
        ConsoleWriteLineApp app = new ConsoleWriteLineApp(null);
        ConsoleWriteLineAppAddOn addOn = new ConsoleWriteLineAppAddOn
            (
                vComponentA0: string0,
                vComponentA1: string1,
                vComponentA2: string2
            );
        
        // Act
        app.Import(addOn);

        // Assert
        Assert.Equal(string0, app.Param0);
        Assert.Equal(string1, app.Param1);
        Assert.Equal(string2, app.Param2);
    }
    public static IEnumerable<object[]> GetMemberData__ConsoleWriteLineApp__Forall_AddOn_Import_Result__All_Param_Values_Are_Equal_To_AddOn_Components()
    {
        yield return new object[] { Constant.String0, Constant.String1, Constant.String2 };
        yield return new object[] { Constant.String1, Constant.String0, Constant.String2 };
        yield return new object[] { Constant.String2, Constant.String1, Constant.String0 };
        yield return new object[] { Constant.String1, Constant.String1, Constant.String1 };
        yield return new object[] { Constant.String1, Constant.String0, Constant.String1 };
        yield return new object[] { Constant.String2, Constant.String2, null! };
        yield return new object[] { null!, Constant.String1, null! };
        yield return new object[] { Constant.String0, null!, Constant.String2 };
        yield return new object[] { null!, null!, null! };
    }



}
