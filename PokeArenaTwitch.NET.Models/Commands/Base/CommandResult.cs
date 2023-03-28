namespace PokeArenaTwitch.NET.Models.Commands.Base
{
    public class CommandResult
    {
        #region Fields



        #endregion

        #region Constructor

        public CommandResult(string result, CommandResultType resultType)
        {
            Result = result;
            ResultType = resultType;
        }

        #endregion

        #region Properties

        public string Result { get; }

        public CommandResultType ResultType { get; }

        #endregion

        #region Methods



        #endregion
    }
}