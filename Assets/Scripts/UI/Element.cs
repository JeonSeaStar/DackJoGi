using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Element : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI title;
    public TextMeshProUGUI explain;
    public Button button;
    public int index;
    public RectTransform bgTransform;
    public GameObject highlight;

    public void BoxSize()
    {
        int count = LineCheck();
        for (int i = 0; i < count; i++)
        {
            if (count == 0)
                return;

            if (i != 1)
                Size(25);
            else if (i == 1)
                Size(25);
        }
    }

    void Size(int i)
    {
        image.rectTransform.localPosition = new Vector2(image.rectTransform.localPosition.x, image.rectTransform.localPosition.y + i / 2);
        title.rectTransform.localPosition = new Vector2(title.rectTransform.localPosition.x, title.rectTransform.localPosition.y + i / 2);
        explain.rectTransform.localPosition = new Vector2(explain.rectTransform.localPosition.x, explain.rectTransform.localPosition.y + i / 2);
        RectTransform buttonRectTransform = button.gameObject.GetComponent<RectTransform>();
        buttonRectTransform.localPosition = new Vector2(buttonRectTransform.localPosition.x, buttonRectTransform.localPosition.y + i / 2);
        //bgTransform.localPosition = new Vector2(bgTransform.localPosition.x, bgTransform.localPosition.y + i / 2f);
        bgTransform.sizeDelta = new Vector2(bgTransform.sizeDelta.x, bgTransform.sizeDelta.y + i);
    }

    int LineCheck()
    {
        char ch = '\n';
        int count = explain.text.Count(f => (f == ch));
        return count;
    }
}
