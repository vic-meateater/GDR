using System.Collections.Generic;
using UnityEngine;

namespace CircleEater
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private LevelObjectView _playerView;
        [SerializeField] private List<LevelObjectView> _enemyViews;

        private PlayerController _playerController;
        private EnemiesController _enemiesController;

        private void Awake()
        {
            _playerController = new PlayerController(_playerView);
            _enemiesController = new EnemiesController(_playerView, _enemyViews);
        }

        private void Update()
        {
            _playerController.Update();
            _enemiesController.Update();
        }

    }
}
