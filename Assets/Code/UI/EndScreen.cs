using MagariProject.Common;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MagariProject.UI
{
    public class EndScreen : MonoBehaviour
    {
        private Button _replayButton;
        private Button _quitButton;
        private TextMeshProUGUI _winnerName;

        private void Awake()
        {
            _replayButton = transform.Find("Replay").GetComponent<Button>();
            _quitButton = transform.Find("Quit").GetComponent<Button>();
            _winnerName = transform.Find("PlayerName").GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            _winnerName.text = Manager.Instance.WinnerName;
            Debug.Log(Manager.Instance.WinnerName);

            _replayButton.onClick.AddListener(Replay);
            _quitButton.onClick.AddListener(QuitGame);
        }

        private void QuitGame()
        {
            Application.Quit();
        }

        private void Replay()
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}