using UnityEngine;
using Dwarffell.TextEngine;
using Dwarffell.VisualNovelFramework;
public class GameManager : MonoBehaviour
{
    public void OnEnable()
    {
        TextPlayer.Start("en_NL");
    }
}
