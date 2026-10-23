using System;

namespace MundialDESKTOP.V1.Models
{
    // --- MODELOS DE ESTADO GLOBAL (/api/state) ---
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

    public class Station
    {
        public string id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public Location location { get; set; }
        public int availableUnitCount { get; set; }
    }

    public class Unit
    {
        public string id { get; set; }
        public string stationId { get; set; }
        public string type { get; set; }
        public string callSign { get; set; }
        public string status { get; set; }
        public Location position { get; set; }
        public string assignedIncidentId { get; set; }
    }

    public class Location
    {
        public double x { get; set; }
        public double y { get; set; }
    }

    // --- MODELOS DAS CHAMADAS TELEFÔNICAS (/api/calls) ---
    public class CallsResponse
    {
        public DateTime serverTime { get; set; }
        public int ringingCount { get; set; } // Quantidade de chamadas tocando (ótimo para o badge)
        public Call[] calls { get; set; }
    }

    public class Call
    {
        public string id { get; set; }
        public string status { get; set; } // "ringing", "active", "ended", "rejected"
        public string callerName { get; set; }
        public string callerNumber { get; set; } // Ajustado conforme o JSON da API
        public string reportedType { get; set; }
        public string description { get; set; }
        public Location location { get; set; }
        public DateTime startedAt { get; set; }
        public DateTime? answeredAt { get; set; }
        public DateTime? endedAt { get; set; }
        public string linkedIncidentId { get; set; }
    }
}