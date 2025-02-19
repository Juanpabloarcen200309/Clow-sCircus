using UnityEngine;
using UnityEngine.SceneManagement; // Importar SceneManager para cambiar escenas
using System.Collections;

public class ClowyCameraController : MonoBehaviour
{
    // ======== VARIABLES PÚBLICAS ========
    public Transform clowy;                // Referencia al transform de Clowy
    public Camera clowyCamera;            // Cámara de Clowy
    public Animator clowyAnimator;        // Animator de Clowy
    public AudioSource screamAudio;       // AudioSource para el sonido del grito

    // ======== VARIABLES PRIVADAS ========
    private GameObject playerCapsule;      // Cápsula del jugador
    private CharacterController playerController; // CharacterController del jugador
    private Camera mainCamera;             // Cámara principal
    private bool hasPlayedScream = false;  // Control para evitar repetir el sonido
    private bool isShaking = false;        // Control para el shake

    // ======== CONFIGURACIONES PARA EL SHAKE ========
    public float shakeDuration = 0.5f;     // Duración del shake
    public float shakeMagnitude = 0.2f;    // Intensidad del shake

    // ======== MÉTODO START ========
    void Start()
    {
        // Desactivar la cámara de Clowy al inicio
        clowyCamera.enabled = false;

        // Buscar la cápsula del jugador
        playerCapsule = GameObject.Find("PlayerCapsule");
        if (playerCapsule != null)
        {
            playerController = playerCapsule.GetComponent<CharacterController>();
        }

        // Buscar la cámara principal por su tag
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera")?.GetComponent<Camera>();
    }

    // ======== MÉTODO UPDATE ========
    void Update()
    {
        // Hacer que la cámara de Clowy siga su posición
        if (clowy != null)
        {
            clowyCamera.transform.position = clowy.position + new Vector3(0, 1.5f, -3f);
            clowyCamera.transform.LookAt(clowy);
        }

        // Obtener el estado de la animación actual
        var stateInfo = clowyAnimator.GetCurrentAnimatorStateInfo(0);

        // ======== Si está en la animación "Scream" ========
        if (stateInfo.IsName("Scream"))
        {
            // 1. Reproducir sonido una sola vez
            if (!hasPlayedScream && screamAudio != null)
            {
                screamAudio.Play();
                hasPlayedScream = true;
            }

            // 2. Hacer el shake si no está en curso
            if (!isShaking)
            {
                StartCoroutine(CameraShake());
            }

            // 3. Cambiar de cámara y desactivar jugador
            clowyCamera.enabled = true;
            if (mainCamera != null) mainCamera.enabled = false;
            if (playerController != null) playerController.enabled = false;
            if (playerCapsule != null) playerCapsule.SetActive(false);
        }

        // ======== Si TERMINÓ la animación "Scream" ========
        if (stateInfo.IsName("Scream") && stateInfo.normalizedTime >= 1f)
        {
            StartCoroutine(ChangeSceneAfterDelay(1f)); // Espera 1 segundo y cambia a GAME OVER
        }
    }

    // ======== MÉTODO PARA EL SHAKE ========
    IEnumerator CameraShake()
    {
        isShaking = true;
        Vector3 originalPosition = clowyCamera.transform.localPosition;

        float elapsed = 0f;
        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;

            clowyCamera.transform.localPosition = originalPosition + new Vector3(x, y, 0);
            elapsed += Time.deltaTime;

            yield return null;
        }

        clowyCamera.transform.localPosition = originalPosition;
        isShaking = false;
    }

    // ======== MÉTODO PARA CAMBIAR DE ESCENA ========
    IEnumerator ChangeSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("GAME OVER");
    }
}
