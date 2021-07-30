using System.Collections;
using UnityEngine;

interface IBonuses
{
    public IEnumerator BonusCorutine(SpriteRenderer gunDrone,
                                     Animator bonusPanel,
                                     Transform playerTransform);
}
