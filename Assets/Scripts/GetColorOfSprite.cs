using System.Collections;
using UnityEngine;
public class GetColorOfSprite : MonoBehaviour
{
    private class Tex
    {
        public float x, y, w, h;
    }

    [SerializeField] Texture2D t2d;
    [SerializeField] Tex tex;
    [SerializeField] SpriteRenderer[] renderers;
    private void Start()
    {
        //StartCoroutine(GetColor());
    }
    /*
    IEnumerator GetColor()
    {
        foreach (var sr in renderers)
        {
            Sprite s = sr.sprite;
            Rect r = s.textureRect;
            Color pc = Color.white;
            if (r.width < 5 || r.height < 5) Destroy(sr.gameObject);
            for (int i = 0; i < r.width; i++)
            {
                for (int j = 0; j < r.height; j++)
                {
                    Color c = t2d.GetPixel(Mathf.FloorToInt(r.x + i), Mathf.FloorToInt(r.y + j));
                    if (c.a == 1)
                    {
                        pc = c;
                        ColorBucket.Instance.AddColor(pc);
                    }
                }
            }
            //Color c = t2d.GetPixel(Mathf.FloorToInt(r.x + r.width*.5f), Mathf.FloorToInt(r.y + r.height*.5f));
            sr.name = pc.ToString();
            yield return new WaitForEndOfFrame();
        }
    }
    */
}
