using System;
using System.Collections.Generic;
using Dwarffell.TextEngine;

namespace Dwarffell.VisualNovelFramework
{
	[Serializable]
	public class Event_PrototypeEvent01 : IEvent
	{
		public Language.Dialogue dialogue = TextPlayer.text.dialogue;
		public Language.Name name = TextPlayer.text.name;
		public List<Segment> segments { get; set; }
		public Action OnEventEnd { get; set; }

		public Event_PrototypeEvent01() 
		{
			segments = new List<Segment>
			{
				new Segment(dialogue.event_PrototypeEvent01_line01),
				new Segment(dialogue.event_PrototypeEvent01_line02,name.lumine),
				new Segment(dialogue.event_PrototypeEvent01_line03,name.celestia),
				new Segment(dialogue.event_PrototypeEvent01_line04,name.lumine),
				new Segment(dialogue.event_PrototypeEvent01_line05,name.celestia, TestAction),
				new Segment(dialogue.event_PrototypeEvent01_line06,name.serena, EndEvent),
			};
		}
		private void TestAction()
		{
			Console.WriteLine("baboom!!");
		}
		private void TestAction(string s)
		{
			Console.WriteLine(s);
		}
		public void EndEvent()
		{
			OnEventEnd?.Invoke();
		}
	}
}

