using MagariProject.Common;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MagariProject.UI
{
    [RequireComponent(typeof(AudioSource))]
    public class EndScreen : MonoBehaviour
    {
        private Button _replayButton;
        private Button _quitButton;
        private TextMeshProUGUI _winnerName;

        #region Audio
        [SerializeField]
        private AudioClip _clip;
        [SerializeField]
        private AudioMixerGroup _clipGroup;
        private AudioSource _source;
        #endregion

        private void Awake()
        {
            _replayButton = transform.Find("Replay").GetComponent<Button>();
            _quitButton = transform.Find("Quit").GetComponent<Button>();
            _winnerName = transform.Find("PlayerName").GetComponent<TextMeshProUGUI>();
            _source = GetComponent<AudioSource>();
            _source.outputAudioMixerGroup = _clipGroup;
        }

        private void Start()
        {
            _winnerName.text = DataManager.Instance.WinnerName;

            _replayButton.onClick.AddListener(Replay);
            _quitButton.onClick.AddListener(QuitGame);
        }

        private void QuitGame()
        {
            _source.PlayOneShot(_clip);
            Application.Quit();
        }

        private void Replay()
        {
            _source.PlayOneShot(_clip);
            SceneManager.LoadScene("GameScene");
        }
    }
}