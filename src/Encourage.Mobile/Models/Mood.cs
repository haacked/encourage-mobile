﻿using SQLite;

namespace Encourage.Mobile.Models
{
	public class Mood : IDatabaseEntity
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public string BackgroundColor { get; set; } = null!;
		public string TextColor { get; set; } = null!;
	}
}
