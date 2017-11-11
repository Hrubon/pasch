public class MasterContainer
{
    private static ServiceContainer services = new ServiceContainer();



    public static void AddService<ST>(ST service)
    {
        services.AddService<ST>(service);
    }


    public static void RemoveService<ST>()
    {
        services.RemoveService<ST>();
    }


    public static ST GetService<ST>()
    {
        return services.GetService<ST>();
    }
}