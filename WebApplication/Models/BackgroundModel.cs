using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackgroundLib;

namespace WebApplication.Models
{
    public class BackgroundModel
    {
        public ClassBackground ClassBackground = new ClassBackground();
        public Homeland Homeland = new Homeland();
        public Sibling Sibling = new Sibling();

        public List<AdoptedOutsideYourRace> AdoptedRaces = AdoptedOutsideYourRace.AdoptedRace();
        public List<CircumstanceOfBirth> CircumstancesOfBirth = CircumstanceOfBirth.CircumstancesOfBirth();
        public List<Conflict> Conflicts = Conflict.Conflicts();
        public List<ConflictSubject> ConflictSubjects = ConflictSubject.ConflictSubjects();
        public List<ConflictMotivation> ConflictMotivations = ConflictMotivation.ConflictMotivations();
        public List<ConflictResolution> ConflictResolutions = ConflictResolution.ConflictResolutions();
        public List<InfluentialAssociate> InfluentialAssociates = InfluentialAssociate.InfluentialAssociates();
        public List<MajorChildhoodEvent> MajorChildhoodEvents = MajorChildhoodEvent.MajorChildhoodEvents();
        public List<Nobility> Nobilities = Nobility.Nobilities();
        public List<Parent> Parents = Parent.GetParents();
        public List<ParentsProfession> ParentsProfessions = ParentsProfession.ParentsProfessions();
        public List<Relationship> RomanticRelationships = Relationship.RomanticRelationships();
        public List<Relationship> RelationshipsWithFellowAdventurers = Relationship.RelationshipsWithFellowAdventurers();
    }
}
