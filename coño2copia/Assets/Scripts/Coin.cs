using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CoinManager.Instance.AddCoin();
            
            // Hace que la llave desaparezca visualmente
            GetComponent<MeshRenderer>().enabled = false;

            // Desactiva la colisión para que no vuelva a contar
            GetComponent<Collider>().enabled = false;
        }
    }
}
