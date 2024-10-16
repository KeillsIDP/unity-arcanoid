using UnityEngine;

public class BallStartUp : MonoBehaviour
{
    [SerializeField] 
    private int startForce;
    [SerializeField]
    private GameObject ballPrefab;

    private void Update() {
        if(!Input.GetMouseButtonDown(0))
            return;

        GameObject ballInstantiated = Instantiate(ballPrefab,
                                                    transform.position,
                                                    Quaternion.identity,
                                                    transform);


        ballInstantiated.transform.parent = null;
        ballInstantiated.GetComponent<Rigidbody2D>().AddForce(Vector2.up*startForce);
        ballInstantiated.transform.right = Vector2.up;
        gameObject.SetActive(false);
    }
}
