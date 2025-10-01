
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace Extensions;

public static class ReflectionExtensions
{
    /// <summary>Creates instances of all non-abstract, public types in the specified assembly 
    /// that derive from <typeparamref name="T"/> and have a public parameterless constructor.</summary>
    public static IReadOnlyList<T> GetInstancesOfType<T>(Assembly assembly)
    {
        List<T> instances = [];
        var types = assembly.GetDerivedTypes<T>();

        foreach (var type in types)
        {
            var constructor = type.GetConstructor([]);

            if (constructor is null)
                continue;

            instances.Add((T)Activator.CreateInstance(type)!);
        }

        return instances;
    }

    public static IEnumerable<Type> GetDerivedTypes<TBase>(this Assembly assembly)
    {
        return assembly.GetDerivedTypes(typeof(TBase));
    }

    public static IEnumerable<Type> GetDerivedTypes(this Assembly assembly, Type baseType)
    {
        return assembly.GetTypes()
            .Where(type =>
                baseType.IsAssignableFrom(type) &&
                type != baseType &&
                !type.IsAbstract &&
                !type.IsInterface
            );
    }
}
