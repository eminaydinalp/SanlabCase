using UnityEngine;

namespace Drag
{
    public class Draggable : MonoBehaviour
    {
        [SerializeField] private Camera _mainCamera;

        private Vector3 _mousePosition;

        public bool isDrag;

        private void Awake()
        {
            if (_mainCamera == null)
            {
                _mainCamera = Camera.main;
            }
        }

        private void OnValidate()
        {
            _mainCamera = Camera.main;
        }

        private void OnMouseDown()
        {
            isDrag = true;
            _mousePosition = Input.mousePosition - GetObjectPos();
        }

        private void OnMouseDrag()
        {
            if(!isDrag) return;
            transform.position = _mainCamera.ScreenToWorldPoint(Input.mousePosition - _mousePosition);
        }

        private Vector3 GetObjectPos()
        {
            return _mainCamera.WorldToScreenPoint(transform.position);
        }
    }
}