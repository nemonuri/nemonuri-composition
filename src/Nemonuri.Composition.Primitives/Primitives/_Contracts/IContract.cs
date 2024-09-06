namespace Nemonuri.Composition.Primitives;

public interface IContract
{
    Type Type {get;}

    object? AdditionalContract {get;}
}
