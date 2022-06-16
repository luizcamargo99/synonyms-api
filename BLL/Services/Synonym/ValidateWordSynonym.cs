using BLL.Interfaces;
using System;

namespace BLL.Services
{
    public class ValidateWordSynonym : IValidate
    {
        private readonly string _word;

        public ValidateWordSynonym(string word)
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
