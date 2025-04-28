using System;

class Program {
    static void Main() {

        var mm = MetamodelLoader.LoadMetamodel();
        
        Console.WriteLine("=== CLASSES ===");
        foreach (var (name, cls) in mm.Classes) {
            Console.WriteLine($"\nClass: {name}");
            Console.WriteLine($"Description: {cls.Description}");
            Console.WriteLine($"SpecializationOf: {string.Join(", ", cls.SpecializationOf)}");
            Console.WriteLine($"CompositionOf   : {string.Join(", ", cls.CompositionOf)}");

            Console.WriteLine("Attributes:");
            if (cls.Attributes.Count > 0) {
                foreach (var (aname, attr) in cls.Attributes) {
                    Console.WriteLine($"    • {aname} ({attr.Type})");
                }
            }
            else {
                Console.WriteLine("    - none");
            }

            Console.WriteLine("Associations:");
            if (cls.Associations.Roles.Count > 0) {
                foreach (var (atype, roleMap) in cls.Associations.Roles) {
                    Console.WriteLine($"    - {atype}:");
                    foreach (var (rid, role) in roleMap) {
                        var maxStr = role.Max?.ToString() ?? "∞";
                        Console.WriteLine($"        {rid}. {role.Name} (min: {role.Min}, max: {maxStr})");
                    }
                }
            }
            else {
                Console.WriteLine("    - none");
            }
        }

        Console.WriteLine("\n=== RELATIONS ===");
        foreach (var (rname, rel) in mm.Relations) {
            Console.WriteLine($"\nRelation: {rname}");
            Console.WriteLine($"Alt Name     : {rel.AltName}");
            Console.WriteLine($"Description  : {rel.Description}");
            Console.WriteLine($"Cardinality  : {rel.Cardinality}");
            Console.WriteLine($"Role         : {rel.Role}");
            Console.WriteLine($"Inverse Role : {rel.InverseRole}");
        }

        Console.WriteLine("\n=== VALUE TYPES ===");
        foreach (var (vtname, vt) in mm.ValueTypes) {
            Console.WriteLine($"\nValueType: {vtname}");
            Console.WriteLine($"Type        : {vt.Type}");
            if (!string.IsNullOrEmpty(vt.Description))
                Console.WriteLine($"Description : {vt.Description}");
            if (vt.Min.HasValue || vt.Max.HasValue)
                Console.WriteLine($"Range       : {vt.Min} .. {vt.Max}");
            if (vt.AllowedValues != null && vt.AllowedValues.Count > 0)
                Console.WriteLine($"Allowed     : {string.Join(", ", vt.AllowedValues)}");
            if (vt.Example != null)
                Console.WriteLine($"Example     : {vt.Example}");
        }

        Console.WriteLine("\n=== REAL ESTATE CORE ===");
        foreach (var (concept, data) in mm.RealEstateCore) {
            Console.WriteLine($"\nConcept: {concept}");
            if (data.TryGetProperty("description", out var desc))
                Console.WriteLine($"Description: {desc.GetString()}");

            if (data.TryGetProperty("subConcepts", out var subs))
                Console.WriteLine($"SubConcepts: {string.Join(", ", subs.EnumerateObject().Select(x => x.Name))}");

            if (data.TryGetProperty("relationships", out var rels)) {
                Console.WriteLine("Relationships:");
                foreach (var r in rels.EnumerateObject()) {
                    Console.WriteLine($"    - {r.Name} → {r.Value.GetString()}");
                }
            }
        }

        Console.WriteLine("\nAll metamodel data loaded and printed successfully.");
    }
}