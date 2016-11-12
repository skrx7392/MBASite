using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBASite.ViewModels
{
    [Serializable]
    public class QuestionnaireAnswers
    {
        public QuestionnaireAnswers()
        {
            this.howDidYouBecomeAwareOfTheMbaProgramAtUcm.Add("Internet search");
            this.howDidYouBecomeAwareOfTheMbaProgramAtUcm.Add("Referral by a friend/co-worker");
            this.howDidYouBecomeAwareOfTheMbaProgramAtUcm.Add("Referral by a manager at work");
            this.howDidYouBecomeAwareOfTheMbaProgramAtUcm.Add("Attended UCM before");
            this.howDidYouBecomeAwareOfTheMbaProgramAtUcm.Add("Other");
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
        public int howManyClassesDoYouPlanToTakeEachFallSpringSemester { get; set; }
        public int howManyClassesToYouPlanToTakeInTheSummer { get; set; }
        public string doYouPlanToWorkWhilePursuingYourMba { get; set; }
        public int ifSoHowManyHoursAWeekDoYouPlanToWork { get; set; }
        public string ifCurrentlyEmployed { get; set; }
        public string forWhomDoYouWork { get; set; }
        public string whatIsYourPosition { get; set; }
        public int howFarIsYourResidenceFromUcmSWarrensburgCampus { get; set; }
        public int howFarIsYourWorkLocationFromUcmSWarresnburgCampus { get; set; }
        public string doYouHaveChildrenForWhomYouAreResponsible { get; set; }
        public string areYouASingleParent { get; set; }
        public string willYouHaveDifficultySchedulingMorningClasses { get; set; }
        public string willYouHaveDifficultySchedulingAfternoonClasses { get; set; }
        public string willYouHaveDifficultySchedulingNightClasses { get; set; }
        public string willYouHaveDifficultySchedulingWeekendClasses { get; set; }
        public string whatIsYourMotivationInPursingAnMba { get; set; }
        public string whatTypeOfPositionDoYouPlanToSeekAfterObtainingYourMba { get; set; }
        public List<string> howDidYouBecomeAwareOfTheMbaProgramAtUcm;
        public List<string> whatAttractedYouToTheMbaProgramAtUcm;
        public string awareOfTheProgram { get; set; }
        public string attractsToProgram { get; set; }
    }
}