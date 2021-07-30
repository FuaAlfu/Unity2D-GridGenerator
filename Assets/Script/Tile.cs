using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2021.7.30
/// </summary>

public class Tile : MonoBehaviour
{
    [SerializeField]
    private Color _baseColor, _offsetColor;

    [SerializeField]
    private SpriteRenderer _renderer;

    //shader, sprite..
    [SerializeField]
    private GameObject _highlight;

    public void Init(bool isoffset)
    {
        _renderer.color = isoffset ? _offsetColor : _baseColor;
    }

    private void OnMouseEnter()
    {
        _highlight.SetActive(true);
    }

    private void OnMouseExit()
    {
        _highlight.SetActive(false);
    }
}
