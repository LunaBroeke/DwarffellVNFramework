using Dwarffell.TextEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwarffell.VisualNovelFramework
{
	public class Event_PrototypeEvent02 : IEvent
	{
		public Language.Dialogue dialogue = TextPlayer.text.dialogue;
		public Language.Name name = TextPlayer.text.name;
		public List<Segment> segments { get; set; }
		public Action<IEvent> OnEventEnd { get; set; }

		public Event_PrototypeEvent02()
		{
			segments = new List<Segment>
			{
				new Segment(dialogue.event_PrototypeEvent02_set00_line01),
				new Segment(dialogue.event_PrototypeEvent02_set00_line02, name.ange,
					new Choice(dialogue.event_PrototypeEvent02_set00_choice01,new Segment(dialogue.event_PrototypeEvent02_set01_line01,name.ange, ()=>SetFlags(1))),
					new Choice(dialogue.event_PrototypeEvent02_set00_choice02,new Segment(dialogue.event_PrototypeEvent02_set02_line01,name.ange, ()=>SetFlags(2))),
					new Choice(dialogue.event_PrototypeEvent02_set00_choice03,new Segment(dialogue.event_PrototypeEvent02_set03_line01,name.ange, ()=>SetFlags(3))),
					new Choice(dialogue.event_PrototypeEvent02_set00_choice04,new Segment(dialogue.event_PrototypeEvent02_set04_line01,name.ange,new Segment(dialogue.event_PrototypeEvent02_set04_line02,name.ange), () => SetFlags(4)))
					),
				new Segment(dialogue.event_PrototypeEvent02_set00_line03,name.ange),
				new Segment(dialogue.event_PrototypeEvent02_set00_line04,name.ange),
				new Segment(dialogue.event_PrototypeEvent02_set00_line05,name.ange,
					new Choice(dialogue.event_PrototypeEvent02_set00_choice05,new Segment(dialogue.event_PrototypeEvent02_set00_line06,name.ange,EndEvent)),
					new Choice(dialogue.event_PrototypeEvent02_set00_choice06,new Segment(dialogue.event_PrototypeEvent02_set00_line06,name.ange,EndEvent))
				),
			};
		}

		public void EndEvent()
		{
			OnEventEnd.Invoke(null);
		}

		private void SetFlags(int i)
		{
			switch (i)
			{
				case 1:
					EventHandler.storyFlags.flag01 = true;
					break;
				case 2:
					EventHandler.storyFlags.flag02 = true;
					break;
				case 3:
					EventHandler.storyFlags.flag03 = true;
					break;
				case 4:
					EventHandler.storyFlags.flag04 = true;
					break;
			}
		}
	}
}
