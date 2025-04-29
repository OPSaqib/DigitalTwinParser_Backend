// FOR CLASSES.JSON
public class Entity {
    public string? Description {get; set;}
    public List<string> SpecializationOf {get; set;}
    public List<string> CompositionOf {get; set;}
    public EntityAssociations Associations {get; set;}
    public EntityAttributes Attributes {get; set;}

    public Entity() {
        Description = null;
        SpecializationOf = new List<string>();
        CompositionOf = new List<string>();
        Associations = new EntityAssociations();
        Attributes = new EntityAttributes();
    }
}

public class EntityAssociations {
    public Dictionary<string, AssociationItem> Has {get; set;}
    public Dictionary<string, AssociationItem> Input {get; set;}
    public Dictionary<string, AssociationItem> Contains {get; set;}

    public EntityAssociations() {
        Has = new Dictionary<string, AssociationItem>();
        Input = new Dictionary<string, AssociationItem>();
        Contains = new Dictionary<string, AssociationItem>();
    }
}

public class AssociationItem {
    public string? Name {get; set;}
    public int? Min {get; set;}
    public int? Max {get; set;}
}

public class EntityAttributes {
    public string? Name {get; set;}
    public string? Description {get; set;}
    public string? ValueType {get; set;}
    public string? Value {get; set;}
}

//EXAMPLE OF INSTIATING DIFFERENT OBJECTS FROM THIS CLASSES.JSON FILE:

/*
// Instantiate Asset
Entity asset = new Entity();
asset.Description = "A resource that can be reused or extended.";
asset.SpecializationOf.Add("BaseAsset"); // JSON has empty array, example value added
asset.CompositionOf.Add("SubComponent1"); // JSON has empty array, example value added
asset.Attributes.Name = "ExampleAsset";
asset.Attributes.Description = "Detailed description of the asset";

// Instantiate Component
Entity component = new Entity();
component.Description = "A specialized asset, that defines a specific object to be modeled virtually. It can be part of a system. It can have 1 or more related models and/or properties. Once defined with 1 or more models, it can be considered a proper asset.";
component.SpecializationOf.Add("Asset");
component.CompositionOf.Add("SubComponent"); // JSON has empty array, example value added
component.Associations.Has.Add("1", new AssociationItem { Name = "Model", Min = 1, Max = null });
component.Associations.Has.Add("2", new AssociationItem { Name = "Property", Min = 0, Max = null });
component.Associations.Has.Add("3", new AssociationItem { Name = "Concept", Min = 1, Max = 1 });
component.Associations.Input.Add("1", new AssociationItem { Name = "Component", Min = 0, Max = null });
component.Associations.Contains.Add("1", new AssociationItem { Name = "Component", Min = 0, Max = null });

// Instantiate System
Entity system = new Entity();
system.Description = "A collection of components that work together to achieve a common goal.";
system.SpecializationOf.Add("Component");
system.CompositionOf.Add("Component");
system.Associations.Has.Add("1", new AssociationItem { Name = "Composition", Min = 1, Max = null });

// Instantiate Property
Entity property = new Entity();
property.Description = "A possibly shared attribute, that can be used to further define a component. It exists to allow for more flexibility when defining components. It can be used for a wide variety of purposes.";
property.SpecializationOf.Add("BaseProperty"); // JSON has empty array, example value added
property.CompositionOf.Add("SubProperty"); // JSON has empty array, example value added
property.Associations.Has.Add("1", new AssociationItem { Name = "Concept", Min = 1, Max = 1 });
property.Attributes.Name = "string";
property.Attributes.Description = "string";
property.Attributes.ValueType = "./ValueTypes.json";
property.Attributes.Value = "custom";

// Instantiate Model
Entity model = new Entity();
model.Description = "A placeholder to represent the relation a component or system can have with a different model. It can be used to define a component's behavior, simulation, and visual properties.";
model.SpecializationOf.Add("BaseModel"); // JSON has empty array, example value added
model.CompositionOf.Add("SubModel"); // JSON has empty array, example value added
model.Attributes.Name = "ExampleModel";
model.Attributes.Description = "Detailed description of the model";

// Instantiate Behavior
Entity behavior = new Entity();
behavior.Description = "A placeholder to represent the behavior model. It is a specialization of model, and as such inherits all from it.";
behavior.SpecializationOf.Add("Model"); // JSON has empty array, example value added
behavior.CompositionOf.Add("SubBehavior"); // JSON has empty array, example value added

// Instantiate Simulation
Entity simulation = new Entity();
simulation.Description = "A placeholder to represent the simulation model. It is a specialization of model, and as such inherits all from it.";
simulation.SpecializationOf.Add("Model"); // JSON has empty array, example value added
simulation.CompositionOf.Add("SubSimulation"); // JSON has empty array, example value added

// Instantiate Visual
Entity visual = new Entity();
visual.Description = "A placeholder to represent the visual model. It is a specialization of model, and as such inherits all from it. This references visual assets, which can be anything from a 3D model to a 2D image.";
visual.SpecializationOf.Add("Model"); // JSON has empty array, example value added
visual.CompositionOf.Add("SubVisual"); // JSON has empty array, example value added

// Instantiate Concept
Entity concept = new Entity();
concept.Description = "A concept is a high-level abstraction that can be used to define a component semantics. It is, generally, obtained from an ontology.";
concept.SpecializationOf.Add("BaseConcept"); // JSON has empty array, example value added
concept.CompositionOf.Add("SubConcept"); // JSON has empty array, example value added
concept.Associations.Has.Add("1", new AssociationItem { Name = "Domain Ontology", Min = 0, Max = 1 });
concept.Attributes.Name = "ExampleConcept";
concept.Attributes.Description = "Detailed description of the concept";

// Instantiate Domain Ontology
Entity domainOntology = new Entity();
domainOntology.Description = "A reference to the version and name of the ontology concepts come from.";
domainOntology.SpecializationOf.Add("BaseOntology"); // JSON has empty array, example value added
domainOntology.CompositionOf.Add("SubOntology"); // JSON has empty array, example value added
domainOntology.Associations.Has.Add("1", new AssociationItem { Name = "Concept", Min = 0, Max = null });
domainOntology.Attributes.Name = "ExampleOntology";
domainOntology.Attributes.Description = "Detailed description of the ontology";

// Instantiate Composition
Entity composition = new Entity();
composition.Description = "A dummy class (placeholder) to represent that a system has some composition description. This is similar to a model.";
composition.SpecializationOf.Add("BaseComposition"); // JSON has empty array, example value added
composition.CompositionOf.Add("SubComposition"); // JSON has empty array, example value added
composition.Attributes.Name = "ExampleComposition";
composition.Attributes.Description = "Detailed description of the composition";
*/


