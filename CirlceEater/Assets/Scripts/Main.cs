using System.Collections.Generic;
using UnityEngine;

namespace CircleEater
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private LevelObjectView _playerView;
        [SerializeField] private List<LevelObjectView> _enemyViews;
        [SerializeField] private Canvas _uiView;

        private PlayerController _playerController;
        private EnemiesController _enemiesController;
        private UIController _uiController;

        private void Awake()
        {
            _uiController = new UIController(_uiView, _playerView, _enemyViews);
            _playerController = new PlayerController(_playerView);
            _enemiesController = new EnemiesController(_playerView, _enemyViews);
        }

        private void Update()
        {
            _playerController.Update();
        }

    }
}
