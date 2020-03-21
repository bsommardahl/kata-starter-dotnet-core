using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace Kata.Spec.CommandDispatch
{
    public class when_dispatching_a_command
    {
        static ICommandDispatcher _systemUnderTest;

        Establish context = () =>
            _systemUnderTest = new CommandDispatcher(new List<ICommandHandler>
            {
                _testCommandHandler
            }) as ICommandDispatcher;

        Because of = () =>
            _systemUnderTest.Dispatch(_testCommand);

        It should_execute_with_the_corresponding_handler = () =>
            _testCommandHandler.CommandExecuted.Should().Be(_testCommand);

        static TestCommandHandler _testCommandHandler = new TestCommandHandler();
        static ICommand _testCommand = new TestCommand() as ICommand;
    }

    public class when_matching_command_handler_based_on_can_handle
    {
        Establish _context = () =>
        {
            _commandHandler = Mock.Of<ICommandHandler>();
            _systemUnderTest = new CommandDispatcher(new List<ICommandHandler>
            {
                _commandHandler
            });

            _testCommand = new TestCommand();

            Mock.Get(_commandHandler).Setup(x => x.CanHandle(_testCommand)).Returns(true);
        };

        Because of = () => _systemUnderTest.Dispatch(_testCommand);

        It should_execute_using_the_correct_handler = () =>
        {
            Mock.Get(_commandHandler).Verify(x => x.Execute(_testCommand));
        };

        static CommandDispatcher _systemUnderTest;
        static ICommandHandler _commandHandler;
        static TestCommand _testCommand;
    }

    public class TestCommandHandler : ICommandHandler
    {
        public ICommand CommandExecuted { get; private set; }

        public void Execute(ICommand command)
        {
            CommandExecuted = command;
        }

        public bool CanHandle(ICommand command)
        {
            return GetType().Name.StartsWith(command.GetType().Name);
        }
    }

    public interface ICommandHandler
    {
        void Execute(ICommand command);
        bool CanHandle(ICommand command);
    }

    public class TestCommand : ICommand
    {
    }

    public interface ICommand
    {
    }

    public class CommandDispatcher : ICommandDispatcher
    {
        readonly IEnumerable<ICommandHandler> _commandHandlers;

        public CommandDispatcher(IEnumerable<ICommandHandler> commandHandlers)
        {
            _commandHandlers = commandHandlers;
        }

        public void Dispatch(ICommand command)
        {
            var matchingCommandHandler = _commandHandlers.First(x => x.CanHandle(command));
            matchingCommandHandler.Execute(command);
        }
    }

    public interface ICommandDispatcher
    {
        void Dispatch(ICommand command);
    }

    //
    //Create a dispatcher that can match commands with handlers and execute them.
    //
    // v1 - Name matching and hand-coded test object
    // v2 - CanHandle method and mocked handler
}