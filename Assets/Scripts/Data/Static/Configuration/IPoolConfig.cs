namespace BlockBreaker.Data.Static.Configuration
{
    public interface IPoolConfig
    {
        int StartCount { get; }
        int StartCapacity { get; }
        int MaxSize { get; }
        bool ThrowErrorIfItemAlreadyInPoolWhenRelease { get; }
    }
}