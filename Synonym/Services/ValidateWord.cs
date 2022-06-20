using Root.Interfaces;
using System;

namespace Synonym.Services
{
    public class ValidateWord : IValidate
    {
        private readonly string _word;

        public ValidateWord(string word)
        {
            _word = word;
        }

        public void Validate ()
        {
            if (string.IsNullOrEmpty(_word))
            {
                throw new ArgumentException("The word field is null or empty");
            }
        }
    }
}
