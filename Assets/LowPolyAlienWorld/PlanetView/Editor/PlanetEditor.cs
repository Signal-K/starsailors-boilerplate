using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Planet))]
public class PlanetEditor : Editor
{
    Planet planet;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        DrawSettingsEditor(planet.shapeSettings, planet.OnShapeSettingsUpdated);
        DrawSettingsEditor(planet.colorSettings, planet.OnColorSettingsUpdated);
    }

    void DrawSettingsEditor(Object settings, System.Action onSettingsUpdated, bool foldout)
    {
        // Check if there have been any settings updates
        using (var check = new EditorGUI.ChangeCheckScope())
        {
            // Draw the context menu for the planet settings
            foldout = EditorGUILayout.InspectorTitlebar(foldout, settings); // Draw the title bar

            if (foldout)
            {
                // Draw the updated settings for the planet
                Editor editor = CreateEditor(settings);
                editor.OnInspectorGUI();

                if (check.changed)
                { // If there have been any changes made to the planet settings using the editor
                    if (onSettingsUpdated != null)
                    {
                        onSettingsUpdated(); // Draw the latest updates -> shape & colour
                    }
                }
            }
        }
    }

    private void OnEnable()
    {
        planet = (Planet)target;
    }
}
