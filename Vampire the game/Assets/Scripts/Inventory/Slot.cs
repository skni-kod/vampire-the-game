using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public bool isEmpty = true;
    private Image backgroundSlot;
    //[SerializeField] private Sprite spriteEmptySlot;
    [SerializeField] private Color32 enterColor;
    [SerializeField] private Color32 exitColor;

    void Awake()
    {
        backgroundSlot = transform.Find("Background").gameObject.GetComponent<Image>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void OnPointerClick(PointerEventData eventData)
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        backgroundSlot.color = enterColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        backgroundSlot.color = exitColor;
    }
}
