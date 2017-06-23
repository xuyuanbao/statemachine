//-------------------------------------------------------------------------------
// <copyright file="Reporting.cs" company="Appccelerate">
//   Copyright (c) 2008-2017 Appccelerate
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//-------------------------------------------------------------------------------

namespace Appccelerate.StateMachine.Async
{
    using System.Collections.Generic;
    using Appccelerate.StateMachine.AsyncMachine;
    using Appccelerate.StateMachine.Infrastructure;
    using FakeItEasy;
    using Xbehave;

    public class Reporting
    {
        [Scenario]
        public void Report(
            IAsyncStateMachine<string, int> machine,
            IStateMachineReport<string, int> report)
        {
            "establish a state machine"._(()
                => machine = new AsyncPassiveStateMachine<string, int>());

            "establish a state machine reporter"._(()
                => report = A.Fake<IStateMachineReport<string, int>>());

            "when creating a report"._(()
                => machine.Report(report));

            "it should call the passed reporter"._(()
                => A.CallTo(() => report.Report(A<string>._, A<IEnumerable<IState<string, int>>>._, A<Initializable<string>>._))
                    .MustHaveHappened());
        }
    }
}