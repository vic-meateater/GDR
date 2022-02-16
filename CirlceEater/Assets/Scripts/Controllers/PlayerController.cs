using UnityEngine;

namespace CircleEater
{
    public class PlayerController 
    {
        private LevelObjectView _view;

        private GameObject selectedObject;
        private Vector3 offset;

        public PlayerController(LevelObjectView player)
        {
            _view = player;
        }

        private void DragPlayer()
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButtonDown(0))
            {
                var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.collider is BoxCollider2D)
                {
                    Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
                    if (targetObject)
                    {
                        selectedObject = targetObject.transform.gameObject;
                        offset = selectedObject.transform.position - mousePosition;
                    }
                }
            }
            if (selectedObject)
            {
                selectedObject.transform.position = mousePosition + offset;
            }
            if (Input.GetMouseButtonUp(0) && selectedObject)
            {
                selectedObject = null;
            }
        }
        public void Update()
        {
            DragPlayer();
        }
    }
}