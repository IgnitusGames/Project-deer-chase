using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MutliFunctionalButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    //Variables
    public float hold_trigger_time;
    public UnityEvent OnLongCLick;
    public UnityEvent OnNormalClick;
    public UnityEvent OnClickStop;

    private bool is_clicked;
    private bool has_lifted;
    private bool long_click_has_activated;
    private float click_time;
    public void OnPointerDown(PointerEventData event_data)
    {
        is_clicked = true;
    }
    public void OnPointerUp(PointerEventData event_data)
    {
        Reset();
        has_lifted = true;
    }
    private void Update()
    {
        if (is_clicked)
        {
            long_click_has_activated = false;
            click_time += Time.deltaTime;
            if (click_time >= hold_trigger_time)
            {
                if (OnLongCLick != null)
                {
                    OnLongCLick.Invoke();
                    long_click_has_activated = true;
                }
            }
        }
        else if(has_lifted && !long_click_has_activated)
        {
            if (OnNormalClick != null)
            {
                OnNormalClick.Invoke();
                has_lifted = false;
            }
        }
        else if(has_lifted && long_click_has_activated)
        {
            if(OnClickStop != null)
            {
                OnClickStop.Invoke();
            }
        }
    }
    private void Reset()
    {
        is_clicked = false;
        click_time = 0;
    }
}