using UnityEngine;

public class DamageBonus : BonusBase
{
    [SerializeField]
    private int damage;
    [SerializeField]
    private Color ballColor;
    public override void BonusActivate()
    {
        base.BonusActivate();  
        BallMovement[] balls = FindObjectsOfType<BallMovement>();  

        foreach (BallMovement ball in balls)
        {
            
            Transform circleTransform = ball.transform.Find("Circle");
            if (circleTransform != null)
            {
                SpriteRenderer spriteRenderer = circleTransform.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    spriteRenderer.color = ballColor;
                }
            }
            ball.GetComponent<BallDamage>().SetDamage(damage);  
        }
    }
}