// FOR Relations.json
public class Relation {
    public string? AltName {get; set;}
    public string? Description {get; set;}
    public string? Cardinality {get; set;}
    public string? Role {get; set;}
    public string? InverseRole {get; set;}

    public Relation() {
        AltName = null;
        Description = null;
        Cardinality = null;
        Role = null;
        InverseRole = null;
    }
}

//EXAMPLE OF INSTIATING DIFFERENT OBJECTS FROM THIS CLASSES.JSON FILE:

/*
// Instantiate Composition
Relation composition = new Relation();
composition.AltName = "composition of";
composition.Description = "A strong ownership relationship where the child cannot exist without the parent.";
composition.Cardinality = "1..*";
composition.Role = "parent";
composition.InverseRole = "child";

// Instantiate Specialization
Relation specialization = new Relation();
specialization.AltName = "specialization of";
specialization.Description = "A relationship where one class is a specialized version of another. If A specalizes B, then A is a subclass of B.";
specialization.Cardinality = "1..1";
specialization.Role = "specalized class";
specialization.InverseRole = "generalized class";

// Instantiate Associations.Has
Relation has = new Relation();
has.AltName = "has a";
has.Description = "A custom relationship that describes that A has B in a non-compositional manner. E.g., Air has matter state, being gas(eous).";
has.Cardinality = "1..1";
has.Role = "owner";
has.InverseRole = "owned";

// Instantiate Associations.Input
Relation input = new Relation();
input.AltName = "gets input from";
input.Description = "A custom relationship that describes that A gets input from some B.";
input.Cardinality = "1..1";
input.Role = "receiver";
input.InverseRole = "sender";

// Instantiate Associations.Contains
Relation contains = new Relation();
contains.AltName = "contains one or more";
contains.Description = "A association relation, describing that A has/contains instances of B, but is not composed of it.";
contains.Cardinality = "1..1";
contains.Role = "container";
contains.InverseRole = "contained";
*/

// FOR ValueTypes.json
public class ValueType {
    public string Type {get; set;}
    public string? Description {get; set;}
    public double? Min {get; set;}
    public double? Max {get; set;}
    public object? Example {get; set;}
    public List<string> AllowedValues {get; set;}

    public ValueType() {
        Type = string.Empty;
        Description = null;
        Min = null;
        Max = null;
        Example = null;
        AllowedValues = new List<string>();
    }
}

//EXAMPLE OF INSTIATING DIFFERENT OBJECTS FROM THIS CLASSES.JSON FILE:

