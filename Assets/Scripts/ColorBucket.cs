using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBucket : MonoBehaviour
{
    public static ColorBucket Instance;

    private void OnEnable()
    {
        if (Instance == null) Instance = this;
    }
    [SerializeField] private float colorSensivity = .01f;
    public List<Color> Colors = new List<Color>();
    private List<ColorIndex> markedParts = new List<ColorIndex>();
    [SerializeField] ColorIndex[] parts;
    [SerializeField] ColorSelection[] selections;
    public int currentIndex = 7;
    private float allParts,coloredParts;
    public Color currentColor;
    public ColorSelection colorSelection;

    public float SelectColor(int index)
    {
        currentIndex = index;
        allParts= 0; coloredParts= 0;
        if (markedParts.Count>0)
        {
            foreach (var mp in markedParts)
            {
               mp.ResetMark();
            }
            markedParts.Clear();
        }
        foreach (var p in parts)
        {
            if(currentIndex==p.colorIndex)
            {
                p.Mark();
                markedParts.Add(p);
                allParts++;
                if (p.isColored) coloredParts++;
            }
        }
        currentColor = Colors[index];
        float fill = coloredParts / allParts;
        Debug.Log(coloredParts + " - " + allParts + " - " + fill);
        return fill;
    }

    public void UpdateProgress()
    {
        selections[currentIndex].SelectColor();
        CheckLevelProgress();
    }

    private void CheckLevelProgress()
    {
        foreach (var p in parts)
        {
            if (!p.isColored) return;
        }
        UIController.Instance.Finish();
    }

}
