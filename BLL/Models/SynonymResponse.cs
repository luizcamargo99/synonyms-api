using System.Collections.Generic;

namespace BLL.Models
{
    public class SynonymResponse : Response
    {
        public List<string> SynonymsList { get; set; }
        public string Word { get; set; }

        public SynonymResponse()
        {
            SynonymsList = new List<string>();
        }
    }
}
