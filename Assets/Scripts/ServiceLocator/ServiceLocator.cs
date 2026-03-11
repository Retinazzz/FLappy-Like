using System;
using System.Collections.Generic;

public class ServiceLocator 
{
    private static readonly Dictionary<string, IService> _services = new();

    public static ServiceLocator Current { get; private set; }

    public static void Initialize()
    {
        Current = new ServiceLocator();
    }
    
    public static void Register<T>(T service) where T : IService
    {
        string key = typeof(T).Name;
        _services.Add(key, service);
    }
    
    public static T Get<T>() where T : IService
    {
        string key = typeof(T).Name;
        if (!_services.ContainsKey(key))
        {
            throw new InvalidOperationException();
        }
        return (T)_services[key] ;
    }        
    
    public static void Unregister<T>() where T : IService
    {
        string key = typeof(T).Name;
        _services.Remove(key);
    }
        
    public static void Clear()
    {
        _services.Clear();
    }
}
