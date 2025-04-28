 public class Asset {
        public string Description {get; set;}
        public List<string> SpecializationOf {get; set;}
        public List<string> CompositionOf {get; set;}
        public Dictionary<string, object> Associations {get; set;}
        public AssetAttributes Attributes {get; set;}

        public Asset() {
          	 Description = string.Empty;
            SpecializationOf = new List<string>();
            CompositionOf = new List<string>();
            Associations = new Dictionary<string, object>();
            Attributes = new AssetAttributes();
        }
    }

    public class AssetAttributes {
        public string Name {get; set;}
        public string Description {get; set;}
    }

//Asset asset = new Asset();

// Set properties
asset.Description = "A reusable resource example";
asset.SpecializationOf.Add("BaseAsset");
asset.CompositionOf.Add("SubComponent1");
asset.Associations.Add("relatedAsset", "AssetId123");
asset.Attributes.Name = "ExampleAsset";
asset.Attributes.Description = "Detailed description of the asset";

// (Optional) Print some values
Console.WriteLine(asset.Attributes.Name); // Outputs: ExampleAsset
