using UnityEngine;

public class BallOnCollisionSound : MonoBehaviour
{
    [SerializeField]
    private GameObject audioPrefab;

    private void OnCollisionEnter2D(Collision2D other) {
        GameObject obj = Instantiate(audioPrefab);
        obj.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("sv");
        Destroy(obj,5);
    }
}
