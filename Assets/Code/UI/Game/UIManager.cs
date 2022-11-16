using MagariProject.Common;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MagariProject.UI
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField]
        private List<Sprite> _tilesSprites = new();
        [SerializeField]
        private List<GameObject> _newTiles = new();

        #region Player One Hand
        private GameObject _playerOne;

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

        private GameObject _chooseTile;
        private bool _isPlayerOne = true;
        private Button _changePlayer;
        private Button _startMove;

        public bool IsPlayerOne => _isPlayerOne;

        protected override void Awake()
        {
            _playerOne = transform.Find("Player1").gameObject;
            _playerTwo = transform.Find("Player2").gameObject;

            _tile1Image = transform.Find("Player1/TileContainer/Tile1").GetComponent<Image>();
            _tile2Image = transform.Find("Player1/TileContainer/Tile2").GetComponent<Image>();
            _tile3Image = transform.Find("Player1/TileContainer/Tile3").GetComponent<Image>();
            _tile4Image = transform.Find("Player1/TileContainer/Tile4").GetComponent<Image>();
            _tile5Image = transform.Find("Player1/TileContainer/Tile5").GetComponent<Image>();

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

            _playerTwoTile1Image = transform.Find("Player2/TileContainer/Tile1").GetComponent<Image>();
            _playerTwoTile2Image = transform.Find("Player2/TileContainer/Tile2").GetComponent<Image>();
            _playerTwoTile3Image = transform.Find("Player2/TileContainer/Tile3").GetComponent<Image>();
            _playerTwoTile4Image = transform.Find("Player2/TileContainer/Tile4").GetComponent<Image>();
            _playerTwoTile5Image = transform.Find("Player2/TileContainer/Tile5").GetComponent<Image>();

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

            _changePlayer = transform.Find("ChangePlayer").GetComponent<Button>();
            _startMove = transform.Find("StartMovement").GetComponent<Button>();

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

            _changePlayer.onClick.AddListener(ChangePlayer);
            _startMove.onClick.AddListener(EnablePlayerMovemement);
        }

        private void SetSprite(Image image)
        {
            int ranSprite = Random.Range(0, _tilesSprites.Count);
            image.sprite = _tilesSprites[ranSprite];
        }

        private void SetMaterial(Image image)
        {
            _chooseTile = _newTiles.Find(x => x.name == image.sprite.name);
            Debug.Log(_chooseTile);
            image.sprite = null;
            image.gameObject.SetActive(false);

        }

        public void ChangeTile(GameObject tile)
        {
            Manager.Instance.ChangeTile(tile, _chooseTile, 180);
            _chooseTile = null;
        }

        private void SetPlayer()
        {
            if (_isPlayerOne)
            {
                _playerTwo.SetActive(false);
                _playerOne.SetActive(true);
                DrawTile(_playerOneImages);
            }
            else
            {
                _playerTwo.SetActive(true);
                _playerOne.SetActive(false);
                DrawTile(_playerTwoImages);
            }
        }

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

        private void ChangePlayer()
        {
            _isPlayerOne = !_isPlayerOne;
            Manager.Instance.DisableMOvement();
            SetPlayer();
        }

        private void EnablePlayerMovemement()
        {
            if(_isPlayerOne)
            {
                Manager.Instance.PlayerOneMovement();
            }
            else
            {
                Manager.Instance.PlayerTwoMovement();
            }
        }
    }
}