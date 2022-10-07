using System.Collections;

using System.Collections.Generic;

using UnityEditor;

using UnityEngine;

using UnityEngine.U2D;

using UnityEditor.U2D;

public class SpriteAtlasPaddingOverride

{

    [MenuItem("Assets/SpriteAtlas Set Padding 32")]

    public static void SpriteAtlasCustomPadding()

    {

        Object[] objs = Selection.objects;

        foreach (var obj in objs)

        {

            SpriteAtlas sa = obj as SpriteAtlas;

            if (sa)

            {

                var ps = sa.GetPackingSettings();

                ps.padding = 32;

                sa.SetPackingSettings(ps);

            }

        }

        AssetDatabase.SaveAssets();

    }

}
