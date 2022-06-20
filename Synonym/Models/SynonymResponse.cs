using Root.Models;
using System.Collections.Generic;

namespace Synonym.Models
{
    public class SynonymResponse : Response
    {
        public List<string> Synonyms { get; set; }
        public string Word { get; set; }

        public SynonymResponse()
        {
            Synonyms = new List<string>();
        }
    }
}
