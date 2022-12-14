using MagariProject.Common;
using MagariProject.Input;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MagariProject.UI
{
    [RequireComponent(typeof(AudioSource))]
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField]
        private List<Sprite> _tilesSprites = new();
        [SerializeField]
        private List<GameObject> _newTiles = new();

        private GameObject _uiGame;
        #region Player One Hand
        private GameObject _playerOne;

        private TextMeshProUGUI _playerOnePhase;

        private Image _tile1Image;
        private Image _tile2Image;
        private Image _tile3Image;
        private Image _tile4Image;
        private Image _tile5Image;

        private Button _button1;
        private Button _button2;
        private Button _button3;
        private Button _button4;
        private Button _button5;

        private List<Image> _playerOneImages = new();
        #endregion

        #region Player Two Hand
        private GameObject _playerTwo;

        private TextMeshProUGUI _playerTwoPhase;

        private Image _playerTwoTile1Image;
        private Image _playerTwoTile2Image;
        private Image _playerTwoTile3Image;
        private Image _playerTwoTile4Image;
        private Image _playerTwoTile5Image;

        private Button _playerTwoButton1;
        private Button _playerTwoButton2;
        private Button _playerTwoButton3;
        private Button _playerTwoButton4;
        private Button _playerTwoButton5;

        private List<Image> _playerTwoImages = new();
        #endregion

        #region Direction
        private Button _spawnUp;
        private Button _spawnDown;
        private Button _spawnLeft;
        private Button _spawnRight;
        private List<Button> _spawnButtons = new();
        private GameObject _buttonContainer;
        #endregion

        #region Pause
        private GameObject _uiPause;
        private GameObject _uiOptions;
        private Button _resume;
        private Button _quit;
        private Button _options;
        private Button _backOptions;
        #endregion

        private GameObject _chooseTile;
        private bool _isPlayerOne = true;
        private Button _changePlayer;
        private Button _startMove;
        private Player _pauseAction;

        public bool IsPlayerOne => _isPlayerOne;

        #region Audio
        [SerializeField]
        private AudioClip _clip;
        [SerializeField]
        private AudioMixerGroup _clipGroup;
        private AudioSource _source;
        #endregion

        protected override void Awake()
        {
            _uiGame = transform.Find("Game").gameObject;

            _playerOne = _uiGame.transform.Find("Player1").gameObject;
            _playerTwo = _uiGame.transform.Find("Player2").gameObject;

            _tile1Image = _uiGame.transform.Find("Player1/TileContainer/Tile1").GetComponent<Image>();
            _tile2Image = _uiGame.transform.Find("Player1/TileContainer/Tile2").GetComponent<Image>();
            _tile3Image = _uiGame.transform.Find("Player1/TileContainer/Tile3").GetComponent<Image>();
            _tile4Image = _uiGame.transform.Find("Player1/TileContainer/Tile4").GetComponent<Image>();
            _tile5Image = _uiGame.transform.Find("Player1/TileContainer/Tile5").GetComponent<Image>();

            _playerOneImages.Add(_tile1Image);
            _playerOneImages.Add(_tile2Image);
            _playerOneImages.Add(_tile3Image);
            _playerOneImages.Add(_tile4Image);
            _playerOneImages.Add(_tile5Image);

            _button1 = _tile1Image.gameObject.GetComponent<Button>();
            _button2 = _tile2Image.gameObject.GetComponent<Button>();
            _button3 = _tile3Image.gameObject.GetComponent<Button>();
            _button4 = _tile4Image.gameObject.GetComponent<Button>();
            _button5 = _tile5Image.gameObject.GetComponent<Button>();

            _playerTwoTile1Image = _uiGame.transform.Find("Player2/TileContainer/Tile1").GetComponent<Image>();
            _playerTwoTile2Image = _uiGame.transform.Find("Player2/TileContainer/Tile2").GetComponent<Image>();
            _playerTwoTile3Image = _uiGame.transform.Find("Player2/TileContainer/Tile3").GetComponent<Image>();
            _playerTwoTile4Image = _uiGame.transform.Find("Player2/TileContainer/Tile4").GetComponent<Image>();
            _playerTwoTile5Image = _uiGame.transform.Find("Player2/TileContainer/Tile5").GetComponent<Image>();

            _playerTwoImages.Add(_playerTwoTile1Image);
            _playerTwoImages.Add(_playerTwoTile2Image);
            _playerTwoImages.Add(_playerTwoTile3Image);
            _playerTwoImages.Add(_playerTwoTile4Image);
            _playerTwoImages.Add(_playerTwoTile5Image);

            _playerTwoButton1 = _playerTwoTile1Image.gameObject.GetComponent<Button>();
            _playerTwoButton2 = _playerTwoTile2Image.gameObject.GetComponent<Button>();
            _playerTwoButton3 = _playerTwoTile3Image.gameObject.GetComponent<Button>();
            _playerTwoButton4 = _playerTwoTile4Image.gameObject.GetComponent<Button>();
            _playerTwoButton5 = _playerTwoTile5Image.gameObject.GetComponent<Button>();

            _buttonContainer = _uiGame.transform.Find("Direction").gameObject;
            _spawnUp = _buttonContainer.transform.Find("Up").gameObject.GetComponent<Button>();
            _spawnDown = _buttonContainer.transform.Find("Down").gameObject.GetComponent<Button>();
            _spawnLeft = _buttonContainer.transform.Find("Left").gameObject.GetComponent<Button>();
            _spawnRight = _buttonContainer.transform.Find("Right").gameObject.GetComponent<Button>();
            _spawnButtons.Add(_spawnUp);
            _spawnButtons.Add(_spawnLeft);
            _spawnButtons.Add(_spawnDown);
            _spawnButtons.Add(_spawnRight);

            _uiPause = transform.Find("Pause").gameObject;
            _uiOptions = transform.Find("Options").gameObject;
            _resume = _uiPause.transform.Find("Resume").GetComponent<Button>();
            _options = _uiPause.transform.Find("Options").GetComponent<Button>();
            _quit = _uiPause.transform.Find("Quit").GetComponent<Button>();
            _backOptions = _uiOptions.transform.Find("Back").GetComponent<Button>();


            _playerOnePhase = _playerOne.transform.Find("Phase").GetComponent<TextMeshProUGUI>();
            _playerTwoPhase = _playerTwo.transform.Find("Phase").GetComponent<TextMeshProUGUI>();

            _changePlayer = _uiGame.transform.Find("ChangePlayer").GetComponent<Button>();
            _startMove = _uiGame.transform.Find("StartMovement").GetComponent<Button>();
            _pauseAction = new();

            _source = GetComponent<AudioSource>();
            _source.outputAudioMixerGroup = _clipGroup;

            base.Awake();
        }

        private void Start()
        {
            SetPlayer();

            _button1.onClick.AddListener(delegate { SetMaterial(_tile1Image); });
            _button2.onClick.AddListener(delegate { SetMaterial(_tile2Image); });
            _button3.onClick.AddListener(delegate { SetMaterial(_tile3Image); });
            _button4.onClick.AddListener(delegate { SetMaterial(_tile4Image); });
            _button5.onClick.AddListener(delegate { SetMaterial(_tile5Image); });

            _playerTwoButton1.onClick.AddListener(delegate { SetMaterial(_playerTwoTile1Image); });
            _playerTwoButton2.onClick.AddListener(delegate { SetMaterial(_playerTwoTile2Image); });
            _playerTwoButton3.onClick.AddListener(delegate { SetMaterial(_playerTwoTile3Image); });
            _playerTwoButton4.onClick.AddListener(delegate { SetMaterial(_playerTwoTile4Image); });
            _playerTwoButton5.onClick.AddListener(delegate { SetMaterial(_playerTwoTile5Image); });

            _buttonContainer.SetActive(false);

            _changePlayer.onClick.AddListener(ChangePlayer);
            _startMove.onClick.AddListener(EnablePlayerMovemement);

            _resume.onClick.AddListener(Resume);
            _quit.onClick.AddListener(Application.Quit);
            _options.onClick.AddListener(OptionsMenu);
            _backOptions.onClick.AddListener(OptionsMenu);
        }

        private void OnEnable()
        {
            _pauseAction.UI.Pause.performed += _ => PauseGame();

            _pauseAction.Enable();
        }

        private void OnDisable()
        {
            _pauseAction.UI.Pause.performed -= _ => PauseGame();

            _pauseAction.Disable();
        }

        /// <summary>
        /// Set a random tile in the player's hand
        /// </summary>
        private void SetSprite(Image image)
        {
            int ranSprite = Random.Range(0, _tilesSprites.Count);
            image.sprite = _tilesSprites[ranSprite];
        }

        /// <summary>
        /// Set the choose tile for the board and removes it from the hand
        /// </summary>
        private void SetMaterial(Image image)
        {
            _source.PlayOneShot(_clip);
            _chooseTile = _newTiles.Find(x => x.name == image.sprite.name);
            image.sprite = null;
            image.gameObject.SetActive(false);
        }

        /// <summary>
        /// Enable the tile's direction choice
        /// </summary>
        public void SetDirectionSpawn(GameObject tile)
        {
            _buttonContainer.SetActive(true);
            _spawnUp.onClick.AddListener(delegate { ChangeTile(tile, 180); });
            _spawnLeft.onClick.AddListener(delegate { ChangeTile(tile, 90); });
            _spawnDown.onClick.AddListener(delegate { ChangeTile(tile, 0); });
            _spawnRight.onClick.AddListener(delegate { ChangeTile(tile, -90); });
        }

        /// <summary>
        /// Set the tile's type and direction and, if the player has no tiles in hand, enable the movement
        /// </summary>
        private void ChangeTile(GameObject tile, float rotation)
        {
            if (_chooseTile != null)
            {
                Manager.Instance.ChangeTile(tile, _chooseTile, rotation);
                _chooseTile = null;
                foreach (Button button in _spawnButtons)
                {
                    button.onClick.RemoveAllListeners();
                }
            }
            _buttonContainer.SetActive(false);

            if (_isPlayerOne)
            {
                if (CheckList(_playerOneImages))
                {
                    EnablePlayerMovemement();
                }
            }
            else
            {
                if (CheckList(_playerTwoImages))
                {
                    EnablePlayerMovemement();
                }
            }
        }

        /// <summary>
        /// Check if the player still has tiles
        /// </summary>
        private bool CheckList(List<Image> list)
        {
            bool allNotActive = true;

            foreach (Image image in list)
            {
                if (image.gameObject.activeInHierarchy)
                {
                    allNotActive = false;
                    break;
                }
            }

            return allNotActive;
        }

        /// <summary>
        /// Change the player UI and fill the player's hand
        /// </summary>
        private void SetPlayer()
        {
            if (_isPlayerOne)
            {
                _playerTwo.SetActive(false);
                _playerOne.SetActive(true);
                _playerOnePhase.text = "Build";
                DrawTile(_playerOneImages);
            }
            else
            {
                _playerTwo.SetActive(true);
                _playerOne.SetActive(false);
                _playerTwoPhase.text = "Build";
                DrawTile(_playerTwoImages);
            }
        }

        /// <summary>
        /// Set a new tile for each tile in hand set to null
        /// </summary>
        private void DrawTile(List<Image> list)
        {
            foreach (Image image in list)
            {
                if (image.sprite == null)
                {
                    image.gameObject.SetActive(true);
                    SetSprite(image);
                }
            }
        }

        public void ChangePlayer()
        {
            _source.PlayOneShot(_clip);
            _isPlayerOne = !_isPlayerOne;
            Manager.Instance.DisableMOvement();
            SetPlayer();
        }

        /// <summary>
        /// enable the players' movements
        /// </summary>
        private void EnablePlayerMovemement()
        {
            _source.PlayOneShot(_clip);
            if (_isPlayerOne)
            {
                Manager.Instance.PlayerOneMovement();
                _playerOnePhase.text = "Move";
            }
            else
            {
                Manager.Instance.PlayerTwoMovement();
                _playerTwoPhase.text = "Move";
            }
        }

        private void PauseGame()
        {
            if (Manager.Instance.CurrentGameState == GameState.Game)
            {
                Manager.Instance.CurrentGameState = GameState.Pause;
                FreezeTime(true);
                _uiPause.SetActive(true);
                _uiGame.SetActive(false);
            }
            else if (Manager.Instance.CurrentGameState == GameState.Pause)
            {
                if (_uiOptions.activeInHierarchy)
                {
                    _uiOptions.SetActive(false);
                    _uiPause.SetActive(true);
                }
                else
                {
                    Resume();
                }
            }
        }

        private void Resume()
        {
            _source.PlayOneShot(_clip);
            _uiGame.SetActive(true);
            _uiOptions.SetActive(false);
            _uiPause.SetActive(false);
            FreezeTime(false);
            Manager.Instance.CurrentGameState = GameState.Game;
        }

        /// <summary>
        /// Manage the timescale of the game and the Car input
        /// </summary>
        /// <param name="activate"> if true freeze game, else defreeze</param>
        private void FreezeTime(bool activate)
        {
            if (activate)
            {
                Time.timeScale = 0;
              
                Manager.Instance.DisableMOvement();
            }
            else
            {
                Time.timeScale = 1;

                Manager.Instance.EnableMovement(_isPlayerOne);
            }
        }

        private void OptionsMenu()
        {
            _source.PlayOneShot(_clip);
            if (_uiOptions.activeInHierarchy)
            {
                _uiOptions.SetActive(false);
                _uiPause.SetActive(true);
            }
            else
            {
                _uiOptions.SetActive(true);
                _uiPause.SetActive(false);
            }
        }
    }
}