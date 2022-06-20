using System.Collections.Generic;

namespace BLL.Models
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
