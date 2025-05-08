
using System.ComponentModel.DataAnnotations;

public class BackendMain {

    /*
    Description: Method to add a new Concept (asset/object) to an existing Dictionary
    @input: String[] parameters (with the data), Dictionary<string, Concept>
    @output: Dictionary<string, Concept>
    */
    public static Dictionary<string, Concept> addConcept(Dictionary<string, Concept> dict, string concept_name, string[] parameters) {
        Concept newConcept = buildConcept(parameters);
        dict[concept_name] = newConcept;
        return dict;
    }

    /*
    Description: Method to build a Concept object from parameters
    @input: string[] parameters (with the data)
    @output: Concept
    */
    private static Concept buildConcept(string[] parameters) {
        Concept concept = new Concept();

        // BUILD THE CONCEPT BASED ON THE PARAMTERS INPUT, FOR NOW ASSUME IT WILL BE DONE LATER
        // BASED ON IMPLEMENTATION LATER ON

        return concept;
    }

    /*
    Description: Method to add a sub-concept to an already existing concept
    @input: Dictionary<string, Concept>, string concept_name, string subConcept
    @output: Dictionary<string, Concept>
    */
    public static Dictionary<string, Concept> addSubConcept(Dictionary<string, Concept> dict, string concept_name, string subConcept) {
        if (dict.ContainsKey(concept_name)) {
            Concept concept = dict[concept_name];
            if (!concept.SubConcepts.ContainsKey(subConcept)) {
                SubConcept newSubConcept = new SubConcept {
                    Name = subConcept
                };
                concept.SubConcepts[subConcept] = newSubConcept;
            }
        }
        return dict;
    }

    /*
    Description: Method to modify the ‘examples’ list in a defined subconcept in a concept
    @input: Dictionary<string, Concept>, string concept_name, string subConcept, List<String> examples
    @output: Dictionary<string, Concept>
    */
    public static Dictionary<string, Concept> modifyExamples(Dictionary<string, Concept> dict, string concept_name, string subConcept, List<string> examples) {
        if (dict.ContainsKey(concept_name)) {
            Concept concept = dict[concept_name];
            if (concept.SubConcepts.ContainsKey(subConcept)) {
                SubConcept targetSubConcept = concept.SubConcepts[subConcept];
                targetSubConcept.Examples = new List<string>(examples);
            }
        }
        return dict;
    }

    /*
    Description: Adds a nested subconcept to an existing subconcept in a concept.
    @input: Dictionary<string, Concept>, string concept_name, string parentSubConcept, string nestedSubConcept
    @output: Dictionary<string, Concept>
    */
    public static Dictionary<string, Concept> addNestedSubConcept(Dictionary<string, Concept> dict, string concept_name, string parentSubConcept, string nestedSubConcept) {
        if (dict.ContainsKey(concept_name)) {
            Concept concept = dict[concept_name];
            if (concept.SubConcepts.ContainsKey(parentSubConcept)) {
                SubConcept parent = concept.SubConcepts[parentSubConcept];
                if (!parent.NestedSubConcepts.ContainsKey(nestedSubConcept)) {
                    SubConcept nested = new SubConcept {
                        Name = nestedSubConcept
                    };
                    parent.NestedSubConcepts[nestedSubConcept] = nested;
                }
            }
        }
        return dict;
    }

    /*
    Description: Adds a relationship to a concept.
    @input: Dictionary<string, Concept>, string concept_name, string relationshipType, string relatedConcept
    @output: Dictionary<string, Concept>
    */
    public static Dictionary<string, Concept> addRelationship(Dictionary<string, Concept> dict, string concept_name, string relationshipType, string relatedConcept) {
        if (dict.ContainsKey(concept_name)) {
            Concept concept = dict[concept_name];
            concept.Relationships[relationshipType] = relatedConcept;
        }
        return dict;
    }


}


