using System;

namespace ForumProject.Biz.Domain.Exceptions
{
    public class InvalidInputException : Exception
    {
        public string Content { get; }

        public InvalidInputException(string calledOn)
        {
            Content = $"{calledOn} is invalid";
        }
    }
}