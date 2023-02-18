using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController Instance;

    private void OnEnable()
    {
        if (Instance == null) Instance = this;
    }

    [SerializeField] GameObject finishPanel;
    [SerializeField] PanZoom panZoom;

    public void Finish()
    {
        panZoom.enabled= false;
        finishPanel.SetActive(true);
    }

    public void ContinueButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name,LoadSceneMode.Single);
    }
}
