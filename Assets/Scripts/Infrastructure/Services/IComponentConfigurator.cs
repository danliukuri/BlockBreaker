namespace BlockBreaker.Infrastructure.Services
{
    public interface IComponentConfigurator<in TComponent>
    {
        public void Configure(TComponent component);
    }
}