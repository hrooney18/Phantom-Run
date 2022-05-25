using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class ReturnToHubClickScript : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public UnityEvent onClick;
    public Color basecolor;
    public Color hoverColor;
    private Text returnToHubText;

    void Start()
    {
        returnToHubText = GetComponent<Text>();
        returnToHubText.color = basecolor;
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        onClick.Invoke();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        returnToHubText.color = hoverColor;
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        returnToHubText.color = basecolor;
    }
}