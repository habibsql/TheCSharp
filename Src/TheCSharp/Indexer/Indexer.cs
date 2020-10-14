using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TheCSharp.Indexer
{
    public class Indexer
    {
        private readonly string[] countries = new string[] { "Bangladesh", "India", "Pakistan" };

        /// <summary>
        /// Retrive and set country name from/to countries list using index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string this[int index]
        {
            get
            {
                string country = countries[index];

                return country;
            }

            set
            {
                countries[index] = value;
            }
        }

        /// <summary>
        /// Retrun index from countries using country name
        /// </summary>
        /// <param name="countryName"></param>
        /// <returns></returns>
        public int this[string countryName]
        {
            get
            {
                for(int index =0; index < countries.Length; index++)
                {
                    if (countries[index].Equals(countryName) )
                    {
                        return index;
                    }
                }

                return -1;
            }
        }
    }
}
