using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[RequireComponent(typeof(Image))]
public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    /* Variable Storage
     */
    public TabGroup tabGroup;

    public Image background;

    /* Event handler, use this to set the actions in the unity editor
     */
    public UnityEvent onTabSelected;
    public UnityEvent onTabDeselected;

    /* This function registers if the pointer has clicked 
     * on the tab this script is attached to
     */
    public void OnPointerClick(PointerEventData eventData)
    {
        tabGroup.OnTabSelected(this);
    }

    /* This function registers if the pointer is hovering over the tab
     * on the tab this script is attached to
     */
    public void OnPointerEnter(PointerEventData eventData)
    {
        tabGroup.OnTabEnter(this);
    }

    /* This function registers if the pointer is moving away from the tab
     * on the tab this script is attached to
     */
    public void OnPointerExit(PointerEventData eventData)
    {
        tabGroup.OnTabExit(this);
    }

    /* Start function runs on start of the game
     * It sets the image component and subscribes the button to the tabgroup
     */
    void Start()
    {
        background = GetComponent<Image>();
        tabGroup.Subscribe(this);
    }

    public void Select()
    {
      if(onTabSelected != null)
        {
            onTabSelected.Invoke();
        }  
    }

    public void Deselect()
    {
        if(onTabDeselected != null)
        {
            onTabDeselected.Invoke();
        }
    }
}
