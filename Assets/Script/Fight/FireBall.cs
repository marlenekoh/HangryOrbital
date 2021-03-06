﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {

    private bool damageShown = false;

    private void Update()
    {
        if (FightManager.winMap)
        {
            Destroy(this);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Monster" || collision.tag == "Boss")
        {
			if(collision.GetComponent<enemyHealth>().currentHealth < 0)
				return;
            this.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
			
            this.GetComponent<Animator>().SetTrigger("Hit");
			SfxManager.PlaySound("FireBallHit");
			
            float damage = (float)SaveManager.Instance.gestureDMG[4];
            if (!damageShown)
            {
                FloatingTextController.CreateFloatingText(damage.ToString(), transform);
                damageShown = true;
            }
            FightManager.currEnemy.gameObject.GetComponent<enemyHealth>().addDamage(damage);
            
            //duration of animation
            StartCoroutine(destroyAfterTime(0.77f)); 
        }
    }
    IEnumerator destroyAfterTime(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(this.gameObject);
    }
}
