using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace CircleEater
{
    public class UIController : IDisposable
    {
        private Canvas _uiView;
        private LevelObjectView _playerView;
        
        private int _enemyViewsCount;
        private int _countCircle = 0;
        private Button _restartButton;

        public UIController(Canvas uiView, LevelObjectView playerView, List<LevelObjectView> enemyViews)
        {
            _uiView = uiView;
            _playerView = playerView;
            _enemyViewsCount = enemyViews.Count;
            _restartButton = uiView.GetComponentInChildren<Button>();
            

            _playerView.OnLevelObjectContact += OnLevelObjectContact;
            _restartButton.onClick.AddListener(ClickButtonListener);
            _restartButton.gameObject.SetActive(false);
        }

        private void ClickButtonListener()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("MainScene");
        }
        private void OnLevelObjectContact(LevelObjectView obj)
        {
            if (obj.GetComponent<CircleCollider2D>())
            {
                _countCircle++;
                var text = _uiView.GetComponentInChildren<Text>();
                text.text = _countCircle.ToString();
                if (_countCircle!=_enemyViewsCount) return;
                _restartButton.gameObject.SetActive(true);
                _playerView.gameObject.SetActive(false);
                Time.timeScale = 0;
            }        
        }

        public void Dispose()
        {
            _playerView.OnLevelObjectContact -= OnLevelObjectContact;
        }
    }
}