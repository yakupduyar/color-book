
using Unity.VisualScripting;
using UnityEngine;

public class ColorIndex : MonoBehaviour
{
    [SerializeField] Sprite s;
    [SerializeField] NumberCanvas nc;

    public SpriteRenderer sRenderer;
    public int colorIndex;
    public bool isColored;

    private SpriteMask mask;
    private GameObject child;

    private void OnEnable()
    {
        if(!sRenderer)
        {
            sRenderer = GetComponent<SpriteRenderer>();
        }
        nc = Instantiate(nc, transform.position, Quaternion.identity);
        nc.transform.SetParent(transform, true);
        nc.SetNumber(colorIndex + 1);
        name = (colorIndex+1).ToString();
    }

    private void OnMouseDown()
    {
        if (colorIndex != ColorBucket.Instance.currentIndex) return;
        isColored = true;
        GetComponent<SpriteRenderer>().color = ColorBucket.Instance.currentColor;
        nc.gameObject.SetActive(false);
        ResetMark();
    }
    private void OnMouseUp()
    {
        if (colorIndex != ColorBucket.Instance.currentIndex) return;
        ColorBucket.Instance.SelectColor(colorIndex);
        ColorBucket.Instance.UpdateProgress();
    }

    public void Mark()
    {
        if(!isColored)
        {
            if (!mask) mask = gameObject.AddComponent<SpriteMask>();
            else mask.enabled = true;
        mask.sprite = sRenderer.sprite;
        child = new GameObject();
        child.transform.SetParent(transform);
        child.transform.localPosition = Vector3.zero;
        //child.transform.localScale = Vector3.one * 50f;
        SpriteRenderer cs = child.AddComponent<SpriteRenderer>();
        cs.sprite = s;
        cs.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
        cs.sortingOrder = sRenderer.sortingOrder+1;
        }
    }

    public void ResetMark()
    {
        mask.enabled = false;
        Destroy(child);
    }
}
