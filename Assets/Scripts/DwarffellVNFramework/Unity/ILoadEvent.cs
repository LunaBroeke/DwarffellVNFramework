using UnityEngine;
using TMPro;
namespace Dwarffell.VisualNovelFramework
{
	/// <summary>
	/// This interface is for keeping track of the most necessities in a scene. This interface should be changed to fit better with your own front-end
	/// </summary>
	public interface ILoadEvent
	{
		public TextMeshProUGUI textbox { get; set; }
		public TextMeshProUGUI nameBox { get; set; }
		public GameObject[] actors { get; set; }
		public void LoadEvent();
	}
}
