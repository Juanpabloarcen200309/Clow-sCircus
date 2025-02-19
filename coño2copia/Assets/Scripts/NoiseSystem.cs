using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NoiseSystem : MonoBehaviour
{
    public float noiseLevel = 0f;
    public float maxNoise = 100f;
    public float noiseIncrease = 20f;
    public float runningNoiseIncreaseRate = 40f;
    public float jumpNoiseIncrease = 15f; // Ruido generado al saltar
    public bool isRunning = false;
    public EnemyAI enemy;

    // Variables del micrófono
    private AudioClip micClip;
    private string micDevice;
    public float micSensitivity = 2f;
    public float micThreshold = 0.1f;

    // Referencia a la barra de ruido
    public Image noiseBarImage;

    // Reducción del ruido con el tiempo
    public float decreaseAmount = 5f;
    public float decreaseInterval = 2f;

    private void Start()
    {
        if (Microphone.devices.Length > 0)
        {
            micDevice = Microphone.devices[0];
            micClip = Microphone.Start(micDevice, true, 1, 44100);
        }

        StartCoroutine(DecreaseNoiseOverTime());
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;
            AddNoise(runningNoiseIncreaseRate * Time.deltaTime);
        }
        else
        {
            isRunning = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddNoise(jumpNoiseIncrease); // Aumenta el ruido al saltar
        }

        float micLoudness = GetMicrophoneLoudness();
        if (micLoudness > micThreshold)
        {
            AddNoise(noiseIncrease);
        }

        if (noiseBarImage != null)
        {
            noiseBarImage.fillAmount = noiseLevel / maxNoise;
        }
    }

    // 🛠️ DETECTAR COLISIÓN CON OBSTÁCULOS
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colisión detectada con: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("El jugador chocó con un obstáculo.");
            AddNoise(noiseIncrease);
        }
    }

    // Si no quieres usar Rigidbody en el jugador, usa este método y marca los obstáculos como "Is Trigger"
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger activado por: " + other.gameObject.name);

        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("El jugador tocó un obstáculo.");
            AddNoise(noiseIncrease);
        }
    }

    private void AddNoise(float amount)
    {
        noiseLevel += amount;
        noiseLevel = Mathf.Clamp(noiseLevel, 0, maxNoise);

        if (noiseLevel >= maxNoise)
        {
            if (enemy == null)
            {
                enemy = GameObject.FindGameObjectWithTag("Enemy")?.GetComponent<EnemyAI>();
            }

            if (enemy != null)
            {
                enemy.StartChasing();
            }
            else
            {
                Debug.LogWarning("No se encontró el enemigo en la escena.");
            }
        }
    }

    private float GetMicrophoneLoudness()
    {
        if (micClip == null) return 0f;

        float[] data = new float[256];
        int micPosition = Microphone.GetPosition(micDevice) - (data.Length + 1);
        if (micPosition < 0) return 0f;

        micClip.GetData(data, micPosition);
        float sum = 0;
        for (int i = 0; i < data.Length; i++)
        {
            sum += Mathf.Abs(data[i]);
        }
        return sum / data.Length * micSensitivity;
    }

    private IEnumerator DecreaseNoiseOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(decreaseInterval);

            noiseLevel -= decreaseAmount;
            noiseLevel = Mathf.Clamp(noiseLevel, 0, maxNoise);

            if (noiseBarImage != null)
            {
                noiseBarImage.fillAmount = noiseLevel / maxNoise;
            }
        }
    }
}
