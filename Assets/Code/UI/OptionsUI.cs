using MagariProject.Common;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace MagariProject.UI
{
    public class OptionsUI : MonoBehaviour
    {
        private Slider _soundSlider;
        private Button _incrementBoardSize;
        private Button _decrementBoardSize;
        private TextMeshProUGUI _boardsize;
        [SerializeField]
        private AudioMixer _mixer;

        private void Awake()
        {
            _soundSlider = transform.Find("MusicSlider").GetComponent<Slider>();
            _incrementBoardSize = transform.Find("Increment").GetComponent<Button>();
            _decrementBoardSize = transform.Find("Decrement").GetComponent<Button>();
            _boardsize = transform.Find("Size").GetComponent<TextMeshProUGUI>();

            _boardsize.text = DataManager.Instance.BoardSize.ToString();
            _soundSlider.value = DataManager.Instance.MusicValue;

            _incrementBoardSize.onClick.AddListener(delegate { SetBoardSize(1); });
            _decrementBoardSize.onClick.AddListener(delegate { SetBoardSize(-1); });

            _soundSlider.onValueChanged.AddListener(delegate { UpdateValueOnChange(_soundSlider.value); });
        }

        private void SetBoardSize(float value)
        {
            DataManager.Instance.BoardSize += value;
            if(DataManager.Instance.BoardSize < 5)
            {
                DataManager.Instance.BoardSize = 5;
            }
            else if(DataManager.Instance.BoardSize > 20)
            {
                DataManager.Instance.BoardSize = 20;
            }

            _boardsize.text = DataManager.Instance.BoardSize.ToString();
        }

        private void UpdateValueOnChange(float value)
        {
            DataManager.Instance.MusicValue = value;
            _mixer.SetFloat("Music", Mathf.Log(value) * 20f);       
        }
    }
}