namespace Nemonuri.Composition.Infrastructure;

public interface IContract
{
    Type TypeContract {get;}

    object? AdditionalContract {get;}
}
