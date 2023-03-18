using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Collider2D low;
    public Collider2D middle;
    public Collider2D high;

    private bool attackable = true;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) && attackable)
        {
            attackable = false;
            StartCoroutine(DelayMethod(2.5f, low => low.enabled = true, low));
            StartCoroutine(DelayMethod(0.3f, low => low.enabled = false, low));
            attackable = true;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            attackable = false;
            StartCoroutine(DelayMethod(2.5f, mid => mid.enabled = true, middle));
            StartCoroutine(DelayMethod(0.3f, mid => mid.enabled = false, middle));
            attackable = true;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            attackable = false;
            StartCoroutine(DelayMethod(2.5f, high => low.enabled = true, high));
            StartCoroutine(DelayMethod(0.3f, high => low.enabled = false, high));
            attackable = true;
        }
    }

    private void EnableColliderThenDisable(string name)
    {
        switch (name)
        {
            case "low":
                low.enabled = true;
                break;
            case "middle":
                break;
            case "high":
                break;
        }
    }
    private IEnumerator DelayMethod(float waitTime, Action<Collider2D> action, Collider2D col)
    {
        yield return new WaitForSeconds(waitTime);
        action(col);
    }
}
