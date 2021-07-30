using System.Collections;
using UnityEngine;
using UnityEngine.UI;

interface IBonuses
{
    public IEnumerator BonusCorutine(GameObject playerObject,
                                     SpriteRenderer gunDrone,
                                     Animator bonusPanel,
                                     SpriteRenderer playerSprite);
}
