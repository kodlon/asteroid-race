using System.Collections;
using UnityEngine;


public class GunBonus : MonoBehaviour, IBonuses
{
    public IEnumerator BonusCorutine(SpriteRenderer gunDrone, Animator bonusPanel, Transform playerTransform)
    {
        bonusPanel.SetInteger("ChangeAnim", 2);
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
}
