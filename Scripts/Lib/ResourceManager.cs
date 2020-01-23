using UnityEngine;
using System.Collections;

public static class ResourceManager//static class of information for menu
{

    public static bool MenuOpen { get; set; }
    public static string LevelName { get; set; }

    private static float buttonHeight = 40;
    private static float headerHeight = 32, headerWidth = 256;
    private static float textHeight = 25, padding = 10;
    public static float MenuWidth { get { return headerWidth + 2 * padding; } }
    public static float ButtonHeight { get { return buttonHeight; } }
    public static float ButtonWidth { get { return (MenuWidth - 3 * padding) / 2; } }
    public static float HeaderHeight { get { return headerHeight; } }
    public static float HeaderWidth { get { return headerWidth; } }
    public static float TextHeight { get { return textHeight; } }
    public static float Padding { get { return padding; } }
}
