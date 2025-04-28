
using System.ComponentModel.DataAnnotations;

class BackendMain {

    /*
    Description: Method to instantiate an entity 
    @output: Entity
    @input: String[]
    */
    static List<Entity> addAsset(List<Entity> assets, string[] parameters) {
        assets.Add(new Entity());
        int length = assets.Count();
        assets[length] = buildAsset(assets[length], parameters);
        return assets;
    }

    /*
    Description: Methood to build an asset, i.e take instantiated asset and populate all it's
    fields as desired by the user. 
    @input: (Entity, string[])
    @output: Entity 
    */
    static Entity buildAsset(Entity asset, string[] parameters) {
        //TODO:
        
        return asset;
    }
}
