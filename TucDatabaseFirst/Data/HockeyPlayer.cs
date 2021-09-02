﻿namespace TucDatabaseFirst.Data
{
    public enum Position
    {
        Goalie,
        Defence,
        Forward
    }

    public class HockeyPlayer
    {
        public int Id { get; set; }
        public string Namn { get; set; }
        public int JerseyNumber { get; set; }

        public string RegNummer { get; set; } //6 tecken
        public string City { get; set; }
    }
}