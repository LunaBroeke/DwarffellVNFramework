using Dwarffell.TextEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwarffell.VisualNovelFramework
{
	public interface IEvent
	{
		public List<Segment> segments { get; set; }
		public Action OnEventEnd { get; set; }

		public void EndEvent();
	}
}
