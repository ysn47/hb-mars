namespace MARS.Core.Abstract
{
    public interface IRover
    {
        void ApplyCommandBulk(string commands);
        void ApplyCommand(char command);
        string GetCurrentPositionAndDirection();
    }
}
