using Dwarffell.TextEngine;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Serialization;

namespace Dwarffell.VisualNovelFramework
{
	public static class EventHandler
	{
		public static event Action<Segment> OnSegmentLoad;
		public static event Action<Segment> OnChoicesLoad;
		public static event Action<Exception> OnException;
		public static event Action OnEnding;
		public static StoryFlags storyFlags = new StoryFlags();

		public static bool choiceMode = false;
		public static int choice = 0;
		public static Segment GetEventData(IEvent loadedEvent, int i)
		{
			try
			{
				Segment s = loadedEvent.segments[i];
				if (s.action != null)
				{
					s.action?.Invoke();
				}
				else if (s.actions != null)
				{
					foreach (Action a in s.actions)
					{
						a?.Invoke();
					}
				}
				if (s.choice1 != null)
				{
					OnChoicesLoad?.Invoke(s);
					LoadChoices();
					return s;
				}
				OnSegmentLoad?.Invoke(s);
				return s;
			}
			catch (Exception e) 
			{
				OnEnding?.Invoke();
				throw new SegmentOutofRangeException("Ended!");
				OnException?.Invoke(e);
				OnSegmentLoad?.Invoke(new Segment($"!!!!{TextPlayer.text.errorMessages.getError}!!!! \n++\n {e.Message}\n++"));
				return null;
			}
		}
		public static void LoadSegment(Segment s)
		{
			OnSegmentLoad?.Invoke(s);
		}

		public static void LoadChoices()
		{
			choiceMode = true;
			choice = 0;
		}
		public static void UnLoadChoices()
		{
			choiceMode = false;
			choice = 0;
		}
		public static Segment MakeChoice(Segment s, int i)
		{
			try
			{
				switch (i)
				{
					case 1:
						return s.choice1.nextSegment;
					case 2:
						return s.choice2.nextSegment;
					case 3:
						return s.choice3.nextSegment;
					case 4:
						return s.choice4.nextSegment;
				}
			}
			catch
			{
				return null;
			}
			return null;
		}
		public static void WipeSubs(Action action)
		{
			foreach (var d in action.GetInvocationList())
			{
				action -= d as Action;
			}
		}
		public static void WipeSubs(Action<IEvent> action)
		{
			foreach (var d in action.GetInvocationList())
			{
				action -= d as Action<IEvent>;
			}
		}
	}
	public class Segment
	{
		public Segment(string text)
		{
			this.charText = text;
		}
		public Segment(string text, string name)
		{
			this.charText = text;
			this.charName = name;
		}
		public Segment(string text, string name, Action action)
		{
			this.charText = text;
			this.charName = name;
			this.action = action;
		}
		public Segment(string text, string name, List<Action> actions)
		{
			this.charText = text;
			this.charName = name;
			this.actions = actions;
		}
		public Segment(string text, string name, Choice c1, Choice c2 = null, Choice c3 = null, Choice c4 = null)
		{
			this.charText = text;
			this.charName = name;
			this.choice1 = c1;
			this.choice2 = c2;
			this.choice3 = c3;
			this.choice4 = c4;
		}
		public Segment(string text, string name, Segment nextSegment)
		{
			this.charText = text;
			this.charName = name;
			this.nextSegment = nextSegment;
		}
		public Segment(string text, string name, Segment nextSegment, Action action)
		{
			this.charText = text;
			this.charName = name;
			this.nextSegment = nextSegment;
			this.action = action;
		}
		public string charName = string.Empty;
		public string charText = string.Empty;
		public Action action = null;
		public List<Action> actions = null;
		public Choice choice1 = null;
		public Choice choice2 = null;
		public Choice choice3 = null;
		public Choice choice4 = null;
		public Segment nextSegment = null;
	}
	public class Choice
	{
		public Choice(string text, Action action)
		{
			this.choiceText = text;
			this.action = action;
		}
		public Choice(string text, Segment s)
		{
			this.choiceText = text;
			this.nextSegment = s;
		}
		public string choiceText;
		public Action action;
		public Segment nextSegment;
	}

	public class SegmentOutofRangeException : Exception
	{
		public SegmentOutofRangeException()
		{

		}

		public SegmentOutofRangeException(string message) : base(message)
		{

		}

		public SegmentOutofRangeException(string message, Exception innerException) : base(message, innerException)
		{

		}

		protected SegmentOutofRangeException(SerializationInfo info, StreamingContext context) : base(info, context)
		{

		}
	}
}
