public class AllServices
{
    private static AllServices _instance;
    public static AllServices Container => _instance ?? (_instance = new AllServices());

    public void RegisterSingle<TService>(TService implemenation) where TService : IService => 
        Implementaion<TService>.ServiceInstance = implemenation;

    public TService Single<TService>() where TService : IService => 
        Implementaion<TService>.ServiceInstance;

    private static class Implementaion<TService> where TService : IService
    {
        public static TService ServiceInstance;
    }
}