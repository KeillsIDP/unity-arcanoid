using UnityEngine;

public class FireBonus : BonusBase
{
    public override void BonusActivate()
    {
        base.BonusActivate();  // Добавляем очки

        BallMovement[] balls = FindObjectsOfType<BallMovement>();  // Находим все объекты шариков на сцене

        foreach (BallMovement ball in balls)
        {
            Transform circleTransform = ball.transform.Find("Circle");
            if (circleTransform != null)
            {
                SpriteRenderer spriteRenderer = circleTransform.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {

                    spriteRenderer.color = new Color(1f, 0.5f, 0f);
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

            ball.SetBallStrength(4); 
        }
    }
}
