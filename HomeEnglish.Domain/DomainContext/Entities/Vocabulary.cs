using System;
using System.Collections.Generic;
using System.Linq;
using HomeEnglish.Domain.Enumns;
using HomeEnglish.Shared.Entities;

namespace HomeEnglish.Domain.Entities
{
    public class Vocabulary : BaseEntity
    {
        public Guid UidStudent { get; private set; }
        public IList<Word> Words { get; private set; }

        public Vocabulary(Guid uidStudent)
        {
            this.UidStudent = uidStudent;
            this.Words = new List<Word>();
        }

        public void AddWord(Word word)
        {
            this.Words.Add(word);
        }

        public string ModifyWord(Word word)
        {
            Word result = this.Words.SingleOrDefault(x => x.Uid == word.Uid);
            if(result == null)
            {
                return "The word was not found";
            }
            result = word;

            return $"Word '{word}' has been successfully modified.";
        }
        
        public void RemoveWord(Word word)
        {
            this.Words.Remove(word);
        }
    }
}