using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelection : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] Image fill;
    [SerializeField] TextMeshProUGUI number;

    private void Start()
    {
        image.color = ColorBucket.Instance.Colors[transform.GetSiblingIndex()];
        number.text = (transform.GetSiblingIndex()+1).ToString();
    }

    public void SelectColor()
    {
        float f = ColorBucket.Instance.SelectColor(transform.GetSiblingIndex());
        fill.fillAmount = f;
    }
}
