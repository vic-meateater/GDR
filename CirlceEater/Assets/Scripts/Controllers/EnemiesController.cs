using System;
using System.Collections.Generic;
using UnityEngine;

namespace CircleEater
{
    public class EnemiesController:IDisposable
    {
        private LevelObjectView _playerView;
        private List<LevelObjectView> _enemyViews;
        
        public EnemiesController(LevelObjectView player, List<LevelObjectView> enemyViews)
        {
            _playerView = player;
            _enemyViews = enemyViews;

            _playerView.OnLevelObjectContact += OnLevelObjectContact;
        }
        
        private void OnLevelObjectContact(LevelObjectView obj)
        {
            if (_enemyViews.Contains(obj))
            {
                GameObject.Destroy(obj.gameObject);
            }
        }

        public void Dispose()
        {
            _playerView.OnLevelObjectContact -= OnLevelObjectContact;
        }
    }
}