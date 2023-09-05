using BlockBreaker.Infrastructure.Services;
using UnityEngine;

namespace BlockBreaker.Features.UI
{
    public class UIConfigurator : IComponentConfigurator<DefeatTextMarker>
    {
        private readonly GameObject _canvas;
        private readonly Transform _uiRoot;

        public UIConfigurator(GameObject canvas, Transform uiRoot)
        {
            _canvas = canvas;
            _uiRoot = uiRoot;
        }

        public void Configure(DefeatTextMarker component) => Configure(component.transform);

        private void Configure(Transform transform)
        {
            transform.SetParent(_uiRoot, false);
            _canvas.SetActive(true);
        }
    }
}