/*
// Instantiate Weight_In_Grams
ValueType weightInGrams = new ValueType();
weightInGrams.Type = "number";
weightInGrams.Description = "The base unit for weight, representing the weight of the item in grams.";
weightInGrams.Min = 0;
weightInGrams.Max = null;
weightInGrams.Example = 1000;

// Instantiate Color_Code
ValueType colorCode = new ValueType();
colorCode.Type = "string";
colorCode.Description = "A string representing the color code of the item.";
colorCode.Min = 0;
colorCode.Max = null;
colorCode.Example = "#FFFFFF";

// Instantiate Useage_State
ValueType useageState = new ValueType();
useageState.Type = "enum";
useageState.Description = "A value representing the usage state of the item.";
useageState.Min = 0;
useageState.Max = null;
useageState.Example = "active";
useageState.AllowedValues.Add("on");
useageState.AllowedValues.Add("off");

// Instantiate Matter_State
ValueType matterState = new ValueType();
matterState.Type = "enum";
matterState.Description = "A value representing the state of matter of the item.";
matterState.Min = 0;
matterState.Max = null;
matterState.Example = "solid";
matterState.AllowedValues.Add("solid");
matterState.AllowedValues.Add("liquid");
matterState.AllowedValues.Add("gas");

// Instantiate Length_In_Meters
ValueType lengthInMeters = new ValueType();
lengthInMeters.Type = "number";
lengthInMeters.Description = "The base unit for length, representing the length of the item in meters.";
lengthInMeters.Min = 0;
lengthInMeters.Max = null;
lengthInMeters.Example = 1.5;

// Instantiate Volume_In_Liters
ValueType volumeInLiters = new ValueType();
volumeInLiters.Type = "number";
volumeInLiters.Description = "The base unit for volume, representing the volume of the item in liters.";
volumeInLiters.Min = 0;
volumeInLiters.Max = null;
volumeInLiters.Example = 2.5;

// Instantiate Temperature_In_Celsius
ValueType temperatureInCelsius = new ValueType();
temperatureInCelsius.Type = "number";
temperatureInCelsius.Description = "The base unit for temperature, representing the temperature of the item in degrees Celsius.";
temperatureInCelsius.Min = -273.15;
temperatureInCelsius.Max = null;
temperatureInCelsius.Example = 25.0;

// Instantiate Time_In_Seconds
ValueType timeInSeconds = new ValueType();
timeInSeconds.Type = "number";
timeInSeconds.Description = "The base unit for time, representing the time of the item in seconds.";
timeInSeconds.Min = 0;
timeInSeconds.Max = null;
timeInSeconds.Example = 3600;

// Instantiate Speed_In_Meters_Per_Second
ValueType speedInMetersPerSecond = new ValueType();
speedInMetersPerSecond.Type = "number";
speedInMetersPerSecond.Description = "The base unit for speed, representing the speed of the item in meters per second.";
speedInMetersPerSecond.Min = 0;
speedInMetersPerSecond.Max = null;
speedInMetersPerSecond.Example = 10.0;

// Instantiate Area_In_Square_Meters
ValueType areaInSquareMeters = new ValueType();
areaInSquareMeters.Type = "number";
areaInSquareMeters.Description = "The base unit for area, representing the area of the item in square meters.";
areaInSquareMeters.Min = 0;
areaInSquareMeters.Max = null;
areaInSquareMeters.Example = 50.0;

// Instantiate Pressure_In_Pascals
ValueType pressureInPascals = new ValueType();
pressureInPascals.Type = "number";
pressureInPascals.Description = "The base unit for pressure, representing the pressure of the item in pascals.";
pressureInPascals.Min = 0;
pressureInPascals.Max = null;
pressureInPascals.Example = 101325;

// Instantiate Energy_In_Joules
ValueType energyInJoules = new ValueType();
energyInJoules.Type = "number";
energyInJoules.Description = "The base unit for energy, representing the energy of the item in joules.";
energyInJoules.Min = 0;
energyInJoules.Max = null;
energyInJoules.Example = 1000;

// Instantiate Density_In_Grams_Per_Cubic_Centimeter
ValueType densityInGramsPerCubicCentimeter = new ValueType();
densityInGramsPerCubicCentimeter.Type = "number";
densityInGramsPerCubicCentimeter.Description = "The base unit for density, representing the density of the item in grams per cubic centimeter.";
densityInGramsPerCubicCentimeter.Min = 0;
densityInGramsPerCubicCentimeter.Max = null;
densityInGramsPerCubicCentimeter.Example = 1.0;

// Instantiate Volume_In_Cubic_Meters
ValueType volumeInCubicMeters = new ValueType();
volumeInCubicMeters.Type = "number";
volumeInCubicMeters.Description = "The base unit for volume, representing the volume of the item in cubic meters.";
volumeInCubicMeters.Min = 0;
volumeInCubicMeters.Max = null;
volumeInCubicMeters.Example = 0.001;

// Instantiate Heat_Capacity_In_Joules_Per_Kelvin
ValueType heatCapacityInJoulesPerKelvin = new ValueType();
heatCapacityInJoulesPerKelvin.Type = "number";
heatCapacityInJoulesPerKelvin.Description = "The base unit for heat capacity, representing the heat capacity of the item in joules per kelvin.";
heatCapacityInJoulesPerKelvin.Min = 0;
heatCapacityInJoulesPerKelvin.Max = null;
heatCapacityInJoulesPerKelvin.Example = 4184;
*/

  
public class Asset {
    public Entity AssetEntity {get; set;}
    public Relation AssetRelation {get; set;}
    public ValueType AssetValue {get; set;}

    public Asset(Entity assetEntity, Relation assetRelation, ValueType assetValue) {
        AssetEntity = assetEntity;
        AssetRelation = assetRelation;
        AssetValue = assetValue;
    }
}
