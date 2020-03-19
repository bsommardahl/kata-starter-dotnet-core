using FluentAssertions;
using Machine.Specifications;

namespace Kata.Spec.CommandDispatch
{
    // public class when_dispatching_a_command
    // {
    //     static Monkey _systemUnderTest;
    //     
    //     Establish context = () => 
    //         _systemUnderTest = new CommandDispatcher() as ICommandDispatcher;
    //
    //     Because of = () => 
    //         _systemUnderTest.Dispatch(new TestCommand());
    //
    //     It should_execute_with_the_corresponding_handler = () =>
    //         _testCommandHandler.CommandExecuted.Should().Be(_testCommand);
    // }
    //
    //Create a dispatcher that can match commands with handlers and execute them.
    //
    // v1 - Name matching and hand-coded test object
    // v2 - CanHandle method and mocked handler
}