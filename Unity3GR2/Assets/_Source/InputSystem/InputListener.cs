using Core;
using Player.Controller;
using UnityEngine;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        [SerializeField] private KeyCode exitAppKey;

        private Game _game;
        public void Construct(Game game)
        {
            _game = game;
        }
        private void Update()
        {
            ListenAppExit();
        }
        private void ListenAppExit()
        {
            if (Input.GetKeyDown(exitAppKey))
            {
                _game.FinishGame();
            }
        }
    }
}
