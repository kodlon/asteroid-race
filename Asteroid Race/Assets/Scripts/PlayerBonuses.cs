using System.Collections;
using UnityEngine;

public class PlayerBonuses : MonoBehaviour
{
    public static IEnumerator GunBonusCoroutine(SpriteRenderer gunDrone, Animator bonusPanel)
    {
        SpawnBullet.Active = true;
        gunDrone.color = new Color(1f, 0.1686275f, 0.1686275f, 1.0f);

        yield return new WaitForSeconds(8);
        bonusPanel.SetInteger("ChangeAnim", 7);
        yield return new WaitForSeconds(2);

        gunDrone.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        SpawnBullet.Active = false;
        bonusPanel.SetInteger("ChangeAnim", 0);
        Player.BonusActive = false;
    }

    public static IEnumerator TimeBonusCoroutine(Animator bonusPanel)
    {
        Time.timeScale = 0.5f;

        yield return new WaitForSeconds(3);

        bonusPanel.SetInteger("ChangeAnim", 5);
        yield return new WaitForSeconds(2);
        bonusPanel.speed = 1f;

        Time.timeScale = 1.0f;
        Player.BonusActive = false;
        bonusPanel.SetInteger("ChangeAnim", 0);
    }

    public static IEnumerator SizeBonusCoroutine(Animator bonusPanel, Transform playerTransform)
    {
        playerTransform.localScale /= 1.5f;

        yield return new WaitForSeconds(8);
        bonusPanel.SetInteger("ChangeAnim", 6);
        yield return new WaitForSeconds(2);

        playerTransform.localScale = Vector3.one;
        Player.BonusActive = false;
        bonusPanel.SetInteger("ChangeAnim", 0);
    }
}
