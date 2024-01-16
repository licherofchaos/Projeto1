using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ColorPickButton : MonoBehaviour
{
    public UnityEvent<Color> ColorPickerEvent;

    [SerializeField] Texture2D colorChart;
    [SerializeField] GameObject chart;
    [SerializeField] RectTransform colorChartRect;
    [SerializeField] RectTransform cursor;
    [SerializeField] Image button;
    [SerializeField] Image cursorColor;

    public void PickColor(BaseEventData data)
    {
        PointerEventData point = data as PointerEventData;

        cursor.position = point.position;

        Vector2 cursorRealPosition = new Vector2(colorChartRect.rect.width / 2 + cursor.localPosition.x, colorChartRect.rect.height / 2 + cursor.localPosition.y);

        Color pickedColor = colorChart.GetPixel((int)(cursorRealPosition.x * (colorChart.width / colorChartRect.rect.width)), (int)(cursorRealPosition.y * (colorChart.height / colorChartRect.rect.height)));
        Debug.Log(pickedColor);
        button.color = pickedColor;
        cursorColor.color = pickedColor;
        ColorPickerEvent.Invoke(pickedColor);
    }
}
