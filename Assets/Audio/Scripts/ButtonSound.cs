using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    Button thisButton;
    [SerializeField] PlaySoundsInUnity playSoundsInUnity;

    private bool m_MouseOver = false;

    private void Awake()
    {
        //Get A ref for the audio source...
        thisButton = GetComponent<Button>();
        if(playSoundsInUnity == null!)
        {
            playSoundsInUnity = GetComponent<PlaySoundsInUnity>();
        }

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

        playSoundsInUnity.PlayHoverMouseSounds();
        Debug.Log("MouseHovering");
    }

    private void OnMouseClick()
    {

        playSoundsInUnity.PlayMouseClickSounds();
        Debug.Log("MouseClick");
    }

 
}
