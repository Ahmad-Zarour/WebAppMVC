using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconWebApp.Models
{
    public class FeverCheckerModel
    {
        public float Temperature { get; set; }
        

		public static string Fever(float temperature)
		{
         
            if (temperature <= 35)
                return "Too low temperature!, Please call for help";
            else if (temperature >= 39)
                return "You have a fever ,Please call for help ";
            else
                return "You Are Ok!";
        }
	}
}
