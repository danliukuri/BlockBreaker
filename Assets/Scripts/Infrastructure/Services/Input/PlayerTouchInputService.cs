using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace BlockBreaker.Infrastructure.Services.Input
{
    public class PlayerTouchInputService : IInitializable, ITickable, IPlayerTouchInputService
    {
        private const int FirstTouchIndex = 0;

        private Dictionary<TouchPhase, Action> _touchHandlingStrategy;

        public event Action OnTouchBegan;
        public event Action OnTouchEnded;
        public event Action OnTouchHold;

        public void Initialize() => _touchHandlingStrategy = new Dictionary<TouchPhase, Action>
        {
            { TouchPhase.Began, () => OnTouchBegan?.Invoke() },
            { TouchPhase.Ended, () => OnTouchEnded?.Invoke() },
            { TouchPhase.Stationary, () => OnTouchHold?.Invoke() }
        };

        public void Tick()
        {
            if (UnityEngine.Input.touchCount > 0)
            {
                Touch touch = UnityEngine.Input.GetTouch(FirstTouchIndex);

                if (_touchHandlingStrategy.TryGetValue(touch.phase, out Action strategy))
                    strategy.Invoke();
            }
        }
    }
}