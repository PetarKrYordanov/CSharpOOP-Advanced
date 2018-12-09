using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Commands
{
    public class RetireCommand : Command
    {

        [Inject]
        private IRepository repository;
        public RetireCommand(string[] data) : base(data)
        {
        }

        public override string Execute()
        {
            try
            {
            this.repository.RetireUnit(this.Data[1]);
                return $"{this.Data[1]} retired!";
            }
            catch (System.InvalidOperationException e)
            {
                return e.Message;
            }
        }
    }
}
