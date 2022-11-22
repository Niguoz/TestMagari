using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MagariProject.UI
{

    public class MainMenu : MonoBehaviour
    {
        private Button _playButton;
        private Button _tutorialButton;
        private Button _optionsButton;
        private Button _exitButton;
        private Button _back;

        private GameObject _menuContainer;
        private GameObject _optionsContainer;

        private void Awake()
        {
            _menuContainer = transform.Find("Menu").gameObject;
            _playButton = _menuContainer.transform.Find("New Game").GetComponent<Button>();
            _tutorialButton = _menuContainer.transform.Find("Tutorial").GetComponent<Button>();
            _optionsButton = _menuContainer.transform.Find("Options").GetComponent<Button>();
            _exitButton = _menuContainer.transform.Find("Exit").GetComponent<Button>();

            _optionsContainer = transform.Find("Options").gameObject;
            _back = _optionsContainer.transform.Find("Back").GetComponent<Button>();

            _playButton.onClick.AddListener(StartGame);
            _tutorialButton.onClick.AddListener(Tutorial);
            _optionsButton.onClick.AddListener(Options);
            _exitButton.onClick.AddListener(QuitGame);
            _back.onClick.AddListener(Options);
        }


        private void StartGame()
        {
            SceneManager.LoadScene("GameScene");
        }

        private void Tutorial()
        {
            SceneManager.LoadScene("Tutorial");
        }

        private void Options()
        {
            if (_optionsContainer.activeInHierarchy)
            {
                _optionsContainer.SetActive(false);
                _menuContainer.SetActive(true);
            }
            else
            {
                _optionsContainer.SetActive(true);
                _menuContainer.SetActive(false);
            }
        }

        private void QuitGame()
        {
            Application.Quit();
        }
    }
}