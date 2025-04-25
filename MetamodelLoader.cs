using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

public class AttributeDef {
    public string Name { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public double? Min { get; set; }
    public double? Max { get; set; }
    public List<string> AllowedValues { get; set; }
    public object Example { get; set; }
}

public class AssociationRole {
    public string Name { get; set; }
    public int Min { get; set; }
    public int? Max { get; set; }
}

public class AssociationDef {
    public Dictionary<string, Dictionary<string, AssociationRole>> Roles { get; set; } = new();
}

public class ClassDef {
    public string Description { get; set; }
    public List<string> SpecializationOf { get; set; } = new();
    public List<string> CompositionOf { get; set; } = new();
    public AssociationDef Associations { get; set; } = new();
    public Dictionary<string, AttributeDef> Attributes { get; set; } = new();
}

public class RelationDef {
    [JsonPropertyName("alt_name")]
    public string AltName { get; set; } //nice
    public string Description { get; set; }
    public string Cardinality { get; set; }
    public string Role { get; set; }
    [JsonPropertyName("inverse_role")]
    public string InverseRole { get; set; }
}

public class Metamodel {
    public Dictionary<string, ClassDef> Classes { get; set; }
    public Dictionary<string, RelationDef> Relations { get; set; }
    public Dictionary<string, AttributeDef> ValueTypes { get; set; }
    public Dictionary<string, JsonElement> RealEstateCore { get; set; }
}

public static class MetamodelLoader {
    public static Metamodel LoadMetamodel() {
        string basePath = Path.Combine(Directory.GetCurrentDirectory(), "data");

        // Deserialize Classes (raw to handle attributes manually)
        var rawClasses = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
            File.ReadAllText(Path.Combine(basePath, "Classes.json")),
            new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

        // Deserialize Relations
        var rawRelations = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
            File.ReadAllText(Path.Combine(basePath, "Relations.json")));

        // Deserialize ValueTypes
        var rawValueTypes = JsonSerializer.Deserialize<Dictionary<string, AttributeDef>>(
            File.ReadAllText(Path.Combine(basePath, "ValueTypes.json")),
            new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

        // Deserialize RealEstateCore
        var rawREC = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
            File.ReadAllText(Path.Combine(basePath, "RealEstateCore.json")));

        // Process Classes
        var classes = new Dictionary<string, ClassDef>();
        foreach (var (cname, cinfo) in rawClasses) {
            var cls = new ClassDef {
                Description = cinfo.GetProperty("description").GetString(),
                SpecializationOf = JsonSerializer.Deserialize<List<string>>(cinfo.GetProperty("specializationOf").GetRawText()),
                CompositionOf = JsonSerializer.Deserialize<List<string>>(cinfo.GetProperty("compositionOf").GetRawText()),
                Associations = new AssociationDef(),
                Attributes = new Dictionary<string, AttributeDef>()
            };

            // Parse associations
            if (cinfo.TryGetProperty("associations", out var assocJson)) {
                foreach (var assocType in assocJson.EnumerateObject()) {
                    var roleMap = new Dictionary<string, AssociationRole>();
                    foreach (var role in assocType.Value.EnumerateObject()) {
                        var obj = role.Value;
                        roleMap[role.Name] = new AssociationRole {
                            Name = obj.GetProperty("name").GetString(),
                            Min = obj.GetProperty("min").GetInt32(),
                            Max = obj.TryGetProperty("max", out var maxVal) && maxVal.ValueKind != JsonValueKind.Null
                                ? maxVal.GetInt32()
                                : null
                        };
                    }
                    cls.Associations.Roles[assocType.Name] = roleMap;
                }
            }

            // Parse attributes
            if (cinfo.TryGetProperty("attributes", out var attrJson)) {
                foreach (var attr in attrJson.EnumerateObject()) {
                    cls.Attributes[attr.Name] = new AttributeDef {
                        Name = attr.Name,
                        Type = attr.Value.GetString() // Treat as string (e.g., "string", "./ValueTypes.json")
                    };
                }
            }

            classes[cname] = cls;
        }

        // Process Relations
        var relations = new Dictionary<string, RelationDef>();
        foreach (var (rname, rinfoElement) in rawRelations) {
            if (rname == "Associations") {
                var subRels = JsonSerializer.Deserialize<Dictionary<string, RelationDef>>(
                    rinfoElement.GetRawText(),
                    new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                foreach (var (subName, subRel) in subRels)
                {
                    relations[subName] = subRel;
                }
            }
            else {
                var rel = JsonSerializer.Deserialize<RelationDef>(
                    rinfoElement.GetRawText(),
                    new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                relations[rname] = rel;
            }
        }

        // Process ValueTypes
        var valueTypes = new Dictionary<string, AttributeDef>();
        foreach (var (vtname, vt) in rawValueTypes) {
            vt.Name = vtname;
            valueTypes[vtname] = vt;
        }

        return new Metamodel {
            Classes = classes,
            Relations = relations,
            ValueTypes = valueTypes,
            RealEstateCore = rawREC
        };
    }
}