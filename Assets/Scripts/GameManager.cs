using UnityEngine;
using Dwarffell.TextEngine;
using Dwarffell.VisualNovelFramework;
public class GameManager : MonoBehaviour
{
    public static VNPlayer vnPlayer;
	public void Awake()
	{
		vnPlayer = new VNPlayer();
	}
	public void OnEnable()
    {
        TextPlayer.Start("en_NL");
    }
}
