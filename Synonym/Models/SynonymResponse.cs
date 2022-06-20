using Root.Models;
using System.Collections.Generic;

namespace Synonym.Models
{
    public class SynonymResponse : Response
    {
        public string Word { get; set; }
        public List<string> Synonyms { get; set; }       

        public SynonymResponse()
        {
            Synonyms = new List<string>();
        }
    }
}
