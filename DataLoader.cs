// GENERATED DATA LOADER METHODS FOR JSON INPUTS
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public static class DataLoader {

    // Classes.json
    public static Dictionary<string, Entity> LoadEntitiesFromClasses(string jsonPath) {
        var dict = new Dictionary<string, Entity>();
        string json = File.ReadAllText(jsonPath);
        using var doc = JsonDocument.Parse(json);
        foreach (var prop in doc.RootElement.EnumerateObject()) {
            var key = prop.Name;
            var entity = new Entity {
                Description = prop.Value.GetProperty("description").GetString(),
            };
            entity.Attributes.Name = key;

            if (prop.Value.TryGetProperty("specializationOf", out var specArr))
                foreach (var item in specArr.EnumerateArray())
                    entity.SpecializationOf.Add(item.GetString());
            if (prop.Value.TryGetProperty("compositionOf", out var compArr))
                foreach (var item in compArr.EnumerateArray())
                    entity.CompositionOf.Add(item.GetString());

            if (prop.Value.TryGetProperty("associations", out var assocObj)) {
                if (assocObj.TryGetProperty("has", out var hasObj)) PopulateAssociations(hasObj, entity.Associations.Has);
                if (assocObj.TryGetProperty("input", out var inputObj)) PopulateAssociations(inputObj, entity.Associations.Input);
                if (assocObj.TryGetProperty("contains", out var containsObj)) PopulateAssociations(containsObj, entity.Associations.Contains);
            }

            if (prop.Value.TryGetProperty("attributes", out var attrObj)) {
                if (attrObj.TryGetProperty("description", out var desc)) entity.Attributes.Description = desc.GetString();
                if (attrObj.TryGetProperty("valueType", out var vt)) entity.Attributes.ValueType = vt.GetString();
                if (attrObj.TryGetProperty("value", out var val)) entity.Attributes.Value = val.ValueKind == JsonValueKind.String ? val.GetString() : val.ToString();
            }

            dict[key] = entity;
        }
        return dict;
    }

    private static void PopulateAssociations(JsonElement assocElement, Dictionary<string, AssociationItem> dict) {
        foreach (var item in assocElement.EnumerateObject()) {
            var ai = new AssociationItem();
            var detail = item.Value;
            if (detail.TryGetProperty("name", out var n)) ai.Name = n.GetString();
            if (detail.TryGetProperty("min", out var mn)) ai.Min = mn.GetInt32();
            if (detail.TryGetProperty("max", out var mx) && mx.ValueKind != JsonValueKind.Null) ai.Max = mx.GetInt32();
            dict[item.Name] = ai;
        }
    }

    // Relations.json
    public static Dictionary<string, Relation> LoadRelations(string jsonPath) {
        var dict = new Dictionary<string, Relation>();
        string json = File.ReadAllText(jsonPath);
        using var doc = JsonDocument.Parse(json);
        foreach (var category in doc.RootElement.EnumerateObject()) {
            if (category.NameEquals("Associations")) {
                foreach (var assoc in category.Value.EnumerateObject()) {
                    var rel = ParseRelation(assoc.Value);
                    dict[assoc.Name] = rel;
                }
            }
            else {
                var rel = ParseRelation(category.Value);
                dict[category.Name] = rel;
            }
        }
        return dict;
    }

    private static Relation ParseRelation(JsonElement element) {
        var r = new Relation();
        if (element.TryGetProperty("alt_name", out var an)) r.AltName = an.GetString();
        if (element.TryGetProperty("description", out var d)) r.Description = d.GetString();
        if (element.TryGetProperty("cardinality", out var c)) r.Cardinality = c.GetString();
        if (element.TryGetProperty("role", out var role)) r.Role = role.GetString();
        if (element.TryGetProperty("inverse_role", out var ir)) r.InverseRole = ir.GetString();
        return r;
    }

    // ValueTypes.json
    public static Dictionary<string, ValueType> LoadValueTypes(string jsonPath) {
        var dict = new Dictionary<string, ValueType>();
        string json = File.ReadAllText(jsonPath);
        using var doc = JsonDocument.Parse(json);
        foreach (var prop in doc.RootElement.EnumerateObject()) {
            var key = prop.Name;
            var elem = prop.Value;
            var vt = new ValueType {
                Type = elem.GetProperty("type").GetString(),
                Description = elem.TryGetProperty("description", out var d) ? d.GetString() : null,
                Min = elem.TryGetProperty("min", out var mn) && mn.ValueKind != JsonValueKind.Null ? mn.GetDouble() : (double?)null,
                Max = elem.TryGetProperty("max", out var mx) && mx.ValueKind != JsonValueKind.Null ? mx.GetDouble() : (double?)null,
                Example = elem.TryGetProperty("example", out var ex) ? (ex.ValueKind == JsonValueKind.Number ? ex.GetDouble() : ex.GetString()) : null
            };
            if (elem.TryGetProperty("allowed_values", out var av))
                foreach (var v in av.EnumerateArray()) vt.AllowedValues.Add(v.GetString());

            dict[key] = vt;
        }
        return dict;
    }

    // RealEstateCore.json
    public static Dictionary<string, Concept> LoadRealEstateCore(string jsonPath) {
        var dict = new Dictionary<string, Concept>();
        string json = File.ReadAllText(jsonPath);
        using var doc = JsonDocument.Parse(json);
        foreach (var prop in doc.RootElement.EnumerateObject()) {
            var key = prop.Name;
            var elem = prop.Value;
            var concept = new Concept {
                Name = key,
                Description = elem.TryGetProperty("description", out var d) ? d.GetString() : null
            };
            if (elem.TryGetProperty("subConcepts", out var sc))
                foreach (var scProp in sc.EnumerateObject())
                    concept.SubConcepts[scProp.Name] = ParseSubConcept(scProp);
            if (elem.TryGetProperty("relationships", out var rels))
                foreach (var r in rels.EnumerateObject())
                    concept.Relationships[r.Name] = r.Value.GetString();

            dict[key] = concept;
        }
        return dict;
    }

    private static SubConcept ParseSubConcept(JsonProperty property) {
        var sub = new SubConcept { 
          Name = property.Name, Description = property.Value.TryGetProperty("description", out var d) ? d.GetString() : null 
        };
        if (property.Value.TryGetProperty("examples", out var ex))
            foreach (var ev in ex.EnumerateArray()) sub.Examples.Add(ev.GetString());
        if (property.Value.TryGetProperty("subConcepts", out var nested))
            foreach (var nsc in nested.EnumerateObject())
                sub.NestedSubConcepts[nsc.Name] = ParseSubConcept(nsc);
        return sub;
    }
}
