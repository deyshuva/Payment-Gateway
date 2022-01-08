using System;
namespace Interface
{
	public interface IConnect
	{
		bool Connect(string userName, string password);
		void Disconnect();
	}
}