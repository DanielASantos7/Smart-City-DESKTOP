using System;

namespace MundialDESKTOP.V1.Models
{
    public class StateResponse
    {
        public DateTime serverTime { get; set; }
        public Incident[] incidents { get; set; }
        public Station[] stations { get; set; }
        public Unit[] units { get; set; }
    }

    public class Incident
    {
        public string id { get; set; }
        public string type { get; set; }
        public string subtype { get; set; }
        public string severity { get; set; }
        public string status { get; set; }
        public DateTime reportedAt { get; set; }
        public Location location { get; set; }
        public string description { get; set; }
        public string[] assignedUnitIds { get; set; }
        public string[] attendingUnitIds { get; set; }
        public string callId { get; set; }
        public DateTime? resolvedAt { get; set; }
    }

    public class Location
    {
        public double x { get; set; }
        public double y { get; set; }
    }

    public class Station
    {
        public string id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public Location1 location { get; set; }
        public int availableUnitCount { get; set; }
    }

    public class Location1
    {
        public double x { get; set; }
        public double y { get; set; }
    }

    public class Unit
    {
        public string id { get; set; }
        public string stationId { get; set; }
        public string type { get; set; }
        public string callSign { get; set; }
        public string status { get; set; }
        public Position position { get; set; }
        public string assignedIncidentId { get; set; }
    }

    public class Position
    {
        public float x { get; set; }
        public float y { get; set; }
    }

}
