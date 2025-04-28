public class Entity {
    public string? Description { get; set; }
    public List<string> SpecializationOf { get; set; }
    public List<string> CompositionOf { get; set; }
    public EntityAssociations Associations { get; set; }
    public EntityAttributes Attributes { get; set; }

    public Entity() {
        Description = null;
        SpecializationOf = new List<string>();
        CompositionOf = new List<string>();
        Associations = new EntityAssociations();
        Attributes = new EntityAttributes();
    }
}

public class EntityAssociations {
    public Dictionary<string, AssociationItem> Has { get; set; }
    public Dictionary<string, AssociationItem> Input { get; set; }
    public Dictionary<string, AssociationItem> Contains { get; set; }

    public EntityAssociations() {
        Has = new Dictionary<string, AssociationItem>();
        Input = new Dictionary<string, AssociationItem>();
        Contains = new Dictionary<string, AssociationItem>();
    }
}

public class AssociationItem {
    public string? Name { get; set; }
    public int? Min { get; set; }
    public int? Max { get; set; }
}

public class EntityAttributes {
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ValueType { get; set; }
    public string? Value { get; set; }
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