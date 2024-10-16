using UnityEngine;

public class BallOnDestroy : MonoBehaviour
{
    private static PlayerHealthManager playerHealthManager;
    private void OnEnable() {
        if(!playerHealthManager)
            playerHealthManager = FindObjectOfType<PlayerHealthManager>();
    }

    private void OnDestroy() {
        playerHealthManager.DecreaseHealth();
    }
}
