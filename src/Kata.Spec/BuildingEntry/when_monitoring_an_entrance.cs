using Machine.Specifications;

namespace Kata.Spec.BuildingEntry
{
    // public class when_monitoring_an_entrance
    // {
    //     Establish _context = () =>
    //     {
    //         _systemUnderTest = new EntranceMonitor();
    //     };
    //
    //     Because of = () => { _result = _systemUnderTest.Entrance("123"); };
    //
    //     It should_log_the_entrance_to_the_db = () => { _result.Should().Be(something); };
    // }

    // Entrance Monitor Kata
    // Build a class that can receive info about a badge-in entrance event and react appropriately

    // 1. Log entrance into building to the db including badgeId and dateTime
    // 2. Solve "entrance" instantiation problem with Factory (refactor)
    // 3. Verify badge Id access based on badge type (implement strategy)
    // 4. Notify security on unauthorized access
}