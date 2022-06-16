using System.Collections.Generic;

namespace BLL.Models
{
    public class ResponseSynonym : Response
    {
        public List<string> SynonymsList { get; set; }
        public string Word { get; set; }

        public ResponseSynonym(string word)
        {
            SynonymsList = new List<string>();
            Word = word;
        }
    }
}
