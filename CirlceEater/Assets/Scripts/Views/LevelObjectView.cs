using System;
using UnityEngine;

namespace CircleEater
{
    [RequireComponent(typeof(Collider2D))]
    public class LevelObjectView : MonoBehaviour
    {
        public Transform _transform;
        public Collider2D _collider;

        public Action<LevelObjectView> OnLevelObjectContact { get; set; }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var levelObject = collision.gameObject.GetComponent<LevelObjectView>();
            OnLevelObjectContact?.Invoke(levelObject);
        }
    }
}