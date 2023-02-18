using UnityEngine;

public class Colorize : MonoBehaviour
{
    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = ColorBucket.Instance.currentColor;
    }
}
