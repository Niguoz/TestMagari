using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MagariProject.UI
{
    [RequireComponent(typeof(AudioSource))]
    public class MainMenu : MonoBehaviour
    {
        private Button _playButton;
        private Button _tutorialButton;
        private Button _optionsButton;
        private Button _exitButton;
        private Button _back;

        private GameObject _menuContainer;
        private GameObject _optionsContainer;

        #region Audio
        [SerializeField]
        private AudioClip _clip;
        [SerializeField]
        private AudioMixerGroup _clipGroup;
        private AudioSource _source;
        #endregion

        private void Awake()
        {
            _menuContainer = transform.Find("Menu").gameObject;
            _playButton = _menuContainer.transform.Find("New Game").GetComponent<Button>();
            _tutorialButton = _menuContainer.transform.Find("Tutorial").GetComponent<Button>();
            _optionsButton = _menuContainer.transform.Find("Options").GetComponent<Button>();
            _exitButton = _menuContainer.transform.Find("Exit").GetComponent<Button>();

            _optionsContainer = transform.Find("Options").gameObject;
            _back = _optionsContainer.transform.Find("Back").GetComponent<Button>();

            _source = GetComponent<AudioSource>();
            _source.outputAudioMixerGroup = _clipGroup;

            _playButton.onClick.AddListener(StartGame);
            _tutorialButton.onClick.AddListener(Tutorial);
            _optionsButton.onClick.AddListener(Options);
            _exitButton.onClick.AddListener(QuitGame);
            _back.onClick.AddListener(Options);
        }


        private void StartGame()
        {
            _source.PlayOneShot(_clip);
            SceneManager.LoadScene("GameScene");
        }

        private void Tutorial()
        {
            _source.PlayOneShot(_clip);
            SceneManager.LoadScene("Tutorial");
        }

        private void Options()
        {
            _source.PlayOneShot(_clip);
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
            _source.PlayOneShot(_clip);
            Application.Quit();
        }
    }
}