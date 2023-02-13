using System.Collections;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textMesh;

    private float currentFPS = 0.0f;

    private void Awake()
    {
        Application.targetFrameRate = 160;
    }

    private void Start()
    {
        StartCoroutine(CalculateFPS());
    }

    private void Update()
    {
        currentFPS = 1.0f / Time.smoothDeltaTime;
    }

    private IEnumerator CalculateFPS()
    {
        while (true)
        {
            PrintFPS();
            yield return new WaitForSeconds(1f);
        }
    }

    private void PrintFPS()
    {
        textMesh.text = "FPS: " + currentFPS;
    }
}
