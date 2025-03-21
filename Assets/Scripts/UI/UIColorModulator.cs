using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[ExecuteAlways]
public sealed class UIColorModulator : MonoBehaviour
{
    public Color Color
    {
        get => this._color;
        set => this._color = value;
    }
    
    [FormerlySerializedAs("color")] [SerializeField] private Color _color = Color.white;
    
    private Image[] images;
    private TextMeshProUGUI[] texts;
    
    private void Awake()
    {
        this.images = this.GetComponentsInChildren<Image>();
        this.texts = this.GetComponentsInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        foreach (Image image in this.images)
        {
            image.color = this._color;
        }

        foreach (TextMeshProUGUI text in this.texts)
        {
            text.color = this._color;
        }
    }
}