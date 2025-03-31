public class Comment
{
    public string CommenterName { get; set; }
    public string CommentText { get; set; }

    public Comment(string commenterName, string commentText)
    {
        CommenterName = commenterName;
        CommentText = commentText;
    }
}
public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    public List<Comment> Comments { get; set; }

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        Comments = new List<Comment>();
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }
}
using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        
        Video video1 = new Video("C# Basics Tutorial", "John Doe", 600);
        video1.Comments.Add(new Comment("Alice", "Great tutorial!"));
        video1.Comments.Add(new Comment("Bob", "Very helpful."));
        video1.Comments.Add(new Comment("Charlie", "Thanks for sharing!"));

        Video video2 = new Video("Python for Beginners", "Jane Smith", 900);
        video2.Comments.Add(new Comment("David", "Awesome content!"));
        video2.Comments.Add(new Comment("Eve", "I learned a lot."));
        video2.Comments.Add(new Comment("Frank", "Keep up the good work!"));
        video2.Comments.Add(new Comment("Grace", "Fantastic!"));

        Video video3 = new Video("JavaScript Fundamentals", "Mike Johnson", 750);
        video3.Comments.Add(new Comment("Henry", "This is amazing."));
        video3.Comments.Add(new Comment("Ivy", "Perfect explanation."));
        video3.Comments.Add(new Comment("Jack", "Super clear."));

        Video video4 = new Video("Data Structures Explained", "Susan Williams", 1200);
        video4.Comments.Add(new Comment("Kelly", "Really helpful!"));
        video4.Comments.Add(new Comment("Liam", "Thanks for this!"));
        video4.Comments.Add(new Comment("Mia", "Very informative."));
        video4.Comments.Add(new Comment("Noah", "Well explained."));

        
        List<Video> videos = new List<Video> { video1, video2, video3, video4 };

        
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            Console.WriteLine("Comments:");
            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.CommentText}");
            }

            Console.WriteLine();
        }

        
        Console.ReadLine();
    }
}