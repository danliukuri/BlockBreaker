using System;

namespace BlockBreaker.Infrastructure.Services.Input
{
    public interface IPlayerTouchInputService
    {
        event Action OnTouchBegan;
        event Action OnTouchEnded;
        event Action OnTouchHold;
    }
}