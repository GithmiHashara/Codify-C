using UnityEngine;
using UnityEngine.UI;

public class AdjustRectTransform : MonoBehaviour
{
    void Start()
    {
        Image image = GetComponent<Image>();
        if (image != null)
        {
            RectTransform rectTransform = GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(image.sprite.rect.width, image.sprite.rect.height);
        }
    }
}
