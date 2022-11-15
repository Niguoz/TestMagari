using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField]
    private List<Sprite> _tilesSprites = new();
    [SerializeField]
    private List<GameObject> _newTiles = new();

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


    private GameObject _chooseTile;
    public GameObject ChooseTile => _chooseTile;

    protected override void Awake()
    {
        _tile1Image = transform.Find("Player1/TileContainer/Tile1").GetComponent<Image>();
        _tile2Image = transform.Find("Player1/TileContainer/Tile2").GetComponent<Image>();
        _tile3Image = transform.Find("Player1/TileContainer/Tile3").GetComponent<Image>();
        _tile4Image = transform.Find("Player1/TileContainer/Tile4").GetComponent<Image>();
        _tile5Image = transform.Find("Player1/TileContainer/Tile5").GetComponent<Image>();

        _button1 = _tile1Image.gameObject.GetComponent<Button>();
        _button2 = _tile2Image.gameObject.GetComponent<Button>();
        _button3 = _tile3Image.gameObject.GetComponent<Button>();
        _button4 = _tile4Image.gameObject.GetComponent<Button>();
        _button5 = _tile5Image.gameObject.GetComponent<Button>();


        base.Awake();
    }

    private void Start()
    {
        _tile1Image.gameObject.SetActive(true);
        _tile2Image.gameObject.SetActive(true);
        _tile3Image.gameObject.SetActive(true);
        _tile4Image.gameObject.SetActive(true);
        _tile5Image.gameObject.SetActive(true);

        SetSprite(_tile1Image);
        SetSprite(_tile2Image);
        SetSprite(_tile3Image);
        SetSprite(_tile4Image);
        SetSprite(_tile5Image);

        _button1.onClick.AddListener(delegate { SetMaterial(_tile1Image.sprite); });
        _button2.onClick.AddListener(delegate { SetMaterial(_tile2Image.sprite); });
        _button3.onClick.AddListener(delegate { SetMaterial(_tile3Image.sprite); });
        _button4.onClick.AddListener(delegate { SetMaterial(_tile4Image.sprite); });
        _button5.onClick.AddListener(delegate { SetMaterial(_tile5Image.sprite); });
    }


    private void SetSprite(Image image)
    {
        int ranSprite = Random.Range(0, _tilesSprites.Count);
        image.sprite = _tilesSprites[ranSprite];
    }

    private void SetMaterial(Sprite image)
    {
        _chooseTile = _newTiles.Find(x => x.name == image.name);
        Debug.Log(_chooseTile);
    }

    public void ChangeTile(GameObject tile)
    {
        Manager.Instance.ChangeTile(tile, _chooseTile, 180);
    }
}