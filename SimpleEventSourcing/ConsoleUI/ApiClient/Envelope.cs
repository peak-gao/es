﻿namespace ConsoleUI
{
	public class Envelope<T>
	{
		public T Result { get; set; }
		public string ErrorMessage { get; set; }
	}
}
