using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemWindow : MonoBehaviour
{
    public GameObject parent;

    public Scrollbar scrollbar;

    public ItemBox itembox;

    List<ItemBox> boxes;

    int items_per_row;
    int items_per_column;
    bool horizontal = false;

    List<Item> items;

    public void Init(List<Item> _items, int _items_per_row, int _items_per_column, bool _horizontal)
    {
        items = _items;
        items_per_row = _items_per_row;
        items_per_column = _items_per_column;
        horizontal = _horizontal;

        // end

        boxes = new List<ItemBox>();

        for (int i = 0; i < items_per_row * items_per_column; i++) // go to 28 which is how many will fit in the window
        {
            var copy = Instantiate(itembox.gameObject); // make a copy
            copy.SetActive(true); // set it active
            copy.name = "item " + (i + 1); // name the object
            copy.transform.SetParent(gameObject.transform); // set parent to this

            var box = copy.GetComponent<ItemBox>();

            boxes.Add(box); // add it to the list
        }

        scrollbar.value = 0; // set up the window to be at the beginning of the list
        ScrollBar(); // call scrollbar to refresh the items
    }

    public void ScrollBar()
    {
        RefreshItems(scrollbar.value);
    }

    public void RefreshItems(float percent)
    {
        int columns;
        int top;

        if (!horizontal)
        {
            columns = items.Count / items_per_row + (items.Count % items_per_row > 0 ? 1 : 0); // get total number of columns

            top = (int)(percent * columns);

            if (top > columns - items_per_column) top = columns - items_per_column;
            if (top < 0) top = 0;
        }
        else
        {
            columns = items.Count / items_per_column + (items.Count % items_per_column > 0 ? 1 : 0); // get total number of columns

            top = (int)(percent * columns);

            if (top > columns - items_per_row) top = columns - items_per_row;
            if (top < 0) top = 0;
        }

        for (int i = 0; i < items_per_row * items_per_column; i++)
        {
            int itm = i + top * items_per_row; // get a reference to the right item

            if (horizontal) itm = i + top * items_per_column;

            boxes[i].Fill(itm, itm < items.Count ? items[itm] : null); // put the item in the box
        }
    }
}
