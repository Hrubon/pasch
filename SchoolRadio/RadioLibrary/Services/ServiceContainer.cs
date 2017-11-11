using System;
using System.Collections.Generic;


public class ServiceContainer
{
    Dictionary<Guid, object> services;



    private Guid LookForService<ST>()
    {
        var guid = typeof(ST).GUID;
        if (!services.ContainsKey(guid))
            throw new InvalidOperationException(string.Format("Container does not contains service of desired type {0}.", typeof(ST).FullName));

        return guid;
    }



    public void AddService<ST>(ST service)
    {
        var guid = typeof(ST).GUID;
        if (services.ContainsKey(guid))
            throw new InvalidOperationException("Conainer already contains service of a same type.");

        services.Add(guid, service);
    }


    public void RemoveService<ST>()
    {
        var guid = LookForService<ST>();
        services.Remove(guid);
    }


    public ST GetService<ST>()
    {
        var guid = LookForService<ST>();
        return (ST)services[guid];
    }



    public ServiceContainer()
    {
        services = new Dictionary<Guid, object>();
    }
}