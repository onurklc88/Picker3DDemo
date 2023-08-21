
public interface ILevelFlow 
{
   
     GameStates.GamePhase CurrentGamePhase  { get; set; }
     void LevelOnPlay(GameStates.GamePhase gamePhase);

   
}
