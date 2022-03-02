using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum Type
    {
        none,
        puzzle,
        paw,
        rabbit,
        spade,
        sun
    }

    public static Type GetRandomType()
    {
        var values = System.Enum.GetValues(typeof(Type));

        return (Type)Random.Range(1, values.Length);
    }

    public Type type { get; private set; }

    public Item(Type t)
    {
        type = t;
    }
}
