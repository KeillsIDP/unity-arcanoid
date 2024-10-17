using UnityEngine;

public class BallDamage : MonoBehaviour
{
    [SerializeField]
    private int damage;

    public void SetDamage(int damage){
        this.damage = damage;
    }

    public int GetDamage(){
        return damage;
    }
}
