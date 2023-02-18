using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberCanvas : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI number;

    public void SetNumber(int n)
    {
        number.text = n.ToString();
    }
}
