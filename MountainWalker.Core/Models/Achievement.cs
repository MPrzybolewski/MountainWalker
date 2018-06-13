using System;
using Newtonsoft.Json;

namespace MountainWalker.Core.Models
{
    public class Achievement
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("date")]
        public string Date { get; set; }
        public bool IsReached { get; set; }
        public string Trophy
        {
            get
            {
				if(Os == "android")
				{
					if (IsReached)
                        return "@drawable/trophy";
                    else
                        return "@drawable/trophyx";	
				}
				else
				{
					if (IsReached)
						return "trophy";
					else
						return "trophyx";
				}
     
                
            }
        }

		public static string Os { get; set; }

        public Achievement () { }

        public Achievement(int id, string name)
        {
            Id = id;
            Name = name;
            Date = "-";
            IsReached = false;
        }
    }
}
