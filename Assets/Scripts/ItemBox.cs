using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class ItemBox : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameObject inventory;
    public List<Sprite> images; // temp to test things

    public Image graphic;

    Item item = null;
    int index = 0;

    public void Fill(int _index, Item _item)
    {
        item = _item;
        index = _index;

        Refresh_Icon();
    }

    void Refresh_Icon()
    {
        graphic.sprite = images[item != null ? (int)item.type : 0];
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        Debug.Log("OnPointerDown: " + Debug_Get_Box_Info());
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        Debug.Log("OnPointerUp: " + Debug_Get_Box_Info());
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        graphic.transform.SetParent(inventory.transform);

        Debug.Log("OnBeginDrag: " + Debug_Get_Box_Info());
    }

    public void OnDrag(PointerEventData eventData)
    {
        graphic.transform.position = eventData.position;

        Debug.Log("OnDrag: " + Debug_Get_Box_Info());
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        graphic.transform.SetParent(transform);
        graphic.transform.localPosition = new Vector3(0, 0, 0);

        Debug.Log("OnEndDrag: " + Debug_Get_Box_Info());
    }

    string Debug_Get_Box_Info()
    {
        return "Index: " + index + " " + name + " Item: " + (item != null ? item.type.ToString() : " empty ");
    }
}
