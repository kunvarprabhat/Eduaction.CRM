using System;
using System.Collections.Generic;

namespace Eduaction.DataModel.DataModels;

public partial class CollegeCourse
{
    public int CollegeId { get; set; }

    public int CourseId { get; set; }

    public bool Specialization { get; set; }

    public virtual CollegeMaster College { get; set; } = null!;

    public virtual CourseMaster Course { get; set; } = null!;
}
