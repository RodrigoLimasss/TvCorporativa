namespace TvCorporativa.DAL
{
    public static class GetServiceHelper
    {
        public static T GetService<T>()
        {
            return (T) NinjectControllerFactory.Kernel.GetService(typeof (T));
        }
    }
}