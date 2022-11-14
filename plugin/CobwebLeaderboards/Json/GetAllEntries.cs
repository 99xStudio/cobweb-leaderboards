namespace CWLB.Json;

public class GetAllEntries // use IEnumarable<GetAllEntries>
{
    public int id { get; set; }
    public DateTime created_at { get; set; }
    public string mod_guid { get; set; }
    public int score { get; set; }
    public string player_name { get; set; }
    public string mod_name { get; set; }
}