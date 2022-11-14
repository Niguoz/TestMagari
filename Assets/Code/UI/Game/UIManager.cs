using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField]
    private List<Sprite> _tilesSprites = new();

    private Image _tile1Image;
    private Image _tile2Image;
    private Image _tile3Image;
    private Image _tile4Image;
    private Image _tile5Image;


    protected override void Awake()
    {
        _tile1Image = transform.Find("TileContainer/Tile1").GetComponent<Image>();
        _tile2Image = transform.Find("TileContainer/Tile2").GetComponent<Image>();
        _tile3Image = transform.Find("TileContainer/Tile3").GetComponent<Image>();
        _tile4Image = transform.Find("TileContainer/Tile4").GetComponent<Image>();
        _tile5Image = transform.Find("TileContainer/Tile5").GetComponent<Image>();

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
    }


    private void SetSprite(Image image)
    {
        int ranSprite = Random.Range(0, _tilesSprites.Count);
        image.sprite = _tilesSprites[ranSprite];
    }
}