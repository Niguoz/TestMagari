using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MagariProject.UI
{
    [RequireComponent(typeof(AudioSource))]
    public class Tutorial : MonoBehaviour
    {
        private GameObject _firstPage;
        private GameObject _secondPage;
        private GameObject _thirdPage;

        private Button _backToMain;
        private Button _startGame;
        private Button _nextButtonPage1;
        private Button _nextButtonPage2;
        private Button _prevButtonPage2;
        private Button _prevButtonPage3;

        #region Audio
        [SerializeField]
        private AudioClip _clip;
        [SerializeField]
        private AudioMixerGroup _clipGroup;
        private AudioSource _source;
        #endregion

        private void Awake()
        {
            _firstPage = transform.Find("InstructionContainer/FirstPage").gameObject;
            _secondPage = transform.Find("InstructionContainer/SecondPage").gameObject;
            _thirdPage = transform.Find("InstructionContainer/ThirdPage").gameObject;

            _backToMain = _firstPage.transform.Find("Main").GetComponent<Button>();
            _nextButtonPage1 = _firstPage.transform.Find("Next").GetComponent<Button>();

            _prevButtonPage2 = _secondPage.transform.Find("Prev").GetComponent<Button>();
            _nextButtonPage2 = _secondPage.transform.Find("Next").GetComponent<Button>();

            _prevButtonPage3 = _thirdPage.transform.Find("Prev").GetComponent<Button>();
            _startGame = _thirdPage.transform.Find("Play").GetComponent<Button>();

            _backToMain.onClick.AddListener(delegate { SceneManager.LoadScene("Main Menu"); });
            _startGame.onClick.AddListener(delegate { SceneManager.LoadScene("GameScene"); });

            _nextButtonPage1.onClick.AddListener(delegate { ChangePage(_secondPage); });
            _nextButtonPage2.onClick.AddListener(delegate { ChangePage(_thirdPage); });
            _prevButtonPage2.onClick.AddListener(delegate { ChangePage(_firstPage); });
            _prevButtonPage3.onClick.AddListener(delegate { ChangePage(_secondPage); });

            _source = GetComponent<AudioSource>();
            _source.outputAudioMixerGroup = _clipGroup;
        }

        /// <summary>
        /// Deactivate all the instruction pages and activate the right one
        /// </summary>
        /// <param name="pageToShow">Page to show</param>
        private void ChangePage(GameObject pageToShow)
        {
            _source.PlayOneShot(_clip);
            _firstPage.SetActive(false);
            _secondPage.SetActive(false);
            _thirdPage.SetActive(false);

            pageToShow.SetActive(true);
        }
    }
}