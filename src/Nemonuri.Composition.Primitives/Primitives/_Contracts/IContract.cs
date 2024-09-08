namespace Nemonuri.Composition.Infrastructure;

public interface IContract
{
    Type Type {get;}

    object? AdditionalContract {get;}
}
