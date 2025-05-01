
using System.ComponentModel.DataAnnotations;

public class BackendMain {

    /*
    Description: Method to instantiate an Concept
    @input: String[] parameters (with the data), List<Concept>
    @output: List<Concept>
    */
    public static List<Concept> addConcept(List<Concept> concepts, string[] parameters) {
        Concept newConcept = buildConcept(parameters);
        concepts.Add(newConcept);
        return concepts;
    }

    /*
    Description: Method to build an Concept object from parameters
    @input: string[] parameters (with the data)
    @output: Concept
    */
    private static Concept buildConcept(string[] parameters) {
        Concept concept = new Concept();

        // MODIFY IT BASED ON HOW THE PARAMTERS LOOKS BELOW IS JUST SOME AI GENERATED EXAMPLE
        
        // Assuming parameters array contains at least Name and Description
        //if (parameters.Length >= 2) {
            //concept.Name = parameters[0];
            //concept.Description = parameters[1];
        //}

        // Handle SubConcepts if provided in parameters (assuming format: name1,desc1,name2,desc2,...)
        //if (parameters.Length > 2) {
            //for (int i = 2; i < parameters.Length; i += 2) {
                //if (i + 1 < parameters.Length) {
                    //SubConcept subConcept = new SubConcept();
                    //subConcept.Name = parameters[i];
                    //subConcept.Description = parameters[i + 1];
                    //concept.SubConcepts.Add(subConcept.Name, subConcept);
                //}
            //}
        //}

        return concept;
    }

    /*
    Description: Method to add a sub-concept to an already existing concept
    @input: List<Concept>, string concept_name, string subConcept
    @output: List<Concept>
    */
    public static List<Concept> addSubConcept(List<Concept> concepts, string concept_name, string subConcept) {
        foreach (Concept concept in concepts) {
            if (concept.Name == concept_name) {
                SubConcept newSubConcept = new SubConcept();
                newSubConcept.Name = subConcept;
                concept.SubConcepts.Add(subConcept, newSubConcept);
                break;
            }
        }
        return concepts;
    }

    /*
    Description: Method to modify the ‘examples’ list in a defined subconcept in a concept
    @input: List<Concept>, string concept_name, string subConcept, List<String> examples
    @output: List<Concept>
    */
    public static List<Concept> modifyExamples(List<Concept> concepts, string concept_name, string subConcept, List<string> examples) {
        foreach (Concept concept in concepts) {
            if (concept.Name == concept_name) {
                if (concept.SubConcepts.ContainsKey(subConcept)) {
                    concept.SubConcepts[subConcept].Examples.Clear();
                    concept.SubConcepts[subConcept].Examples.AddRange(examples);
                    break;
                }
            }
        }
        return concepts;
    }

}


