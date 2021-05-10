using System;

namespace ForumProject.Biz.Domain.Exceptions
{
    public class DbRuleException : Exception
    {
        public string Content { get; }

        public DbRuleException(string calledOn)
        {
            Content = $"{calledOn} is invalid";
        }
    }
}