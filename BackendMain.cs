
using System.ComponentModel.DataAnnotations;

class BackendMain {

    /*
    Description: Method to instantiate an Asset 
    @output: List<Asset>
    @input: String[]
    */
    public static List<Asset> addAsset(List<Asset> assets, string[] parameters) {
        
        Asset asset = buildAsset(parameters);
        assets.Add(asset);
        return assets;
    }

    /*
    Description: Methood to build an asset, i.e take instantiated asset and populate all it's
    fields as desired by the user. 
    @input: (Asset, string[])
    @output: Asset 
    */
    private static Asset buildAsset(string[] parameters) {
        //TODO:
        Asset asset = new Asset();

        return asset;
    }

    
    
    /*
    Description: Method to build an entity object and initialize it with all of the parameters parsed. 
    fields as desired by the user. 
    @input: (Asset, string[])
    @output: Asset 
    */
    private Entity buildEntity(string[] parameters) {
        Entity entity = new Entity();
        /*
        Assuming parameter mapping like:
        parameters[0] = Description
        parameters[1] = SpecializationOf (comma-separated)
        parameters[2] = CompositionOf (comma-separated)
        parameters[3] = Attribute Name
        parameters[4] = Attribute Description
        parameters[5] = Attribute ValueType
        parameters[6] = Attribute Value
        */
        if (parameters.Length > 0) entity.Description = parameters[0];
        if (parameters.Length > 1 && !string.IsNullOrEmpty(parameters[1]))
            entity.SpecializationOf = parameters[1].Split(',').Select(s => s.Trim()).ToList();
        if (parameters.Length > 2 && !string.IsNullOrEmpty(parameters[2]))
            entity.CompositionOf = parameters[2].Split(',').Select(s => s.Trim()).ToList();
        if (parameters.Length > 3) entity.Attributes.Name = parameters[3];
        if (parameters.Length > 4) entity.Attributes.Description = parameters[4];
        if (parameters.Length > 5) entity.Attributes.ValueType = parameters[5];
        if (parameters.Length > 6) entity.Attributes.Value = parameters[6];

        return entity; 
    }

    /*
    //Example of paramters:
    string[] parameters = new string[] {
        "Electric Motor",                     // [0] Description
        "RotatingMachine,Electromechanical", // [1] SpecializationOf (comma-separated)
        "MotorHousing,DriveShaft",           // [2] CompositionOf (comma-separated)
        "MotorID",                            // [3] Attribute Name
        "Unique identifier for the motor",   // [4] Attribute Description
        "string",                             // [5] Attribute ValueType
        "EM-12345"                            // [6] Attribute Value
    };
    */


    /*
    Description: Method to build an entity object and initialize it with all of the parameters parsed. 
    fields as desired by the user. 
    @input: (Asset, string[])
    @output: Asset 
    */
    private Relation buildRelation(string[] parameters) {
        Relation relation = new Relation();
        
        if (parameters.Length > 0) entity.Description = parameters[0];
        if (parameters.Length > 1 && !string.IsNullOrEmpty(parameters[1]))
            entity.SpecializationOf = parameters[1].Split(',').Select(s => s.Trim()).ToList();
        if (parameters.Length > 2 && !string.IsNullOrEmpty(parameters[2]))
            entity.CompositionOf = parameters[2].Split(',').Select(s => s.Trim()).ToList();
        if (parameters.Length > 3) entity.Attributes.Name = parameters[3];
        if (parameters.Length > 4) entity.Attributes.Description = parameters[4];
        if (parameters.Length > 5) entity.Attributes.ValueType = parameters[5];
        if (parameters.Length > 6) entity.Attributes.Value = parameters[6];

        return entity; 
    }

}

