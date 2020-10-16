namespace WeatherBot.RequestModels.LocationApi
{
    public class Details
    {
        public string Key { get; set; }
        public string StationCode { get; set; }
        public float? StationGmtOffset { get; set; }
        public string BandMap { get; set; }
        public string Climo { get; set; }
        public string LocalRadar { get; set; }
        public string MediaRegion { get; set; }
        public string Metar { get; set; }
        public string NxMetro { get; set; }
        public string NxState { get; set; }
        public long? Population { get; set; }
        public string PrimaryWarningCountyCode { get; set; }
        public string PrimaryWarningZoneCode { get; set; }
        public string Satellite { get; set; }
        public string Synoptic { get; set; }
        public string MarineStation { get; set; }
        public float? MarineStationGmtOffset { get; set; }
        public string VideoCode { get; set; }
        public int? PartnerId { get; set; }
        public Dma Dma { get; set; }
        public SourceModel[] Sources { get; set; }
        public string CanonicalPostalCode { get; set; }
        public string CanonicalLocationKey { get; set; }
        public string LocationStem { get; set; }
    }
}