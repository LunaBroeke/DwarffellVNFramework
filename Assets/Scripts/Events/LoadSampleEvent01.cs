using UnityEngine;
using Dwarffell.TextEngine;
using Dwarffell.VisualNovelFramework;
using TMPro;
/// <summary>
/// This script is a sample of loading an event file that doesn't have MonoBehaviour
/// </summary>
public class LoadSampleEvent01 : MonoBehaviour, ILoadEvent
{
	[field: SerializeField]public TextMeshProUGUI textbox { get; set; }
	[field: SerializeField]public TextMeshProUGUI nameBox { get; set; }
	[field: SerializeField]public GameObject[] actors { get; set; }
	public int progress = 0;
	public IEvent ev = new Event_PrototypeEvent01();
	public void Start()
	{
		EventHandler.OnSegmentLoad += LoadSegment;
		LoadEvent();
	}
	public void LoadEvent()
	{
		EventHandler.GetEventData(ev,0);
	}

	public void LoadSegment(Segment se)
	{
		textbox.text = se.charText;
		nameBox.text = se.charName;
	}
}
