
using System.ComponentModel.DataAnnotations;

class BackendMain {

    /*
    Description: Method to instantiate an entity 
    @output: Entity
    @input: String[]
    */
    static List<Entity> addAsset(List<Entity> assets, string[] parameters) {
        Entity asset = new Entity();
        asset = buildAsset(asset, parameters);
        assets.Add(asset);
        return assets;
    }

    /*
    Description: Methood to build an asset, i.e take instantiated asset and populate all it's
    fields as desired by the user. 
    @input: (Entity, string[])
    @output: Entity 
    */
    static Entity buildAsset(Entity asset, string[] parameters) {
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
        
        if (parameters.Length > 0) asset.Description = parameters[0];
        if (parameters.Length > 1 && !string.IsNullOrEmpty(parameters[1]))
            asset.SpecializationOf = parameters[1].Split(',').Select(s => s.Trim()).ToList();
        if (parameters.Length > 2 && !string.IsNullOrEmpty(parameters[2]))
            asset.CompositionOf = parameters[2].Split(',').Select(s => s.Trim()).ToList();
        if (parameters.Length > 3) asset.Attributes.Name = parameters[3];
        if (parameters.Length > 4) asset.Attributes.Description = parameters[4];
        if (parameters.Length > 5) asset.Attributes.ValueType = parameters[5];
        if (parameters.Length > 6) asset.Attributes.Value = parameters[6];

        return asset;
    }
}
