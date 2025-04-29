
using System.ComponentModel.DataAnnotations;

public class BackendMain {

    /*
    Description: Method to instantiate an Asset 
    @output: List<Asset>
    @input: String[] parameters
    */
    public static List<Asset> addAsset(List<Asset> assets, string[] parameters) {
        Asset asset = buildAsset(parameters);
        assets.Add(asset);
        return assets;
    }

    /*
    Description: Method to build an Asset object from parameters
    @input: string[] parameters
    @output: Asset
    */
    private static Asset buildAsset(string[] parameters) {
        // Assumes parameters:
        // [0-6] => Entity
        // [7-11] => Relation
        // [12-17] => ValueType

        Entity entity = buildEntity(parameters);
        Relation relation = buildRelation(parameters);
        ValueType valueType = buildValueType(parameters);

        return new Asset(entity, relation, valueType);
    }

    /*
    Description: Method to build an entity object and initialize it with parameters
    */
    private static Entity buildEntity(string[] parameters) {
        Entity entity = new Entity();

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
    Description: Method to build a Relation object from parameters
    */
    private static Relation buildRelation(string[] parameters) {
        Relation relation = new Relation();

        if (parameters.Length > 7) relation.AltName = parameters[7];
        if (parameters.Length > 8) relation.Description = parameters[8];
        if (parameters.Length > 9) relation.Cardinality = parameters[9];
        if (parameters.Length > 10) relation.Role = parameters[10];
        if (parameters.Length > 11) relation.InverseRole = parameters[11];

        return relation;
    }

    /*
    Description: Method to build a ValueType object from parameters
    */
    private static ValueType buildValueType(string[] parameters) {
        ValueType valueType = new ValueType();

        if (parameters.Length > 12) valueType.Type = parameters[12];
        if (parameters.Length > 13) valueType.Description = parameters[13];

        if (parameters.Length > 14 && double.TryParse(parameters[14], out double min))
            valueType.Min = min;

        if (parameters.Length > 15 && double.TryParse(parameters[15], out double max))
            valueType.Max = max;

        if (parameters.Length > 16) valueType.Example = parameters[16];

        if (parameters.Length > 17 && !string.IsNullOrEmpty(parameters[17]))
            valueType.AllowedValues = parameters[17].Split(',').Select(s => s.Trim()).ToList();

        return valueType;
    }

        /*
    Example input string array:
    string[] parameters = new string[]
    {
        "Electric Motor",                              // [0] Entity.Description
        "RotatingMachine,Electromechanical",           // [1] Entity.SpecializationOf
        "MotorHousing,DriveShaft",                     // [2] Entity.CompositionOf
        "MotorID",                                      // [3] Entity.Attributes.Name
        "Unique identifier for the motor",             // [4] Entity.Attributes.Description
        "string",                                       // [5] Entity.Attributes.ValueType
        "EM-12345",                                     // [6] Entity.Attributes.Value

        "has a",                                        // [7] Relation.AltName
        "Motor has a unique identifier",               // [8] Relation.Description
        "1..1",                                         // [9] Relation.Cardinality
        "owner",                                        // [10] Relation.Role
        "owned",                                        // [11] Relation.InverseRole

        "string",                                       // [12] ValueType.Type
        "ID as a string",                               // [13] ValueType.Description
        "0",                                            // [14] ValueType.Min
        "",                                             // [15] ValueType.Max (blank/null)
        "EM-12345",                                     // [16] ValueType.Example
        ""                                              // [17] ValueType.AllowedValues (optional, comma-separated)
    };
    */
}


