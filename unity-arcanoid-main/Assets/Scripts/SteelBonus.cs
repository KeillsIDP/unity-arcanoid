using UnityEngine;

public class SteelBonus : BonusBase
{
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
                    
                    spriteRenderer.color = new Color(0.5f, 0.5f, 0.5f);
                }
                else
                {
                    Debug.LogWarning("SpriteRenderer не найден на объекте Circle.");
                }
            }
            else
            {
                Debug.LogWarning("Дочерний объект 'Circle' не найден у мяча.");
            }

            ball.SetBallStrength(40);  
        }
    }
}
