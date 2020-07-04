using System;

namespace CoreDemo.Models
{
    /// <summary>
    /// 电影院
    /// </summary>
    public class Cinema
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
    }
}
