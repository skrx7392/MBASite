using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MBASite.ViewModels
{
    [Serializable]
    public class QuestionnaireAnswers
    {
        public QuestionnaireAnswers()
        {
            howDidYouBecomeAwareOfTheMbaProgramAtUcm = new List<string>();
            whatAttractedYouToTheMbaProgramAtUcm = new List<string>();
            howDidYouBecomeAwareOfTheMbaProgramAtUcm.Add("Internet search");
            howDidYouBecomeAwareOfTheMbaProgramAtUcm.Add("Referral by a friend/co-worker");
            howDidYouBecomeAwareOfTheMbaProgramAtUcm.Add("Referral by a manager at work");
            howDidYouBecomeAwareOfTheMbaProgramAtUcm.Add("Attended UCM before");
            howDidYouBecomeAwareOfTheMbaProgramAtUcm.Add("Other");
            whatAttractedYouToTheMbaProgramAtUcm.Add("Cost");
            whatAttractedYouToTheMbaProgramAtUcm.Add("Entrance Requirements");
            whatAttractedYouToTheMbaProgramAtUcm.Add("Reputation");
            whatAttractedYouToTheMbaProgramAtUcm.Add("Proximity to work");
            whatAttractedYouToTheMbaProgramAtUcm.Add("Proximity to home");
            whatAttractedYouToTheMbaProgramAtUcm.Add("Familiarity with UCM");
            whatAttractedYouToTheMbaProgramAtUcm.Add("Know other students");
            whatAttractedYouToTheMbaProgramAtUcm.Add("AACSB Accredition");
            whatAttractedYouToTheMbaProgramAtUcm.Add("Other");
        }

        [DisplayName("How many classes do you plan to take each fall / spring semester?")]
        public int howManyClassesDoYouPlanToTakeEachFallSpringSemester { get; set; }
        [DisplayName("How many classes to you plan to take in the summer?")]
        public int howManyClassesToYouPlanToTakeInTheSummer { get; set; }
        [DisplayName("Do you plan to work while pursuing your MBA?")]
        public bool doYouPlanToWorkWhilePursuingYourMba { get; set; }
        [DisplayName("If so, how many hours a week do you plan to work ?")]
        public int ifSoHowManyHoursAWeekDoYouPlanToWork { get; set; }
        [DisplayName("Are you currently employed?")]
        public bool ifCurrentlyEmployed { get; set; }
        [DisplayName("For whom do you work?")]
        public string forWhomDoYouWork { get; set; }
        [DisplayName("What is your position?")]
        public string whatIsYourPosition { get; set; }
        [DisplayName("How far is your residence from UCM’s Warrensburg campus?")]
        public int howFarIsYourResidenceFromUcmSWarrensburgCampus { get; set; }
        [DisplayName("How far is your work location from UCM’s Warresnburg campus?")]
        public int howFarIsYourWorkLocationFromUcmSWarresnburgCampus { get; set; }
        [DisplayName("Do you have children for whom you are responsible?")]
        public bool doYouHaveChildrenForWhomYouAreResponsible { get; set; }
        [DisplayName("Are you a single parent?")]
        public bool areYouASingleParent { get; set; }
        [DisplayName("Will you have difficulty scheduling morning classes?")]
        public bool willYouHaveDifficultySchedulingMorningClasses { get; set; }
        [DisplayName("Will you have difficulty scheduling afternoon classes?")]
        public bool willYouHaveDifficultySchedulingAfternoonClasses { get; set; }
        [DisplayName("Will you have difficulty scheduling night classes?")]
        public bool willYouHaveDifficultySchedulingNightClasses { get; set; }
        [DisplayName("Will you have difficulty scheduling weekend classes?")]
        public bool willYouHaveDifficultySchedulingWeekendClasses { get; set; }
        [DisplayName("What is your motivation in pursing an MBA?")]
        public string whatIsYourMotivationInPursingAnMba { get; set; }
        [DisplayName("What type of position do you plan to seek after obtaining your MBA?")]
        public string whatTypeOfPositionDoYouPlanToSeekAfterObtainingYourMba { get; set; }
        
        public List<string> howDidYouBecomeAwareOfTheMbaProgramAtUcm;

        public List<string> whatAttractedYouToTheMbaProgramAtUcm;
        [DisplayName("How did you become aware of the MBA program at UCM?")]
        public string awareOfTheProgram { get; set; }
        [DisplayName("What attracted you to the MBA program at UCM?")]
        public string attractsToProgram { get; set; }
    }
}