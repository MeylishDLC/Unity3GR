using Core;
using Player.Controller;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        [SerializeField] private KeyCode exitAppKey;
        [SerializeField] private KeyCode reloadSceneKey;

        private Game _game;
        public void Construct(Game game)
        {
            _game = game;
        }
        private void Update()
        {
            ListenAppExit();
            ListenSceneReload();
        }
        private void ListenAppExit()
        {
            if (Input.GetKeyDown(exitAppKey))
            {
                _game.FinishGame();
            }
        }
        private void ListenSceneReload()
        {
            if (Input.GetKeyDown(reloadSceneKey))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
