namespace SakuraBlue.Entities.Agent
{
    public enum AIState
    {
       Dead,//dont do anything just allow for corpse looting 
       Sleeping,//dont do anything but may transition to being awake can safely be approached
       Normal, //Can become away or start hunting
       Aware, //Expanded Awareness range will be more willing to start hunting
       Hunting // will try to catch a target
    }
}