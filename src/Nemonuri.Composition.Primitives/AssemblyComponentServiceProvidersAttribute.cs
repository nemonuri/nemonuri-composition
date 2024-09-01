namespace Nemonuri.Composition;

[AttributeUsage(AttributeTargets.Assembly)]
public class AssemblyComponentServiceProvidersAttribute : Attribute 
{
  public Type[] ComponentServiceProviderTypes {get;}

  public AssemblyComponentServiceProvidersAttribute(Type[] componentServiceProviderTypes)
  {
    ComponentServiceProviderTypes = componentServiceProviderTypes ?? [];
  }
}