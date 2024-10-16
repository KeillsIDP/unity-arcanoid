using UnityEngine;

public class NormBonus : BonusBase
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
                 
                    spriteRenderer.color = new Color(1f, 1f, 1f);
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

            ball.SetBallStrength(1);  
        }
    }
}
