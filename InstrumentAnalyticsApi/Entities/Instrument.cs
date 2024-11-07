
namespace InstrumentAnalyticsApi.Entities;


public class Identifiers
{
    public string isin { get; set; }
    public string clientInternal { get; set; }
    public string lusidInstrumentId { get; set; }
    public string sedol { get; set; }
}

public class InstrumentDefinition
{
    public DateTime? startDate { get; set; }
    public DateTime? maturityDate { get; set; }
    public string domCcy { get; set; }

    public double? couponRate { get; set; }
    public Identifiers identifiers { get; set; }
    public string calculationType { get; set; }

    public string instrumentType { get; set; }
}

public class InstrumentRoot{
    public IEnumerable<Instrument> values{get; set;}
}
public class Instrument
{
    // public string Href { get; set; }
    public string scope { get; set; }
    public string lusidInstrumentId { get; set; }

    public string name { get; set; }
    public Identifiers identifiers { get; set; }
    
        public InstrumentDefinition instrumentDefinition { get; set; }
    public string state { get; set; }
    public string assetClass { get; set; }
    public string domCcy { get; set; }
}


// public class Version
// {
//     public DateTime effectiveFrom { get; set; }
//     public DateTime asAtDate { get; set; }
//     public DateTime asAtCreated { get; set; }
//     public string userIdCreated { get; set; }
//     public string requestIdCreated { get; set; }
//     public DateTime asAtModified { get; set; }
//     public string userIdModified { get; set; }
//     public string requestIdModified { get; set; }
//     public int? asAtVersionNumber { get; set; }
//     public string entityUniqueId { get; set; }
// }

