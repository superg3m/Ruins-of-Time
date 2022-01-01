using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Roll_GUI : MonoBehaviour
{
    // Accessing playerMovement script
    private PlayerMovement pm;
    
    // Accessing Image from unity editor

    [SerializeField] private Image imageCooldown;
    [SerializeField] private TMP_Text textCooldown;

    private void Start()
    {
        textCooldown.gameObject.SetActive(false);
        imageCooldown.fillAmount = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        pm = FindObjectOfType<PlayerMovement>();
        //Debug.Log(pm.dashCooldownTimer);
        if (pm.dashCooldown) applyCooldown();
        else
        {
            imageCooldown.fillAmount = 0.0f;
            textCooldown.gameObject.SetActive(false);
        }
    }

    public void applyCooldown()
    {
        if (pm.dashCooldownTimer < 0.0f)
        {
            // done
        }
        else
        {
            textCooldown.gameObject.SetActive(true);
            textCooldown.text = Mathf.RoundToInt(pm.dashCooldownTimer).ToString();
            imageCooldown.fillAmount = pm.dashCooldownTimer / pm.dashCooldownTime;
        }
    }
}

