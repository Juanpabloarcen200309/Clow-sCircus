using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    public CanvasGroup fadeCanvas;
    public float fadeDuration = 1f;

    void Start()
    {
        // Asegurar que el canvas esté completamente visible si la escena inicia desde el menú
        if (fadeCanvas.alpha == 1)
        {
            StartCoroutine(FadeIn()); // Hacer fade in al iniciar la escena
        }
    }

    public void ChangeScene(string sceneName)
    {
        StartCoroutine(FadeOut(sceneName));
    }

    IEnumerator FadeIn()
    {
        float time = fadeDuration;
        while (time > 0)
        {
            time -= Time.deltaTime;
            fadeCanvas.alpha = time / fadeDuration;
            yield return null;
        }
        fadeCanvas.alpha = 0;
    }

    IEnumerator FadeOut(string sceneName)
    {
        float time = 0;
        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            fadeCanvas.alpha = time / fadeDuration;
            yield return null;
        }

        // Esperar un pequeño momento antes de cargar la escena
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(sceneName);
    }
}
