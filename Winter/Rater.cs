using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winter
{
	class Rater
	{
		string state { get; set; }
		Dictionary<string, Dictionary<string, string>> dict { get; set; }

		public Rater()
		{
			dict = new Dictionary<string, Dictionary<string, string>>();
		}

		public Dictionary<string, Dictionary<string, string>> GetAverageRate()
		{
			/*
			String[] lines = System.IO.File.ReadAllLines(@"StateAveragePremium.txt");

			foreach (string line in lines)
			{
				string[] arr_temp = line.Split(' ');

				if (!this.dict.ContainsKey(this.state))
				{
					this.dict.Add(arr_temp[0], new Dictionary<string, string>() { { arr_temp[1], arr_temp[2] } });
				}
				else
				{
					dict[arr_temp[0]].Add(arr_temp[1], arr_temp[2]);
				}
			}
        
			*/

			dict.Add("AZ", new Dictionary<string, string>() { 
			                                                  { "Progressive", "419.833333"}, 
			                                                  { "Metlife", "808.350810"} 
			                                                });
			dict.Add("CA", new Dictionary<string, string>() { { "Progressive", "767.591538" }, { "21st Century Insurance", "802.730769" } });
			return dict;
		}

		public Dictionary<string, string> GetAverageRateForState(string state)
		{
			Dictionary<string, Dictionary<string, string>> collection = GetAverageRate();

			return collection[state];
		}
	}
}
