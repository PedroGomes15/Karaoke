using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SubtitleSingleController : MonoBehaviour
{
    public Notes note;

    public SubtitleController controller;

    public int index;

    public bool canMove = true;

    public bool played = false;

    void Start()
    {
        
    }

    public float speed;

    void FixedUpdate()
    {
        if (this.transform.localPosition.y < controller.limitY[index])
        {
            this.transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else
        {
            Vector2 newPos = this.transform.localPosition;
            newPos.y = controller.limitY[index];
            this.transform.localPosition = newPos;
        }

    }

    private void Update()
    {
        var sTime = ConfigUtils.ConvertTime(note.startTime);
        var eTime = ConfigUtils.ConvertTime(note.endTime);

        if (controller.CurrentSeconds() >= sTime && controller.CurrentSeconds() <= eTime)
        {
            this.GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Bold;
            this.GetComponent<TextMeshProUGUI>().color = new Color32(255,255,255,255);

            played = true;

        }
        else
        {
            this.GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Normal;
            this.GetComponent<TextMeshProUGUI>().color = new Color32(147,147,147,225);

            if (played == true)
            {
                controller.DestroyLast();
                played = false;
                controller.SubtractIndex();
                index = 3;
                controller.CreateSubtitle(2);
            }
        }
    }
}
