using UnityEngine;
using UnityEngine.InputSystem;
using Dwarffell.TextEngine;
using Dwarffell.VisualNovelFramework;
using TMPro;
using System.Collections;
using Unity.VisualScripting;
/// <summary>
/// This script is a sample of loading an event file that doesn't have MonoBehaviour
/// </summary>
public class LoadSampleEvent01 : MonoBehaviour, ILoadEvent
{
	[field: SerializeField] public TextMeshProUGUI textbox { get; set; }
	[field: SerializeField] public TextMeshProUGUI nameBox { get; set; }
	[field: SerializeField] public GameObject[] actors { get; set; }
	public int progress = -1;
	public IEvent ev = new Event_PrototypeEvent01();
	private bool advancePressed;
	private bool canAdvance;
	private System.Action EventEndAction;
	public void OnEnable()
	{
		EventEndAction = () => LoadNewEvent(new Event_PrototypeEvent02());
		GameManager.vnPlayer.Controls.Enable();
		GameManager.vnPlayer.Controls.Advance.performed += OnAdvancePressed;
		EventHandler.OnSegmentLoad += LoadSegment;
		ev.OnEventEnd += EventEndAction;
		canAdvance = true;
		//LoadEvent();
	}
	public void LoadEvent()
	{
		EventHandler.GetEventData(ev, 0);
	}
	private void OnAdvancePressed(InputAction.CallbackContext context)
	{
		try
		{
			advancePressed = true;
			if (canAdvance == true)
			{
				progress++;
				EventHandler.GetEventData(ev, progress);
				canAdvance = false;
			}
		}
		catch (SegmentOutofRangeException e)
		{
			Debug.Log("b");
		}
	}

	public void LoadSegment(Segment se)
	{
		StartCoroutine(LoadSegmentRoutine(se));
	}
	public IEnumerator LoadSegmentRoutine(Segment se)
	{
		advancePressed = false;
		textbox.text = se.charText;
		nameBox.text = se.charName;
		//yield return new WaitUntil(() => advancePressed);
		yield return new WaitForEndOfFrame();
		if (se.nextSegment == null)
		{
			canAdvance = true;
		}
		else
		{
			EventHandler.LoadSegment(se.nextSegment);
		}
	}
	public void LoadNewEvent(IEvent @event)
	{
		ev = @event;
		progress = -1;
		advancePressed = false;
		canAdvance = true;
	}
	public void OnDisable()
	{
		ev.OnEventEnd -= EventEndAction;
		EventHandler.OnSegmentLoad -= LoadSegment;
		GameManager.vnPlayer.Controls.Advance.performed -= OnAdvancePressed;
		GameManager.vnPlayer.Controls.Disable();
	}
}
