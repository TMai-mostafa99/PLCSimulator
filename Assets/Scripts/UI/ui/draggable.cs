using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{


    public Transform parentToReturnTo = null;
    public Transform placeholderParent = null;
    public Transform org = null;
    GameObject placeholder = null;

 //   private Transform ParentPos;

    public UnityAction Dropped;
    private Transform MenuTransform;
    [SerializeField] private GameObject ComponentPrefab;
    [SerializeField] private bool dropped = true;
    private void Start()
    {
        MenuTransform = transform.parent;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {

  
        placeholder = new GameObject();
        
        placeholder.transform.SetParent(this.transform.parent);
        placeholder.name = "PLACEHOLDER";
       
        LayoutElement le = placeholder.AddComponent<LayoutElement>();
        le.preferredWidth = 30;
        le.preferredHeight = 30;
        le.flexibleWidth = 0;
        le.flexibleHeight = 0;

        RectTransform Rectplaceholder = placeholder.transform.GetComponent<RectTransform>();
        Rectplaceholder.sizeDelta = new Vector2(50,50);

        placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

        parentToReturnTo = this.transform.parent;
        placeholderParent = parentToReturnTo;
        this.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
        org = parentToReturnTo;


        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log ("OnDrag");

        if (placeholderParent != null)
        {
            this.transform.position = eventData.position;

            if (placeholder.transform.parent != placeholderParent)
                placeholder.transform.SetParent(placeholderParent);

            int newSiblingIndex = placeholderParent.childCount;

            for (int i = 0; i < placeholderParent.childCount; i++)
            {
                if (this.transform.position.x < placeholderParent.GetChild(i).position.x)
                {

                    newSiblingIndex = i;

                    if (placeholder.transform.GetSiblingIndex() < newSiblingIndex)
                        newSiblingIndex--;

                    break;
                }
            }

            placeholder.transform.SetSiblingIndex(newSiblingIndex);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        this.transform.SetParent(placeholderParent);

        //if (placeholderParent == GameObject.FindGameObjectWithTag("Panel out").transform ) //no panel out for now
        //{ this.transform.SetParent(org);  }




        
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        if (placeholder.transform.parent.tag == "Menu") 
        {
            GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            dropped = false;
        } 
        else
        {
            this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
            if (MenuTransform.childCount == 0)
            {

                GameObject newplaceholder = Instantiate(ComponentPrefab, MenuTransform.transform);
                newplaceholder.GetComponent<PLCComponent>().ResetAdding();
                newplaceholder.GetComponent<draggable>().dropped = true;
                newplaceholder.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
                newplaceholder.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
                newplaceholder.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
         
                newplaceholder.name = gameObject.name;  
                newplaceholder.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
                newplaceholder.GetComponent<RectTransform>().localScale = Vector3.one;
            }
          
        }

        if (dropped) Dropped?.Invoke();
        
        Destroy(placeholder);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
      Destroy(placeholder);

    }


}
