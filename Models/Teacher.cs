﻿namespace webapi.Models;

public class Teacher
{


    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }


    public int CourseId { get; set; }
    public Course Course { get; set; }

}
