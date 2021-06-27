using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    Button thisButton;

    private bool m_MouseOver = false;

    private void Awake()
    {
        //Get A ref for the audio source...
        thisButton = GetComponent<Button>();

    }

    private void Update()
    {
        if (m_MouseOver)
        {
            OnMouseHover();
            m_MouseOver = false;
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        m_MouseOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        m_MouseOver = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnMouseClick();
            Debug.Log("click");
        }
    }
    private void OnMouseHover()
    {
        
        ServiceLocator.Instance.GetService<IUiSound>().PlayHoverMouseSounds();
        Debug.Log("MouseHovering");
    }

    private void OnMouseClick()
    {
        ServiceLocator.Instance.GetService<IUiSound>().PlayMouseClickSounds();
        Debug.Log("MouseClick");
    }

 
}
